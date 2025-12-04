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
using System.Data.SqlClient;


namespace Staj
{
    public partial class kullaniciprofili : DevExpress.XtraEditors.XtraForm
    {
        string baglanticümlesi, kulid;
        public kullaniciprofili(string baglanticümlesim,string kulidim)
        {
            InitializeComponent();
            baglanticümlesi = baglanticümlesim;
            kulid = kulidim;
        }
        public OleDbConnection baglanti = new OleDbConnection();
        string eskisifre;
        public void vericek()
        {
            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM kullanicilar WHERE kulid like '" + kulid + "'", baglanti);
            OleDbDataReader oku = null;
            oku = cmd.ExecuteReader();
            while (oku.Read())
            {
                labelControl7.Text = oku["kulisim"].ToString() + " " + oku["kulsoyisim"].ToString();
                labelControl8.Text = oku["kule_mail"].ToString();
                labelControl9.Text = oku["kulil"].ToString();
                labelControl10.Text = oku["kulilce"].ToString();
                labelControl11.Text = oku["kulgsm"].ToString();
                labelControl12.Text = oku["kuladres"].ToString();
                pictureEdit1.Image = Image.FromFile(Application.StartupPath + "\\profil\\" + oku["kulresim"].ToString());
                eskisifre = oku["kulsifre"].ToString();
            }
            oku.Close();
            baglanti.Close();     
        }
        private void kullaniciprofili_Load(object sender, EventArgs e)
        {
            baglanti.ConnectionString = baglanticümlesi.ToString();
            vericek();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            sifredegis ac = new sifredegis(baglanticümlesi, kulid, eskisifre);
            ac.ShowDialog();
        }
    }
}