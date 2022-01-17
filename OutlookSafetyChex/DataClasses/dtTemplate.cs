using CheccoSafetyTools;
using System;
using System.Data;
using System.Net.Mail;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookSafetyChex
{
    [System.ComponentModel.DesignerCategory("Code")]

    // [SerializableAttribute]
    public abstract class dtTemplate : DataTable
    {
        protected readonly AddInSafetyCheck instance = Globals.AddInSafetyCheck;
        protected readonly cst_Log mLogger = Globals.AddInSafetyCheck.mLogger;

        public Control mView = Globals.AddInSafetyCheck.dialogWindow;
        private static readonly String logArea = "dtTemplate";
 
        public dtTemplate()
        {
            this.TableName = this.GetType().Name;
        }

        public void addDataRow(object[] rowData)
        {
            DataRow rc = null;
            try
            {
                if (rowData != null)
                {
                    if ( mView != null && mView.InvokeRequired)
                    {
                        mView.Invoke(new Action(delegate ()
                        {
                            rc = this.Rows.Add(rowData);
                        }));
                    }
                    else
                    {
                        rc = this.Rows.Add(rowData);
                    }
                }
            }
            catch (Exception ex)
            {
                if (mLogger != null) mLogger.logException(ex,logArea + "::addDataRow()");
            }
            //return rc;
        }

        public String checkEmail(MailAddress tMailAddr, String logArea = null)
		{
            String tName = instance.mWebUtil.sanitizeEmail(tMailAddr.DisplayName,false);
            String tAddr = instance.mWebUtil.sanitizeEmail(tMailAddr.Address,true);
            // grab domain owner for email domain            
			String tNotes = instance.suspiciousLink(Uri.UriSchemeMailto + ":" + tAddr,tName);
			tNotes += instance.suspiciousEmail(tMailAddr);
            tNotes += instance.suspiciousLabel(tName);
            // do we need to log it here?
            if (cst_Util.isValidString(tNotes) && cst_Util.isValidString(logArea))
            {
                dsMailItem parent = this.DataSet as dsMailItem;
                if (parent != null) parent.logFinding(logArea, "4", "SUSPICIOUS EMAIL", tNotes);
            }
            return tNotes;
		}

		public int populate(bool refresh = true)
        {
            if (refresh)
            {
                if (mView != null && mView.InvokeRequired)
                {
                    mView.Invoke(new Action(delegate ()
                    {
                        this.Rows.Clear();
                    }));
                }
                else
                {
                    this.Rows.Clear();
                }
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
            // UI
            if (mView.InvokeRequired)
            {
                mView.Invoke(new Action( delegate ()
                    {
                        mView.Refresh();
                    }));
            }
            else
            {
                mView.Refresh();
            }
            return this.Rows.Count;
        }
        public abstract int buildData(dsMailItem parent, Outlook.MailItem myItem);
    }
}
