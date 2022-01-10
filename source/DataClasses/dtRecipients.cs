using CheccoSafetyTools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Outlook = Microsoft.Office.Interop.Outlook;
using cst_WHOIS = CheccoSafetyTools.cst_WHOISNET_API;

namespace OutlookSafetyChecks
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
				String tName = tRecipient.Name;
				String tEmail = tRecipient.Address;
				String tTag = cst_Outlook.getRecipientTag(tRecipient);
				String tType = cst_Outlook.getRecipientType(tRecipient);
				String tOwner = "[not checked]";
				String tResults = "";
				try
				{
					MailAddress tMailAddress = new MailAddress(tEmail,tName);
					// grab domain owner for email domain            
					String tHost = tMailAddress.Host;
					String tDomain = cst_Util.pullDomain(tHost);
					// check email
					tResults = checkEmail(tMailAddress,logTitle);
					if (Properties.Settings.Default.opt_Lookup_WHOIS)
					{
						tOwner = cst_WHOIS.whoisOwner(tDomain, Properties.Settings.Default.opt_Use_CACHE);
					}
				}
                catch (Exception ex)
                {
					tResults += "[* Invalid [" + tTag + "] Email Address Specified]";
					parent.log(logTitle, "1", "INVALID DATA", "Invalid ["+tTag+ "] Email Address Specified");
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
