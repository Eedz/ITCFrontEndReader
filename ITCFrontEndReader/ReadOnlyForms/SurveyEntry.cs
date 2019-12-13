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
    public partial class SurveyEntry : Form
    {
        public MainMenu frmParent;
        public string key;                      // unique ID for this instance
        public int index; // there will be a maximum of 3 survey entry forms
        public Survey CurrentSurvey;            // currently displayed survey
        public SurveyQuestion CurrentQuestion;  // currently displayed question
        BindingSource bs;

        // references to popup forms
       
       
        SurveyEntryBrown frmBrown;
       
        // translation
        // deleted questions

        public SurveyEntry()
        {
            InitializeComponent();
        }

        public SurveyEntry(string surveyCode)
        {

            CurrentSurvey = DBAction.GetSurveyInfo(surveyCode);
            DBAction.FillQuestions(CurrentSurvey);

            if (CurrentSurvey.Questions == null)
            {
                MessageBox.Show("Error getting " + surveyCode + "'s questions. Ensure there is at least one question in this survey.");
                Close();
            }


            InitializeComponent();

            this.MouseWheel += SurveyEntry_OnMouseWheel;
            //txtPrePR.MouseWheel += SurveyEntry_OnMouseWheel;

            bs = new BindingSource
            {
                DataSource = CurrentSurvey.Questions

            };
            bs.PositionChanged += Bs_PositionChanged;
         
            navQuestions.BindingSource = bs;            


            BindProperties();

            LockForm();

            ColorForm();


        }

        #region Events
        private void SurveyEntry_Load(object sender, EventArgs e)
        {
            CurrentQuestion = (SurveyQuestion)bs.Current;
            //bs.Position = frmParent.currentUser.positions[index]; // TODO add position property to user
        
            LoadQuestion();
        }

        protected void SurveyEntry_OnMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta == -120)
                bs.MoveNext();
            else if (e.Delta == 120)
            {
                bs.MovePrevious();
            }

        }

        /// <summary>
        /// Updates subforms to match the current record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bs_PositionChanged(object sender, EventArgs e)
        {
            CurrentQuestion = (SurveyQuestion)bs.Current;

            if (frmBrown != null)
                frmBrown.UpdateForm(CurrentQuestion.RefVarName);

           

            LoadQuestion();
        }

        private void cboGoToVar_SelectedIndexChanged(object sender, EventArgs e)
        {
            GoToQuestion(cboGoToVar.GetItemText(cboGoToVar.SelectedItem));

            cboGoToVar.SelectedValue = "";
        }
        #endregion

        #region Form Setup
        private void ColorForm()
        {
            Color temp = Color.FromArgb(0xAAC499);
            Color result = Color.FromArgb(temp.R, temp.G, temp.B);
            this.BackColor = result;
        }

        /// <summary>
        /// Bind the controls to the current survey's properties.
        /// </summary>
        private void BindProperties()
        {
            // top portion
            txtSurvey.DataBindings.Add(new Binding("Text", CurrentSurvey, "SurveyCode"));
            txtVarName.DataBindings.Add(new Binding("Text", bs, "VarName"));
            txtQnum.DataBindings.Add(new Binding("Text", bs, "Qnum"));

            // go to box
            cboGoToVar.ValueMember = "refVarName";
            cboGoToVar.DataSource = DBAction.GetAllRefVars(CurrentSurvey.SurveyCode);
            cboGoToVar.DisplayMember = "refVarName";
            cboGoToVar.SelectedValue = "";


            // labels

            // fill 

            cboDomainLabel.DataSource = DBAction.ListDomainLabels();
            cboDomainLabel.ValueMember = "ID";
            cboDomainLabel.DisplayMember = "LabelText";

            cboTopicLabel.DataSource = DBAction.GetTopicLabels();
            cboTopicLabel.ValueMember = "ID";
            cboTopicLabel.DisplayMember = "LabelText";

            cboContentLabel.DataSource = DBAction.GetContentLabels();
            cboContentLabel.ValueMember = "ID";
            cboContentLabel.DisplayMember = "LabelText";

            cboProductLabel.DataSource = DBAction.GetProductLabels();
            cboProductLabel.ValueMember = "ID";
            cboProductLabel.DisplayMember = "LabelText";

            // bind
            txtVarLabel.DataBindings.Add("Text", bs, "VarLabel");
            cboDomainLabel.DataBindings.Add("SelectedValue", bs, "Domain.ID");
            cboTopicLabel.DataBindings.Add("SelectedValue", bs, "Topic.ID");
            cboContentLabel.DataBindings.Add("SelectedValue", bs, "Content.ID");
            cboProductLabel.DataBindings.Add("SelectedValue", bs, "Product.ID");

            // field info
            chkTableFormat.DataBindings.Add("Checked", bs, "TableFormat");
            chkScriptOnly.DataBindings.Add("Checked", bs, "ScriptOnly");
            txtVarType.DataBindings.Add("Text", bs, "VarType");
            numDec.DataBindings.Add("Value", bs, "NumDec");
            numCols.DataBindings.Add("Value", bs, "NumCol");

            
        }

        /// <summary>
        /// Binds the wording number boxes' ReadOnly attribute to the Current Survey's locked attribute
        /// </summary>
        private void LockForm()
        {
            
        }
        #endregion

        #region Menu - Functions
        private void filterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SurveyEntryFilter frmFilter = new SurveyEntryFilter();
            frmFilter.frmParent = this;
            frmFilter.ShowDialog();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // search wordings with clipboard
            SearchWordings();
        }

        #endregion

        #region Menu - Go To
        private void iSISSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {

            QuestionSearch frm = new QuestionSearch();
            frm.frmParent = this.frmParent;
            frm.key = "QuestionSearch";
            frmParent.AddTab(frm, "QuestionSearch", "QuestionSearch");
            // TODO fill in VarName
        }

        private void numberingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SurveyNumbering frm = new SurveyNumbering(CurrentSurvey.SurveyCode);
            frm.frmParent = this.frmParent;
            frm.key = "Numbering";
            frmParent.AddTab(frm, "Numbering", "Numbering");
        }

        private void harmonyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        
        #endregion

        #region Menu - View 
        private void translationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TranslationViewer frm = new TranslationViewer(CurrentQuestion.ID);
            frm.Show();
        }
        private void relatedQuestionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmBrown != null)
            {
                frmBrown.Close();
            }

            frmBrown = new SurveyEntryBrown(CurrentQuestion.RefVarName, frmParent.currentUser.SurveyEntryBrown[index - 1]);
            frmBrown.frmParent = this;
            frmBrown.Left = this.Left + 600;
            frmBrown.Top = this.Top + 100;
            frmBrown.TopLevel = true;
            frmBrown.TopMost = true;
            frmBrown.BringToFront();
            frmBrown.Show();
        }
        #endregion

        #region Menu - Toggle Fields

        private void labelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelLabels.Visible = !panelLabels.Visible;
        }
        #endregion

        #region Menu - Export
        private void questionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportToolStripMenuItem.ShowDropDown();
        }

        private void translationsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            exportToolStripMenuItem.ShowDropDown();
        }

        private void exportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // check which are checked
            bool q = questionToolStripMenuItem.Checked;
            bool t = translationsToolStripMenuItem1.Checked;

            SurveyReport sr = new SurveyReport();
            sr.AddSurvey(new ReportSurvey(CurrentSurvey.SurveyCode));
            sr.Surveys[0].AddQuestion(CurrentQuestion);
            if (t)
            {
                sr.Surveys[0].Questions[0].Translations.AddRange(DBAction.GetQuestionTranslations(sr.Surveys[0].Questions[0].ID));
                sr.Surveys[0].TransFields.AddRange(DBAction.GetLanguages(CurrentSurvey));
            }

            sr.FileName = "\\\\psychfile\\psych$\\psych-lab-gfong\\SMG\\Access\\Reports\\ISR\\" + "Survey Entry Export - " + DateTime.Today.ToString("d").Replace("-", "");
            sr.GenerateReport();

            sr.OutputReportTableXML();
            // TODO export items if each type is checked
        }
        #endregion

        private void cmdToggleFieldInfo_Click(object sender, EventArgs e)
        {
            panelFieldInfo.Visible = !panelFieldInfo.Visible;
            if (cmdToggleFieldInfo.Text == "v")
                cmdToggleFieldInfo.Text = "^";
            else
                cmdToggleFieldInfo.Text = "v";
        }

        #region Methods

        public void ChangeSurvey(string newSurvey)
        {
            CurrentSurvey = null;
            CurrentSurvey = DBAction.GetSurveyInfo(newSurvey);
            DBAction.FillQuestions(CurrentSurvey);

            bs.DataSource = CurrentSurvey.Questions;
            txtSurvey.DataBindings.Clear();
            txtSurvey.DataBindings.Add("Text", CurrentSurvey, "SurveyCode");

            CurrentQuestion = (SurveyQuestion)bs.Current;

            LockForm();
        }

        public void LoadQuestion()
        {
            rtbQuestionText.Rtf = "";
            rtbQuestionText.Rtf = CurrentQuestion.GetQuestionTextRich();
          // TODO incorporate color into LitQ @"{\colortbl;\red0\green0\blue255;}" 
        }

        private void MoveRecord(int count)
        {

            if (count > 0)
                for (int i = 0; i < count; i++)
                {
                    bs.MoveNext();
                }
            else
                for (int i = 0; i < Math.Abs(count); i++)
                {
                    bs.MovePrevious();
                }
        }

        private void GoToQuestion(string refVarName)
        {
            int index = 0;
            int currentIndex = bs.Position;
            bool found = false;
            foreach (SurveyQuestion sq in CurrentSurvey.Questions)
            {
                if (sq.RefVarName == refVarName)
                {
                    found = true;
                    break;
                }
                else
                {
                    index++;
                }
            }

            if (found) bs.Position = index;
        }

        private void GoToQnum(string qnum)
        {
            int index = 0;
            int currentIndex = bs.Position;
            bool found = false;
            foreach (SurveyQuestion sq in CurrentSurvey.Questions)
            {
                if (sq.Qnum == qnum)
                {
                    found = true;
                    break;
                }
                else
                {
                    index++;
                }
            }

            if (found) bs.Position = index;
        }

        // TODO test
        private void SearchWordings()
        {
            string searchTerm = Clipboard.GetText();
            // search the current list of questions
        }

       

        /// <summary>
        /// Close any popup forms that were opened by this form. Then close this form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseForm(object sender, EventArgs e)
        {
            if (frmBrown != null) frmBrown.Close();
            Close();
        }

        /// <summary>
        /// Save the survey and position for the current user. Close the tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SurveyEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            DBAction.SaveSession("frm" + this.Name + index, CurrentSurvey.SurveyCode, bs.Position, frmParent.currentUser);
              
            frmParent.CloseTab(key);
        }



        #endregion

        
    }
}
