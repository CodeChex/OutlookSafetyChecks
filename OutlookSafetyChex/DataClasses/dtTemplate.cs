using AngleSharp.Dom;
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

        public String verifyHREF(IElement tNode, String tTag = "href")
        {
            String tNotes = "";
            try
            {
                String tDisplay = tNode.TextContent;
                String tLink = tNode.GetAttribute(tTag);
                String tLabel = "<" + tNode.NodeName + " " + tTag + "=...>";
                if (mLogger != null) mLogger.logVerbose(tLabel, "Link");
                // needs to have some visible 
                if (!cst_Util.isValidString(tDisplay) && !tNode.HasChildNodes)
                {
                    tDisplay = "[empty]";
                    tNotes += "NO VISIBLE Text\r\n";
                }
                if (!cst_Util.isValidString(tLink))
                {
                    tLink = "[empty]";
                    tNotes += "NO Location Specified\r\n";
                }
                else
                {
                    tNotes += verifyLink(tLink, tDisplay, true);
                }
            }
            catch (Exception ex)
            {
                if (mLogger != null) mLogger.logException(ex, "dtLinkList::verifyHREF\r\n\t" + tNode.OuterHtml + "\r\n");
            }
            return tNotes;
        }

        public String verifySRC(IElement tNode, String tTag = "src")
        {
            String tNotes = "";
            try
            {
                String tDisplay = tNode.TextContent;
                String tLink = tNode.GetAttribute(tTag);
                String tLabel = "<" + tNode.NodeName + " " + tTag + "=...>";
                if (mLogger != null) mLogger.logVerbose(tLabel, "Link");
                if (!cst_Util.isValidString(tLink))
                {
                    tLink = "[empty]";
                    tNotes += "NO Location Specified\r\n";
                }
                else
                {
                    if (tNode.NodeName.Equals("img", StringComparison.OrdinalIgnoreCase))
                    {
                        tNotes += verifyImage(tLink);
                    }
                    tNotes += verifyLink(tLink, tDisplay, false);
                }
            }
            catch (Exception ex)
            {
                if (mLogger != null) mLogger.logException(ex, "dtLinkList::verifySRC\r\n\t" + tNode.OuterHtml + "\r\n");
            }
            return tNotes;
        }

        public String verifyCODEBASE(IElement tNode, String tTag = "codebase")
        {
            String tNotes = "";
            try
            {
                String tDisplay = tNode.TextContent;
                String tLink = tNode.GetAttribute(tTag);
                String tLabel = "<" + tNode.NodeName + " " + tTag + "=...>";
                // additional warning
                tNotes += "Potential Executable Object\r\n";
                // check codebase URL
                tNotes += verifySRC(tNode, tTag);
            }
            catch (Exception ex)
            {
                if (mLogger != null) mLogger.logException(ex, "dtLinkList::verifySRC\r\n\t" + tNode.OuterHtml + "\r\n");
            }
            return tNotes;
        }

        public String verifyLink(String tLink, String tText, bool allowParam)
        {
            String tNotes = "";
            // check each link
            String tProtocol = "[unknown]";
            String tMimeType = "[not checked]";
            tNotes += instance.suspiciousLink(tLink, tText, allowParam);
            try
            {
                cst_URL tURL = cst_URL.parseURL(tLink);
                tProtocol = tURL.mUri.Scheme;
                if (tProtocol == Uri.UriSchemeMailto)
                {
                    tMimeType = "[Email-Address]";
                    tNotes += checkEmail(new MailAddress(tURL.mPath));
                }
                else
                {
                    if (Properties.Settings.Default.opt_DeepInspect_LINKS)
                    {
                        tMimeType = instance.mWebUtil.wgetContentType(tLink);
                    }
                }
            }
            catch (Exception ex)
            {
                if (mLogger != null) mLogger.logException(ex, "dtLinkList::verifyLink(" + tLink + ")");
            }
            return tNotes;
        }

        public String verifyImage(String tLink)
        {
            String tNotes = "";
            bool goodExt = false;
            String[] validImgExt = { ".png", ".jpg", ".jpeg", ".gif", ".svg" };
            foreach (String ext in validImgExt)
            {
                if (tLink.EndsWith(ext, StringComparison.OrdinalIgnoreCase))
                {
                    goodExt = true;
                    break;
                }
            }
            if (!goodExt)
            {
                tNotes += "UNCOMMON <img> File Specified\r\n";
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
