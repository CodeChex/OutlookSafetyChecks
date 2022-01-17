using CheccoSafetyTools;
using System;
using System.Data;
using System.Net.Mail;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookSafetyChex
{
    public class dtRecipients : dtTemplate
    {
        private static readonly String logArea = Properties.Resources.Title_Contacts + " (Recipients)";
        public dtRecipients()
        {
			this.Columns.Add("Field", Type.GetType("System.String"));
			this.Columns.Add("Name", Type.GetType("System.String"));
			this.Columns.Add("Address", Type.GetType("System.String"));
			this.Columns.Add("Owner", Type.GetType("System.String"));
			this.Columns.Add("Checks", Type.GetType("System.String"));
		}

		public override int buildData(dsMailItem parent, Outlook.MailItem myItem)
        {
			int iRec = 0;
            if (mLogger != null)
                mLogger.logInfo("Inspecting [" + myItem.Recipients.Count + "] Recipients", logArea);
            foreach (Outlook.Recipient tRecipient in myItem.Recipients)
			{
				iRec++;
				String tName = instance.mWebUtil.sanitizeEmail(tRecipient.Name,false);
				String tEmail = instance.mWebUtil.sanitizeEmail(tRecipient.Address,true);
				String tTag = cst_Outlook.getRecipientTag(tRecipient);
				String tType = cst_Outlook.getRecipientType(tRecipient);
				String tOwner = "[not checked]";
				String tResults = "";
                if (mLogger != null) mLogger.logVerbose(tTag + ": [" + tEmail + "]", "Recipient");
                tResults += instance.suspiciousLabel(tName);
                try
                {
                    if (cst_Util.isValidString(tEmail))
                    {
                        MailAddress tMailAddress = new MailAddress(tEmail, tName);
                        // grab domain owner for email domain            
                        String tHost = tMailAddress.Host;
                        String tDomain = instance.mWebUtil.pullDomain(tHost);
                        // check email  
                        tResults += checkEmail(tMailAddress, logArea);
                        // compare each Recipient against Sender data extracted
                        try
                        {
                            dtTemplate myTable = parent.findTableClass<dtSender>() as dtTemplate;
                            if (myTable != null)
                            {
                                foreach (DataRow zRow in myTable.Rows)
                                {
                                    String chkFld = zRow.Field<String>("Field");
                                    // compare [Recipient.Name] against each [Sender.name]
                                    String chkName = instance.mWebUtil.sanitizeEmail(zRow.Field<String>("Name"), false);
                                    bool dupName = chkName.Equals(tName, StringComparison.OrdinalIgnoreCase);
                                    // compare [Recipient.Email] against each [Sender.email]
                                    String chkAddress = instance.mWebUtil.sanitizeEmail(zRow.Field<String>("Address"), true);
                                    bool dupAddr = chkAddress.Equals(tEmail, StringComparison.OrdinalIgnoreCase);
                                    // log it?
                                    if (dupName || dupAddr)
                                    {
                                        String noteDetails = "[* To: = " + chkFld + "]";
                                        //parent.log(logTitle, "1", "ANOMALY", noteDetails);
                                        tResults += noteDetails + "\r\n";
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            if (mLogger != null) mLogger.logException(ex, "dtRecipients::build cannot find Sender table");
                        }
                        // get additional info
                        if (Properties.Settings.Default.opt_Lookup_WHOIS)
                        {
                            tOwner = instance.mWHOIS.whoisOwner(tDomain, Properties.Settings.Default.opt_Use_CACHE);
                        }
                    }
                    else if (cst_Util.isValidString(tName))
                    {
                        tResults += "[* \"" + tTag + ":\" Name with NO Email Address Specified]";
                    }
                }
                catch (Exception ex)
                {
                    tResults += "Error [" + tTag + "]: " + ex.Message;
                }
                // add row
                String[] rowData = new[] { tTag, tName, tEmail, tOwner, tResults };
				this.addDataRow(rowData);
                // log it
                if (cst_Util.isValidString(tResults))
                    parent.logFinding(logArea, "1", "ANOMALY", tResults);
            }
            if (this.Rows.Count == 0)
            {
                parent.logFinding(logArea, "1", "ANOMALY", "No Recipients Specified");
            }
            else if (this.Rows.Count > 10)
            {
                parent.logFinding(logArea, "1", "ANOMALY", "Large # of Recipients [" + iRec + "]");
            }
			return this.Rows.Count;
        }
    } // class
} // namespace
