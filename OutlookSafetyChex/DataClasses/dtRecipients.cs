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
			foreach (Outlook.Recipient tRecipient in myItem.Recipients)
			{
				iRec++;
				String tName = cst_Util.sanitizeEmail(tRecipient.Name);
				String tEmail = cst_Util.sanitizeEmail(tRecipient.Address);
				String tTag = cst_Outlook.getRecipientTag(tRecipient);
				String tType = cst_Outlook.getRecipientType(tRecipient);
				String tOwner = "[not checked]";
				String tResults = "";
				try
				{
                    MailAddress tMailAddress = new MailAddress(tEmail, tName);
                    // grab domain owner for email domain            
                    String tHost = tMailAddress.Host;
					String tDomain = cst_Util.pullDomain(tHost);
					// check email  
					tResults = checkEmail(tMailAddress,logTitle);
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
                                String chkName = cst_Util.sanitizeEmail(zRow.Field<String>("Name"));
                                bool dupName = chkName.Equals(tName, StringComparison.OrdinalIgnoreCase);
                                // compare [Recipient.Email] against each [Sender.email]
                                String chkAddress = cst_Util.sanitizeEmail(zRow.Field<String>("Address"));
                                bool dupAddr = chkAddress.Equals(tEmail, StringComparison.OrdinalIgnoreCase);
                                // log it?
                                if ( dupName || dupAddr)
                                {
                                    String noteDetails = "[* To: = " + chkFld + "]";
                                    parent.log(logTitle, "1", "ANOMALY", noteDetails);
                                    tResults += noteDetails + "\r\n";
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        cst_Util.logException(ex, "dtRecipients::build cannot find Sender table");
                    }
                    // get additional info
                    if (Properties.Settings.Default.opt_Lookup_WHOIS)
					{
						tOwner = cst_WHOIS.whoisOwner(tDomain, Properties.Settings.Default.opt_Use_CACHE);
					}
				}
                catch (Exception ex)
                {
                    tResults += "[* Invalid [" + tTag + "] Email Address Specified]";
					parent.log(logTitle, "1", "INVALID DATA", "Invalid ["+tTag+ "] Email Address Specified: " + ex.Message);
				}
				// add row
				String[] rowData = new[] { tTag, tName, tEmail, tOwner, tResults };
				this.Rows.Add(rowData);
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
