﻿using CheccoSafetyTools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookSafetyChex
{
    [System.ComponentModel.DesignerCategory("Code")]

    // [SerializableAttribute]
    public class dsMailItem : DataSet
    {
        // static instance map
        private static Dictionary<String,dsMailItem> mapDataSets = new  Dictionary<String,dsMailItem>();

        // non-static members
        protected readonly AddInSafetyCheck instance = Globals.AddInSafetyCheck;
        protected readonly cst_Log mLogger = Globals.AddInSafetyCheck.mLogger;
 
        public readonly Outlook.MailItem mailItem;
        protected readonly dtWarnings findingsLog = new dtWarnings();

        public static void RemoveAll()
        {
            while (dsMailItem.mapDataSets.Count > 0)
            {
                String entryID = dsMailItem.mapDataSets.First().Key;
                dsMailItem.mapDataSets.Remove(entryID);
            }
        }

        public static dsMailItem Find(String entryID)
        {
            dsMailItem rc = null;
            dsMailItem.mapDataSets.TryGetValue(entryID, out rc);
			return rc;
        }

        public static void Remove(String entryID)
        {
            dsMailItem rc = null;
            if (dsMailItem.mapDataSets.TryGetValue(entryID, out rc))
            {
                dsMailItem.mapDataSets.Remove(entryID);
                rc.Clear();
                rc.Dispose();
            }
        }

        public DataTable findTableName(String tableName)
        {
            int idx = this.Tables.IndexOf(tableName);
            if (idx >= 0) return this.Tables[idx] as dtTemplate;
            return null;
        }

        public DataTable findTableClass<T>()
        {
            foreach (DataTable table in this.Tables)
            {
                if (table is T)
                {
                    return table as dtTemplate;
                }
            }
            return null;
        }

        public void logFinding(String tType, String tSeverity, String tCategory, String tDetails)
        {
            if ( cst_Util.isValidString(tType)
                && cst_Util.isValidString(tCategory)
                && cst_Util.isValidString(tDetails) )
            {
                if (mLogger != null) mLogger.logMessage(tDetails, tCategory);
                if (findingsLog != null)
                {
                    String szCount = findingsLog.Rows.Count.ToString();
                    String[] row = new[] { szCount, tType, /* tSeverity, */ tCategory, tDetails };
                    findingsLog.addDataRow(row);
                }
            }
		}

		public dsMailItem(Outlook.MailItem myItem)
        {
            if (cst_Outlook.isValidMailItem(myItem))
            {
                if ( !mapDataSets.ContainsKey(myItem.EntryID) )
                {
                    this.mailItem = myItem;
					this.Tables.Add(findingsLog);
					this.Tables.Add(new dtEnvelope());
                    this.Tables.Add(new dtHeaders());
                    this.Tables.Add(new dtSender());
                    this.Tables.Add(new dtRecipients());
					this.Tables.Add(new dtRouteList());
					this.Tables.Add(new dtRoutesCheck());
                    this.Tables.Add(new dtBody());
                    this.Tables.Add(new dtLinkList());
					this.Tables.Add(new dtLinksCheck());
                    this.Tables.Add(new dtAttachments());
                    dsMailItem.mapDataSets.Add(myItem.EntryID, this);
                }
                else
                {
                    throw new Exception("MailItemDataSet [constructor]: EntryID already exists in global HashMap");
                }
            }
            else
            {
                throw new Exception("MailItemDataSet [constructor]: Invalid Outlook MailItem or EntryID");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (this.mailItem != null)
            {
                if (dsMailItem.mapDataSets.ContainsKey(this.mailItem.EntryID))
                {
                    dsMailItem.mapDataSets.Remove(this.mailItem.EntryID);
                }
            }
        }

    }
}
