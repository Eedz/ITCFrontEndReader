namespace ITCFrontEndReader
{
    partial class SurveyNumbering
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSurvey = new System.Windows.Forms.ComboBox();
            this.lstReport = new System.Windows.Forms.ListView();
            this.OldQ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AltQnum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VarName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VarLabel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RespName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TableFormat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Corrected = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.formToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reLoadSurveyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.surveyEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputDisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.questionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.translationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.questionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.translationsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdShowComments = new System.Windows.Forms.Button();
            this.cmdShowQuestion = new System.Windows.Forms.Button();
            this.cmdShowAltQnum = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(756, 27);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(27, 28);
            this.cmdClose.TabIndex = 10;
            this.cmdClose.Text = "X";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(250, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 31);
            this.label1.TabIndex = 9;
            this.label1.Text = "Survey Numbering";
            // 
            // cboSurvey
            // 
            this.cboSurvey.FormattingEnabled = true;
            this.cboSurvey.Location = new System.Drawing.Point(63, 12);
            this.cboSurvey.Name = "cboSurvey";
            this.cboSurvey.Size = new System.Drawing.Size(77, 21);
            this.cboSurvey.TabIndex = 7;
            // 
            // lstReport
            // 
            this.lstReport.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.OldQ,
            this.AltQnum,
            this.VarName,
            this.VarLabel,
            this.RespName,
            this.TableFormat,
            this.Corrected});
            this.lstReport.FullRowSelect = true;
            this.lstReport.Location = new System.Drawing.Point(12, 161);
            this.lstReport.Name = "lstReport";
            this.lstReport.Size = new System.Drawing.Size(733, 478);
            this.lstReport.TabIndex = 6;
            this.lstReport.UseCompatibleStateImageBehavior = false;
            this.lstReport.View = System.Windows.Forms.View.List;
            // 
            // OldQ
            // 
            this.OldQ.Text = "Old Q#";
            // 
            // AltQnum
            // 
            this.AltQnum.Text = "AltQnum";
            this.AltQnum.Width = 0;
            // 
            // VarName
            // 
            this.VarName.Text = "VarName";
            // 
            // VarLabel
            // 
            this.VarLabel.Text = "VarLabel";
            this.VarLabel.Width = 240;
            // 
            // RespName
            // 
            this.RespName.Text = "RespName";
            // 
            // TableFormat
            // 
            this.TableFormat.Text = "TableFormat";
            // 
            // Corrected
            // 
            this.Corrected.Text = "Corrected";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formToolStripMenuItem,
            this.goToToolStripMenuItem,
            this.outputDisplayToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(795, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // formToolStripMenuItem
            // 
            this.formToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reLoadSurveyToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.formToolStripMenuItem.Name = "formToolStripMenuItem";
            this.formToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.formToolStripMenuItem.Text = "Form";
            // 
            // reLoadSurveyToolStripMenuItem
            // 
            this.reLoadSurveyToolStripMenuItem.Name = "reLoadSurveyToolStripMenuItem";
            this.reLoadSurveyToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.reLoadSurveyToolStripMenuItem.Text = "Re-Load Survey";
            this.reLoadSurveyToolStripMenuItem.Click += new System.EventHandler(this.reLoadSurveyToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // goToToolStripMenuItem
            // 
            this.goToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.surveyEntryToolStripMenuItem});
            this.goToToolStripMenuItem.Name = "goToToolStripMenuItem";
            this.goToToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.goToToolStripMenuItem.Text = "Go To";
            // 
            // surveyEntryToolStripMenuItem
            // 
            this.surveyEntryToolStripMenuItem.Name = "surveyEntryToolStripMenuItem";
            this.surveyEntryToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.surveyEntryToolStripMenuItem.Text = "Survey Entry";
            this.surveyEntryToolStripMenuItem.Click += new System.EventHandler(this.surveyEntryToolStripMenuItem_Click);
            // 
            // outputDisplayToolStripMenuItem
            // 
            this.outputDisplayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.questionsToolStripMenuItem,
            this.commentsToolStripMenuItem,
            this.translationsToolStripMenuItem});
            this.outputDisplayToolStripMenuItem.Name = "outputDisplayToolStripMenuItem";
            this.outputDisplayToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.outputDisplayToolStripMenuItem.Text = "View";
            // 
            // questionsToolStripMenuItem
            // 
            this.questionsToolStripMenuItem.CheckOnClick = true;
            this.questionsToolStripMenuItem.Name = "questionsToolStripMenuItem";
            this.questionsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.questionsToolStripMenuItem.Text = "Questions";
            this.questionsToolStripMenuItem.Click += new System.EventHandler(this.questionsToolStripMenuItem_Click);
            // 
            // commentsToolStripMenuItem
            // 
            this.commentsToolStripMenuItem.Name = "commentsToolStripMenuItem";
            this.commentsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.commentsToolStripMenuItem.Text = "Comments";
            this.commentsToolStripMenuItem.Click += new System.EventHandler(this.commentsToolStripMenuItem_Click);
            // 
            // translationsToolStripMenuItem
            // 
            this.translationsToolStripMenuItem.Name = "translationsToolStripMenuItem";
            this.translationsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.translationsToolStripMenuItem.Text = "Translations";
            this.translationsToolStripMenuItem.Click += new System.EventHandler(this.translationsToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.questionsToolStripMenuItem1,
            this.translationsToolStripMenuItem1,
            this.toolStripSeparator1,
            this.exportToolStripMenuItem1});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // questionsToolStripMenuItem1
            // 
            this.questionsToolStripMenuItem1.Checked = true;
            this.questionsToolStripMenuItem1.CheckOnClick = true;
            this.questionsToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.questionsToolStripMenuItem1.Name = "questionsToolStripMenuItem1";
            this.questionsToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.questionsToolStripMenuItem1.Text = "Questions";
            this.questionsToolStripMenuItem1.Click += new System.EventHandler(this.questionsToolStripMenuItem1_Click);
            // 
            // translationsToolStripMenuItem1
            // 
            this.translationsToolStripMenuItem1.CheckOnClick = true;
            this.translationsToolStripMenuItem1.Name = "translationsToolStripMenuItem1";
            this.translationsToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.translationsToolStripMenuItem1.Text = "Translations";
            this.translationsToolStripMenuItem1.Click += new System.EventHandler(this.translationsToolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // exportToolStripMenuItem1
            // 
            this.exportToolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.exportToolStripMenuItem1.Name = "exportToolStripMenuItem1";
            this.exportToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.exportToolStripMenuItem1.Text = "Export...";
            this.exportToolStripMenuItem1.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // cmdShowComments
            // 
            this.cmdShowComments.Location = new System.Drawing.Point(20, 39);
            this.cmdShowComments.Name = "cmdShowComments";
            this.cmdShowComments.Size = new System.Drawing.Size(120, 23);
            this.cmdShowComments.TabIndex = 13;
            this.cmdShowComments.Text = "View Comments";
            this.cmdShowComments.UseVisualStyleBackColor = true;
            this.cmdShowComments.Click += new System.EventHandler(this.cmdShowComments_Click);
            // 
            // cmdShowQuestion
            // 
            this.cmdShowQuestion.Location = new System.Drawing.Point(20, 68);
            this.cmdShowQuestion.Name = "cmdShowQuestion";
            this.cmdShowQuestion.Size = new System.Drawing.Size(120, 23);
            this.cmdShowQuestion.TabIndex = 14;
            this.cmdShowQuestion.Text = "View Question";
            this.cmdShowQuestion.UseVisualStyleBackColor = true;
            this.cmdShowQuestion.Click += new System.EventHandler(this.cmdShowQuestion_Click);
            // 
            // cmdShowAltQnum
            // 
            this.cmdShowAltQnum.Location = new System.Drawing.Point(22, 97);
            this.cmdShowAltQnum.Name = "cmdShowAltQnum";
            this.cmdShowAltQnum.Size = new System.Drawing.Size(118, 23);
            this.cmdShowAltQnum.TabIndex = 15;
            this.cmdShowAltQnum.Text = "Show AltQnum";
            this.cmdShowAltQnum.UseVisualStyleBackColor = true;
            this.cmdShowAltQnum.Click += new System.EventHandler(this.cmdShowAltQnum_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Survey";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmdShowAltQnum);
            this.panel1.Controls.Add(this.cmdShowQuestion);
            this.panel1.Controls.Add(this.cmdShowComments);
            this.panel1.Controls.Add(this.cboSurvey);
            this.panel1.Location = new System.Drawing.Point(592, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(153, 131);
            this.panel1.TabIndex = 17;
            // 
            // SurveyNumbering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(185)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(795, 668);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstReport);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SurveyNumbering";
            this.Text = "SurveyNumbering";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SurveyNumbering_FormClosed);
            this.Load += new System.EventHandler(this.SurveyNumbering_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSurvey;
        private System.Windows.Forms.ListView lstReport;
        private System.Windows.Forms.ColumnHeader OldQ;
        private System.Windows.Forms.ColumnHeader AltQnum;
        private System.Windows.Forms.ColumnHeader VarName;
        private System.Windows.Forms.ColumnHeader VarLabel;
        private System.Windows.Forms.ColumnHeader RespName;
        private System.Windows.Forms.ColumnHeader TableFormat;
        private System.Windows.Forms.ColumnHeader Corrected;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem formToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reLoadSurveyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem surveyEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outputDisplayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem questionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem translationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem questionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem translationsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button cmdShowComments;
        private System.Windows.Forms.Button cmdShowQuestion;
        private System.Windows.Forms.Button cmdShowAltQnum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
    }
}