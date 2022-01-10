using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Office = Microsoft.Office.Core;
using Outlook = Microsoft.Office.Interop.Outlook;
using MessageBox = System.Windows.Forms.MessageBox;

// Follow these steps to enable the Ribbon (XML) item:

// 1: Copy the following code block into the ThisAddin, ThisWorkbook, or ThisDocument class.

//  protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
//  {
//      return new CustomUI_Handler();
//  }

// 2. Create callback methods in the "Ribbon Callbacks" region of this class to handle user
//    actions, such as clicking a button. Note: if you have exported this Ribbon from the Ribbon designer,
//    move your code from the event handlers to the callback methods and modify the code to work with the
//    Ribbon extensibility (RibbonX) programming model.

// 3. Assign attributes to the control tags in the Ribbon XML file to identify the appropriate callback methods in your code.  

// For more information, see the Ribbon XML documentation in the Visual Studio Tools for Office Help.


namespace OutlookSafetyChex
{
    [ComVisible(true)]
    public class CustomUI_Handler : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;

        public CustomUI_Handler()
        {
            ribbon = null;
        }

        #region IRibbonExtensibility Members

        public string GetCustomUI(string ribbonID)
        {
            string ribbonXML = null;

            if (ribbonID == "Microsoft.Outlook.Explorer")
            {
                ribbonXML = GetResourceText("OutlookSafetyChex.CustomUI_ContextMenu.xml");
            }
            else if (ribbonID == "Microsoft.Outlook.Mail.Read")
            {
                ribbonXML = GetResourceText("OutlookSafetyChex.CustomUI_AddInRibbon.xml");
            }
            else
            {
                //MessageBox.Show(ribbonID, "GetCustomUI::RibbonID");
            }
            return ribbonXML;
        }

        #endregion

        #region Ribbon Callbacks
        //Create callback methods here. For more information about adding callback methods, visit https://go.microsoft.com/fwlink/?LinkID=271226
        public void SafetyCheck_Selector(Office.IRibbonControl control)
        {
            Outlook.MailItem myMail = Globals.AddInSafetyCheck.getSelectedMailItem();
            Globals.AddInSafetyCheck.loadDialog(myMail);
        }
        public void SafetyCheck_Inspector(Office.IRibbonControl control)
        {
            Outlook.MailItem myMail = Globals.AddInSafetyCheck.getOpenMailItem();
            Globals.AddInSafetyCheck.loadDialog(myMail);
        }

/*
        public void Toggle_WHOIS(Office.IRibbonControl control, bool pressed)
        {
            Globals.AddInSafetyCheck.check_WHOIS = pressed;
        }
        public bool IsSelected_WHOIS(Office.IRibbonControl control)
        {
            bool fSelected = Globals.AddInSafetyCheck.check_WHOIS;
            return fSelected;
        }

        public void Toggle_DNSBL(Office.IRibbonControl control, bool pressed)
        {
            Globals.AddInSafetyCheck.check_BLACKLIST = pressed;
        }
        public bool IsSelected_DNSBL(Office.IRibbonControl control)
        {
            bool fSelected = Globals.AddInSafetyCheck.check_BLACKLIST;
            return fSelected;
        }

        public void Toggle_CACHE(Office.IRibbonControl control, bool pressed)
        {
            bool fSelected = Globals.AddInSafetyCheck.check_BLACKLIST;
            Globals.AddInSafetyCheck.use_CACHE = pressed;
        }
        public bool IsSelected_CACHE(Office.IRibbonControl control)
        {
            bool fSelected = Globals.AddInSafetyCheck.use_CACHE;
            return fSelected;
        }

        public void ShowEnvelope_Selector(Office.IRibbonControl control)
        {
            Outlook.MailItem myMail = getSelectedMailItem(control);
            Globals.AddInSafetyCheck.ShowEnvelope(myMail);
        }
        public void ShowEnvelope_Inspector(Office.IRibbonControl control)
        {
            Outlook.MailItem myMail = getOpenMailItem(control);
            Globals.AddInSafetyCheck.ShowEnvelope(myMail);
        }

        public void DumpHeaders_Selector(Office.IRibbonControl control)
        {
            Outlook.MailItem myMail = getSelectedMailItem(control);
            Globals.AddInSafetyCheck.DumpHeaders(myMail);
        }
        public void DumpHeaders_Inspector(Office.IRibbonControl control)
        {
            Outlook.MailItem myMail = getOpenMailItem(control);
            Globals.AddInSafetyCheck.DumpHeaders(myMail);
        }

        public void CheckReplyTo_Selector(Office.IRibbonControl control)
        {
            Outlook.MailItem myMail = getSelectedMailItem(control);
            Globals.AddInSafetyCheck.CheckReplyTo(myMail);
        }
        public void CheckReplyTo_Inspector(Office.IRibbonControl control)
        {
            Outlook.MailItem myMail = getOpenMailItem(control);
            Globals.AddInSafetyCheck.CheckReplyTo(myMail);
        }

        public void CheckLinks_Selector(Office.IRibbonControl control)
        {
            Outlook.MailItem myMail = getSelectedMailItem(control);
            Globals.AddInSafetyCheck.InspectLinks(myMail);
        }
        public void CheckLinks_Inspector(Office.IRibbonControl control)
        {
            Outlook.MailItem myMail = getOpenMailItem(control);
            Globals.AddInSafetyCheck.InspectLinks(myMail);
        }

        public void CheckAttachments_Selector(Office.IRibbonControl control)
        {
            Outlook.MailItem myMail = getSelectedMailItem(control);
            Globals.AddInSafetyCheck.InspectAttachments(myMail);
        }
        public void CheckAttachments_Inspector(Office.IRibbonControl control)
        {
            Outlook.MailItem myMail = getOpenMailItem(control);
            Globals.AddInSafetyCheck.InspectAttachments(myMail);
        }

        public bool EnableAttachments_Selector(Office.IRibbonControl control)
        {
            bool fEnable = false;
            Outlook.MailItem myMail = getSelectedMailItem(control);
            fEnable = (myMail != null) && (myMail.Attachments.Count > 0);
            return fEnable;
        }
        public bool EnableAttachments_Inspector(Office.IRibbonControl control)
        {
            bool fEnable = false;
            Outlook.MailItem myMail = getOpenMailItem(control);
            fEnable = (myMail != null) && (myMail.Attachments.Count > 0);
            return fEnable;
        }

        public void CheckRouting_Selector(Office.IRibbonControl control)
        {
            Outlook.MailItem myMail = getSelectedMailItem(control);
            Globals.AddInSafetyCheck.InspectRouting(myMail);
        }
        public void CheckRouting_Inspector(Office.IRibbonControl control)
        {
            Outlook.MailItem myMail = getOpenMailItem(control);
            Globals.AddInSafetyCheck.InspectRouting(myMail);
        }

        public bool EnableRouting_Selector(Office.IRibbonControl control)
        {
            bool fEnable = false;
            Outlook.MailItem myMail = getSelectedMailItem(control);
            fEnable = (myMail != null) && (myMail.SenderEmailType == "SMTP");
            return fEnable;
        }
        public bool EnableRouting_Inspector(Office.IRibbonControl control)
        {
            bool fEnable = false;
            Outlook.MailItem myMail = getOpenMailItem(control);
            fEnable = (myMail != null) && (myMail.SenderEmailType == "SMTP");
            return fEnable;
        }
*/

        public void CustomUI_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
        }

        #endregion

        #region Helpers

        private static string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i)
            {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
                    {
                        if (resourceReader != null)
                        {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        #endregion
    }
}
