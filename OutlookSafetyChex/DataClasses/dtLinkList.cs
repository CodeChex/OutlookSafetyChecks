using CheccoSafetyTools;
using DCSoft.RTF;
using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookSafetyChex
{
    public class dtLinkList : dtTemplate
    {
        public dtLinkList()
        {
            this.Columns.Add("Display Name", Type.GetType("System.String"));
            this.Columns.Add("HyperLink", Type.GetType("System.String"));
            this.Columns.Add("Content-Type", Type.GetType("System.String"));
            this.Columns.Add("Notes", Type.GetType("System.String"));
        }

        public override int buildData(dsMailItem parent, Outlook.MailItem myItem)
        {
            String logArea = Properties.Resources.Title_Links + " / List";
            String format = "";
            List<DictionaryEntry> arrLinks = new List<DictionaryEntry>();
            // Check Body for Links
            switch (myItem.BodyFormat)
            {
                case Outlook.OlBodyFormat.olFormatHTML:
                    format = "HTML";
                    // EXAMPLE: <a href="URL">Link Description</a>
                    String tHtml = myItem.HTMLBody;
                    // Read links from DOM
                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(tHtml);
                    HtmlNodeCollection tNodeList = doc.DocumentNode.SelectNodes(".//a");
                    if (tNodeList != null)
                    {
                        foreach (HtmlNode tNode in tNodeList)
                        {
                            String tDisplay = tNode.InnerText;
                            if (!cst_Util.isValidString(tDisplay))
                            {
                                tDisplay = tNode.InnerHtml;
                            }
                            String tLink = "";
                            try
                            {
                                tLink = tNode.Attributes["href"].Value;
                                arrLinks.Add(new DictionaryEntry(tLink, tDisplay));
                            }
                            catch 
                            { 
                                // ignore this error
                            }
                        }
                    }
                    break;
                case Outlook.OlBodyFormat.olFormatRichText:
                    format = "RTF";
                    // EXAMPLE: {\\field {\\*\\fldinst {HYPERLINK \"URL\"} {\\fldrslt {Link Description}}}
                    byte[] buffer = myItem.RTFBody;
                    string s = System.Text.Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                    RTFDomDocument rtfDoc = new RTFDomDocument();
                    rtfDoc.LoadRTFText(s);
                    arrLinks.AddRange(traverseRTF(rtfDoc.Elements));
                    break;
                case Outlook.OlBodyFormat.olFormatPlain:
                    format = "Text";
                    String tText = myItem.Body;
                    Regex urlRx = new Regex(@"(?<url>(http(s?):[/][/]|mailto:|(s?)ftp(s?):|scp:|www.)([a-z]|[A-Z]|[0-9]|[\\-]|[/.]|[~])*)", RegexOptions.IgnoreCase);
                    MatchCollection matches = urlRx.Matches(tText);         
                    foreach (Match match in matches)
                    {
                         String tLink = "";
                        try
                        {
                            tLink = match.Groups["url"].Value;
                            arrLinks.Add(new DictionaryEntry(tLink, tLink));
                        }
                        catch
                        {
                            // ignore this error
                        }
                    }
                    break;
                default:
                    format = "[unknown]";
                    break;
            }
            // check each link
            foreach (DictionaryEntry tEntry in arrLinks)
            {
                String tLink = tEntry.Key as String;
                String tDisplay = tEntry.Value as String;
                String tProtocol = "[unknown]";
                String tMimeType = "[not checked]";
                cst_Util.logVerbose(tDisplay, "Link");
                String tNotes = "";
                if (!cst_Util.isValidString(tDisplay))
                {
                    tDisplay = "[empty]";
                    tNotes += "Link has NO Text\r\n";
                }
                if (!cst_Util.isValidString(tLink))
                {
                    tLink = "[empty]";
                    tNotes += "Link has NO Location\r\n";
                }
                else
                {
                    tNotes += Globals.AddInSafetyCheck.suspiciousLink(tLink, tDisplay);
                    try
                    {
                        Uri tUri = new Uri(tLink);
                        tProtocol = tUri.Scheme;
                        if (tProtocol == Uri.UriSchemeMailto)
                        {
                            tMimeType = "[Email-Address]";
                        }
                        else if (Properties.Settings.Default.opt_DeepInspect_LINKS)
                        {
                            tMimeType = cst_Util.wgetContentType(tLink);
                        }
                    }
                    catch (Exception ex)
                    {
                        cst_Util.logException(ex, "dtLinkList::buildData(" + tLink + ")");
                    }
                }
                String[] rowData = new[] { tDisplay, tLink, tMimeType, tNotes };
                this.Rows.Add(rowData);
                // log it
                if (cst_Util.isValidString(tNotes)) parent.log(format + ": " + logArea, "4", "SUSPICIOUS LINK", tNotes);
            }
            return this.Rows.Count;
        }

        private List<DictionaryEntry> traverseRTF(RTFDomElementList tList)
        {
            List<DictionaryEntry> rc = new List<DictionaryEntry>();
            foreach (RTFDomElement rEL in tList)
            {
                if (rEL is RTFDomField)
                {
                    RTFDomField rFLD = rEL as RTFDomField;
                    String s = rFLD.Instructions;
                    Regex rgx = new Regex("HYPERLINK\\s+\"(.*?)\"");
                    foreach (Match m in rgx.Matches(s))
                    {
                        String tDisplay = rFLD.ResultString;
                        String tLink = m.Groups[1].Value;
                        rc.Add(new DictionaryEntry(tLink, tDisplay));
                   }
                }
               rc.AddRange(traverseRTF(rEL.Elements));
            }
            return rc;
        }
    } // class
} // namespace
