using CheccoSafetyTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutlookSafetyChex.Forms
{

    public partial class templateOptionList : Form
    {
        readonly String[] arrSuggested; // baseline suggestions
        readonly String[] arrAvailable; // all possible options
        readonly String[] origSelected; // original selections

        public templateOptionList(String title, 
                                    String[] tAvailable, 
                                    String[] tSelected, 
                                    String[] tDefaults = null)
        {
            InitializeComponent();
            this.Text = title;
            this.arrAvailable = tAvailable;
            this.origSelected = tSelected;
            this.arrSuggested = tDefaults;
            this.listBoxAvailable.Items.Clear();
            this.listBoxAvailable.Items.AddRange(tAvailable);
            this.listBoxSelected.Items.Clear();
            this.listBoxSelected.Items.AddRange(tSelected);
            btnSuggested.Visible = cst_Util.isValidArray(this.arrSuggested);
        }

        private void addAll_Click(object sender, EventArgs e)
        {
            this.listBoxSelected.Items.Clear();
            this.listBoxSelected.Items.AddRange(this.listBoxAvailable.Items);
        }

        private void removeAll_Click(object sender, EventArgs e)
        {
            this.listBoxSelected.Items.Clear();
        }

        private void addSelected_Click(object sender, EventArgs e)
        {
            String[] tArray = listBoxAvailable.SelectedItems.Cast<String>().ToArray();
            foreach ( String t in tArray )
            {
                if ( !listBoxSelected.Items.Contains(t) ) listBoxSelected.Items.Add(t);
            }
        }

        private void removeSelected_Click(object sender, EventArgs e)
        {
            String[] tArray = listBoxSelected.SelectedItems.Cast<String>().ToArray();
            foreach (String t in tArray)
            {
                // if ( !listBoxAvailable.Items.Contains(t) ) listBoxAvailable.Items.Add(t);
                listBoxSelected.Items.Remove(t);
            }
        }

        private void addNew_Click(object sender, EventArgs e)
        {
            if ( cst_Util.isValidString(this.textInputNew.Text) )
            {
                String t = this.textInputNew.Text.Trim();
                if (!listBoxSelected.Items.Contains(t)) listBoxSelected.Items.Add(t);
                if (!listBoxAvailable.Items.Contains(t)) listBoxAvailable.Items.Add(t);
            }
        }

        private void btnRevert_Click(object sender, EventArgs e)
        {
            this.listBoxAvailable.Items.Clear();
            this.listBoxAvailable.Items.AddRange(this.arrAvailable);
            this.listBoxSelected.Items.Clear();
            this.listBoxSelected.Items.AddRange(this.origSelected);
        }

        private void btnSuggested_Click(object sender, EventArgs e)
        {
            this.listBoxSelected.Items.Clear();
            this.listBoxSelected.Items.AddRange(this.arrSuggested);
        }
    }
}
