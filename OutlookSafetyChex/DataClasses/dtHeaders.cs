using CheccoSafetyTools;
using System;
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
                        String tNotes = Globals.AddInSafetyCheck.suspiciousValue(tValue,1024);
                        // special case for subject line
                        if ( tName.Equals("subject",StringComparison.CurrentCultureIgnoreCase) )
                        {
                            tNotes += Globals.AddInSafetyCheck.suspiciousText(tValue);
                            // simple, but subject starting with whitespace are forwned upon
                            if (tName.StartsWith(" "))
                            {
                                tNotes += "Subject Line has Leading Whitespace\r\n";
                            }
                        }
                        // log it
                        if (cst_Util.isValidString(tNotes))
                        {
                            parent.log(Properties.Resources.Title_Headers, "4", "HEADER:" + tName, tNotes);
                        }
                        String[] rowData = new[] { tName, tValue, tNotes };
                        this.Rows.Add(rowData);
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
                String tNotes = Globals.AddInSafetyCheck.suspiciousValue(tValue,1024);
                // special case for subject line
                if (tName.Equals("subject", StringComparison.CurrentCultureIgnoreCase))
                {
                    tNotes += Globals.AddInSafetyCheck.suspiciousText(tValue);
                    // simple, but subject starting with whitespace are forwned upon
                    if (tName.StartsWith(" "))
                    {
                        tNotes += "Subject Line has Leading Whitespace\r\n";
                    }
                }
                // log it
                if (cst_Util.isValidString(tNotes))
                {
                    parent.log(Properties.Resources.Title_Headers, "4", "HEADER:" + tName, tNotes);
                }
                String[] rowData = new[] { tName, tValue, tNotes };
                this.Rows.Add(rowData);
            }/*
            if (this.Rows.Count == 0)
            {
                String tReason = "Header List is EMPTY";
                parent.log(Properties.Resources.Title_Headers, "4", "HEADER LIST", tReason);
            }
            */
            return this.Rows.Count;
        }
    } // class
} // namespace
