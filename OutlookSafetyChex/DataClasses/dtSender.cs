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
		private static readonly String logArea = Properties.Resources.Title_Contacts + " (Senders)";
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
			// Obtain "From:"
			String senderName = instance.mWebUtil.sanitizeEmail(myItem.SenderName,false);
			String senderEmail = instance.mWebUtil.sanitizeEmail(myItem.SenderEmailAddress,true);
            String senderOwner = "[not checked]";
			String senderNotes = "";
			String senderHost = null;
			String senderDomain = null;
			String senderUser = null;
			senderNotes += instance.suspiciousLabel(senderName);
			if (mLogger != null) 
				mLogger.logInfo("Inspecting [From: " + senderEmail + "]", logArea);
			try
			{
				if (cst_Util.isValidString(senderEmail))
				{
					MailAddress senderAddress = new MailAddress(senderEmail, senderName);
					// grab domain owner for email domain   
					senderUser = senderAddress.User;
					senderHost = senderAddress.Host;
					senderDomain = instance.mWebUtil.pullDomain(senderHost);
					// check email
					if (Properties.Settings.Default.opt_Lookup_WHOIS)
					{
						senderOwner = instance.mWHOIS.whoisOwner(senderDomain, Properties.Settings.Default.opt_Use_CACHE);
					}
					senderNotes += checkEmail(senderAddress, logArea);
				}
				else if (cst_Util.isValidString(senderName))
                {
					senderNotes += "[* \"From:\" Name with NO Email Address Specified]";
				}
			}
			catch (Exception ex)
            {
				senderNotes += "[* Invalid \"From:\" Email Address Specified]";
                if (mLogger != null) mLogger.logException(ex, "Parsing From: " + senderEmail);
            }
            // add row
            String[] rowData = new[] { "From", senderName, senderEmail, senderOwner, senderNotes };
			this.addDataRow(rowData);
			// log it
			if (cst_Util.isValidString(senderNotes))
				parent.logFinding(logArea, "1", "ANOMALY", senderNotes);

			// Obtain "ReplyTo:"
			if (mLogger != null)
				mLogger.logInfo("Inspecting [" + myItem.ReplyRecipients.Count + "] Reply-To", logArea);
			foreach (Outlook.Recipient tReplyAddr in myItem.ReplyRecipients)
			{
				String tTag = "Reply-To:"; // cst_Outlook.getRecipientTag(tReplyAddr);
				String tType = cst_Outlook.getRecipientType(tReplyAddr);
				// Obtain Sender (Reply-To:)
				String replyToName = instance.mWebUtil.sanitizeEmail(tReplyAddr.Name,false);
				String replyToEmail = instance.mWebUtil.sanitizeEmail(tReplyAddr.Address,true);
				String replyToOwner = "[not checked]";
				String replyToNotes = "";
				if (mLogger != null) mLogger.logVerbose("Reply-To: [" + replyToEmail + "]", "Sender");
				replyToNotes += instance.suspiciousLabel(replyToName);
				// grab domain owner for email domain 
				try
				{
					if (cst_Util.isValidString(replyToEmail))
					{
						MailAddress replyToAddress = new MailAddress(replyToEmail, replyToName);
						String replyToHost = replyToAddress.Host;
						String replyToDomain = instance.mWebUtil.pullDomain(replyToHost);
						// start checks
						if (Properties.Settings.Default.opt_Lookup_WHOIS)
						{
							replyToOwner = instance.mWHOIS.whoisOwner(replyToDomain, Properties.Settings.Default.opt_Use_CACHE);
						}
						replyToNotes += checkEmail(replyToAddress, logArea);
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
                    if (mLogger != null) mLogger.logException(ex, "Parsing " + tTag + ": " + replyToEmail);
                }
                rowData = new[] { tTag, replyToName, replyToEmail, replyToOwner, replyToNotes };
				this.addDataRow(rowData);
				// log it
				if (cst_Util.isValidString(replyToNotes))
					parent.logFinding(logArea, "1", "ANOMALY", replyToNotes);
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
						String tVal = instance.mWebUtil.sanitizeEmail(tRow.ItemArray[1] as String, true);
						if (mLogger != null) mLogger.logVerbose("Return-Path: [" + tVal + "]", "Sender");
						if (cst_Util.isValidString(tVal)) arrReply.Add(tVal); 
					}
				}
			}
			if (mLogger != null)
				mLogger.logInfo("Inspecting [" + arrReply.Count + "] Return-Path", logArea);
			foreach (String iReturnPath in arrReply)
            {
                // Obtain Sender (Return-Path:)
                String replyToOwner = "[not checked]";
                String replyToNotes = "";
                // grab domain owner for email domain            
                try
                {
					String replyToEmail = instance.mWebUtil.sanitizeEmail(iReturnPath,true);
					if (cst_Util.isValidString(replyToEmail))
					{
						MailAddress replyToAddress = new MailAddress(replyToEmail);
						String replyToHost = replyToAddress.Host;
						String replyToDomain = instance.mWebUtil.pullDomain(replyToHost);
						// start checks
						if (Properties.Settings.Default.opt_Lookup_WHOIS)
						{
							replyToOwner = instance.mWHOIS.whoisOwner(replyToDomain, Properties.Settings.Default.opt_Use_CACHE);
						}
						replyToNotes = checkEmail(replyToAddress, logArea);
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
                    if (mLogger != null) mLogger.logException(ex, "Parsing Return-Path: " + iReturnPath);
                }
                rowData = new[] { "Return-Path", "", iReturnPath, replyToOwner, replyToNotes };
                this.addDataRow(rowData);
				// log it
				if (cst_Util.isValidString(replyToNotes))
					parent.logFinding(logArea, "1", "ANOMALY", replyToNotes);
			}
			return this.Rows.Count;
        }
    } // class
} // namespace
