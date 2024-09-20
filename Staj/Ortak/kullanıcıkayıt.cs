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
using System.IO;

namespace Staj
{
    public partial class kullanıcıkayıt : DevExpress.XtraEditors.XtraForm
    {
        string baglanticümlecigi, kulid;
        public kullanıcıkayıt(string baglanticümlecigim, string kulidim)
        {
            InitializeComponent();
            baglanticümlecigi = baglanticümlecigim;
            kulid = kulidim;
        }
        public OleDbConnection baglanti = new OleDbConnection();
        private void kullanıcıkayıt_Load(object sender, EventArgs e)
        {
            baglanti.ConnectionString = baglanticümlecigi.ToString();
            comboBoxCinsiyet.Properties.Items.Add("Erkek");
            comboBoxCinsiyet.Properties.Items.Add("Kadın");
        }
        OpenFileDialog dialog = new OpenFileDialog();
        string profilresim;
        string resimyolumuz, resimadimiz;
        public void kaydet()
        {
            benzersizkayitsorgu();
            DateTime dt = DateTime.Now;
            DateTime dateString = DateTime.Now;
            string saat = dateString.Hour.ToString();
            string dakika = dateString.Minute.ToString();
            string saniye = dateString.Second.ToString();
            string sn = saat + "." + dakika + "." + saniye + ".";
            string tarih = dt.ToString("dd.MM.yyyy");          
            try
            {
                string resimyolu = Application.StartupPath + "\\profil\\" + tarih + " " + sn + "." + dialog.SafeFileName;
                FileInfo fi = new FileInfo(dialog.FileName);
                fi.CopyTo(resimyolu);
                profilresim = tarih + " " + sn + "." + dialog.SafeFileName;
            }
            catch
            {
            }
            try
            {
                if (txtKadi.Text == "" || txtSifre.Text == "" || txtAdi.Text == "" || txtSoyadi.Text == "")
                {
                    XtraMessageBox.Show("Yıldız İle Gösterilen Alanlar \n Boş Geçilemez Lütfen Doldurunuz", "Uyarı...");
                }
                else
                {
                    if (txtSifre.Text.Length <= 7)
                    {
                        XtraMessageBox.Show("Şifre En AZ 8 Karakter Olmalıdır...", "Uyarı...");
                    }
                    else
                    {
                        if (toplamsayi != 0)
                        {
                            XtraMessageBox.Show("Girmiş Olduğunuz Kullanıcı Adı Daha Önceden Kullanılmıştır \nLütfen Başka Bir Kullanıcı Adı Giriniz...", "Uyarı...");
                        }
                        else
                        {
                            OleDbCommand cmd = new OleDbCommand("insert into kullanicilar (kuladi,kulsifre,kulisim,kulsoyisim,kule_mail,kulgsm,kulil,kulilce,kuladres,kulresim,cinsiyet,yedekdurumu) values (@kuladi,@kulsifre,@kulisim,@kulsoyisim,@kule_mail,@kulgsm,@kulil,@kulilce,@kuladres,@kulresim,@cinsiyet,@yedekdurumu) ", baglanti);
                            cmd.Parameters.Add("kuladi", OleDbType.VarChar).Value = txtKadi.Text;
                            cmd.Parameters.Add("kulsifre", OleDbType.VarChar).Value = txtSifre.Text;
                            cmd.Parameters.Add("kulisim", OleDbType.VarChar).Value = txtAdi.Text;
                            cmd.Parameters.Add("kulsoyisim", OleDbType.VarChar).Value = txtSoyadi.Text;
                            cmd.Parameters.Add("kule_mail", OleDbType.VarChar).Value = txtMail.Text;
                            cmd.Parameters.Add("kulgsm", OleDbType.VarChar).Value = txtTelefon.Text;
                            cmd.Parameters.Add("kulil", OleDbType.VarChar).Value = txtSehir.Text;
                            cmd.Parameters.Add("kulilce", OleDbType.VarChar).Value = txtilce.Text;
                            cmd.Parameters.Add("kuladres", OleDbType.VarChar).Value = memoAdres.Text;
                            if (dialog.SafeFileName == "")
                            {
                                cmd.Parameters.Add("kulresim", OleDbType.VarChar).Value = "";
                            }
                            else
                            {
                                cmd.Parameters.Add("kulresim", OleDbType.VarChar).Value = profilresim.ToString();
                            }
                            cmd.Parameters.Add("cinsiyet", OleDbType.VarChar).Value = comboBoxCinsiyet.Text;
                            if (checkEdit1.Checked == true)
                            {
                                cmd.Parameters.Add("yedekdurumu", OleDbType.VarChar).Value = "Alınsın";
                            }
                            else
                            {
                                cmd.Parameters.Add("yedekdurumu", OleDbType.VarChar).Value = "Alınmasın";
                            }
                            baglanti.Open();
                            if (cmd.ExecuteNonQuery() == 1)
                            {
                                XtraMessageBox.Show("Kayıt Başarılı...", "Bilgi...");
                                txtKadi.Text = "";
                                txtSifre.Text = "";
                                txtAdi.Text = "";
                                txtSoyadi.Text = "";
                                txtMail.Text = "";
                                txtTelefon.Text = "";
                                txtSehir.Text = "";
                                memoAdres.Text = "";
                            }
                            else
                            {
                                XtraMessageBox.Show("Kayıt Başarısız...", "Hata...");
                            }
                        }
                    }
                }
            }
            catch
            {
                baglanti.Close();
            }
            baglanti.Close();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            kaydet();
        }

