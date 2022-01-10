using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Outlook = Microsoft.Office.Interop.Outlook;
using CheccoSafetyTools;

namespace OutlookSafetyChecks
{
    public class dtEnvelope : dtTemplate
    {
        public dtEnvelope()
        {
            this.Columns.Add("Field", Type.GetType("System.String"));
            this.Columns.Add("Contents", Type.GetType("System.String"));
        }

        public override int buildData(dsMailItem parent, Outlook.MailItem myItem)
        {
            String[] rowData;
            // New Row: ID
            rowData = new[] { "Identifier:", myItem.EntryID };
            this.Rows.Add(rowData);
            // New Row: SUBJECT
            rowData = new[] { "Subject:", myItem.Subject };
            this.Rows.Add(rowData);
            // New Row: DATE
            rowData = new[] { "Received:", myItem.ReceivedTime.ToString() };
            this.Rows.Add(rowData);
            // New Row: FROM
            String tSender = myItem.SenderName;
            if (myItem.SenderName != myItem.SenderEmailAddress)
                tSender += "\r\n\t<" + myItem.SenderEmailAddress + ">";
            rowData = new[] { "Sender:", tSender };
            this.Rows.Add(rowData);
            // New Row: TO
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
                rowData = new[] { tTag + ": [" + iRec + "]", tRec };
                this.Rows.Add(rowData);
            }
            // New Row: SIZE
            rowData = new[] { "Size (Bytes):", myItem.Size.ToString() };
            this.Rows.Add(rowData);
            // New Row: ATTACHMENTS
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
                rowData = new[] { "Attachment [" + iAtt + "]:", tFiles };
                this.Rows.Add(rowData);
            }
            return this.Rows.Count;
        }
    } // class
} // namespace
