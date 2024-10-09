using CheccoSafetyTools;
using RtfDomParser;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using AngleSharp.Html.Parser;
using AngleSharp.Html.Dom;
using AngleSharp.Dom;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookSafetyChex
{
    public class dtLinkList : dtTemplate
    {
        private static readonly String logArea = Properties.Resources.Title_Links + " (List)";

        public dtLinkList()
        {
            this.Columns.Add("Content-Type", Type.GetType("System.String"));
            this.Columns.Add("Display Name", Type.GetType("System.String"));
            this.Columns.Add("HyperLink", Type.GetType("System.String"));
            this.Columns.Add("Notes", Type.GetType("System.String"));
        }

        public override int buildData(dsMailItem parent, Outlook.MailItem myItem)
        {
            String tLink = "";
            String tDisplay = "";
            String tLabel = "";
            String tTag = "";
            String tNotes = "";
            // Check Body for Links
            switch (myItem.BodyFormat)
            {
                case Outlook.OlBodyFormat.olFormatHTML:
                    if (mLogger != null) mLogger.logMessage("Format = HTML", logArea);
                    // EXAMPLE: <a href="URL">Link Description</a>
                    String tHtml = myItem.HTMLBody;
                    // Read links from DOM
                    IHtmlDocument doc = instance.mWebUtil.htmlParser.ParseDocument(tHtml);
                    // HTML node types that have <A HREF="...">
                    tTag = "href";
                    IHtmlCollection<IElement> tNodeList = doc.Body.QuerySelectorAll("a["+tTag+"]");
                    if (mLogger != null)
                        mLogger.logInfo("Inspecting [" + tNodeList.Length + "] " + tTag.ToUpper() + " Elements", logArea);
                    foreach (IElement tNode in tNodeList)
                    {
                        tDisplay = tNode.TextContent;
                        tLink = tNode.GetAttribute(tTag);
                        tLabel = "<" + tNode.NodeName + " " + tTag + "=...>";
                        tNotes = verifyHREF(tNode, tTag);
                        // update List of Links
                        String[] rowData = new[] { tLabel, tDisplay, tLink, tNotes };
                        this.addDataRow(rowData);
                        // log it
                        if (cst_Util.isValidString(tNotes))
                        {
                            parent.logFinding(logArea, "4", "SUSPICIOUS " + tLabel, tNotes);
                            if (mLogger != null) mLogger.logMessage(tNode.OuterHtml, tNotes);
                        }
                    }
                    // HTML node types that have <zzz SRC="...">
                    // { "img","div","iframe","embed",... };
                    tTag = "src";
                    tNodeList = doc.Body.QuerySelectorAll("[" + tTag + "]");
                    if (mLogger != null)
                        mLogger.logInfo("Inspecting [" + tNodeList.Length + "] " + tTag.ToUpper() + " Elements", logArea);
                    foreach (IElement tNode in tNodeList)
                    {
                        tDisplay = tNode.TextContent;
                        tLink = tNode.GetAttribute(tTag);
                        tLabel = "<" + tNode.NodeName + " " + tTag + "=...>";
                        tNotes = verifySRC(tNode, tTag);
                        // update List of Links
                        String[] rowData = new[] { tLabel, tDisplay, tLink, tNotes };
                        this.addDataRow(rowData);
                        // log it
                        if (cst_Util.isValidString(tNotes))
                        {
                            parent.logFinding(logArea, "4", "SUSPICIOUS " + tLabel, tNotes);
                            if (mLogger != null) mLogger.logMessage(tNode.OuterHtml, tNotes);
                        }
                    }
                    // HTML node types that have <zzz CODEBASE="...">
                    // { "embed", "object", "applet", ... };
                    tTag = "codebase";
                    tNodeList = doc.Body.QuerySelectorAll("[" + tTag + "]");
                    if (mLogger != null)
                        mLogger.logInfo("Inspecting [" + tNodeList.Length + "] " + tTag.ToUpper() + " Elements", logArea);
                    foreach (IElement tNode in tNodeList)
                    {
                        tNotes = verifyCODEBASE(tNode, tTag);
                        // update List of Links
                        String[] rowData = new[] { tLabel, tDisplay, tLink, tNotes };
                        this.addDataRow(rowData);
                        // log it
                        if (cst_Util.isValidString(tNotes))
                        {
                            parent.logFinding(logArea, "4", "SUSPICIOUS " + tLabel, tNotes);
                            if (mLogger != null) mLogger.logMessage(tNode.OuterHtml, tNotes);
                        }
                    }
                    break;
                case Outlook.OlBodyFormat.olFormatRichText:
                    if (mLogger != null) mLogger.logMessage("Format = RTF", logArea);
                    // EXAMPLE: {\\field {\\*\\fldinst {HYPERLINK \"URL\"} {\\fldrslt {Link Description}}}
                    string s = myItem.RTFBody.ToString(); // System.Text.Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                    RTFDomDocument rtfDoc = new RTFDomDocument();
                    rtfDoc.LoadRTFText(s);
                    if (mLogger != null)
                        mLogger.logInfo("Inspecting [" + rtfDoc.Elements.Count + "] RTF Elements", logArea);
                    traverseRTF(parent, rtfDoc.Elements);
                    break;
                case Outlook.OlBodyFormat.olFormatPlain:
                    if (mLogger != null) mLogger.logMessage("Format = PlainText", logArea);
                    String tText = myItem.Body;
                    List<cst_URL> arrFound = cst_URL.parseTextForURLs(tText);
                    if (mLogger != null)
                        mLogger.logInfo("Inspecting [" + arrFound.Count + "] Plaintext URLs", logArea);
                    foreach (cst_URL t in arrFound)
                    {
                        tLink = t.mURL;
                        tDisplay = t.mURL;
                        tNotes = verifyLink(tLink, tDisplay, true);
                        // update list
                        String[] rowData = new[] { tLabel, tDisplay, tLink, tNotes };
                        this.addDataRow(rowData);
                        // log it
                        if (cst_Util.isValidString(tNotes))
                        {
                            parent.logFinding(logArea, "4", "SUSPICIOUS LINK", tNotes);
                            if (mLogger != null) mLogger.logMessage(t.mURL, tNotes);
                        }
                    }
                    break;
                default:
                    if (mLogger != null) mLogger.logMessage("Format = [unspecified]", logArea);
                    break;
            }
            return this.Rows.Count;
        }

        private int traverseRTF(dsMailItem parent, RTFDomElementList tList)
        {
            int count = 0;
            foreach (RTFDomElement rEL in tList)
            {
                if (rEL is RTFDomField)
                {
                    RTFDomField rFLD = rEL as RTFDomField;
                    String s = rFLD.Instructions;
                    Regex rgx = new Regex("HYPERLINK\\s+\"(.*?)\"");
                    foreach (Match m in rgx.Matches(s))
                    {
                        count++;
                        String tDisplay = rFLD.ResultString;
                        String tLink = m.Groups[1].Value;
                        String tNotes = verifyLink(tLink, tDisplay, true);
                        // add it to the list
                        String[] rowData = new[] { "{HYPERLINK}", tDisplay, tLink, tNotes };
                        this.addDataRow(rowData);
                        // log it
                        if (cst_Util.isValidString(tNotes))
                        {
                            parent.logFinding(logArea, "4", "SUSPICIOUS {HYPERLINK}", tNotes);
                            if (mLogger != null) mLogger.logMessage(s, tNotes);
                        }
                    }
                }
                count += traverseRTF(parent, rEL.Elements);
            }
            return count;
        }
    } // class
} // namespace
