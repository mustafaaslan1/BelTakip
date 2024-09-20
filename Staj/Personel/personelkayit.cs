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
    public partial class personelkayit : DevExpress.XtraEditors.XtraForm
    {
        string baglanticümlecigi, kulid, deger, perid;
        public personelkayit(string baglanticümlecigim, string kulidm, string degerim, string peridim)
        {
            InitializeComponent();
            baglanticümlecigi = baglanticümlecigim;
            kulid = kulidm;
            deger = degerim;
            perid = peridim;
        }
        OleDbConnection baglanti = new OleDbConnection();

        public void vericek()
        {
            try
            {
                string sorgu = "SELECT * FROM personelkayit WHERE perid like '" + perid + "'";
                baglanti.Open();
                OleDbCommand veri = new OleDbCommand(sorgu, baglanti);
                OleDbDataReader oku = veri.ExecuteReader();
                while (oku.Read())
                {
                    txtAdi.Text = oku["perisim"].ToString();
                    txtSoyadi.Text = oku["persoyisim"].ToString();
                    txtKimlik.Text = oku["perkimlik"].ToString();
                    txtSicil.Text = oku["persicilno"].ToString();
                    txtKayitTarihi.Text = oku["perkayittarihi"].ToString();

                    if (oku["percinsiyet"].ToString() == "Kadın")
                    {
                        radioGroup1.SelectedIndex = 0;
                    }
                    else if (oku["percinsiyet"].ToString() == "Erkek")
                    {
                        radioGroup1.SelectedIndex = 1;
                    }

                    txtTelefon.Text = oku["pertelefon"].ToString();
                    txtBirim.Text = oku["perbirim"].ToString();
                    txtMail.Text = oku["permail"].ToString();
                    memoAdres.Text = oku["peradres"].ToString();
                    txtAnneadi.Text = oku["peranneadi"].ToString();
                    txtBabaadi.Text = oku["perbabaadi"].ToString();
                    txtDogumTarihi.Text = oku["perdogumtarihi"].ToString();
                    txtDogumYeri.Text = oku["perdogumyeri"].ToString();
                    txtKanGrubu.Text = oku["perkangrubu"].ToString();

                }
                oku.Close();
                baglanti.Close();

            }
            catch
            {
                baglanti.Close();

            }
        }

        int toplamsayi = 0;
        public void benzersizkayitsorgu()
        {
            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT count(*) as sayi FROM personelkayit WHERE persicilno like '" + txtSicil.Text + "'", baglanti);
            OleDbDataReader oku = null;
            oku = cmd.ExecuteReader();
            while (oku.Read())
            {
                toplamsayi = Convert.ToInt32(oku["sayi"].ToString());
            }
            oku.Close();
            baglanti.Close();

        }

        public void kaydet()
        {
            try
            {
                if (txtAdi .Text == "" || txtSoyadi.Text == "" || txtKimlik.Text == "" || txtSicil.Text =="")
                {
                    XtraMessageBox.Show("Yıldızlı Alanlar Boş Geçilemez \nLütfen Yıldızlı Alanları Giriniz...", "Uyarı...", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    baglanti.Open();
                    OleDbCommand komut = new OleDbCommand("INSERT INTO personelkayit (perisim,persoyisim,perkimlik,persicilno,percinsiyet,pertelefon,perbirim,perkayittarihi,permail,peradres,peranneadi,perbabaadi,perdogumtarihi,perdogumyeri,perkangrubu,aktiflik) VALUES (@perisim,@persoyisim,@perkimlik,@persicilno,@percinsiyet,@pertelefon,@perbirim,@perkayittarihi,@permail,@peradres,@peranneadi,@perbabaadi,@perdogumtarihi,@perdogumyeri,@perkangrubu,@aktiflik) ", baglanti);
                    komut.Parameters.Add("perisim", OleDbType.VarChar).Value = txtAdi.Text;
                    komut.Parameters.Add("persoyisim", OleDbType.VarChar).Value = txtSoyadi.Text;
                    komut.Parameters.Add("perkimlik", OleDbType.VarChar).Value = txtKimlik.Text;
                    komut.Parameters.Add("persicilno", OleDbType.VarChar).Value = txtSicil.Text;
                    if (radioGroup1.SelectedIndex.ToString() == "0")
                    {
                        komut.Parameters.Add("percinsiyet", OleDbType.VarChar).Value = "Kadın";
                    }
                    else if (radioGroup1.SelectedIndex.ToString() == "1")
                    {
                        komut.Parameters.Add("percinsiyet", OleDbType.VarChar).Value = "Erkek";
                    }
                    komut.Parameters.Add("pertelefon", OleDbType.VarChar).Value = txtTelefon.Text;
                    komut.Parameters.Add("perbirim", OleDbType.VarChar).Value = txtBirim.Text;
                    komut.Parameters.Add("perkayittarihi", OleDbType.VarChar).Value = txtKayitTarihi.Text;
                    komut.Parameters.Add("permail", OleDbType.VarChar).Value = txtMail.Text;
                    komut.Parameters.Add("peradres", OleDbType.VarChar).Value = memoAdres.Text;
                    komut.Parameters.Add("peranneadi", OleDbType.VarChar).Value = txtAnneadi.Text;
                    komut.Parameters.Add("perbabaadi", OleDbType.VarChar).Value = txtBabaadi.Text;
                    komut.Parameters.Add("perdogumtarihi", OleDbType.VarChar).Value = txtDogumTarihi.Text;
                    komut.Parameters.Add("perdogumyeri", OleDbType.VarChar).Value = txtDogumYeri.Text;
                    komut.Parameters.Add("perkangrubu", OleDbType.VarChar).Value = txtKanGrubu.Text;
                    komut.Parameters.Add("aktiflik", OleDbType.Boolean).Value = true;
                    if (komut.ExecuteNonQuery() == 1)
                    {
                        XtraMessageBox.Show("Kayıt İşlemi Başarılı...", "Bilgi...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        baglanti.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("Kayıt İşlemi Başarısız...", "Hata...", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        baglanti.Close();
                    }
                }
            }
            catch
            {
                baglanti.Close();
            }
        }

        public void güncelle()
        {
            if (txtAdi.Text == "" || txtSoyadi.Text == "" || txtKimlik.Text == "")
            {
                XtraMessageBox.Show("Yıldız ile gösterilen alanlar boş geçilemez \n  Lütfen yıldızlı alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            else
            {

                try
                {
                    baglanti.Open();
                    OleDbCommand sorgu = new OleDbCommand("UPDATE personelkayit SET perisim=@perisim,persoyisim=@persoyisim,perkimlik=@perkimlik,percinsiyet=@percinsiyet,pertelefon=@pertelefon,perbirim=@perbirim,perkayittarihi=@perkayittarihi, "
                        + "permail=@permail,peradres=@peradres,peranneadi=@peranneadi,perbabaadi=@perbabaadi,perdogumtarihi=@perdogumtarihi,perdogumyeri=@perdogumyeri,perkangrubu=@perkangrubu WHERE perid like'" + perid.ToString() + "'", baglanti);
                    sorgu.Parameters.AddWithValue("perisim", txtAdi.Text);
                    sorgu.Parameters.AddWithValue("persoyisim", txtSoyadi.Text);
                    sorgu.Parameters.AddWithValue("perkimlik", txtKimlik.Text);
                    if (radioGroup1.SelectedIndex == 0)
                    {
                        sorgu.Parameters.AddWithValue("percinsiyet", "Kadın");
                    }
                    else if (radioGroup1.SelectedIndex == 1)
                    {
                        sorgu.Parameters.AddWithValue("percinsiyet", "Erkek");
                    }

                    sorgu.Parameters.AddWithValue("pertelefon", txtTelefon.Text);
                    sorgu.Parameters.AddWithValue("perbirim", txtBirim.Text);
                    sorgu.Parameters.AddWithValue("perkayittarihi", txtKayitTarihi.Text);
                    sorgu.Parameters.AddWithValue("permail", txtMail.Text);
                    sorgu.Parameters.AddWithValue("peradres", memoAdres.Text);
                    sorgu.Parameters.AddWithValue("peranneadi", txtAnneadi.Text);
                    sorgu.Parameters.AddWithValue("perbabaadi", txtBabaadi.Text);
                    sorgu.Parameters.AddWithValue("perdogumtarihi", txtDogumTarihi.Text);
                    sorgu.Parameters.AddWithValue("perdogumyeri", txtDogumYeri.Text);
                    sorgu.Parameters.AddWithValue("perkangrubu", txtKanGrubu.Text);
                    if (sorgu.ExecuteNonQuery() == 1)
                    {
                        XtraMessageBox.Show("Güncelleme işlemi başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("Güncelleme işlemi başarısız", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    }
                    baglanti.Close();
                }   
                catch
                {

                }
            }
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (deger == "1")
            {
                benzersizkayitsorgu();
                btnKaydet.Text = "Kaydet";
                if (toplamsayi == 0)
                {
                    kaydet();
                    txtKayitTarihi.Text = "";
                    txtAdi.Text = "";
                    txtSoyadi.Text = "";
                    txtSicil.Text = "";
                    txtKimlik.Text = "";
                    txtTelefon.Text = "";
                    txtBirim.Text = "";
                    txtMail.Text = "";
                    txtAnneadi.Text = "";
                    txtBabaadi.Text = "";
                    txtDogumTarihi.Text = "";
                    txtDogumYeri.Text = "";
                    txtKanGrubu.Text = "";
                    memoAdres.Text = "";
                }
                else
                {
                    XtraMessageBox.Show("Girmiş Olduğunuz Plaka Daha Önceden Eklenmiştir...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
            }
            else if (deger == "2")
            {
                btnKaydet.Text = "Güncelle";
                güncelle();
            }
           
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void personelkayit_Load(object sender, EventArgs e)
        {
            baglanti.ConnectionString = baglanticümlecigi.ToString();
            if (deger == "1")
            {
                btnKaydet.Text = "Kaydet";
            }
            else if (deger == "2")
            {
                btnKaydet.Text = "Güncelle";
                vericek();
                txtSicil.Enabled = false;
            }
        }
    }
}