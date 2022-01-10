using CheccoSafetyTools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookSafetyChecks
{
    [System.ComponentModel.DesignerCategory("Code")]

    // [SerializableAttribute]
    public abstract class dtTemplate : DataTable
    {
        public dtTemplate()
        {
            this.TableName = this.GetType().Name;
        }

        public String checkEmail(MailAddress tMailAddr, String logArea = null)
		{
			// grab domain owner for email domain            
			String tHost = tMailAddr.Host;
			String tNotes = Globals.AddInSafetyCheck.suspiciousLink(Uri.UriSchemeMailto + ":" + tMailAddr.Address,tMailAddr.DisplayName);
			String tReason = Globals.AddInSafetyCheck.suspiciousEmail(tMailAddr);
            if (cst_Util.isValidString(tReason)) tNotes += tReason;
            // do we need to log it here?
            if (cst_Util.isValidString(tNotes) && cst_Util.isValidString(logArea))
            {
                dsMailItem parent = this.DataSet as dsMailItem;
                if (parent != null) parent.log(logArea, "4", "SUSPICIOUS EMAIL", tNotes);
            }
            return tNotes;
		}

		public int populate(bool refresh = true)
        {
            if (refresh) this.Rows.Clear();
            if (this.Rows.Count == 0)
            {
                dsMailItem parent = this.DataSet as dsMailItem;
                if (parent != null)
                {
                    Outlook.MailItem myItem = parent.mailItem;
                    if (cst_Outlook.isValidMailItem(myItem))
                    {
                        buildData(parent, myItem);
                    }
                }
            }
            return this.Rows.Count;
        }
        public abstract int buildData(dsMailItem parent, Outlook.MailItem myItem);
    }
}
