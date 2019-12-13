using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITCFrontEndReader
{
    public partial class QuestionSearch : Form
    {
        enum SearchType { QuickSearch, AdvancedSearch }
        enum OutputTarget { Screen, Document }
        enum VarNameSearchType { VarName, refVarName }

        public MainMenu frmParent;
        public string key;                      // unique ID for this instance

        VarNameSearchType varSearchType;

        public QuestionSearch()
        {
            InitializeComponent();
        }

        private void QuestionSearch_Load(object sender, EventArgs e)
        {
            varSearchType = VarNameSearchType.refVarName;

            for (int i = 0; i< lstFieldsToShow.Items.Count; i ++)
            {
                switch (lstFieldsToShow.Items[i].ToString())
                {
                    case "refVarName":
                    case "PreA":
                    case "LitQ":
                    case "RespOptions":
                        lstFieldsToShow.SelectedIndices.Add(i);
                        break;
                    
                }
            }

            UpdateSortableFields();
            lstFieldsToShow.SelectedIndexChanged += FieldToShowChanged_SelectedIndexChanged;
        }

        private void FieldToShowChanged_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSortableFields();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                SearchQuestions(SearchType.QuickSearch, OutputTarget.Screen);
            }
        }



        private void SearchQuestions (SearchType searchType, OutputTarget outputTarget)
        {
            string where = "", wherenot;
            string generalwhere, globalwhere, exclusions;
            string excludeHidden;
            bool showTranslation;

            // gather search criteria
            excludeHidden = "NOT Survey IN (SELECT Survey FROM qrySurveyInfo WHERE HideSurvey = True)";

            switch (searchType) { 
                case SearchType.QuickSearch:
                    // get survey/var filter
                    where = GetSVCriteria();
                    // get general criteria

                    // get exclusions

                    // get global criteria

                    // toggle translations

                    // complete criteria

                break;
                case SearchType.AdvancedSearch:
                    // get criteria 

                    // toggle translation
                break;
            }

            where += " AND " + excludeHidden;
            where = ITCLib.Utilities.TrimString(where, " AND ");

            if (where.Equals(excludeHidden))
            {
                MessageBox.Show("No search criteria specified.");
                return;
            }

            // output to target

            switch (outputTarget)
            {
                case OutputTarget.Document:

                    break;
                case OutputTarget.Screen:
                    break;
            }

        }

        private string GetSVCriteria()
        {
            string strVarName = "";
            string strSurvey = "";
            string crit = "";

            // survey
            if (!string.IsNullOrEmpty(txtSurvey.Text))
            {
                string txt = txtSurvey.Text.Replace(" ", "");
                var items = txt.Split(new char[] { ',' });

                strSurvey = "(Survey LIKE '*" + string.Join("*' OR Survey Like '*", items) + "*')";
            }

            // varname
            if (!string.IsNullOrEmpty(txtVarName.Text))
            {
                string txt = txtVarName.Text.Replace(" ", "");
                var items = txt.Split(new char[] { ',' });

                if (varSearchType == VarNameSearchType.VarName)
                    strVarName = " AND (VarName LIKE '" + string.Join("*' OR VarName Like '*", items) + "*')";
                else 
                    strVarName = " AND (refVarName LIKE '" + string.Join("*' OR refVarName Like '*", items) + "*')";
            }

            crit = strSurvey + strVarName;
            crit = ITCLib.Utilities.TrimString(crit, " AND ");
            return crit;
        }

        private string GetGeneralCriteria()
        {
            string crit = "";

            string where = "";
            string qnumLow, qnumHigh;
            string altQnum;

            string[] ROs, NRs;
            string Qnum, PreP, PreI, PreA, LitQ, PstI, PstP;
            string VarLabel, Domain, Topic, COntent, Product;
            string Translation;
            string Keyword;

            // qnum (TODO SEPARATE SUB)
            if (!string.IsNullOrEmpty(txtQnum.Text))
            {
                string txt = txtQnum.Text;
                if (txt.IndexOf('-') >= 0)
                {
                    qnumLow = txt.Substring(0, txt.IndexOf('-'));
                    qnumHigh = txt.Substring(txt.IndexOf('-')+1);
                    if (Int32.Parse(qnumLow) > Int32.Parse(qnumHigh))
                    {
                        MessageBox.Show("Qnum Range Error.");
                        return "";
                    }
                    else
                    {
                        Qnum = " AND Qnum BETWEEN '" + qnumLow + "' AND '" + qnumHigh + "'";
                    }
                }
                else
                {
                    Qnum = " AND Qnum Like '*" + txt + "*'";
                }
            }



            return crit;
        }

        private void UpdateSortableFields()
        {
            bool qAdded = false;
            lstColOrder.Items.Clear();
            lstSortBy.Items.Clear();
            for (int i = 0; i < lstFieldsToShow.SelectedIndices.Count; i ++)
            {
                int index = lstFieldsToShow.SelectedIndices[i];
                string item = lstFieldsToShow.Items[index].ToString();

                switch (item)
                {
                    case "refVarName":
                    case "VarName":
                    case "Survey":
                    case "VarLabel":
                    case "Qnum":
                    case "AltQnum":
                    case "Topic":
                    case "Content":
                        lstSortBy.Items.Add(item);
                        lstColOrder.Items.Add(item);
                        break;
                    case "Translation":
                        lstColOrder.Items.Add(item);
                        break;
                    case "PreP":
                    case "PreI":
                    case "PreA":
                    case "LitQ":
                    case "PstI":
                    case "PstP":
                    case "RespOptions":
                    case "NRCodes":
                        if (!qAdded)
                        {
                            lstColOrder.Items.Add("Question");
                            qAdded = true; 
                        }
                        break;
                }
            }
        }

        #region Control Box


        private void cmdClear_Click(object sender, EventArgs e)
        {
            // clear quick search

            // clear Survey/VarName panel
            txtSurvey.Text = "";
            txtVarName.Text = "";

            // clear general fields
            foreach (Control c in panelGeneral.Controls)
            {
                if (c is TextBox)
                    c.Text = "";
            }
            cboProduct.SelectedItem = null;

            // clear global fields
            txtGlobalCriteria.Text = "";
            lstGlobalFields.SelectedIndex = -1;

            // clear exlcusions
            dgvExclusions.Rows.Clear();

            // clear advanced
            //dgvAdvancedSearch.Clear();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        private void QuestionSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmParent.CloseTab(key);
        }

        private void cmdColUp_Click(object sender, EventArgs e)
        {
            if (lstColOrder.SelectedItem == null) return;

            if (lstColOrder.SelectedIndex == 0) return;

            string item = lstColOrder.SelectedItem.ToString();
            int sel = lstColOrder.SelectedIndex;
            lstColOrder.Items.RemoveAt(sel);
            lstColOrder.Items.Insert(sel - 1, item);
            lstColOrder.SelectedIndex = sel - 1;
        }

        private void cmdColDown_Click(object sender, EventArgs e)
        {
            if (lstColOrder.SelectedItem == null) return;

            if (lstColOrder.SelectedIndex == lstColOrder.Items.Count -1) return;

            string item = lstColOrder.SelectedItem.ToString();
            int sel = lstColOrder.SelectedIndex;
            lstColOrder.Items.RemoveAt(sel);
            lstColOrder.Items.Insert(sel + 1, item);
            lstColOrder.SelectedIndex = sel + 1;
        }

        private void cmdSortUp_Click(object sender, EventArgs e)
        {
            if (lstSortBy.SelectedItem == null) return;

            if (lstSortBy.SelectedIndex == 0) return;

            string item = lstSortBy.SelectedItem.ToString();
            int sel = lstSortBy.SelectedIndex;
            lstSortBy.Items.RemoveAt(sel);
            lstSortBy.Items.Insert(sel - 1, item);
            lstSortBy.SelectedIndex = sel - 1;
        }

        private void cmdSortDown_Click(object sender, EventArgs e)
        {
            if (lstSortBy.SelectedItem == null) return;

            if (lstSortBy.SelectedIndex == lstSortBy.Items.Count - 1) return;

            string item = lstSortBy.SelectedItem.ToString();
            int sel = lstSortBy.SelectedIndex;
            lstSortBy.Items.RemoveAt(sel);
            lstSortBy.Items.Insert(sel + 1, item);
            lstSortBy.SelectedIndex = sel + 1;
        }

        private void chkGlobalSearch_CheckedChanged(object sender, EventArgs e)
        {
            cmdClearGlobal.Visible = chkGlobalSearch.Checked;
            panelGlobal.Visible = chkGlobalSearch.Checked;
        }
    }
}
