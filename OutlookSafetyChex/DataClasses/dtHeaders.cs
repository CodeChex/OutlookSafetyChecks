using CheccoSafetyTools;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookSafetyChex
{
    public class dtHeaders : dtTemplate
    {
        static String logArea = Properties.Resources.Title_Headers;
        public dtHeaders()
        {
            this.Columns.Add("Field", Type.GetType("System.String"));
            this.Columns.Add("Contents", Type.GetType("System.String"));
            this.Columns.Add("Notes", Type.GetType("System.String"));
        }

        public override int buildData(dsMailItem parent, Outlook.MailItem myItem)
        {
            /*
                if internet headers are available at the time that the message is converted to MAPI, 
                they are converted and stored in a special MAPI property named PR_TRANSPORT_MESSAGE_HEADERS                     
            */
            String headers = cst_Outlook.getHeaders(myItem);
			// splitting the headers into parseable lines
			String[] hdrDelims = { "\r\n", "\n\r", "\n", "\r", "\0" };
            String[] arrHeader = headers.Split(hdrDelims, StringSplitOptions.RemoveEmptyEntries);
            String rgxStr = "^(\\S*):\\s*(.*)$";
            Regex rgx = new Regex(rgxStr);
            // aggregating Received entries (may have multple lines)
            String tName = null;
            String tValue = null;
            if (mLogger != null)
                mLogger.logInfo("Inspecting [" + arrHeader.Count() + "] Header Entries", logArea);
            foreach (String tHeader in arrHeader)
            {
                Match m = rgx.Match(tHeader);
                // found new ":"
                if (m.Groups.Count > 2)  
                {
                    // save any pending
                    if (cst_Util.isValidString(tName))
                    {
                        if (mLogger != null) mLogger.logVerbose(tName, "Header");
                        String tNotes = checkHeader(parent, tName, tValue);
                    }
                    // start new one
                    tName = m.Groups[1].Value.Trim();
                    tValue = m.Groups[2].Value;
                }
                // found just data
                else  
                {
                    tValue += " " + tHeader;
                }
            }
            // save any pending
            if (cst_Util.isValidString(tName))
            {
                if (mLogger != null) mLogger.logVerbose(tName, "Header");
                String tNotes = checkHeader(parent, tName, tValue);
            }/*
            if (this.Rows.Count == 0)
            {
                String tReason = "Header List is EMPTY";
                parent.log(logArea, "4", "HEADER LIST", tReason);
            }
            */
            return this.Rows.Count;
        }

        public String checkHeader(dsMailItem parent, String tName, String tValue)
        {
            String rc = "";
            try
            {
                if (cst_Util.isValidString(tName) && cst_Util.isValidString(tValue))
                {
                    rc = instance.suspiciousValue(tValue, 1024);
                    String tStr = tName.ToLower();
                    switch ( tStr )
                    {
                        case "x-originating-ip":
                            String tIPAddr = instance.mWebUtil.parseIPaddress(tValue);
                            if (cst_Util.isValidString(tIPAddr))
                            {
                                rc += instance.suspiciousIP(tIPAddr);
                                if (Properties.Settings.Default.opt_Lookup_WHOIS)
                                {
                                    rc += instance.mWHOIS.whoisOwner(tIPAddr, Properties.Settings.Default.opt_Use_CACHE);
                                }
                            }
                            break;
                        case "list-unsubscribe":
                            cst_URL tLink = cst_URL.parseURL(tValue,false);
                            if (tLink != null)
                            {
                                rc += instance.suspiciousLink(tLink.mURL);
                                try
                                {
                                     if (Properties.Settings.Default.opt_Lookup_WHOIS)
                                    {
                                        String tDomain = instance.mWebUtil.pullDomain(tLink.mUri.Host);
                                        rc += instance.mWHOIS.whoisOwner(tDomain, Properties.Settings.Default.opt_Use_CACHE);
                                    }
                                }
                                catch
                                {
                                    rc += "[INVALID LINK FORMAT]\r\n";
                                }
                            }
                            break;
                        case "content-language":
                            rc += checkLanguageCulture(tValue);
                            break;
                        case "content-type":
                            rc += checkContentType(tValue);
                            break;
                        /* 
                        already covered by envelope processing
                        case "to":
                        case "from":
                        case "subject":
                            rc += instance.suspiciousLabel(tValue);
                            break;
                        */
                        default:
                            if ( (tStr.Contains("spam") || tStr.Contains("virus") ) && 
                                Properties.Settings.Default.opt_ShowSpamHeaders)
                            {
                                parent.logFinding(logArea, "99", tName, tValue);
                            }
                            break;
                    }
                }
            }
            catch { }
            // always add to the list because it will be used for routing checks
            String[] rowData = new[] { tName, tValue, rc };
            this.addDataRow(rowData); 
            // log it
            if (cst_Util.isValidString(rc))
            {
                parent.logFinding(logArea, "4", tName, rc);
            }
            return rc;
        }

        public String checkLanguageCulture(String tValue)
        {
            // Conent-Language: us-EN
            String rc = "";
            List<String> checkCultures = instance.getLocalCULTUREs();
            try
            {
                if (cst_Util.isValidString(tValue))
                {
                    // check character encoding (case insensitive)
                    if (!checkCultures.Contains(tValue.Trim(), StringComparer.OrdinalIgnoreCase))
                    {
                        rc += "Uncommon Language-Culture (" + tValue + ")\r\n";
                    }
                }
            }
            catch { }
            return rc;
        }

        public String checkContentType(String tValue)
        {
            // Content-Type: text/html; charset="..."
            // Content-Type: multipart/alternative; boundary="..."
            String rc = "";
            List<String> checkFormats = instance.getLocalMIMETYPEs();
            List<String> checkCharSets = instance.getLocalCODEPAGEs();
            String tFormat = null;
            String tCharSet = null;
            String rgxPattern = @"charset\=""(\S+)""";
            Regex rgx = new Regex(rgxPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            try
            {
                if (cst_Util.isValidString(tValue))
                {
                    String[] arrEL = tValue.Split(';');
                    tFormat = arrEL[0];
                    if (arrEL.Length > 1)
                    {
                        Match m = rgx.Match(arrEL[1]);
                        if (m.Groups.Count > 1)
                        {
                            tCharSet = m.Groups[1].Value;
                        }
                    }
                }
                // validate MIME format (case insensitive)
                if (cst_Util.isValidString(tFormat))
                {
                    if ( !checkFormats.Contains(tFormat.Trim(), StringComparer.OrdinalIgnoreCase) )
                    {
                        rc += "Uncommon MIMEtype (" + tFormat + ")\r\n";
                    }
                }
                // validate charset (case insensitive)
                if (cst_Util.isValidString(tCharSet))
                {
                    if (!checkCharSets.Contains(tCharSet.Trim(), StringComparer.OrdinalIgnoreCase))
                    {
                        rc += "Uncommon Codepage (" + tCharSet + ")\r\n";
                    }
                }
            }
            catch { }
            return rc;
        }
    } // class
} // namespace
