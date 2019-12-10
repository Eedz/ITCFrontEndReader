namespace ITCFrontEndReader
{
    partial class SurveyEntryFilter
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdClear = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdApply = new System.Windows.Forms.Button();
            this.cmdAddBrown = new System.Windows.Forms.Button();
            this.cboSurveys = new System.Windows.Forms.ComboBox();
            this.txtBrown = new System.Windows.Forms.TextBox();
            this.cboMain = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Brown Survey";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Main Survey";
            // 
            // cmdClear
            // 
            this.cmdClear.Location = new System.Drawing.Point(156, 75);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(46, 26);
            this.cmdClear.TabIndex = 21;
            this.cmdClear.Text = "Clear";
            this.cmdClear.UseVisualStyleBackColor = true;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(91, 75);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(59, 26);
            this.cmdCancel.TabIndex = 20;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdApply
            // 
            this.cmdApply.Location = new System.Drawing.Point(5, 75);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(80, 25);
            this.cmdApply.TabIndex = 19;
            this.cmdApply.Text = "Apply";
            this.cmdApply.UseVisualStyleBackColor = true;
            // 
            // cmdAddBrown
            // 
            this.cmdAddBrown.Location = new System.Drawing.Point(217, 43);
            this.cmdAddBrown.Name = "cmdAddBrown";
            this.cmdAddBrown.Size = new System.Drawing.Size(28, 20);
            this.cmdAddBrown.TabIndex = 17;
            this.cmdAddBrown.Text = "<";
            this.cmdAddBrown.UseVisualStyleBackColor = true;
            // 
            // cboSurveys
            // 
            this.cboSurveys.FormattingEnabled = true;
            this.cboSurveys.Location = new System.Drawing.Point(255, 42);
            this.cboSurveys.Name = "cboSurveys";
            this.cboSurveys.Size = new System.Drawing.Size(121, 21);
            this.cboSurveys.TabIndex = 16;
            // 
            // txtBrown
            // 
            this.txtBrown.Location = new System.Drawing.Point(91, 43);
            this.txtBrown.Name = "txtBrown";
            this.txtBrown.Size = new System.Drawing.Size(121, 20);
            this.txtBrown.TabIndex = 14;
            // 
            // cboMain
            // 
            this.cboMain.FormattingEnabled = true;
            this.cboMain.Location = new System.Drawing.Point(91, 12);
            this.cboMain.Name = "cboMain";
            this.cboMain.Size = new System.Drawing.Size(121, 21);
            this.cboMain.TabIndex = 13;
            // 
            // SurveyEntryFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 112);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdClear);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdApply);
            this.Controls.Add(this.cmdAddBrown);
            this.Controls.Add(this.cboSurveys);
            this.Controls.Add(this.txtBrown);
            this.Controls.Add(this.cboMain);
            this.Name = "SurveyEntryFilter";
            this.Text = "SurveyEntryFilter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdApply;
        private System.Windows.Forms.Button cmdAddBrown;
        private System.Windows.Forms.ComboBox cboSurveys;
        private System.Windows.Forms.TextBox txtBrown;
        private System.Windows.Forms.ComboBox cboMain;
    }
}