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
#if DEBUG
                ribbonXML = ribbonXML.Replace("button id=\"SafetyCheckMenu\" label=\"",
                    "button id =\"SafetyCheckMenu\" label=\"(DEBUG) ");
#endif
            }
            else if (ribbonID == "Microsoft.Outlook.Mail.Read")
            {
                ribbonXML = GetResourceText("OutlookSafetyChex.CustomUI_AddInRibbon.xml");
#if DEBUG
                ribbonXML = ribbonXML.Replace("button id=\"SafetyCheckButton\" label=\"",
                    "button id =\"SafetyCheckButton\" label=\"(DEBUG) ");
#endif
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
            if (myMail != null)
            {
                Globals.AddInSafetyCheck.loadDialog(myMail);
            }
        }
        public void SafetyCheck_Inspector(Office.IRibbonControl control)
        {
            Outlook.MailItem myMail = Globals.AddInSafetyCheck.getOpenMailItem();
            if (myMail != null)
            {
                Globals.AddInSafetyCheck.loadDialog(myMail);
            }
        }

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
