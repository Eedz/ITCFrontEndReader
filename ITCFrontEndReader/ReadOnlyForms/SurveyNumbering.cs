using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using ITCLib;

namespace ITCFrontEndReader
{
    enum QuestionType { Series, Standalone, Heading, InterviewerNote, Subheading }

    public partial class SurveyNumbering : Form
    {
        public MainMenu frmParent;
        public string key;

        Survey CurrentSurvey { get; set; }

        bool ShowCorrected { get; set; }

        public SurveyNumbering()
        {
            InitializeComponent();
        }

        public SurveyNumbering(string surveyCode)
        {
            InitializeComponent();
            CurrentSurvey = DBAction.GetSurveyInfo(surveyCode);
            
            LoadSurvey();
        }

        private void SurveyNumbering_Load(object sender, EventArgs e)
        {
            

            
            cboSurvey.DataSource = DBAction.GetAllSurveys();
            cboSurvey.ValueMember = "SurveyCode";
            cboSurvey.DisplayMember = "SurveyCode";

            cboSurvey.SelectedItem = null;

            cboSurvey.SelectedIndexChanged += SurveyChanged;
            ColorForm();

        }

        private void ColorForm()
        {
            Color temp = Color.FromArgb(0xADC0D9);
            Color result = Color.FromArgb(temp.R, temp.G, temp.B);
            this.BackColor = result;
        }

        private void SurveyChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboSurvey.GetItemText(cboSurvey.SelectedItem))) return;

            CurrentSurvey = DBAction.GetSurveyInfo(cboSurvey.GetItemText(cboSurvey.SelectedItem));
            LoadSurvey();

        }

        private void LoadSurvey()
        {
            if (CurrentSurvey == null) return;

            DBAction.FillQuestions(CurrentSurvey, true);
            lstReport.Items.Clear();
            lstReport.View = View.Details;

            foreach (SurveyQuestion sq in CurrentSurvey.Questions)
            {
                ListViewItem li = new ListViewItem(new string[] { sq.Qnum, sq.AltQnum, sq.VarName, sq.VarLabel, sq.RespName, sq.CorrectedFlag.ToString(), sq.TableFormat.ToString() });
                li.Tag = sq;
                lstReport.Items.Add(li);
                FormatListItem(li, GetQuestionType(li));
            }
        }

        #region Form Menu
        private void reLoadSurveyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadSurvey();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lstReport.Items.Clear();
            cboSurvey.SelectedItem = null;
        }
        #endregion

        #region Go To Menu

        // TODO filter currently open form or close and open a new one?
        private void surveyEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentSurvey == null)
                return;


            if (frmParent.GetTab("Survey Entry") == null)
            {
                SurveyEntry frm = new SurveyEntry(CurrentSurvey.SurveyCode);
                frmParent.AddTab(frm, "Survey Entry", "SurveyEntry");
            }
            else
            {
                SurveyEntry frm = (SurveyEntry)frmParent.GetTab("Survey Entry").Controls["Survey Entry"];
                
                frmParent.FocusTab("Survey Entry");
            }
        }
        #endregion

        #region View Menu

        private void questionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO open question viewer
        }

        private void commentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO open comment viewer
        }

        private void translationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO open translation viewer
        }
        #endregion

        #region Export Menu

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // check which are checked
            bool q = questionsToolStripMenuItem1.Checked;
            bool t = translationsToolStripMenuItem1.Checked;
            // TODO export items if each type is checked
        }

        private void questionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            exportToolStripMenuItem.ShowDropDown();
        }

        private void translationsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            exportToolStripMenuItem.ShowDropDown();
        }
        #endregion

        private void cmdShowComments_Click(object sender, EventArgs e)
        {
            // TODO open comment viewer
        }

        private void cmdShowQuestion_Click(object sender, EventArgs e)
        {
            // TODO open question viewer
        }

        private void cmdShowAltQnum_Click(object sender, EventArgs e)
        {
            if (lstReport.Columns[1].Width == 0)
            {
                lstReport.Columns[1].Width = 60;
                cmdShowAltQnum.Text = "Hide AltQnum";
            }
            else
            {
                lstReport.Columns[1].Width = 0;
                cmdShowAltQnum.Text = "Show AltQnum";
            }
        }

        

        /// <summary>
        /// Determines the type of questions for the given row.
        /// </summary>
        /// <param name="row"></param>
        /// <returns>QuestionType enum based on the Qnum and VarName.</returns>
        private QuestionType GetQuestionType(ListViewItem row)
        {
            string qnum = row.Text;
            string varname = row.SubItems[2].Text;

            int head = Int32.Parse(Utilities.GetSeriesQnum(qnum));
            string tail = Utilities.GetQnumSuffix(qnum);

            QuestionType qType;

            // get Question Type
            if (varname.StartsWith("Z"))
            {
                if (varname.EndsWith("s"))
                    qType = QuestionType.Subheading; // subheading
                else
                    qType = QuestionType.Heading; // heading
            }
            else if (varname.StartsWith("HG"))
            {
                qType = QuestionType.Standalone; // QuestionType.InterviewerNote; // interviewer note
            }
            else
            {
                if ((tail == "" || tail == "a") && (head != 0))
                    qType = QuestionType.Standalone; // standalone or first in series
                else
                    qType = QuestionType.Series; // series
            }
            return qType;
        }

        /// <summary>
        /// Adds color and formatting to the specified row, based on its QuestionType.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="questionType"></param>
        private void FormatListItem(ListViewItem row, QuestionType questionType)
        {
            // color row based on type
            row.UseItemStyleForSubItems = true;
            row.Tag = questionType;


            switch (questionType)
            {
                case QuestionType.Series:
                    row.ForeColor = Color.Black;
                    break;
                case QuestionType.Standalone:
                    row.ForeColor = Color.Blue;
                    row.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                    break;

                case QuestionType.Heading:
                    row.ForeColor = Color.Magenta;
                    row.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                    break;
                case QuestionType.InterviewerNote:
                    row.ForeColor = Color.Lime;
                    row.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                    break;
                case QuestionType.Subheading:
                    row.ForeColor = Color.LightBlue;
                    row.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                    break;

            }

            if (ShowCorrected)
                if (row.SubItems[8].ToString() == "True")
                    row.ForeColor = Color.Maroon;
        }

      

        private void SurveyNumbering_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmParent.CloseTab(key);
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();

        }
    }
}
