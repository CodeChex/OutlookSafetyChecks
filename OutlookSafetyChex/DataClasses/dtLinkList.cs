using CheccoSafetyTools;
using DCSoft.RTF;
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
                    IHtmlCollection<IElement> tNodeList = doc.Body.QuerySelectorAll("a[href]");
                    if (mLogger != null)
                        mLogger.logInfo("Inspecting [" + tNodeList.Length + "] HREF Elements", logArea);
                    foreach (IElement tNode in tNodeList)
                    {
                        tNotes = verifyHREF(parent, tNode, "href");
                    }
                    // HTML node types that have <zzz SRC="...">
                    // { "img","div","iframe","embed",... };
                    tNodeList = doc.Body.QuerySelectorAll("[src]");
                    if (mLogger != null)
                        mLogger.logInfo("Inspecting [" + tNodeList.Length + "] SRC Elements", logArea);
                    foreach (IElement tNode in tNodeList)
                    {
                        tNotes = verifySRC(parent, tNode, "src");
                    }
                    // HTML node types that have <zzz CODEBASE="...">
                    // { "embed", "object", "applet", ... };
                    tNodeList = doc.Body.QuerySelectorAll("[codebase]");
                    if (mLogger != null)
                        mLogger.logInfo("Inspecting [" + tNodeList.Length + "] CODEBASE Elements", logArea);
                    foreach (IElement tNode in tNodeList)
                    {
                        tNotes = verifyCODEBASE(parent, tNode, "codebase");
                    }
                    break;
                case Outlook.OlBodyFormat.olFormatRichText:
                    if (mLogger != null) mLogger.logMessage("Format = RTF", logArea);
                    // EXAMPLE: {\\field {\\*\\fldinst {HYPERLINK \"URL\"} {\\fldrslt {Link Description}}}
                    byte[] buffer = myItem.RTFBody;
                    string s = System.Text.Encoding.UTF8.GetString(buffer, 0, buffer.Length);
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
                        // log it
                        if (cst_Util.isValidString(tNotes))
                        {
                            String[] rowData = new[] { tLabel, tDisplay, tLink, tNotes };
                            this.addDataRow(rowData);
                            parent.logFinding(logArea, "4", "SUSPICIOUS LINK", tNotes);
                        }
                    }
                    break;
                default:
                    if (mLogger != null) mLogger.logMessage("Format = [unspecified]", logArea);
                    break;
            }
            return this.Rows.Count;
        }

        private String verifyHREF(dsMailItem parent, IElement tNode, String tTag="href")
        {
            String tNotes = "";
            bool dump = false;
            try
            {
                String tDisplay = tNode.TextContent;
                String tLink = tNode.GetAttribute(tTag);
                String tLabel = "<" + tNode.NodeName + " " + tTag + "=...>";
                if (mLogger != null) mLogger.logVerbose(tLabel, "Link");
                // needs to have some visible 
                if (!cst_Util.isValidString(tDisplay) && !tNode.HasChildNodes)
                {
                    tDisplay = "[empty]";
                    tNotes += "NO VISIBLE Text\r\n";
                    dump = true;
                }
                if (!cst_Util.isValidString(tLink))
                {
                    tLink = "[empty]";
                    tNotes += "NO Location Specified\r\n";
                    dump = true;
                }
                else
                {
                    tNotes += verifyLink(tLink, tDisplay, true);
                }
                // update List of Links
                String[] rowData = new[] { tLabel, tDisplay, tLink, tNotes };
                this.addDataRow(rowData);
                // log now if necessary and possible
                if (cst_Util.isValidString(tNotes) && parent!=null)
                {
                    parent.logFinding(logArea, "4", "SUSPICIOUS " + tLabel, tNotes);
                    if (dump) if (mLogger != null) mLogger.logMessage(tNode.OuterHtml, tNotes);
                }
            }
            catch (Exception ex)
            {
                if (mLogger != null) mLogger.logException(ex, "dtLinkList::verifyHREF\r\n\t" + tNode.OuterHtml + "\r\n");
            }
            return tNotes;
        }
        private String verifySRC(dsMailItem parent, IElement tNode, String tTag="src")
        {
            String tNotes = "";
            bool dump = false;
            try
            {
                String tDisplay = tNode.TextContent;
                String tLink = tNode.GetAttribute(tTag);
                String tLabel = "<" + tNode.NodeName + " " + tTag + "=...>";
                if (mLogger != null) mLogger.logVerbose(tLabel, "Link");
                if (!cst_Util.isValidString(tLink))
                {
                    tLink = "[empty]";
                    tNotes += "NO Location Specified\r\n";
                    dump = true;
                }
                else
                {
                    tNotes += verifyLink(tLink, tDisplay, false);
                }
                // update List of Links
                String[] rowData = new[] { tLabel, tDisplay, tLink, tNotes };
                this.addDataRow(rowData);
                // log now if necessary and possible
                if (cst_Util.isValidString(tNotes) && parent != null)
                {
                    parent.logFinding(logArea, "4", "SUSPICIOUS " + tLabel, tNotes);
                    if (dump) if (mLogger != null) mLogger.logMessage(tNode.OuterHtml,tNotes);
                }
            }
            catch (Exception ex)
            {
                if (mLogger != null) mLogger.logException(ex, "dtLinkList::verifySRC\r\n\t" + tNode.OuterHtml + "\r\n");
            }
            return tNotes;
        }
        private String verifyCODEBASE(dsMailItem parent, IElement tNode, String tTag="codebase")
        {
            String tNotes = "";
            try
            {
                String tDisplay = tNode.TextContent;
                String tLink = tNode.GetAttribute(tTag);
                String tLabel = "<" + tNode.NodeName + " " + tTag + "=...>";
                // additional warning
                tNotes += "Potential Executable Object\r\n";
                // check codebase URL
                tNotes += verifySRC(parent, tNode, tTag);
            }
            catch (Exception ex)
            {
                if (mLogger != null) mLogger.logException(ex, "dtLinkList::verifySRC\r\n\t" + tNode.OuterHtml + "\r\n");
            }
            return tNotes;
        }

        private String verifyLink(String tLink, String tText, bool allowParam )
        {
            String tNotes = "";
            // check each link
            String tProtocol = "[unknown]";
            String tMimeType = "[not checked]";
            tNotes += instance.suspiciousLink(tLink, tText);
            try
            {
                cst_URL tURL = cst_URL.parseURL(tLink);
                tProtocol = tURL.mUri.Scheme;
                if (tProtocol == Uri.UriSchemeMailto)
                {
                    tMimeType = "[Email-Address]";
                }
                else if (Properties.Settings.Default.opt_DeepInspect_LINKS)
                {
                    tMimeType = instance.mWebUtil.wgetContentType(tLink);
                }
            }
            catch (Exception ex)
            {
                if (mLogger != null) mLogger.logException(ex, "dtLinkList::verifyLink(" + tLink + ")");
            }
            return tNotes;
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
