using CheccoSafetyTools;
using System;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookSafetyChex
{
    public class dtEnvelope : dtTemplate
    {
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
            this.Rows.Add(rowData);
            // New Row: SUBJECT
            cst_Log.logVerbose("SUBJECT", "Envelope");
            tValue = myItem.Subject;
            tNotes = Globals.AddInSafetyCheck.suspiciousLabel(tValue);
            if (cst_Util.isValidString(tNotes))
                parent.log(Properties.Resources.Title_Envelope, "3", "SUBJECT", tNotes);
            rowData = new[] { "Subject:", myItem.Subject, tNotes };
            this.Rows.Add(rowData);
            // New Row: DATE
            cst_Log.logVerbose("Date:", "Envelope");
            rowData = new[] { "Received:", myItem.ReceivedTime.ToString() };
            this.Rows.Add(rowData);
            // New Row: FROM
            cst_Log.logVerbose("From:", "Envelope");
            tValue = myItem.SenderName;
            tNotes = Globals.AddInSafetyCheck.suspiciousLabel(tValue);
            if (cst_Util.isValidString(tNotes))
                parent.log(Properties.Resources.Title_Envelope, "3", "FROM", tNotes);
            String tSender = myItem.SenderName;
            if (myItem.SenderName != myItem.SenderEmailAddress)
                tSender += "\r\n\t<" + myItem.SenderEmailAddress + ">";
            rowData = new[] { "Sender:", tSender, tNotes };
            this.Rows.Add(rowData);
            // New Row: TO
            cst_Log.logVerbose("To:", "Envelope");
            String tRec = "[" + myItem.Recipients.Count.ToString() + "]";
            rowData = new[] { "# Recipients:", tRec };
            this.Rows.Add(rowData);
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
                tNotes = Globals.AddInSafetyCheck.suspiciousLabel(tValue);
                if (cst_Util.isValidString(tNotes))
                    parent.log(Properties.Resources.Title_Envelope, "3", "TO", tNotes);
                rowData = new[] { tTag + ": [" + iRec + "]", tRec, tNotes };
                this.Rows.Add(rowData);
            }
            // New Row: SIZE
            cst_Log.logVerbose("Size:", "Envelope");
            rowData = new[] { "Size (Bytes):", myItem.Size.ToString() };
            this.Rows.Add(rowData);
            // New Row: ATTACHMENTS
            cst_Log.logVerbose("Attachments:", "Envelope");
            String tFiles = "[" + myItem.Attachments.Count.ToString() + "]";
            rowData = new[] { "# Attachments:", tFiles };
            this.Rows.Add(rowData);
            int iAtt = 0;
            foreach (Outlook.Attachment tAttachment in myItem.Attachments)
            {
                iAtt++;
                tFiles = "\"" + tAttachment.DisplayName + "\"";
                if (tAttachment.DisplayName != tAttachment.FileName)
                    tFiles += " <" + tAttachment.FileName + ">";
                tValue = tAttachment.DisplayName;
                tNotes = Globals.AddInSafetyCheck.suspiciousLabel(tValue);
                if (cst_Util.isValidString(tNotes))
                    parent.log(Properties.Resources.Title_Envelope, "3", "ATTACHMENT", tNotes);
                rowData = new[] { "Attachment [" + iAtt + "]:", tFiles, tNotes };
                this.Rows.Add(rowData);
            }
            return this.Rows.Count;
        }
    } // class
} // namespace
