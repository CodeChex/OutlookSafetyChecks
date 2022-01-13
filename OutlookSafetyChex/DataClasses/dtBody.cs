using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using CheccoSafetyTools;
using DCSoft.RTF;
using System;
using System.Collections;
using System.Collections.Generic;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookSafetyChex
{
    public class dtBody: dtTemplate
    {
        static String logArea = Properties.Resources.Title_Body;
        public dtBody()
        {
            this.Columns.Add("Content-Type", Type.GetType("System.String"));
            this.Columns.Add("Content-Length", Type.GetType("System.String"));
            this.Columns.Add("Notes", Type.GetType("System.String"));
        }
        public override int buildData(dsMailItem parent, Outlook.MailItem myItem)
        {
            String tNotes = "[not checked]";
            String tReason = "";
            String[] rowData = null;
            // Text Checks
            {
                switch (myItem.BodyFormat)
                {
                    case Outlook.OlBodyFormat.olFormatHTML:
                        String tHtml = myItem.HTMLBody;
                        if (Properties.Settings.Default.test_Body)
                        {
                            cst_Log.logVerbose("Text Check", "HTML Parsing");
                            // Read links from DOM
                            IHtmlDocument doc = cst_Util.htmlParser.ParseDocument(tHtml);
                            List<IElement> tNodeList = traverseDOM(doc.Body.Children);
                            if (tNodeList != null)
                            {
                                foreach (IElement tNode in tNodeList)
                                {
                                    String tTag = tNode.NodeName;
                                    cst_Log.logVerbose(tTag, "HTML Parsing");
                                    tNotes = "";
                                    // check plaintext
                                    String tStr = tNode.TextContent;
                                    tNotes += Globals.AddInSafetyCheck.suspiciousText(tStr);
                                    // check HTML attributes for hiding/beaconing techniques
                                    String tLink = "";
                                    int uWD = -1;
                                    int uHT = -1;
                                    String tSIZE = "";
                                    switch (tTag)
                                    {
                                        case "img":
                                        case "div":
                                        case "iframe":
                                        case "embed":
                                        case "area":
                                            tLink = tNode.GetAttribute("src");
                                            tNotes += Globals.AddInSafetyCheck.suspiciousLink(tLink, tTag, false);
                                            uWD = int.Parse(tNode.GetAttribute("width"));
                                            uHT = int.Parse(tNode.GetAttribute("height"));
                                            if (uWD == 0 || uHT == 0)
                                            {
                                                tNotes += "[HIDDEN using ZERO-SIZE]: " + tTag + "\r\n";
                                            }
                                            break;
                                        case "a":
                                            tLink = tNode.GetAttribute("href");
                                            tNotes += Globals.AddInSafetyCheck.suspiciousLink(tLink, tTag, false);
                                            break;
                                        case "object":
                                        case "applet":
                                            tLink = tNode.GetAttribute("codebase");
                                            tNotes += Globals.AddInSafetyCheck.suspiciousLink(tLink, tTag);
                                            uWD = int.Parse(tNode.GetAttribute("width"));
                                            uHT = int.Parse(tNode.GetAttribute("height"));
                                            if (uWD == 0 || uHT == 0)
                                            {
                                                tNotes += "[HIDDEN using ZERO-SIZE]: " + tTag + "\r\n";
                                            }
                                            break;
                                        case "font":
                                            String szColor = tNode.GetAttribute("color");
                                            if (cst_Util.isValidString(szColor) &&
                                                (szColor.Equals("white", StringComparison.OrdinalIgnoreCase)
                                                || szColor.Equals("#FFFFFF", StringComparison.OrdinalIgnoreCase) ) )
                                            {
                                                tNotes += "[HIDDEN/WHITE]: " + tTag + "\r\n";
                                            }
                                            tSIZE = tNode.GetAttribute("size");
                                            if (tSIZE.StartsWith("0") )
                                            {
                                                tNotes += "[HIDDEN/ZERO-SIZE]: " + tTag + "\r\n";
                                            }
                                            break;
                                    }
                                    // check CSS for similar hiding/beaconing techniques
                                    try
                                    {
                                        String szStyle = tNode.GetAttribute("style");
                                        String[] arrStyles = szStyle.Split(';');
                                        foreach (String tAttr in arrStyles)
                                        {
                                            bool sneaky = false;
                                            String[] tStyle = tAttr.Split(':');
                                            if (tStyle.Length > 1)
                                            {
                                                String tName = tStyle[0];
                                                String tValue = tStyle[1];
                                                switch ( tName )
                                                {
                                                    case "display":
                                                        sneaky = tValue.Equals("none",StringComparison.OrdinalIgnoreCase);
                                                        break;
                                                    case "visible":
                                                        sneaky = tValue.Equals("false", StringComparison.OrdinalIgnoreCase);
                                                        break;
                                                    case "color":
                                                        sneaky = tValue.Equals("white", StringComparison.OrdinalIgnoreCase)
                                                            || tValue.Equals("#FFFFFF", StringComparison.OrdinalIgnoreCase);
                                                        break;
                                                    case "width":
                                                    case "height":
                                                        Int32 tV = cst_Util.isValidString(tValue) ? Int32.Parse(tValue) : -1;
                                                        sneaky = (tV == 0);
                                                        break;
                                                    case "font-size":
                                                        sneaky = tValue.StartsWith("0");
                                                        break;
                                                    case "background-image":
                                                    case "background-attachment":
                                                        tReason = Globals.AddInSafetyCheck.suspiciousLink(tValue, tName, false);
                                                        if (cst_Util.isValidString(tReason))
                                                        {
                                                            sneaky = true;
                                                            tNotes += tReason;
                                                        }
                                                        break;
                                                }
                                                if (sneaky)
                                                {
                                                    tNotes += "[HIDDEN using CSS]: " + tTag + " (" + tAttr + ")\r\n";
                                                }
                                            }
                                        }
                                    }
                                    catch { }
                                    // log results
                                    if ( cst_Util.isValidString(tNotes) )
                                    {
                                        rowData = new[] { "HTML <" + tTag + ">", "" + tNode.Text().Length + "", tNotes };
                                        this.Rows.Add(rowData);
                                        parent.log(logArea, "4", "SUSPICIOUS CONTENT", tNotes);
                                    }
                                }
                            }
                        }
                        break;
                    case Outlook.OlBodyFormat.olFormatRichText:
                        byte[] buffer = myItem.RTFBody;
                        if (Properties.Settings.Default.test_Body)
                        {
                            cst_Log.logVerbose("Text Check", "RTF Parsing");
                            string s = System.Text.Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                            tNotes += Globals.AddInSafetyCheck.suspiciousText(s);
                            RTFDomDocument rtfDoc = new RTFDomDocument();
                            rtfDoc.LoadRTFText(s);
                            List<DictionaryEntry> arrElements = traverseRTF(rtfDoc.Elements);
                            foreach (DictionaryEntry tNode in arrElements)
                            {
                                String tTag = tNode.Key as String;
                                String tStr = tNode.Value as String;
                                tNotes = "";
                                cst_Log.logVerbose(tTag, "RTF Parsing");
                                // check raw text
                                try
                                {
                                    tNotes += Globals.AddInSafetyCheck.suspiciousText(tStr);
                                }
                                catch { }
                                // TODO: check embedded items that have external sources
                                // log results
                                if (cst_Util.isValidString(tNotes))
                                {
                                    rowData = new[] { "RTF {" + tTag + "}", "" + tStr.Length + "", tNotes };
                                    this.Rows.Add(rowData);
                                    parent.log(logArea, "4", "SUSPICIOUS CONTENT", tNotes);
                                }
                            }
                        }
                        break;
                    case Outlook.OlBodyFormat.olFormatPlain:
                        tNotes = "";
                        String tText = myItem.Body;
                        cst_Log.logVerbose("Plain Text", "Parsing");
                        if (Properties.Settings.Default.test_Body)
                        {
                             tNotes += Globals.AddInSafetyCheck.suspiciousText(tText);
                        }
                        // log results
                        if (cst_Util.isValidString(tNotes))
                        {
                            rowData = new[] { "Plain Text", "" + tText.Length + "", tNotes };
                            this.Rows.Add(rowData);
                            parent.log(logArea, "4", "SUSPICIOUS CONTENT", tNotes);
                        }
                        break;
                    default:
                        tNotes = "";
                        String tData = myItem.Body;
                        cst_Log.logVerbose("Raw Data", "Parsing");
                        if (Properties.Settings.Default.test_Body)
                        {
                            tNotes += "Cannot Parse Contents\r\n";
                        }
                        // log results
                        if (cst_Util.isValidString(tNotes))
                        {
                            rowData = new[] { "Raw Data", "" + tData.Length + "", tNotes };
                            this.Rows.Add(rowData);
                            parent.log(logArea, "4", "SUSPICIOUS CONTENT", tNotes);
                        }
                        break;
                }
            }
            return this.Rows.Count;
        }

        private List<IElement> traverseDOM(IHtmlCollection<IElement> tList)
        {
            List<IElement> rc = new List<IElement>();
            foreach (IElement rEL in tList)
            {
                rc.Add(rEL);
                rc.AddRange(traverseDOM(rEL.Children));
            }
            return rc;
        }

        private List<DictionaryEntry> traverseRTF(RTFDomElementList tList)
        {
            List<DictionaryEntry> rc = new List<DictionaryEntry>();
            foreach (RTFDomElement rEL in tList)
            {
                rc.Add(new DictionaryEntry(rEL.GetType().Name, rEL.InnerText));
                rc.AddRange(traverseRTF(rEL.Elements));
            }
            return rc;
        }
    } // class
} // namespace
