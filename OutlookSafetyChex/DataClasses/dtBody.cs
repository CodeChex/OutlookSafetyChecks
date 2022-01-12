using CheccoSafetyTools;
using DCSoft.RTF;
using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookSafetyChex
{
    public class dtBody: dtTemplate
    {
        public dtBody()
        {
            this.Columns.Add("Content-Type", Type.GetType("System.String"));
            this.Columns.Add("Content-Length", Type.GetType("System.String"));
            this.Columns.Add("Notes", Type.GetType("System.String"));
        }
        public override int buildData(dsMailItem parent, Outlook.MailItem myItem)
        {
            String logArea = Properties.Resources.Title_Body;
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
                            HtmlDocument doc = new HtmlDocument();
                            doc.LoadHtml(tHtml);
                            HtmlNodeCollection tNodeList = doc.DocumentNode.SelectNodes(".//*");
                            if (tNodeList != null)
                            {
                                foreach (HtmlNode tNode in tNodeList)
                                {
                                    String tTag = tNode.Name.ToLower();
                                    cst_Log.logVerbose(tTag, "HTML Parsing");
                                    tNotes = "";
                                    // check plaintext
                                    try
                                    {
                                        String tStr = tNode.GetDirectInnerText();
                                        tNotes += Globals.AddInSafetyCheck.suspiciousText(tStr);
                                    }
                                    catch { }
                                    // check HTML attributes for hiding/beaconing techniques
                                    switch (tTag)
                                    {
                                        case "img":
                                            try
                                            {
                                                String tLink = tNode.Attributes["src"].Value;
                                                tNotes += Globals.AddInSafetyCheck.suspiciousLink(tLink, tTag, false);
                                            }
                                            catch { }
                                            try
                                            {
                                                String szWD = tNode.Attributes["width"].Value;
                                                Int32 tWD = cst_Util.isValidString(szWD) ? Int32.Parse(szWD) : -1;
                                                String szHT = tNode.Attributes["height"].Value;
                                                Int32 tHT = cst_Util.isValidString(szHT) ? Int32.Parse(szHT) : -1;
                                                if (tWD == 0 || tHT == 0)
                                                {
                                                    tNotes += "[HIDDEN using ZERO-SIZE]: " + tTag + "\r\n";
                                                }
                                            }
                                            catch { }
                                            break;
                                        case "object":
                                        case "applet":
                                            try
                                            {
                                                String tLink = tNode.Attributes["codebase"].Value;
                                                tNotes += Globals.AddInSafetyCheck.suspiciousLink(tLink, tTag);
                                            }
                                            catch { }
                                            try
                                            {
                                                String szWD = tNode.Attributes["width"].Value;
                                                Int32 tWD = cst_Util.isValidString(szWD) ? Int32.Parse(szWD) : -1;
                                                String szHT = tNode.Attributes["height"].Value;
                                                Int32 tHT = cst_Util.isValidString(szHT) ? Int32.Parse(szHT) : -1;
                                                if (tWD == 0 || tHT == 0)
                                                {
                                                    tNotes += "[HIDDEN using ZERO-SIZE]: " + tTag + "\r\n";
                                                }
                                            }
                                            catch { }
                                            break;
                                        case "embed":
                                        case "area":
                                            try
                                            {
                                                String tLink = tNode.Attributes["src"].Value;
                                                tNotes += Globals.AddInSafetyCheck.suspiciousLink(tLink, tTag);
                                            }
                                            catch { }
                                            try
                                            {
                                                String szWD = tNode.Attributes["width"].Value;
                                                Int32 tWD = cst_Util.isValidString(szWD) ? Int32.Parse(szWD) : -1;
                                                String szHT = tNode.Attributes["height"].Value;
                                                Int32 tHT = cst_Util.isValidString(szHT) ? Int32.Parse(szHT) : -1;
                                                if (tWD == 0 || tHT == 0)
                                                {
                                                    tNotes += "[HIDDEN using ZERO-SIZE]: " + tTag + "\r\n";
                                                }
                                            }
                                            catch { }
                                            break;
                                        case "iframe":
                                            try
                                            {
                                                String tLink = tNode.Attributes["src"].Value;
                                                tNotes += Globals.AddInSafetyCheck.suspiciousLink(tLink, tTag);
                                            }
                                            catch { }
                                            try
                                            {
                                                String szWD = tNode.Attributes["width"].Value;
                                                Int32 tWD = cst_Util.isValidString(szWD) ? Int32.Parse(szWD) : -1;
                                                String szHT = tNode.Attributes["height"].Value;
                                                Int32 tHT = cst_Util.isValidString(szHT) ? Int32.Parse(szHT) : -1;
                                                if (tWD == 0 || tHT == 0)
                                                {
                                                    tNotes += "[HIDDEN using ZERO-SIZE]: " + tTag + "\r\n";
                                                }
                                            }
                                            catch { }
                                            break;
                                        case "font":
                                            try
                                            {
                                                String szColor = tNode.Attributes["color"].Value;
                                                if (cst_Util.isValidString(szColor) &&
                                                    (szColor.Equals("white", StringComparison.OrdinalIgnoreCase)
                                                    || szColor.Equals("#FFFFFF", StringComparison.OrdinalIgnoreCase) ) )
                                                {
                                                    tNotes += "[HIDDEN/WHITE]: " + tTag + "\r\n";
                                                }
                                            }
                                            catch { }
                                            try
                                            {
                                                String szPT = tNode.Attributes["size"].Value;
                                                Int32 tPT = cst_Util.isValidString(szPT) ? Int32.Parse(szPT) : -1;
                                                if (tPT == 0)
                                                {
                                                    tNotes += "[HIDDEN/ZERO-SIZE]: " + tTag + "\r\n";
                                                }
                                            }
                                            catch { }
                                            break;
                                        case "div":
                                            try
                                            {
                                                String szWD = tNode.Attributes["width"].Value;
                                                Int32 tWD = cst_Util.isValidString(szWD) ? Int32.Parse(szWD) : -1;
                                                String szHT = tNode.Attributes["height"].Value;
                                                Int32 tHT = cst_Util.isValidString(szHT) ? Int32.Parse(szHT) : -1;
                                                if (tWD == 0 || tHT == 0)
                                                {
                                                    tNotes += "[HIDDEN using ZERO-SIZE]: " + tTag + "\r\n";
                                                }
                                            }
                                            catch { }
                                            break;
                                    }
                                    // check CSS for similar hiding/beaconing techniques
                                    try
                                    {
                                        String szStyle = tNode.Attributes["style"].Value;
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
                                                    case "font-size":
                                                        Int32 tV = cst_Util.isValidString(tValue) ? Int32.Parse(tValue) : -1;
                                                        sneaky = (tV == 0);
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
                                        rowData = new[] { "HTML <" + tTag + ">", "" + tNode.InnerLength + "", tNotes };
                                        this.Rows.Add(rowData);
                                        parent.log("HTML <" + tTag + ">: " + logArea, "4", "SUSPICIOUS CONTENT", tNotes);
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
                                    parent.log("RTF {" + tTag + "}: " + logArea, "4", "SUSPICIOUS CONTENT", tNotes);
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
                            parent.log("Plain Text: " + logArea, "4", "SUSPICIOUS CONTENT", tNotes);
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
                            parent.log("Raw Data: " + logArea, "4", "SUSPICIOUS CONTENT", tNotes);
                        }
                        break;
                }
            }
            return this.Rows.Count;
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
