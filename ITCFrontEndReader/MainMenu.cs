using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITCLib;

namespace ITCFrontEndReader
{
    public partial class MainMenu : Form
    {
        public UserPrefs currentUser;
        public MainMenu()
        {
            InitializeComponent();
            currentUser = DBAction.GetUser(Environment.UserName);
            DBAction.FillUserSurveyFilters(currentUser);
        }


        private void cmdOpenSurveyEntry_Click(object sender, EventArgs e)
        {
            if (GetTab("Survey Entry") != null)
            {
                tabControl1.SelectTab("Survey Entry");
                return;
            }
            string surveyFilter = currentUser.SurveyEntryCodes[0];
            SurveyEntry frm = new SurveyEntry(surveyFilter);
            frm.frmParent = this;
            frm.key = "Survey Entry";
            frm.index = 1;

            try
            {
                AddTab(frm, "Survey Entry", "Survey Entry");
                tabControl1.TabPages[frm.key].Text = "Entry - " + surveyFilter;
            }
            catch
            {

            }

        }

        private void cmdOpenNumbering_Click(object sender, EventArgs e)
        {
            if (GetTab("Numbering") != null)
            {
                tabControl1.SelectTab("Numbering");
                return;
            }
           
            SurveyNumbering frm = new SurveyNumbering();
            frm.frmParent = this;
            frm.key = "Numbering";
         

            try
            {
                AddTab(frm, "Numbering", "Numbering");
                
            }
            catch
            {

            }
        }

        #region Tab-related methods
        /// <summary>
        /// Adds a new tab to the main tab control and adds the provided form to the tab.
        /// </summary>
        /// <param name="frm"></param>
        public void AddTab(Form frm, string key, string name)
        {

            frm.BringToFront();
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();

            tabControl1.TabPages.Add(key, name);
            tabControl1.TabPages[key].Controls.Add(frm);
            tabControl1.SelectTab(key);
        }

        public TabPage GetTab(string key)
        {
            return tabControl1.TabPages[key];
        }

        public void FocusTab(string key)
        {
            
            tabControl1.SelectedTab = tabControl1.TabPages[key];
        }

        /// <summary>
        /// Removes the specified tab from the main tab control.
        /// </summary>
        /// <param name="key"></param>
        public void CloseTab(string key)
        {
            tabControl1.TabPages.Remove(tabControl1.TabPages[key]);
        }

        #endregion

        
    }
}
