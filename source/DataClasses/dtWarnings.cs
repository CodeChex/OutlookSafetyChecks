using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookSafetyChecks
{
	public class dtWarnings : dtTemplate
	{
		public dtWarnings()
		{
			this.TableName = this.GetType().Name;
			this.Columns.Add("Area", Type.GetType("System.String"));
			this.Columns.Add("Severity", Type.GetType("System.String"));
			this.Columns.Add("Finding", Type.GetType("System.String"));
			this.Columns.Add("Details", Type.GetType("System.String"));
		}

        public override int buildData(dsMailItem parent, Outlook.MailItem myItem)
        {
            List<String> arrFlagged = new List<string>();
            dtHeaders tHeaders = parent.findTableClass<dtHeaders>() as dtHeaders;
            if (tHeaders != null)
            {
                if (tHeaders.Rows.Count == 0) tHeaders.populate(false);
                foreach (DataRow tRow in tHeaders.Rows)
                {
                    String tKey = tRow.ItemArray[0] as String;
                    String tVal = tRow.ItemArray[1] as String;
                    if (tKey.Contains("Spam")) arrFlagged.Add(tVal);
                }
            } 
			// start parsing
			foreach (String s in arrFlagged)
			{
                // TODO: dtWarnings? from SMTP headers
			}
			return this.Rows.Count;
		}
	} // class
} // namespace
