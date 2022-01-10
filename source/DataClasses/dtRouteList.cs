using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Outlook = Microsoft.Office.Interop.Outlook;
using CheccoSafetyTools;

namespace OutlookSafetyChecks
{
    public class dtRouteList : dtTemplate
    {
        public dtRouteList()
        {
            this.Columns.Add("Hop", Type.GetType("System.Int16"));
            this.Columns.Add("From", Type.GetType("System.String"));
			this.Columns.Add("From Host", Type.GetType("System.String"));
			this.Columns.Add("From IP", Type.GetType("System.String"));
			this.Columns.Add("By", Type.GetType("System.String"));
			this.Columns.Add("By Host", Type.GetType("System.String"));
			this.Columns.Add("By App", Type.GetType("System.String"));
			this.Columns.Add("With", Type.GetType("System.String"));
            this.Columns.Add("ID", Type.GetType("System.String"));
            this.Columns.Add("For", Type.GetType("System.String"));
			this.Columns.Add("Timestamp", Type.GetType("System.String"));
		}

		public override int buildData(dsMailItem parent, Outlook.MailItem myItem)
        {
            List<String> arrRECVD = new List<string>();
            dtHeaders tHeaders = parent.findTableClass<dtHeaders>() as dtHeaders;
            if ( tHeaders != null )
            {
                if (tHeaders.Rows.Count == 0) tHeaders.populate(false);
                foreach ( DataRow tRow in tHeaders.Rows)
                {
                    String tKey = tRow.ItemArray[0] as String;
                    String tVal = tRow.ItemArray[1] as String;
                    if (tKey == "Received") arrRECVD.Add(tVal);
                }
            }
            // start parsing
            int nHop = 0;
            foreach (String s in arrRECVD)
            {
                nHop++;
                // cst_Util.logInfo(s,"dtRouteList::buildData [Received Header]");
                /* (https://www.pobox.com/helpspot/index.php?pg=kb.page&id=253)
                 The structure of a "Received:" header
                     from 
                        the name the sending computer gave for itself (the name associated with that computer's IP address [its IP address])
                     by
                        the receiving computer's name (the software that computer uses) (usually Sendmail, qmail or Postfix)
                     with 
                        protocol (usually SMTP, ESMTP or ESMTPS)
                     id 
                        id assigned by local computer for logging;
                     for
                        <recipient>
                     ;
                        timestamp (usually given in the computer's localtime; see below for how you can convert these all to your time)
                 */
                // REGEX? "(?<=from|by|with|id|for)\s+(.*);\s+(.*)\s+"
                // manually parse this crap in reverse order (because regex is greedy)
                String[] sep;
                String[] arrS;
				String tFROM = "";
				String tFROM_HOST = "";
				String tFROM_IP = "";
				String tBY = "";
				String tBY_HOST = "";
				String tBY_APP = "";
				String tWITH = "";
				String tID = "";
				String tFOR = "";
				String tTIMESTAMP = "";

				String test = s;
                // - TIMESTAMP
                sep = new String[] { ";" };
                arrS = test.Split(sep, 2, StringSplitOptions.None);
                test = arrS[0].Trim();
                if (arrS.Length > 1)
                {
                    tTIMESTAMP = arrS[1].Trim();
                }
                // - FOR
                sep = new String[] { " for " };
                arrS = test.Split(sep, 2, StringSplitOptions.None);
                test = arrS[0].Trim();
                if (arrS.Length > 1)
                {
                    tFOR = arrS[1].Trim();
                }
                // - ID
                sep = new String[] { " id " };
                arrS = test.Split(sep, 2, StringSplitOptions.None);
                test = arrS[0].Trim();
                if (arrS.Length > 1)
                {
                    tID = arrS[1].Trim();
                }
                // - WITH
                sep = new String[] { " with " };
                arrS = test.Split(sep, 2, StringSplitOptions.None);
                test = arrS[0].Trim();
                if (arrS.Length > 1)
                {
                    tWITH = arrS[1].Trim();
                }
                // - BY
                sep = new String[] { " by " };
                arrS = test.Split(sep, 2, StringSplitOptions.None);
                test = arrS[0].Trim();
                if (arrS.Length > 1)
                {
                    tBY = arrS[1].Trim();
                    // parse out server name(s) and email application
                    String rgxStr = "([A-Za-z0-9\\.\\-]+)(.*\\((.*)\\))?";
                    Regex rgx = new Regex(rgxStr);
                    Match m = rgx.Match(arrS[1]);
                    if (m.Groups.Count > 1)
                    {
                        tBY_HOST = m.Groups[1].Value.Trim();
                        if (m.Groups.Count > 2)
                        {
                            tBY_APP = m.Groups[2].Value.Trim();
                        }
                    }
                }
                // - FROM
                sep = new String[] { "from " };
                arrS = test.Split(sep, 2, StringSplitOptions.None);
                test = arrS[0].Trim();
                if (arrS.Length > 1)
                {
                    tFROM = arrS[1].Trim();
                    // parse out server name(s) and IP
                    /* formats: 
                            server (IP)
                            server (alias [IP])
                            server (alias) ([IP])
                            server (ACK alias) (IP)
                            server (ACK alias) ([IP])
                     */
                    //String rgxStr = "([A-Za-z0-9\\-\\.]+).*\\((?:.*)\\[(\\d+\\.\\d+\\.\\d+\\.\\d+)\\]\\)";
					String rgxStr = "([A-Za-z0-9\\-\\.]+).*\\D(\\d+\\.\\d+\\.\\d+\\.\\d+)\\D";
					Regex rgx = new Regex(rgxStr);
                    Match m = rgx.Match(arrS[1]);
                    if (m.Groups.Count > 1)
                    {
                        tFROM_HOST = m.Groups[1].Value.Trim();
                        if (m.Groups.Count > 2)
                        {
                            tFROM_IP = m.Groups[2].Value.Trim();
                       }
                    }
                }
				// display
				String[] rowData = new[] { nHop.ToString(),
						tFROM, tFROM_HOST, tFROM_IP,
						tBY, tBY_HOST, tBY_APP,
						tWITH,
						tID,
						tFOR,
						tTIMESTAMP
				};
				this.Rows.Add(rowData);
			}
            return this.Rows.Count;
        }
    } // class
} // namespace
