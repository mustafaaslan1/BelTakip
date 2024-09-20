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
    public partial class Anaform : DevExpress.XtraEditors.XtraForm
    {
        string baglanticümlecigi, kulid;
        public Anaform(string baglanticümlecigim,string kulidim)
        {
            InitializeComponent();
            baglanticümlecigi = baglanticümlecigim;
            kulid = kulidim;
        }
        public OleDbConnection baglanti = new OleDbConnection();
        string yeddurum,yol;
        public void yedekdurumu()
        {
            try
            {
                string sorgu = "SELECT * FROM kullanicilar WHERE kulid like'" + kulid.ToString() + "'";
                baglanti.Open();
                OleDbCommand veri = new OleDbCommand(sorgu, baglanti);
                OleDbDataReader oku = veri.ExecuteReader();
                while (oku.Read())
                {
                    yeddurum = oku["yedekdurumu"].ToString();
                    yol = oku["yedekyolu"].ToString(); 
                }
                oku.Close();
                baglanti.Close();

            }
            catch
            {
                baglanti.Close();

            }
        }
        private void Anaform_FormClosing(object sender, FormClosingEventArgs e)
        {
           
           
        }
        public void kullanicibilgileri()
        {
            try
            {
                string sorgu = "SELECT * FROM kullanicilar WHERE kulid like'" + kulid.ToString() + "'";
                baglanti.Open();
                OleDbCommand veri = new OleDbCommand(sorgu, baglanti);
                OleDbDataReader oku = veri.ExecuteReader();
                while (oku.Read())
                {
                    this.Text = "Hoş Geldin("+oku["kulisim"].ToString() + " " + oku["kulsoyisim"].ToString()+")";
                    tema.LookAndFeel.SkinName = oku["kultema"].ToString();
                }
                oku.Close();
                baglanti.Close();

            }
            catch
            {
                baglanti.Close();

            }
        }
        private void Anaform_Load(object sender, EventArgs e)
        {
            baglanti.ConnectionString = baglanticümlecigi.ToString();
            kullanicibilgileri();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            kullanıcıkayıt ac = new kullanıcıkayıt(baglanticümlecigi,kulid);
            ac.ShowDialog();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult cikis = MessageBox.Show("Programdan güvenli bir şekilde çıkış yapmak istiyormusunuz?","UYARI",MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);
            if (cikis == DialogResult.OK) {
                Application.Exit();
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            kullaniciprofili ac = new kullaniciprofili(baglanticümlecigi,kulid);
            ac.ShowDialog();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            profilguncelleme ac = new profilguncelleme(baglanticümlecigi,kulid);
            ac.ShowDialog();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string datapath = Environment.CurrentDirectory + @"/Data.mdb";
                string dosyaadı = DateTime.Now.ToString("dd.MM.yyyy");
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string backuppath = fbd.SelectedPath.ToString();
                    File.Copy(datapath, backuppath + @"/" + dosyaadı + " " + "backup.mdb", true);
                    XtraMessageBox.Show("Veri tabanı backup'u alınmıştır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }

            }
            catch
            {

            }
        }
        public void temagüncelle()
        {
            try
            {
                baglanti.Open();
                OleDbCommand sorgu = new OleDbCommand("UPDATE kullanicilar SET kultema=@kultema WHERE kulid like'" + kulid.ToString() + "'", baglanti);
                sorgu.Parameters.AddWithValue("kultema", tema.LookAndFeel.SkinName.ToString());
                sorgu.ExecuteNonQuery();
                baglanti.Close();
            }
            catch
            {
                baglanti.Close();

            }
        }
        private void Anaform_FormClosed(object sender, FormClosedEventArgs e)
        {
            yedekdurumu();
            temagüncelle();
            if (yeddurum == "Alınsın")
            {
                try
                {
                    string datapath = Environment.CurrentDirectory + @"/Data.mdb";
                    string dosyaadı = DateTime.Now.ToString("dd.MM.yyyy");
                    File.Copy(datapath, yol + @"/" + dosyaadı + " " + "backup.mdb", true);
                    XtraMessageBox.Show("Veri tabanı backup'u alınmıştır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    Dispose();
                    Application.Exit();
                }
                catch
                {
                    
                }
                
            }
            Application.Exit();
        }

        private void navButton2_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            arackayıt ac = new arackayıt(baglanticümlecigi,kulid,"1",null);
            ac.ShowDialog();
        }
        public void aktifaracliste()
        {
            baglanti.Open();
            string sorgu = "SELECT * FROM araclar  WHERE aktiflik like '-1'";
            OleDbCommand komut = new OleDbCommand(sorgu,baglanti);
            OleDbDataReader oku = null;
            oku = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Plaka",Type.GetType("System.String"));
            dt.Columns.Add("Marka", Type.GetType("System.String"));
            dt.Columns.Add("Model", Type.GetType("System.String"));
            dt.Columns.Add("Yılı", Type.GetType("System.String"));
            dt.Columns.Add("Rengi", Type.GetType("System.String"));
            dt.Columns.Add("Tipi", Type.GetType("System.String"));
            dt.Columns.Add("Kayıt Tarihi", Type.GetType("System.String"));
            dt.Columns.Add("Yakıt", Type.GetType("System.String"));
            dt.Columns.Add("Vites", Type.GetType("System.String"));
            dt.Columns.Add("Şase No", Type.GetType("System.String"));
            dt.Columns.Add("Açıklama", Type.GetType("System.String"));
            dt.Columns.Add("aktiflik", Type.GetType("System.Boolean"));
            dt.Columns.Add("id", Type.GetType("System.String"));
            while (oku.Read())
            {
                DataRow dr = dt.NewRow();
                dr[0] = oku["aracplaka"].ToString();
                dr[1] = oku["aracmarka"].ToString();
                dr[2] = oku["aracmodel"].ToString();
                dr[3] = oku["aracyılı"].ToString();
                dr[4] = oku["aracrengi"].ToString();
                dr[5] = oku["aractipi"].ToString();
                dr[6] = oku["kayıttarihi"].ToString();
                dr[7] = oku["yakıt"].ToString();
                dr[8] = oku["vites"].ToString();
                dr[9] = oku["şaseno"].ToString();
                dr[10] = oku["açıklama"].ToString();
                dr[11] = oku["aktiflik"].ToString();
                dr[12] = oku["id"].ToString();
                dt.Rows.Add(dr);
            }
            gridControl1.DataSource = dt;
            oku.Close();
            baglanti.Close();
            gridView1.Columns["id"].Visible = false;
            gridView1.Columns["aktiflik"].Visible = false;
        }
        public void pasifaracliste()
        {
            baglanti.Open();
            string sorgu = "SELECT * FROM araclar  WHERE aktiflik like '0'";
            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
            OleDbDataReader oku = null;
            oku = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Plaka", Type.GetType("System.String"));
            dt.Columns.Add("Marka", Type.GetType("System.String"));
            dt.Columns.Add("Model", Type.GetType("System.String"));
            dt.Columns.Add("Yılı", Type.GetType("System.String"));
            dt.Columns.Add("Rengi", Type.GetType("System.String"));
            dt.Columns.Add("Tipi", Type.GetType("System.String"));
            dt.Columns.Add("Kayıt Tarihi", Type.GetType("System.String"));
            dt.Columns.Add("Yakıt", Type.GetType("System.String"));
            dt.Columns.Add("Vites", Type.GetType("System.String"));
            dt.Columns.Add("Şase No", Type.GetType("System.String"));
            dt.Columns.Add("Açıklama", Type.GetType("System.String"));
            dt.Columns.Add("aktiflik", Type.GetType("System.Boolean"));
            dt.Columns.Add("id", Type.GetType("System.String"));
            while (oku.Read())
            {
                DataRow dr = dt.NewRow();
                dr[0] = oku["aracplaka"].ToString();
                dr[1] = oku["aracmarka"].ToString();
                dr[2] = oku["aracmodel"].ToString();
                dr[3] = oku["aracyılı"].ToString();
                dr[4] = oku["aracrengi"].ToString();
                dr[5] = oku["aractipi"].ToString();
                dr[6] = oku["kayıttarihi"].ToString();
                dr[7] = oku["yakıt"].ToString();
                dr[8] = oku["vites"].ToString();
                dr[9] = oku["şaseno"].ToString();
                dr[10] = oku["açıklama"].ToString();
                dr[11] = oku["aktiflik"].ToString();
                dr[12] = oku["id"].ToString();
                dt.Rows.Add(dr);
            }
            gridControl1.DataSource = dt;
            oku.Close();
            baglanti.Close();
            gridView1.Columns["id"].Visible = false;
            gridView1.Columns["aktiflik"].Visible = false;
        }
        private void navButton3_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            aktifaracliste();
        }

        private void navButton4_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            pasifaracliste();
        }

        public void aktifpersonelliste()
        {
            baglanti.Open();
            string sorgu1 = "SELECT * FROM personelkayit  WHERE aktiflik like '-1'";
            OleDbCommand komut = new OleDbCommand(sorgu1, baglanti);
            OleDbDataReader oku1 = null;
            oku1 = komut.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("Adı", Type.GetType("System.String"));
            dt1.Columns.Add("Soyadı", Type.GetType("System.String"));
            dt1.Columns.Add("Kimlik Numarası", Type.GetType("System.String"));
            dt1.Columns.Add("Sicil Numarası", Type.GetType("System.String"));
            dt1.Columns.Add("Cinsiyet", Type.GetType("System.String"));
            dt1.Columns.Add("Telefon Numarası", Type.GetType("System.String"));
            dt1.Columns.Add("Çalıştığı Birim", Type.GetType("System.String"));
            dt1.Columns.Add("İşe Giriş Tarihi", Type.GetType("System.String"));
            dt1.Columns.Add("Mail", Type.GetType("System.String"));
            dt1.Columns.Add("Adres", Type.GetType("System.String"));
            dt1.Columns.Add("Anne Adı", Type.GetType("System.String"));
            dt1.Columns.Add("Baba Adı", Type.GetType("System.String"));
            dt1.Columns.Add("Doğum Tarihi", Type.GetType("System.String"));
            dt1.Columns.Add("Doğum Yeri", Type.GetType("System.String"));
            dt1.Columns.Add("Kan Grubu", Type.GetType("System.String"));
            dt1.Columns.Add("aktiflik", Type.GetType("System.Boolean"));
            dt1.Columns.Add("perid", Type.GetType("System.String"));
            while (oku1.Read())
            {
                DataRow dr = dt1.NewRow();
                dr[0] = oku1["perisim"].ToString();
                dr[1] = oku1["persoyisim"].ToString();
                dr[2] = oku1["perkimlik"].ToString();
                dr[3] = oku1["persicilno"].ToString();
                dr[4] = oku1["percinsiyet"].ToString();
                dr[5] = oku1["pertelefon"].ToString();
                dr[6] = oku1["perbirim"].ToString();
                dr[7] = oku1["perkayittarihi"].ToString();
                dr[8] = oku1["permail"].ToString();
                dr[9] = oku1["peradres"].ToString();
                dr[10] = oku1["peranneadi"].ToString();
                dr[11] = oku1["perbabaadi"].ToString();
                dr[12] = oku1["perdogumtarihi"].ToString();
                dr[13] = oku1["perdogumyeri"].ToString();
                dr[14] = oku1["perkangrubu"].ToString();
                dr[15] = oku1["aktiflik"].ToString();
                dr[16] = oku1["perid"].ToString();
                dt1.Rows.Add(dr);
            }
            gridControl2.DataSource = dt1;
            oku1.Close();
            baglanti.Close();
            gridView2.Columns["perid"].Visible = false;
            gridView2.Columns["aktiflik"].Visible = false;
        }
        public void pasifpersonelliste()
        {
            baglanti.Open();
            string sorgu1 = "SELECT * FROM personelkayit WHERE aktiflik like '0'";
            OleDbCommand komut = new OleDbCommand(sorgu1, baglanti);
            OleDbDataReader oku1 = null;
            oku1 = komut.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("Adı", Type.GetType("System.String"));
            dt1.Columns.Add("Soyadı", Type.GetType("System.String"));
            dt1.Columns.Add("Kimlik Numarası", Type.GetType("System.String"));
            dt1.Columns.Add("Sicil Numarası", Type.GetType("System.String"));
            dt1.Columns.Add("Cinsiyet", Type.GetType("System.String"));
            dt1.Columns.Add("Telefon Numarası", Type.GetType("System.String"));
            dt1.Columns.Add("Çalıştığı Birim", Type.GetType("System.String"));
            dt1.Columns.Add("İşe Giriş Tarihi", Type.GetType("System.String"));
            dt1.Columns.Add("Mail", Type.GetType("System.String"));
            dt1.Columns.Add("Adres", Type.GetType("System.String"));
            dt1.Columns.Add("Anne Adı", Type.GetType("System.String"));
            dt1.Columns.Add("Baba Adı", Type.GetType("System.String"));
            dt1.Columns.Add("Doğum Tarihi", Type.GetType("System.String"));
            dt1.Columns.Add("Doğum Yeri", Type.GetType("System.String"));
            dt1.Columns.Add("Kan Grubu", Type.GetType("System.String"));
            dt1.Columns.Add("aktiflik", Type.GetType("System.Boolean"));
            dt1.Columns.Add("perid", Type.GetType("System.String"));
            while (oku1.Read())
            {
                DataRow dr = dt1.NewRow();
                dr[0] = oku1["perisim"].ToString();
                dr[1] = oku1["persoyisim"].ToString();
                dr[2] = oku1["perkimlik"].ToString();
                dr[3] = oku1["persicilno"].ToString();
                dr[4] = oku1["percinsiyet"].ToString();
                dr[5] = oku1["pertelefon"].ToString();
                dr[6] = oku1["perbirim"].ToString();
                dr[7] = oku1["perkayittarihi"].ToString();
                dr[8] = oku1["permail"].ToString();
                dr[9] = oku1["peradres"].ToString();
                dr[10] = oku1["peranneadi"].ToString();
                dr[11] = oku1["perbabaadi"].ToString();
                dr[12] = oku1["perdogumtarihi"].ToString();
                dr[13] = oku1["perdogumyeri"].ToString();
                dr[14] = oku1["perkangrubu"].ToString();
                dr[15] = oku1["aktiflik"].ToString();
                dr[16] = oku1["perid"].ToString();
                dt1.Rows.Add(dr);
            }
            gridControl2.DataSource = dt1;
            oku1.Close();
            baglanti.Close();
            gridView2.Columns["perid"].Visible = false;
            gridView2.Columns["aktiflik"].Visible = false;
        }

        private void gridControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && gridView1.SelectedRowsCount == 1)
            {
                if (Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "aktiflik")) == 1)
                {
                    barButtonItem7.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    barButtonItem8.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;                   

                }
                else if (Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "aktiflik")) == 0)
                {
                    barButtonItem7.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    barButtonItem8.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                menü.ShowPopup(MousePosition);
            }
        }



        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            arackayıt ac = new arackayıt(baglanticümlecigi, kulid, "2", Convert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id")));
            ac.ShowDialog();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("UPDATE araclar SET aktiflik=@aktiflik WHERE id like'" + Convert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id")) + "'", baglanti);
            komut.Parameters.AddWithValue("aktiflik", true);
            if (komut.ExecuteNonQuery() == 1)
            {
                XtraMessageBox.Show("Kayıt Aktif Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
             
            }
            else
            {
                XtraMessageBox.Show("Kayıt Aktif Edilemedi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            baglanti.Close();
            pasifaracliste();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("UPDATE araclar SET aktiflik=@aktiflik WHERE id like'" + Convert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id")) + "'", baglanti);
            komut.Parameters.AddWithValue("aktiflik", false);
            if (komut.ExecuteNonQuery() == 1)
            {
                XtraMessageBox.Show("Kayıt Pasif Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            }
            else
            {
                XtraMessageBox.Show("Kayıt Pasif Edilemedi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            baglanti.Close();
            aktifaracliste();
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("DELETE * FROM araclar WHERE id like'" + Convert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id")) + "'", baglanti);           
            if (komut.ExecuteNonQuery() == 1)
            {
                XtraMessageBox.Show("Kayıt Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            }
            else
            {
                XtraMessageBox.Show("Kayıt Silinemedi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            baglanti.Close();
            if (Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "aktiflik")) == 1)
            {
                aktifaracliste();

            }
            else if (Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "aktiflik")) == 0)
            {
                pasifaracliste();
            }
          
           
        }

        private void navButton5_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            rapor ac = new rapor("1",null);
            ac.Show();
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rapor ac = new rapor("2", Convert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id")));
            ac.Show();
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            aracyakitfisi ac = new aracyakitfisi(baglanticümlecigi, Convert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id")));
            ac.Show();
        }

        private void navButton6_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            personelkayit ac = new personelkayit(baglanticümlecigi, kulid, "1", null);
            ac.ShowDialog();
        }

        private void navButton7_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            aktifpersonelliste();
        }

        private void navButton8_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            pasifpersonelliste();
        }

        private void gridControl2_MouseClick(object sender, MouseEventArgs e)
        {   
            if (e.Button == MouseButtons.Right && gridView2.SelectedRowsCount == 1)
            {
                if (Convert.ToDecimal(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "aktiflik")) == 1)
                {
                    barButtonItem15.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    barButtonItem16.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;                   

                }
                else if (Convert.ToDecimal(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "aktiflik")) == 0)
                {
                    barButtonItem15.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    barButtonItem16.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                menü2.ShowPopup(MousePosition);
            }
        
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut1 = new OleDbCommand("UPDATE personelkayit SET aktiflik=@aktiflik WHERE perid like'"  + Convert.ToString(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "perid")) + "'", baglanti);
            komut1.Parameters.AddWithValue("aktiflik", false);
            if (komut1.ExecuteNonQuery() == 1)
            {
                XtraMessageBox.Show("Kayıt Pasif Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            }
            else
            {
                XtraMessageBox.Show("Kayıt Pasif Edilemedi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            baglanti.Close();
            aktifpersonelliste();
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            personelkayit ac = new personelkayit(baglanticümlecigi, kulid, "2", Convert.ToString(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "perid")));
            ac.ShowDialog();
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut1 = new OleDbCommand("UPDATE personelkayit SET aktiflik=@aktiflik WHERE perid like'" + Convert.ToString(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "perid")) + "'", baglanti);
            komut1.Parameters.AddWithValue("aktiflik", true);
            if (komut1.ExecuteNonQuery() == 1)
            {
                XtraMessageBox.Show("Kayıt Aktif Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            }
            else
            {
                XtraMessageBox.Show("Kayıt Aktif Edilemedi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            baglanti.Close();
            pasifpersonelliste();
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut1 = new OleDbCommand("DELETE * FROM personelkayit WHERE perid like'" + Convert.ToString(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "perid")) + "'", baglanti);
            if (komut1.ExecuteNonQuery() == 1)
            {
                XtraMessageBox.Show("Kayıt Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            }
            else
            {
                XtraMessageBox.Show("Kayıt Silinemedi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            baglanti.Close();
            if (Convert.ToDecimal(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "aktiflik")) == 1)
            {
                aktifpersonelliste();

            }
            else if (Convert.ToDecimal(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "aktiflik")) == 0)
            {
                pasifpersonelliste();
            }
          
        }

        private void navButton9_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            personelrapor ac = new personelrapor("1", null);
            ac.Show();
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            personelrapor ac = new personelrapor("2", Convert.ToString(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "perid")));
            ac.Show();
        }
    }
}