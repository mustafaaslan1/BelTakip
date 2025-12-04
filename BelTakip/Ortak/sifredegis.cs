using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.OleDb;

namespace Staj
{
    public partial class sifredegis : DevExpress.XtraEditors.XtraForm
    {
        string baglanticümlesi, kulid, eskisifre;
        public sifredegis(string baglanticümlecigim,string kulidim ,string exsifre)
        {
            InitializeComponent();
            baglanticümlesi = baglanticümlecigim;
            kulid = kulidim;
            eskisifre = exsifre;
        }
        public OleDbConnection baglanti = new OleDbConnection();
        private void sifredegis_Load(object sender, EventArgs e)
        {
            baglanti.ConnectionString = baglanticümlesi.ToString();
            simpleButton1.Enabled = false;
            labelControl4.Visible = false;
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            if (txtYeniSifre.Text == txtYeniTekrar.Text)
            {
                labelControl4.Text = "Şifre Eşleşiyor";
                labelControl4.ForeColor = Color.Green;               
                labelControl4.Visible = true;
                if (txtYeniSifre.Text.Length <= 7 || txtYeniTekrar.Text.Length <= 7)
                {
                    simpleButton1.Enabled = false;
                }
                else
                {
                    simpleButton1.Enabled = true;
                }
            }
            else
            {
                labelControl4.Text = "Şifre Eşleşmiyor";
                labelControl4.ForeColor = Color.Red;
                simpleButton1.Enabled = false;
                labelControl4.Visible = true;
            }

         }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {
            if (txtYeniSifre.Text == txtYeniTekrar.Text)
            {
                labelControl4.Text = "Şifre Eşleşiyor";
                labelControl4.ForeColor = Color.Green;
                labelControl4.Visible = true;
                if (txtYeniSifre.Text.Length <= 7 || txtYeniTekrar.Text.Length <= 7)
                {
                    simpleButton1.Enabled = false;
                }
                else
                {
                    simpleButton1.Enabled = true;
                }
            }
            else
            {
                labelControl4.Text = "Şifre Eşleşmiyor";
                labelControl4.ForeColor = Color.Red;
                simpleButton1.Enabled = false;
                labelControl4.Visible = true;
            }

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (eskisifre != txtEskiSifre.Text)
            {
                XtraMessageBox.Show("Eski Şifreniz Hatalı \nLütfen Kontrol Ediniz...", "Hata...");
            }
            else
            {
                if (eskisifre == txtYeniSifre.Text)
                {
                    XtraMessageBox.Show("Eski Şifreniz Yeni Şifrenizle Aynı Olamaz \nlütfen Kontrol Ediniz", "Uyarı...");
                }
                else
                {
                    baglanti.Open();
                    OleDbCommand sorgu = new OleDbCommand("UPDATE kullanicilar SET kulsifre=@kulsifre WHERE kulid like'" + kulid.ToString() + "'", baglanti);
                    sorgu.Parameters.AddWithValue("kulsifre", txtYeniSifre.Text);
                    if (sorgu.ExecuteNonQuery() == 1)
                    {
                        XtraMessageBox.Show("Kayıt İşlemi başarılı", "Bilgi...");
                        Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("Kayıt İşlemi Başarısız", "Hata...");
                    }
                }

                
            }
        }
        int gizle = 1;
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (gizle == 0)
            {
                txtYeniSifre.Properties.PasswordChar = '*';
                gizle = 1;
            }
            else if (gizle == 1)
            {
                txtYeniSifre.Properties.PasswordChar = '\0';
                gizle = 0;
            }
        }
        int gizle1 = 1;
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (gizle1 == 0)
            {
                txtYeniTekrar.Properties.PasswordChar = '*';
                gizle1 = 1;
            }
            else if (gizle1 == 1)
            {
                txtYeniTekrar.Properties.PasswordChar = '\0';
                gizle1 = 0;
            }
        }
    }
}