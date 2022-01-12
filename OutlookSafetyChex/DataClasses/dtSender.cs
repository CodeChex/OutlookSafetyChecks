using CheccoSafetyTools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Mail;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookSafetyChex
{
    public class dtSender : dtTemplate
    {
        public dtSender()
        {
			this.Columns.Add("Field", Type.GetType("System.String"));
			this.Columns.Add("Name", Type.GetType("System.String"));
			this.Columns.Add("Address", Type.GetType("System.String"));
			this.Columns.Add("Owner", Type.GetType("System.String"));
			this.Columns.Add("Notes", Type.GetType("System.String"));
		}

		public override int buildData(dsMailItem parent, Outlook.MailItem myItem)
        {
			String logTitle = Properties.Resources.Title_Contacts + " / Sender";
			// Obtain "From:"
			String senderName = cst_Util.sanitizeEmail(myItem.SenderName,false);
			String senderEmail = cst_Util.sanitizeEmail(myItem.SenderEmailAddress,true);
            String senderOwner = "[not checked]";
			String senderNotes = "";
			String senderHost = null;
			String senderDomain = null;
			String senderUser = null;
			senderNotes += Globals.AddInSafetyCheck.suspiciousLabel(senderName);
			cst_Log.logVerbose("From: " + senderEmail, "Sender");
			try
			{
				if (cst_Util.isValidString(senderEmail))
				{
					MailAddress senderAddress = new MailAddress(senderEmail, senderName);
					// grab domain owner for email domain   
					senderUser = senderAddress.User;
					senderHost = senderAddress.Host;
					senderDomain = cst_Util.pullDomain(senderHost);
					// check email
					if (Properties.Settings.Default.opt_Lookup_WHOIS)
					{
						senderOwner = cst_WHOIS.whoisOwner(senderDomain, Properties.Settings.Default.opt_Use_CACHE);
					}
					senderNotes += checkEmail(senderAddress, logTitle);
				}
				else if (cst_Util.isValidString(senderName))
                {
					senderNotes += "[* \"From:\" Name with NO Email Address Specified]";
				}
			}
			catch (Exception ex)
            {
				senderNotes += "[* Invalid \"From:\" Email Address Specified]";
                cst_Log.logException(ex, "Parsing From: " + senderEmail);
            }
            // add row
            String[] rowData = new[] { "From", senderName, senderEmail, senderOwner, senderNotes };
			this.Rows.Add(rowData);
			// log it
			if (cst_Util.isValidString(senderNotes))
				parent.log(logTitle, "1", "ANOMALY", senderNotes);

			// Obtain "ReplyTo:"
			foreach (Outlook.Recipient tReplyAddr in myItem.ReplyRecipients)
			{
				String tTag = "Reply-To:"; // cst_Outlook.getRecipientTag(tReplyAddr);
				String tType = cst_Outlook.getRecipientType(tReplyAddr);
				// Obtain Sender (Reply-To:)
				String replyToName = cst_Util.sanitizeEmail(tReplyAddr.Name,false);
				String replyToEmail = cst_Util.sanitizeEmail(tReplyAddr.Address,true);
				String replyToOwner = "[not checked]";
				String replyToNotes = "";
				cst_Log.logVerbose("Reply-To: [" + replyToEmail + "]", "Sender");
				replyToNotes += Globals.AddInSafetyCheck.suspiciousLabel(replyToName);
				// grab domain owner for email domain 
				try
				{
					if (cst_Util.isValidString(replyToEmail))
					{
						MailAddress replyToAddress = new MailAddress(replyToEmail, replyToName);
						String replyToHost = replyToAddress.Host;
						String replyToDomain = cst_Util.pullDomain(replyToHost);
						// start checks
						if (Properties.Settings.Default.opt_Lookup_WHOIS)
						{
							replyToOwner = cst_WHOIS.whoisOwner(replyToDomain, Properties.Settings.Default.opt_Use_CACHE);
						}
						replyToNotes += checkEmail(replyToAddress, logTitle);
						// advanced checks
						if (replyToEmail != senderEmail)
						{
							replyToNotes += "[* MISMATCHED From/ReplyTo]: ";
							String noteDetails = "";
							if (replyToAddress.User != senderUser)
							{
								noteDetails += "USER, ";
							}
							if (replyToDomain != senderDomain)
							{
								noteDetails += "DOMAIN, ";
							}
							else if (replyToHost != senderHost)
							{
								noteDetails += "SERVER, ";
							}
							replyToNotes += noteDetails + "\r\n";
							//parent.log(logTitle, "1", "MISMATCHED From/" + tTag, noteDetails);
						}
					}
					else if (cst_Util.isValidString(replyToName))
					{
						replyToNotes += "[* \"" + tTag + ":\" Name with NO Email Address Specified]";
					}
				}
				catch (Exception ex)
                {
					replyToNotes += "[* Invalid \"" + tTag + ":\" Email Address Specified]";
					//parent.log(logTitle, "1", "INVALID DATA", "Invalid [" + tTag + ":] Email Address Specified");
                    cst_Log.logException(ex, "Parsing " + tTag + ": " + replyToEmail);
                }
                rowData = new[] { tTag, replyToName, replyToEmail, replyToOwner, replyToNotes };
				this.Rows.Add(rowData);
				// log it
				if (cst_Util.isValidString(replyToNotes))
					parent.log(logTitle, "1", "ANOMALY", replyToNotes);
			}

			// Obtain "Return-Path:"
			List<String> arrReply = new List<string>();
			dtHeaders tHeaders = parent.findTableClass<dtHeaders>() as dtHeaders;
			if (tHeaders != null)
			{
				if (tHeaders.Rows.Count == 0) tHeaders.populate(false);
				foreach (DataRow tRow in tHeaders.Rows)
				{
					String tKey = tRow.ItemArray[0] as String;
					if ( tKey.Equals("Return-Path",StringComparison.OrdinalIgnoreCase) )
					{
						String tVal = cst_Util.sanitizeEmail(tRow.ItemArray[1] as String, true);
						cst_Log.logVerbose("Return-Path: [" + tVal + "]", "Sender");
						if (cst_Util.isValidString(tVal)) arrReply.Add(tVal); 
					}
				}
			}
            foreach (String iReturnPath in arrReply)
            {
                // Obtain Sender (Return-Path:)
                String replyToOwner = "[not checked]";
                String replyToNotes = "";
                // grab domain owner for email domain            
                try
                {
					String replyToEmail = cst_Util.sanitizeEmail(iReturnPath,true);
					if (cst_Util.isValidString(replyToEmail))
					{
						MailAddress replyToAddress = new MailAddress(replyToEmail);
						String replyToHost = replyToAddress.Host;
						String replyToDomain = cst_Util.pullDomain(replyToHost);
						// start checks
						if (Properties.Settings.Default.opt_Lookup_WHOIS)
						{
							replyToOwner = cst_WHOIS.whoisOwner(replyToDomain, Properties.Settings.Default.opt_Use_CACHE);
						}
						replyToNotes = checkEmail(replyToAddress, logTitle);
						// advanced checks
						if (replyToEmail != senderEmail)
						{
							replyToNotes += "[* MISMATCHED From/Return-Path]: ";
							String noteDetails = "";
							if (replyToAddress.User != senderUser)
							{
								noteDetails += "USER, ";
							}
							if (replyToDomain != senderDomain)
							{
								noteDetails += "DOMAIN, ";
							}
							else if (replyToHost != senderHost)
							{
								noteDetails += "SERVER, ";
							}
							replyToNotes += noteDetails + "\r\n";
							//parent.log(logTitle, "1", "MISMATCHED From/Return-Path", noteDetails);
						}
					}
				}
				catch (Exception ex)
                {
                    replyToNotes += "[* Invalid \"Return-Path:\" Email Address Specified]";
                    // parent.log(logTitle, "1", "INVALID DATA", "Invalid [Return-Path:] Email Address Specified");
                    cst_Log.logException(ex, "Parsing Return-Path: " + iReturnPath);
                }
                rowData = new[] { "Return-Path", "", iReturnPath, replyToOwner, replyToNotes };
                this.Rows.Add(rowData);
				// log it
				if (cst_Util.isValidString(replyToNotes))
					parent.log(logTitle, "1", "ANOMALY", replyToNotes);
			}
			return this.Rows.Count;
        }
    } // class
} // namespace
