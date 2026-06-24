namespace MedAllergy
{
    partial class FormRegister
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
            this.txtNamaBaru = new System.Windows.Forms.TextBox();
            this.txtEmailBaru = new System.Windows.Forms.TextBox();
            this.txtPassBaru = new System.Windows.Forms.TextBox();
            this.brnSimpan = new System.Windows.Forms.Button();
            this.brnKembali = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNamaBaru
            // 
            this.txtNamaBaru.Location = new System.Drawing.Point(265, 197);
            this.txtNamaBaru.Multiline = true;
            this.txtNamaBaru.Name = "txtNamaBaru";
            this.txtNamaBaru.Size = new System.Drawing.Size(194, 32);
            this.txtNamaBaru.TabIndex = 0;
            // 
            // txtEmailBaru
            // 
            this.txtEmailBaru.Location = new System.Drawing.Point(264, 255);
            this.txtEmailBaru.Multiline = true;
            this.txtEmailBaru.Name = "txtEmailBaru";
            this.txtEmailBaru.Size = new System.Drawing.Size(195, 32);
            this.txtEmailBaru.TabIndex = 1;
            // 
            // txtPassBaru
            // 
            this.txtPassBaru.Location = new System.Drawing.Point(264, 317);
            this.txtPassBaru.Multiline = true;
            this.txtPassBaru.Name = "txtPassBaru";
            this.txtPassBaru.Size = new System.Drawing.Size(195, 32);
            this.txtPassBaru.TabIndex = 2;
            // 
            // brnSimpan
            // 
            this.brnSimpan.BackColor = System.Drawing.Color.DarkGray;
            this.brnSimpan.ForeColor = System.Drawing.Color.White;
            this.brnSimpan.Location = new System.Drawing.Point(314, 364);
            this.brnSimpan.Name = "brnSimpan";
            this.brnSimpan.Size = new System.Drawing.Size(94, 32);
            this.brnSimpan.TabIndex = 3;
            this.brnSimpan.Text = "Simpan";
            this.brnSimpan.UseVisualStyleBackColor = false;
            this.brnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // brnKembali
            // 
            this.brnKembali.BackColor = System.Drawing.Color.DarkGray;
            this.brnKembali.ForeColor = System.Drawing.Color.White;
            this.brnKembali.Location = new System.Drawing.Point(625, 529);
            this.brnKembali.Name = "brnKembali";
            this.brnKembali.Size = new System.Drawing.Size(100, 27);
            this.brnKembali.TabIndex = 4;
            this.brnKembali.Text = "kembali";
            this.brnKembali.UseVisualStyleBackColor = false;
            this.brnKembali.Click += new System.EventHandler(this.btnKembali_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(230, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(258, 45);
            this.label2.TabIndex = 32;
            this.label2.Text = "Create Account";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(264, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "Nama Baru";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(266, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "Email Baru";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(266, 294);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 20);
            this.label4.TabIndex = 35;
            this.label4.Text = "Password Baru";
            // 
            // FormRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(733, 562);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.brnKembali);
            this.Controls.Add(this.brnSimpan);
            this.Controls.Add(this.txtPassBaru);
            this.Controls.Add(this.txtEmailBaru);
            this.Controls.Add(this.txtNamaBaru);
            this.Name = "FormRegister";
            this.Text = "Form Registrasi";
            this.Load += new System.EventHandler(this.FormRegister_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNamaBaru;
        private System.Windows.Forms.TextBox txtEmailBaru;
        private System.Windows.Forms.TextBox txtPassBaru;
        private System.Windows.Forms.Button brnSimpan;
        private System.Windows.Forms.Button brnKembali;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}