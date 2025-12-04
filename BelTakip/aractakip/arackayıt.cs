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
    public partial class arackayıt : DevExpress.XtraEditors.XtraForm
    {
        string baglanticümlecigi, kulid, deger, aracid;
        public arackayıt(string baglanticümlecigim, string kulidm, string degerim, string aracidim)
        {
            InitializeComponent();
            baglanticümlecigi = baglanticümlecigim;
            kulid = kulidm;
            deger = degerim;
            aracid = aracidim;
        }
        OleDbConnection baglanti = new OleDbConnection();
        public void vericek()
        {
            try
            {
                string sorgu = "SELECT * FROM araclar WHERE id like '" + aracid + "'";
                baglanti.Open();
                OleDbCommand veri = new OleDbCommand(sorgu, baglanti);
                OleDbDataReader oku = veri.ExecuteReader();
                while (oku.Read())
                {
                    txtPlaka.Text = oku["aracplaka"].ToString();
                    txtMarka.Text = oku["aracmarka"].ToString();
                    txtModel.Text = oku["aracmodel"].ToString();
                    txtYil.Text = oku["aracyılı"].ToString();
                    txtRenk.Text = oku["aracrengi"].ToString();
                    txtTip.Text = oku["aractipi"].ToString();
                    txtKayitTarihi.Text = oku["kayıttarihi"].ToString();

                    if (oku["yakıt"].ToString() == "Benzin")
                    {
                        radioGroup1.SelectedIndex = 0;
                    }
                    else if (oku["yakıt"].ToString() == "Dizel")
                    {
                        radioGroup1.SelectedIndex = 1;
                    }
                    else if (oku["yakıt"].ToString() == "Elektrik")
                    {
                        radioGroup1.SelectedIndex = 2;
                    }
                    else if (oku["yakıt"].ToString() == "Benzin & LPG")
                    {
                        radioGroup1.SelectedIndex = 3;
                    }

                    if (oku["vites"].ToString() == "Manuel")
                    {
                        radioGroup1.SelectedIndex = 0;
                    }
                    else if (oku["vites"].ToString() == "Otomatik")
                    {
                        radioGroup1.SelectedIndex = 1;
                    }
                    else if (oku["vites"].ToString() == "Yarı Otomatik")
                    {
                        radioGroup1.SelectedIndex = 2;
                    }
                    txtSaseNo.Text = oku["şaseno"].ToString();
                    memoAciklama.Text = oku["açıklama"].ToString();
                    
                    
                }
                oku.Close();
                baglanti.Close();

            }
            catch
            {
                baglanti.Close();

            }
        }
        private void arackayıt_Load(object sender, EventArgs e)
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
                txtPlaka.Enabled = false;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void kaydet()
        {
            try
            {
                if (txtPlaka.Text == "" || txtMarka.Text == "" || txtModel.Text == "")
                {
                    XtraMessageBox.Show("Yıldızlı Alanlar Boş Geçilemez \nLütfen Yıldızlı Alanları Giriniz...", "Uyarı...", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    baglanti.Open();
                    OleDbCommand komut = new OleDbCommand("INSERT INTO araclar (aracplaka,aracmarka,aracmodel,aracyılı,aracrengi,aractipi,kayıttarihi,yakıt,vites,şaseno,açıklama,aktiflik) VALUES (@aracplaka,@aracmarka,@aracmodel,@aracyılı,@aracrengi,@aractipi,@kayıttarihi,@yakıt,@vites,@şaseno,@açıklama,@aktiflik) ", baglanti);
                    komut.Parameters.Add("aracplaka", OleDbType.VarChar).Value = txtPlaka.Text;
                    komut.Parameters.Add("aracmarka", OleDbType.VarChar).Value = txtMarka.Text;
                    komut.Parameters.Add("aracmodel", OleDbType.VarChar).Value = txtModel.Text;
                    komut.Parameters.Add("aracyılı", OleDbType.VarChar).Value = txtYil.Text;
                    komut.Parameters.Add("aracrengi", OleDbType.VarChar).Value = txtRenk.Text;
                    komut.Parameters.Add("aractipi", OleDbType.VarChar).Value = txtTip.Text;
                    komut.Parameters.Add("kayıttarihi", OleDbType.VarChar).Value = txtKayitTarihi.Text;
                    if (radioGroup1.SelectedIndex.ToString() == "0")
                    {
                        komut.Parameters.Add("yakıt", OleDbType.VarChar).Value = "Benzin";
                    }
                    else if (radioGroup1.SelectedIndex.ToString() == "1")
                    {
                        komut.Parameters.Add("yakıt", OleDbType.VarChar).Value = "Dizel";
                    }
                    else if (radioGroup1.SelectedIndex.ToString() == "2")
                    {
                        komut.Parameters.Add("yakıt", OleDbType.VarChar).Value = "Elektrik";
                    }
                    else if (radioGroup1.SelectedIndex.ToString() == "3")
                    {
                        komut.Parameters.Add("yakıt", OleDbType.VarChar).Value = "Benzin & LPG";
                    }
                    if (radioGroup2.SelectedIndex.ToString() == "0")
                    {
                        komut.Parameters.Add("vites", OleDbType.VarChar).Value = "Manuel";
                    }
                    else if (radioGroup2.SelectedIndex.ToString() == "1")
                    {
                        komut.Parameters.Add("vites", OleDbType.VarChar).Value = "Otomatik";
                    }
                    else if (radioGroup2.SelectedIndex.ToString() == "2")
                    {
                        komut.Parameters.Add("vites", OleDbType.VarChar).Value = "Yarı Otomatik";
                    }

                    komut.Parameters.Add("şaseno", OleDbType.VarChar).Value = txtSaseNo.Text;
                    komut.Parameters.Add("açıklama", OleDbType.VarChar).Value = memoAciklama.Text;
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
            if (txtModel.Text == ""  || txtMarka.Text == "")
            {
                XtraMessageBox.Show("Yıldız ile gösterilen alanlar boş geçilemez \n  Lütfen yıldızlı alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            else
            {

                try
                {
                    baglanti.Open();
                    OleDbCommand sorgu = new OleDbCommand("UPDATE araclar SET aracmarka=@aracmarka,aracmodel=@aracmodel,  " +
                        "aracyılı=@aracyılı,aracrengi=@aracrengi,aractipi=@aractipi,kayıttarihi=@kayıttarihi,yakıt=@yakıt,vites=@vites,şaseno=@şaseno,açıklama=@açıklama " +
                        "WHERE id like'" + aracid.ToString() + "'", baglanti);                    
                    sorgu.Parameters.AddWithValue("aracmarka", txtMarka.Text);
                    sorgu.Parameters.AddWithValue("aracmodel", txtModel.Text);
                    sorgu.Parameters.AddWithValue("aracyılı", txtYil.Text);
                    sorgu.Parameters.AddWithValue("aracrengi", txtRenk.Text);
                    sorgu.Parameters.AddWithValue("aractipi", txtTip.Text);
                    sorgu.Parameters.AddWithValue("kayıttarihi", txtKayitTarihi.Text);

                    if (radioGroup1.SelectedIndex == 0)
                    {
                        sorgu.Parameters.AddWithValue("yakıt", "Benzin");
                    }
                    else if (radioGroup1.SelectedIndex == 1)
                    {
                        sorgu.Parameters.AddWithValue("yakıt", "Dizel");
                    }
                    else if (radioGroup1.SelectedIndex == 2)
                    {
                        sorgu.Parameters.AddWithValue("yakıt", "Elektrik");
                    }
                    else if (radioGroup1.SelectedIndex == 3)
                    {
                        sorgu.Parameters.AddWithValue("yakıt", "Benzin & LPG");
                    }

                    if (radioGroup2.SelectedIndex == 0)
                    {
                        sorgu.Parameters.AddWithValue("vites", "Manuel");
                    }
                    else if (radioGroup2.SelectedIndex == 1)
                    {
                        sorgu.Parameters.AddWithValue("vites", "Otomatik");
                    }
                    else if (radioGroup2.SelectedIndex == 2)
                    {
                        sorgu.Parameters.AddWithValue("vites", "Yarı Otomatik");
                    }
                    sorgu.Parameters.AddWithValue("şaseno", txtSaseNo.Text);
                    sorgu.Parameters.AddWithValue("açıklama", memoAciklama.Text);

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
        int toplamsayi = 0;
        public void benzersizkayitsorgu()
        {
            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT count(*) as sayi FROM araclar WHERE aracplaka like '" + txtPlaka.Text + "'", baglanti);
            OleDbDataReader oku = null;
            oku = cmd.ExecuteReader();
            while (oku.Read())
            {
                toplamsayi = Convert.ToInt32(oku["sayi"].ToString());
            }
            oku.Close();
            baglanti.Close();

        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (deger == "1")
            {
                benzersizkayitsorgu();
                btnKaydet.Text = "Kaydet";
                if (toplamsayi == 0)
                {
                    kaydet();
                    txtKayitTarihi.Text = "";
                    txtMarka.Text = "";
                    txtModel.Text = "";
                    txtPlaka.Text = "";
                    txtRenk.Text = "";
                    txtSaseNo.Text = "";
                    txtTip.Text = "";
                    txtYil.Text = "";
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

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

      
    }
}