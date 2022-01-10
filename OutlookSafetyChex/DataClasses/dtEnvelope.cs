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
            String tNotes = "";
             // New Row: ID
            rowData = new[] { "Identifier:", myItem.EntryID };
            this.Rows.Add(rowData);
            // New Row: SUBJECT
            cst_Util.logVerbose("SUBJECT", "Envelope");
            tNotes = Globals.AddInSafetyCheck.suspiciousText(myItem.Subject);
            if (cst_Util.isValidString(tNotes))
            {
                parent.log(Properties.Resources.Title_Envelope, "4", "SUBJECT", tNotes);
            }
            rowData = new[] { "Subject:", myItem.Subject, tNotes };
            this.Rows.Add(rowData);
            // New Row: DATE
            cst_Util.logVerbose("Date:", "Envelope");
            rowData = new[] { "Received:", myItem.ReceivedTime.ToString() };
            this.Rows.Add(rowData);
            // New Row: FROM
            cst_Util.logVerbose("From:", "Envelope");
            tNotes = Globals.AddInSafetyCheck.suspiciousText(myItem.SenderName);
            if (cst_Util.isValidString(tNotes))
            {
                parent.log(Properties.Resources.Title_Envelope, "4", "FROM", tNotes);
            }
            String tSender = myItem.SenderName;
            if (myItem.SenderName != myItem.SenderEmailAddress)
                tSender += "\r\n\t<" + myItem.SenderEmailAddress + ">";
            rowData = new[] { "Sender:", tSender, tNotes };
            this.Rows.Add(rowData);
            // New Row: TO
            cst_Util.logVerbose("To:", "Envelope");
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
                tNotes = Globals.AddInSafetyCheck.suspiciousText(tRecipient.Name);
                if (cst_Util.isValidString(tNotes))
                {
                    parent.log(Properties.Resources.Title_Envelope, "4", "TO", tNotes);
                }
                rowData = new[] { tTag + ": [" + iRec + "]", tRec, tNotes };
                this.Rows.Add(rowData);
            }
            // New Row: SIZE
            cst_Util.logVerbose("Size:", "Envelope");
            rowData = new[] { "Size (Bytes):", myItem.Size.ToString() };
            this.Rows.Add(rowData);
            // New Row: ATTACHMENTS
            cst_Util.logVerbose("Attachments:", "Envelope");
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
                tNotes = Globals.AddInSafetyCheck.suspiciousText(tAttachment.DisplayName);
                if (cst_Util.isValidString(tNotes))
                {
                    parent.log(Properties.Resources.Title_Envelope, "4", "ATTACHMENT", tNotes);
                }
                rowData = new[] { "Attachment [" + iAtt + "]:", tFiles, tNotes };
                this.Rows.Add(rowData);
            }
            return this.Rows.Count;
        }
    } // class
} // namespace