        private void pictureEdit1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                DialogResult dr = new DialogResult();
                dialog.Filter = "(*jpg)|*.jpg|(*png)|*.png";
                dr = dialog.ShowDialog();
                pictureEdit1.Image = Image.FromFile(dialog.FileName);

            }
            catch
            {

            }
        }
        int gizle = 1;
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (gizle == 0)
            {
                txtSifre.Properties.PasswordChar = '*';
                gizle = 1;
            }
            else if(gizle==1)
            {
                txtSifre.Properties.PasswordChar = '\0';
                gizle = 0;
            }
        }
        int toplamsayi = 0;
        public void benzersizkayitsorgu()
        {
            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT count(*) as sayi FROM kullanicilar WHERE kuladi like '"+txtKadi.Text+"'", baglanti);
            OleDbDataReader oku = null;
            oku = cmd.ExecuteReader();
            while (oku.Read())
            {
                toplamsayi = Convert.ToInt32(oku["sayi"].ToString());
            }
            oku.Close();
            baglanti.Close();          
           
        }
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            //Random rdm = new Random();
            //txtSifre.Text = rdm.Next(99999999, 999999999).ToString();
            Random rastgele = new Random();
            string kharf = "abcçdefgğhıijklmnoöprsştuüvyz";
            string bharf = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ";
            string sayilar = "1234567890";
            string isaret = "!'^+-_/?";
            string kharf1 = "";
            string bharf1 = "";
            string sayilar1 = "";
            string isaret1 = "";
            for (int j = 0; j < 5; j++)
            {
                sayilar1 += sayilar[rastgele.Next(sayilar.Length)].ToString();
            }
            for (int i = 0; i < 1; i++) 
            {
                bharf1 += bharf[rastgele.Next(bharf.Length)].ToString();
            }
            for (int k = 0; k < 1; k++)
            {
                isaret1 += isaret[rastgele.Next(isaret.Length)].ToString(); 
            }
            for (int t = 0; t < 1; t++) 
            {
                kharf1 += kharf[rastgele.Next(kharf.Length)].ToString();
            }

            string yenisifre = sayilar1.ToString() + bharf1.ToString() + isaret1.ToString() + kharf1.ToString();
            txtSifre.Text = yenisifre.ToString(); 
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}