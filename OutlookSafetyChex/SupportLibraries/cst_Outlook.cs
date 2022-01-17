using System;
using System.Collections.Generic;
using System.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace CheccoSafetyTools
{
    abstract class cst_Outlook
	{
		public static bool isValidMailItem(Outlook.MailItem tItem)
        {
            return (tItem != null && cst_Util.isValidString(tItem.EntryID));
        }

        public static String getHeaders(Outlook.MailItem myItem)
        {
            String headers = myItem.PropertyAccessor.GetProperty("http://schemas.microsoft.com/mapi/proptag/0x007D001E");
            headers = headers.Replace('\t', ' ');
            return headers;
        }

        public static List<Outlook.ContactItem> FindContacts(Outlook.Application tApp,String tQuery)
		{
			List<Outlook.ContactItem> arrRC = null;
			try
			{
                Outlook.NameSpace tNS = tApp.GetNamespace("MAPI");
                Outlook.MAPIFolder contactsFolder = tNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts);
                Outlook.Items contactItems = contactsFolder.Items;
                Outlook.Items arrFound = contactItems.Restrict(tQuery);
				arrRC = arrFound.Cast<Outlook.ContactItem>().ToList();
			}
			catch (Exception ex)
			{
				//mLogger.logException(ex, "cst_Outlook::FindContacts("+tQuery+")");
			}
			return arrRC;
		}

		public static List<Outlook.ContactItem> FindContactByFirstLastName(Outlook.Application tApp, String firstName, String lastName)
		{
			List<Outlook.ContactItem> arrRC = null;
			String tQuery = String.Format("[FirstName]='{0}' and [LastName]='{1}'", firstName, lastName);
			arrRC = FindContacts(tApp,tQuery);
			return arrRC;
		}
		public static List<Outlook.ContactItem> FindContactByDisplayName(Outlook.Application tApp, String displayName)
		{
			List<Outlook.ContactItem> arrRC = null;
			String tQuery = String.Format("[Email1DisplayName]='{0}' or [Email2DisplayName]='{0}' or [Email3DisplayName]='{0}'", displayName);
			arrRC = FindContacts(tApp,tQuery);
			return arrRC;
		}
		public static List<Outlook.ContactItem> FindContactByEmail(Outlook.Application tApp, String email)
		{
			List<Outlook.ContactItem> arrRC = null;
			String tQuery = String.Format("[Email1Address]='{0}' or [Email2Address]='{0}' or [Email3Address]='{0}'", email);
			arrRC = FindContacts(tApp,tQuery);
			return arrRC;
		}
		public static List<Outlook.ContactItem> FindContactByOrganization(Outlook.Application tApp, String company)
		{
			List<Outlook.ContactItem> arrRC = null;
			String tQuery = String.Format("[CompanyName]='{0}'", company);
			arrRC = FindContacts(tApp,tQuery);
			return arrRC;
		}

		public static String getRecipientTag(Outlook.Recipient tRecipient)
		{
			// Obtain "To/CC/BCC/Originator:"
			String rc = "";
			try
			{
				switch ((Outlook.OlMailRecipientType)tRecipient.Type)
				{
					case Outlook.OlMailRecipientType.olTo:
						rc = "To";
						break;
					case Outlook.OlMailRecipientType.olCC:
						rc = "CC";
						break;
					case Outlook.OlMailRecipientType.olBCC:
						rc = "BCC";
						break;
					case Outlook.OlMailRecipientType.olOriginator:
						rc = "Originator";
						break;
				}
			}
			catch // (Exception ex)
			{
				// do nothing here
			}
			return rc;
		}

		public static String getRecipientType(Outlook.Recipient tRecipient)
		{
			// Obtain recipient type
			String rc = "";
			try
			{
				switch (tRecipient.DisplayType)
				{
					case Outlook.OlDisplayType.olAgent:
						rc = "Agent";
						break;
					case Outlook.OlDisplayType.olDistList:
						rc = "Distribution-List";
						break;
					case Outlook.OlDisplayType.olForum:
						rc = "Forum";
						break;
					case Outlook.OlDisplayType.olOrganization:
						rc = "Organization";
						break;
					case Outlook.OlDisplayType.olPrivateDistList:
						rc = "Private-List";
						break;
					case Outlook.OlDisplayType.olRemoteUser:
						rc = "Remote-User";
						break;
					case Outlook.OlDisplayType.olUser:
						rc = "User";
						break;
				}
			}
			catch // (Exception ex)
			{
				// do nothing here
			}
			return rc;
		}

	} // class
} // namespace
