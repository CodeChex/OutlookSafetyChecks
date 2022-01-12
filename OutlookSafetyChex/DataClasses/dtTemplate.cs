using CheccoSafetyTools;
using System;
using System.Data;
using System.Net.Mail;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookSafetyChex
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
            String tName = cst_Util.sanitizeEmail(tMailAddr.DisplayName,false);
            String tAddr = cst_Util.sanitizeEmail(tMailAddr.Address,true);
            // grab domain owner for email domain            
			String tNotes = Globals.AddInSafetyCheck.suspiciousLink(Uri.UriSchemeMailto + ":" + tAddr,tName);
			tNotes += Globals.AddInSafetyCheck.suspiciousEmail(tMailAddr);
            tNotes += Globals.AddInSafetyCheck.suspiciousLabel(tName);
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
            if (refresh)
            {
                this.Rows.Clear();
                Globals.AddInSafetyCheck.dialogWindow.Refresh();
            }
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
