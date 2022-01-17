using CheccoSafetyTools;
using System;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookSafetyChex
{
    public class dtEnvelope : dtTemplate
    {
        static String logArea = Properties.Resources.Title_Envelope;
        public dtEnvelope()
        {
            this.Columns.Add("Field", Type.GetType("System.String"));
            this.Columns.Add("Contents", Type.GetType("System.String"));
            this.Columns.Add("Notes", Type.GetType("System.String"));
        }

        public override int buildData(dsMailItem parent, Outlook.MailItem myItem)
        {
            String[] rowData;
            String tValue = null;
            String tNotes = "";
             // New Row: ID
            rowData = new[] { "Identifier:", myItem.EntryID };
            this.addDataRow(rowData);
            // New Row: SUBJECT
            if (mLogger != null) mLogger.logVerbose("SUBJECT", "Envelope");
            tValue = myItem.Subject;
            tNotes = instance.suspiciousLabel(tValue);
            if (cst_Util.isValidString(tNotes))
                parent.logFinding(logArea, "3", "SUBJECT", tNotes);
            rowData = new[] { "Subject:", myItem.Subject, tNotes };
            this.addDataRow(rowData);
            // New Row: DATE
            if (mLogger != null) mLogger.logVerbose("Date:", "Envelope");
            rowData = new[] { "Received:", myItem.ReceivedTime.ToString() };
            this.addDataRow(rowData);
            // New Row: FROM
            if (mLogger != null) mLogger.logVerbose("From:", "Envelope");
            tValue = myItem.SenderName;
            tNotes = instance.suspiciousLabel(tValue);
            if (cst_Util.isValidString(tNotes))
                parent.logFinding(logArea, "3", "FROM", tNotes);
            String tSender = myItem.SenderName;
            if (myItem.SenderName != myItem.SenderEmailAddress)
                tSender += "\r\n\t<" + myItem.SenderEmailAddress + ">";
            rowData = new[] { "Sender:", tSender, tNotes };
            this.addDataRow(rowData);
            // New Row: TO
            if (mLogger != null) mLogger.logVerbose("To:", "Envelope");
            String tRec = "[" + myItem.Recipients.Count.ToString() + "]";
            rowData = new[] { "# Recipients:", tRec };
            this.addDataRow(rowData);
            int iRec = 0;
            foreach (Outlook.Recipient tRecipient in myItem.Recipients)
            {
				String tTag = cst_Outlook.getRecipientTag(tRecipient);
				String tType = cst_Outlook.getRecipientType(tRecipient);
				iRec++;
                tRec = "\"" + tRecipient.Name + "\"";
                if (tRecipient.Name != tRecipient.Address)
                    tRec += " <" + tRecipient.Address + ">";
                tValue = tRecipient.Name;
                tNotes = instance.suspiciousLabel(tValue);
                if (cst_Util.isValidString(tNotes))
                    parent.logFinding(logArea, "3", "TO", tNotes);
                rowData = new[] { tTag + ": [" + iRec + "]", tRec, tNotes };
                this.addDataRow(rowData);
            }
            // New Row: SIZE
            if (mLogger != null) mLogger.logVerbose("Size:", "Envelope");
            rowData = new[] { "Size (Bytes):", myItem.Size.ToString() };
            this.addDataRow(rowData);
            // New Row: ATTACHMENTS
            if (mLogger != null) mLogger.logVerbose("Attachments:", "Envelope");
            String tFiles = "[" + myItem.Attachments.Count.ToString() + "]";
            rowData = new[] { "# Attachments:", tFiles };
            this.addDataRow(rowData);
            int iAtt = 0;
            foreach (Outlook.Attachment tAttachment in myItem.Attachments)
            {
                iAtt++;
                tFiles = "\"" + tAttachment.DisplayName + "\"";
                if (tAttachment.DisplayName != tAttachment.FileName)
                    tFiles += " <" + tAttachment.FileName + ">";
                tValue = tAttachment.DisplayName;
                tNotes = instance.suspiciousLabel(tValue);
                if (cst_Util.isValidString(tNotes))
                    parent.logFinding(logArea, "3", "ATTACHMENT", tNotes);
                rowData = new[] { "Attachment [" + iAtt + "]:", tFiles, tNotes };
                this.addDataRow(rowData);
            }
            return this.Rows.Count;
        }
    } // class
} // namespace
