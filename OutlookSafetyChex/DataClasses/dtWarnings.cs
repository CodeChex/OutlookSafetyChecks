using System;
using System.Collections.Generic;
using System.Data;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookSafetyChex
{
    public class dtWarnings : dtTemplate
	{
		public dtWarnings()
		{
			this.TableName = this.GetType().Name;
			this.Columns.Add("Area", Type.GetType("System.String"));
			//this.Columns.Add("Severity", Type.GetType("System.String"));
			this.Columns.Add("Finding", Type.GetType("System.String"));
			this.Columns.Add("Details", Type.GetType("System.String"));
		}

        public override int buildData(dsMailItem parent, Outlook.MailItem myItem)
        {
			return this.Rows.Count;
		}
	} // class
} // namespace
