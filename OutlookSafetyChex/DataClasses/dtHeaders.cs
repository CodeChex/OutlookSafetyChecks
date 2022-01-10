using CheccoSafetyTools;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookSafetyChex
{
    public class dtHeaders : dtTemplate
    {
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
            foreach (String tHeader in arrHeader)
            {
                Match m = rgx.Match(tHeader);
                // found new ":"
                if (m.Groups.Count > 2)  
                {
                    // save any pending
                    if (cst_Util.isValidString(tName))
                    {
                        cst_Util.logVerbose(tName, "Header");
                        String tNotes = checkHeader(parent, tName, tValue);
                    }
                    // start new one
                    tName = m.Groups[1].Value.Trim();
                    tValue = m.Groups[2].Value.Trim();
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
                cst_Util.logVerbose(tName, "Header");
                String tNotes = checkHeader(parent, tName, tValue);
            }/*
            if (this.Rows.Count == 0)
            {
                String tReason = "Header List is EMPTY";
                parent.log(Properties.Resources.Title_Headers, "4", "HEADER LIST", tReason);
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
                    rc = Globals.AddInSafetyCheck.suspiciousValue(tValue, 1024);
                    switch ( tName.ToLower() )
                    {
                        case "subject":
                            rc += checkSubject(tValue);
                            break;
                        case "content-transfer-encoding":
                            rc += checkCharEncoding(tValue);
                            break;
                        case "content-type":
                            rc += checkContentType(tValue);
                            break;
                    }
                }
            }
            catch { }
            // always add to the list because it will be used for routing checks
            String[] rowData = new[] { tName, tValue, rc };
            this.Rows.Add(rowData); 
            // log it
            if (cst_Util.isValidString(rc))
            {
                parent.log(Properties.Resources.Title_Headers, "4", "HEADER:" + tName, rc);
            }
            return rc;
        }

        public String checkSubject(String tValue)
        {
            String rc = "";
            rc += Globals.AddInSafetyCheck.suspiciousText(tValue);
            // simple, but subject starting with whitespace are forwned upon
            if (tValue.StartsWith(" "))
            {
                rc += "Subject Line has Leading Whitespace\r\n";
            }
            return rc;
        }

        public String checkCharEncoding(String tValue)
        {
            // Content-Transfer-Encoding: 8bit
            String rc = "";
            List<String> commonEncoding = AddInSafetyCheck.getCommonENCODINGs();
            try
            {
                if (cst_Util.isValidString(tValue))
                {
                    // check character encoding
                    if (!commonEncoding.Contains(tValue.Trim().ToLower()))
                    {
                        rc += "Uncommon Encoding (" + tValue + ")\r\n";
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
            List<String> commonFormats = AddInSafetyCheck.getCommonMIMETYPEs();
            List<String> commonCharSets = AddInSafetyCheck.getCommonCODEPAGEs();
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
                // validate MIME format
                if (cst_Util.isValidString(tFormat))
                {
                    if ( !commonFormats.Contains(tFormat.Trim().ToLower()) )
                    {
                        rc += "Uncommon MIME format (" + tFormat + ")\r\n";
                    }
                }
                // validate charset
                if (cst_Util.isValidString(tCharSet))
                {
                    if (!commonCharSets.Contains(tCharSet.Trim().ToLower()))
                    {
                        rc += "Uncommon Character Set (" + tCharSet + ")\r\n";
                    }
                }
            }
            catch { }
            return rc;
        }
    } // class
} // namespace
