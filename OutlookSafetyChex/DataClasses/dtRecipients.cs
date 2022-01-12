using CheccoSafetyTools;
using System;
using System.Data;
using System.Net.Mail;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookSafetyChex
{
    public class dtRecipients : dtTemplate
    {
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
			String logTitle = Properties.Resources.Title_Contacts + " / Recipient";
            cst_Log.logVerbose("Count: [" + myItem.Recipients.Count + "]", "Recipients");
            foreach (Outlook.Recipient tRecipient in myItem.Recipients)
			{
				iRec++;
				String tName = cst_Util.sanitizeEmail(tRecipient.Name,false);
				String tEmail = cst_Util.sanitizeEmail(tRecipient.Address,true);
				String tTag = cst_Outlook.getRecipientTag(tRecipient);
				String tType = cst_Outlook.getRecipientType(tRecipient);
				String tOwner = "[not checked]";
				String tResults = "";
                cst_Log.logVerbose(tTag + ": [" + tEmail + "]", "Recipient");
                tResults += Globals.AddInSafetyCheck.suspiciousLabel(tName);
                try
                {
                    if (cst_Util.isValidString(tEmail))
                    {
                        MailAddress tMailAddress = new MailAddress(tEmail, tName);
                        // grab domain owner for email domain            
                        String tHost = tMailAddress.Host;
                        String tDomain = cst_Util.pullDomain(tHost);
                        // check email  
                        tResults += checkEmail(tMailAddress, logTitle);
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
                                    String chkName = cst_Util.sanitizeEmail(zRow.Field<String>("Name"), false);
                                    bool dupName = chkName.Equals(tName, StringComparison.OrdinalIgnoreCase);
                                    // compare [Recipient.Email] against each [Sender.email]
                                    String chkAddress = cst_Util.sanitizeEmail(zRow.Field<String>("Address"), true);
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
                            cst_Log.logException(ex, "dtRecipients::build cannot find Sender table");
                        }
                        // get additional info
                        if (Properties.Settings.Default.opt_Lookup_WHOIS)
                        {
                            tOwner = cst_WHOIS.whoisOwner(tDomain, Properties.Settings.Default.opt_Use_CACHE);
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
				this.Rows.Add(rowData);
                // log it
                if (cst_Util.isValidString(tResults))
                    parent.log(logTitle, "1", "ANOMALY", tResults);
            }
            if (this.Rows.Count == 0)
            {
                parent.log(logTitle, "1", "ANOMALY", "No Recipients Specified");
            }
            else if (this.Rows.Count > 10)
            {
                parent.log(logTitle, "1", "ANOMALY", "Large # of Recipients [" + iRec + "]");
            }
			return this.Rows.Count;
        }
    } // class
} // namespace
