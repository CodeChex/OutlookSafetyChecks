using CheccoSafetyTools;
using OutlookSafetyChex.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookSafetyChex
{
    public partial class dlgSafetyCheck : Form
    {
        AddInSafetyCheck instance = Globals.AddInSafetyCheck;
        cst_Log mLogger = Globals.AddInSafetyCheck.mLogger;

        public Dictionary<Thread, Stopwatch> pendingThreads = new Dictionary<Thread, Stopwatch>();
        public Stopwatch gStopwatch = new Stopwatch();

        public dlgSafetyCheck(Outlook.MailItem myItem)
        {
            InitializeComponent();
            initializePane();
            // UI
            String title = "Subject: " + myItem.Subject;
            this.textBoxProgress.Text = title;
            this.Text = ""
#if DEBUG
                + "(DEBUG) "
#endif
                + Properties.Resources.ShortName + " - " + title;
            this.rawHeaderTextBox.Text = cst_Outlook.getHeaders(myItem);
            this.btnCancel.Enabled = false;
        }

        private void dlgSafetyCheck_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mLogger != null) mLogger.setLoggingUI(null, null);
            if (instance != null) instance.cleanupDialog();
        }

#region application customizations

        void initializePane()
        {
            try
            {
                resetTabs();
                // Link logger
                if (mLogger != null) mLogger.setLoggingUI(
                    new TextBox[] { this.textDebug },
                    new TextBox[] { this.textBoxProgress });
                // Main TAB
                initializeGridView(this.logGridView, instance.findTableClass<dtWarnings>());
                // Info TAB
                this.envelopeTab.Text = Properties.Resources.Title_Envelope;
                initializeGridView(this.envelopeGridView, instance.findTableClass<dtEnvelope>());
                // Header TAB
                this.headerTab.Text = Properties.Resources.Title_Headers;
                initializeGridView(this.headerGridView, instance.findTableClass<dtHeaders>());
                // Route TAB
                this.routeTab.Text = Properties.Resources.Title_Routing;
                initializeGridView(this.routeCheckGridView, instance.findTableClass<dtRoutesCheck>());
                initializeGridView(this.routeListGridView, instance.findTableClass<dtRouteList>());
                // Contact TAB
                this.contactTab.Text = Properties.Resources.Title_Contacts;
                initializeGridView(this.senderGridView, instance.findTableClass<dtSender>());
                initializeGridView(this.recipientsGridView, instance.findTableClass<dtRecipients>());
                // Body TAB
                this.bodyTab.Text = Properties.Resources.Title_Body;
                initializeGridView(this.bodyGridView, instance.findTableClass<dtBody>());
                // Links TAB
                this.linksTab.Text = Properties.Resources.Title_Links;
                initializeGridView(this.linkCheckGridView, instance.findTableClass<dtLinksCheck>());
                initializeGridView(this.linkListGridView, instance.findTableClass<dtLinkList>());
                // Attachments TAB
                this.attachmentsTab.Text = Properties.Resources.Title_Attachments;
                initializeGridView(this.attachmentsGridView, instance.findTableClass<dtAttachments>());
                // reset log
                if (mLogger != null) mLogger.logInfo(null, null, true);
            }
            catch (Exception ex)
            {
                if (mLogger != null) mLogger.logException(ex, "initializePane()");
            }
        }

        void initializeGridView(DataGridView myGridView, dtTemplate myTable = null)
        {
            if (myGridView != null)
            {
                myGridView.SuspendLayout();
                try
                {
                    myGridView.DataSource = null;
                    myGridView.Rows.Clear();
                    myGridView.Columns.Clear();
                    myGridView.Dock = DockStyle.Fill;
                    myGridView.AutoGenerateColumns = true;
                    myGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    myGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                    myGridView.AllowUserToAddRows = false;
                    myGridView.AllowUserToDeleteRows = false;
                    myGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    myGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    myGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                    myGridView.AllowUserToResizeColumns = true;
                    myGridView.AllowUserToResizeRows = true;
                    myGridView.ScrollBars = ScrollBars.Both;
                    myGridView.ReadOnly = true;
                    myGridView.TabIndex = 0;
                    if (myTable != null)
                    {
                        myGridView.DataSource = new DataView(myTable);
                        myTable.mView = myGridView;
                    }
                }
                catch (Exception ex)
                {
                    if (mLogger != null) mLogger.logException(ex, "initializeGridView(" + myGridView.Name + ")");
                }
                myGridView.ResumeLayout(true);
            }
        }

        #endregion

        private void setTabVisibility(TabPage tTab, bool visible)
        {
            int idx = this.myTabControl.TabPages.IndexOf(this.loggingTab);
            if (this.myTabControl.InvokeRequired)
            {
                myTabControl.Invoke(new Action(delegate ()
                {
                    if (!visible)
                    {
                        this.myTabControl.TabPages.Remove(tTab);
                    }
                    else if (!this.myTabControl.TabPages.Contains(tTab))
                    {
                        this.myTabControl.TabPages.Insert(idx, tTab);
                    }
                }));
            }
            else
            {
                if (!visible)
                {
                    this.myTabControl.TabPages.Remove(tTab);
                }
                else if ( !this.myTabControl.TabPages.Contains(tTab) )
                {
                    this.myTabControl.TabPages.Insert(idx,tTab);
                }
            }
        }

        private void resetTabs()
        {
            // hide tabs
            setTabVisibility(envelopeTab, false);
            setTabVisibility(headerTab, false);
            setTabVisibility(contactTab, false);
            setTabVisibility(routeTab, false);
            setTabVisibility(linksTab, false);
            setTabVisibility(attachmentsTab, false);
            setTabVisibility(bodyTab, false);
        }

        private void btnRunTests_Click(object sender, EventArgs ev)
        {
            gStopwatch.Reset();
            gStopwatch.Start();
            instance.ABORT_PROCESSING = false;
            this.btnRunTests.Enabled = false;
            this.btnSettings.Enabled = false;
            this.btnAbout.Enabled = false;
            this.btnCancel.Enabled = true;
            resetTabs();
            // jump to log
            if (Properties.Settings.Default.opt_ShowLog)
            {
                this.myTabControl.SelectedTab = this.loggingTab;
            }
            instance.resetLog(Properties.Settings.Default.opt_Force_REFRESH);
            if (mLogger != null) mLogger.logMessage("Start Time: " + DateTime.Now + "", "<<< BEGIN >>>", true);
            spawnThread(new ThreadStart(runChecks), "Main Thread");
         }

        private void spawnThread(ThreadStart worker, String title = null)
        {
            worker += () => { threadComplete(); };
            Thread z = new Thread(worker);
            Stopwatch watch = new Stopwatch();
            watch.Start();
            try
            {
                pendingThreads.Add(z, watch);
                z.Start();
                if (mLogger != null)
                {
                    mLogger.logMessage("Thread [" + z.ManagedThreadId + "] Spawned", title);
                    mLogger.logMessage("PENDING Threads = " + pendingThreads.Count, "spawnThread");
                }
            }
            catch (Exception ex)
            {
                pendingThreads.Remove(z);
                if (mLogger != null) mLogger.logMessage(ex.Message, "ThreadStart [" + title + "] Exception");
            }
        }

        private void postRun()
        {
            gStopwatch.Stop();
            String completionStatus = "Elapsed (" + gStopwatch.Elapsed + ")";
            this.btnRunTests.Enabled = true;
            this.btnSettings.Enabled = true;
            this.btnAbout.Enabled = true;
            this.btnCancel.Enabled = false;
            if (mLogger != null) mLogger.logMessage(completionStatus, "<<< Q.E.D. >>>");
            //MessageBox.Show(completionStatus, "AddInSafetyCheck");
        }

        private void threadComplete()
        {
            Thread z = Thread.CurrentThread;
            String completionStatus = (instance.ABORT_PROCESSING ? "ABORTED" : "DONE");
            try
            {
                if (pendingThreads.ContainsKey(z))
                {
                    Stopwatch watch = pendingThreads[z];
                    if (watch != null)
                    {
                        watch.Stop();
                        String elapsedTime = "Elapsed (" + watch.Elapsed + ")";
                        completionStatus += " " + elapsedTime;
                    }
                    pendingThreads.Remove(z);
                }
            }
            catch (Exception ex)
            {
                if (mLogger != null) mLogger.logMessage(ex.Message, "ThreadComplete [" + z.ManagedThreadId + "] Exception");
            }
            if (mLogger != null)
            {
                mLogger.logMessage(completionStatus, "ThreadComplete [" + z.ManagedThreadId + "]");
                mLogger.logMessage("PENDING Threads = " + pendingThreads.Count, "threadComplete");
            }
            if (pendingThreads.Count == 0)
            {
                this.Invoke(new Action(delegate () {
                    this.postRun();
                }));
            }
        }

        private void runChecks() 
        {
            bool linearTask = !Properties.Settings.Default.opt_ThreadedProcessing;
            Thread z = Thread.CurrentThread;
            try
            {
                // always parse envelope
                if (true)
                {
                    parseEnvelope();
                }
                if (!instance.ABORT_PROCESSING && Properties.Settings.Default.test_Headers)
                {
                    parseHeaders();
                }
                // here is where we can parallelize tasks
                if (!instance.ABORT_PROCESSING && Properties.Settings.Default.test_Contacts)
                {
                    if (linearTask) testContacts();
                    else spawnThread(new ThreadStart(testContacts), "Inspecting Contacts");
                }
                if (!instance.ABORT_PROCESSING && Properties.Settings.Default.test_Routes)
                {
                    if (linearTask) testRoutes();
                    else spawnThread(new ThreadStart(testRoutes), "Inspecting Routes");
                }
                if (!instance.ABORT_PROCESSING && Properties.Settings.Default.test_Links)
                {
                    if (linearTask) testLinks();
                    else spawnThread(new ThreadStart(testLinks), "Inspecting Links");
                }
                if (!instance.ABORT_PROCESSING && Properties.Settings.Default.test_Attachments)
                {
                    if (linearTask) testAttachments();
                    else spawnThread(new ThreadStart(testAttachments), "Inspecting Attachments");
                }
                if (!instance.ABORT_PROCESSING && Properties.Settings.Default.test_Body)
                {
                    if (linearTask) testBody();
                    else spawnThread(new ThreadStart(testBody), "Inspecting Body/Contents");
                }
                String completionStatus = (instance.ABORT_PROCESSING ? "ABORTED" : "DONE");
                if (mLogger != null) mLogger.logMessage(completionStatus, "Thread [" + z.ManagedThreadId + "]");
            }
            catch (Exception ex)
            {
                if (mLogger != null) mLogger.logMessage(ex.Message, "Thread [" + z.ManagedThreadId + "] Exception");
            }
        }

        private void parseEnvelope()
        {
            if (mLogger != null) mLogger.logInfo("[" + Properties.Resources.Title_Envelope + "] ...",
                 "" + DateTime.Now + "");
            setTabVisibility(envelopeTab, true);
            instance.ParseEnvelope(Properties.Settings.Default.opt_Force_REFRESH);
        }
        private void parseHeaders()
        {
            if (mLogger != null) mLogger.logInfo("[" + Properties.Resources.Title_Headers + "] ...",
                 "" + DateTime.Now + "");
            setTabVisibility(headerTab, true);
            instance.ParseHeaders(Properties.Settings.Default.opt_Force_REFRESH);
        }
        private void testContacts()
        {
            if (mLogger != null) mLogger.logInfo("[" + Properties.Resources.Title_Contacts + "] ...",
                "" + DateTime.Now + "");
            setTabVisibility(contactTab, true);
            instance.AnalyzeContacts(Properties.Settings.Default.opt_Force_REFRESH);
        }
        private void testRoutes()
        {
            if (mLogger != null) mLogger.logInfo("[" + Properties.Resources.Title_Routing + "] ...",
                "" + DateTime.Now + "");
            setTabVisibility(routeTab, true);
            instance.AnalyzeRoutes(Properties.Settings.Default.opt_Force_REFRESH);
        }
        private void testLinks()
        {
            if (mLogger != null) mLogger.logInfo("[" + Properties.Resources.Title_Links + "] ...",
                 "" + DateTime.Now + "");
            setTabVisibility(linksTab, true);
            instance.AnalyzeLinks(Properties.Settings.Default.opt_Force_REFRESH);
        }
        private void testAttachments()
        {
            if (mLogger != null) mLogger.logInfo("[" + Properties.Resources.Title_Attachments + "] ...",
                "" + DateTime.Now + "");
            setTabVisibility(attachmentsTab, true);
            instance.AnalyzeAttachments(Properties.Settings.Default.opt_Force_REFRESH);
        }
        private void testBody()
        {
            if (mLogger != null) mLogger.logInfo("[" + Properties.Resources.Title_Body + "] ...",
                "" + DateTime.Now + "");
            setTabVisibility(bodyTab, true);
            instance.AnalyzeBody(Properties.Settings.Default.opt_Force_REFRESH);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            instance.ABORT_PROCESSING = true;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            dlgSafetyCheckConfig tDlg = new dlgSafetyCheckConfig();
            tDlg.ShowDialog();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            dlgAbout tDlg = new dlgAbout();
            tDlg.ShowDialog();
        }
    } // class
} // namespace
