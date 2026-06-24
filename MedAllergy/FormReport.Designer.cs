namespace MedAllergy
{
    partial class FormReport
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
            this.crvDiagnosis = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.ReportDiagnosis1 = new MedAllergy.ReportDiagnosis();
            this.ReportDiagnosis2 = new MedAllergy.ReportDiagnosis();
            this.SuspendLayout();
            // 
            // crvDiagnosis
            // 
            this.crvDiagnosis.ActiveViewIndex = 0;
            this.crvDiagnosis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvDiagnosis.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvDiagnosis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvDiagnosis.Location = new System.Drawing.Point(0, 0);
            this.crvDiagnosis.Name = "crvDiagnosis";
            this.crvDiagnosis.ReportSource = this.ReportDiagnosis2;
            this.crvDiagnosis.Size = new System.Drawing.Size(800, 450);
            this.crvDiagnosis.TabIndex = 0;
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crvDiagnosis);
            this.Name = "FormReport";
            this.Text = "FormReport";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvDiagnosis;
        private ReportDiagnosis ReportDiagnosis1;
        private ReportDiagnosis ReportDiagnosis2;
    }
}