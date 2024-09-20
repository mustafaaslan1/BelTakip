namespace Staj
{
    partial class sifredegis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sifredegis));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtEskiSifre = new DevExpress.XtraEditors.TextEdit();
            this.txtYeniSifre = new DevExpress.XtraEditors.TextEdit();
            this.txtYeniTekrar = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtEskiSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniTekrar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(62, 18);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Eski Şifre:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(59, 52);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 16);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Yeni Şifre:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(20, 85);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(102, 16);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Yeni Şifre Takrar:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(124, 113);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(7, 16);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "x";
            // 
            // txtEskiSifre
            // 
            this.txtEskiSifre.Location = new System.Drawing.Point(124, 15);
            this.txtEskiSifre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEskiSifre.Name = "txtEskiSifre";
            this.txtEskiSifre.Properties.PasswordChar = '*';
            this.txtEskiSifre.Size = new System.Drawing.Size(248, 22);
            this.txtEskiSifre.TabIndex = 4;
            // 
            // txtYeniSifre
            // 
            this.txtYeniSifre.Location = new System.Drawing.Point(124, 48);
            this.txtYeniSifre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtYeniSifre.Name = "txtYeniSifre";
            this.txtYeniSifre.Properties.PasswordChar = '*';
            this.txtYeniSifre.Size = new System.Drawing.Size(248, 22);
            this.txtYeniSifre.TabIndex = 5;
            this.txtYeniSifre.EditValueChanged += new System.EventHandler(this.textEdit2_EditValueChanged);
            // 
            // txtYeniTekrar
            // 
            this.txtYeniTekrar.Location = new System.Drawing.Point(124, 81);
            this.txtYeniTekrar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtYeniTekrar.Name = "txtYeniTekrar";
            this.txtYeniTekrar.Properties.PasswordChar = '*';
            this.txtYeniTekrar.Size = new System.Drawing.Size(248, 22);
            this.txtYeniTekrar.TabIndex = 6;
            this.txtYeniTekrar.EditValueChanged += new System.EventHandler(this.textEdit3_EditValueChanged);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(95, 138);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(116, 41);
            this.simpleButton1.TabIndex = 7;
            this.simpleButton1.Text = "Şifre Değiş";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(228, 138);
            this.simpleButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(116, 41);
            this.simpleButton2.TabIndex = 8;
            this.simpleButton2.Text = "Vazgeç";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl5.Location = new System.Drawing.Point(124, 187);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(189, 16);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "Şifre en az 8 karakter olmalıdır...";
            // 
            // simpleButton3
            // 
            this.simpleButton3.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton3.Image")));
            this.simpleButton3.Location = new System.Drawing.Point(379, 47);
            this.simpleButton3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(37, 26);
            this.simpleButton3.TabIndex = 30;
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // simpleButton4
            // 
            this.simpleButton4.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton4.Image")));
            this.simpleButton4.Location = new System.Drawing.Point(379, 80);
            this.simpleButton4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(37, 26);
            this.simpleButton4.TabIndex = 31;
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // sifredegis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 211);
            this.Controls.Add(this.simpleButton4);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.txtYeniTekrar);
            this.Controls.Add(this.txtYeniSifre);
            this.Controls.Add(this.txtEskiSifre);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "sifredegis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Şifre Değiştir";
            this.Load += new System.EventHandler(this.sifredegis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtEskiSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniTekrar.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtEskiSifre;
        private DevExpress.XtraEditors.TextEdit txtYeniSifre;
        private DevExpress.XtraEditors.TextEdit txtYeniTekrar;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
    }
}