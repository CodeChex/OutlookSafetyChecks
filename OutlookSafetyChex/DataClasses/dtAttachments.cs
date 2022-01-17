using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CheccoSafetyTools;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookSafetyChex
{
    public class dtAttachments : dtTemplate
    {
        static String logArea = Properties.Resources.Title_Attachments;

        public dtAttachments()
        {
            this.Columns.Add("Display Name", Type.GetType("System.String"));
            this.Columns.Add("File Name", Type.GetType("System.String"));
            this.Columns.Add("Mime Type", Type.GetType("System.String"));
            this.Columns.Add("Binary Signature", Type.GetType("System.String"));
            this.Columns.Add("Notes", Type.GetType("System.String"));
        }

        public override int buildData(dsMailItem parent, Outlook.MailItem myItem)
        {
            if (mLogger != null) 
                mLogger.logInfo("Inspecting [" + myItem.Attachments.Count + "]", logArea);
            foreach (Outlook.Attachment tAttachment in myItem.Attachments)
            {
                if (mLogger != null) mLogger.logVerbose(tAttachment.DisplayName, logArea);
                String tMimeType = "[not checked]";
                String tFileSig = "[not checked]";
                String tNotes = instance.suspiciousAttachment(tAttachment, out tMimeType, out tFileSig);
                String[] rowData = new[] {
                        tAttachment.DisplayName,
                        tAttachment.FileName,
                        tMimeType,
                        tFileSig,
                        tNotes };
                this.addDataRow(rowData);
                // log it
                if (cst_Util.isValidString(tNotes)) parent.logFinding(logArea, "4", "SUSPICIOUS ATTACHMENT", tNotes);
            }
            return this.Rows.Count;
        }
    } // class
} // namespace
