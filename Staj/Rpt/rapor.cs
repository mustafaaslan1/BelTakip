using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Staj
{
    public partial class rapor : DevExpress.XtraEditors.XtraForm
    {
        string degisken, deger1;
        public rapor(string degiskenim, string degerim1)
        {
            InitializeComponent();
            deger1 = degerim1;
            degisken = degiskenim;
        }
        ReportDocument cryRpt = new ReportDocument();
        TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
        TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
        ConnectionInfo crConnectionInfo = new ConnectionInfo();
        Tables CrTables;
        private void rapor_Load(object sender, EventArgs e)
        {
            ParameterDiscreteValue gelen = new ParameterDiscreteValue();
            ParameterValues gelen1 = new ParameterValues();

            ParameterDiscreteValue gelen2 = new ParameterDiscreteValue();
            ParameterValues gelen3 = new ParameterValues();
            //crConnectionInfo.Password = "1234"; veritabanı şifre kodu
            if (degisken == "1")
            {
                string al = Application.StartupPath + "\\Rpt\\araclistesi.rpt";
                cryRpt.Load(al);

            }
            if (degisken == "2")
            {
                string al = Application.StartupPath + "\\Rpt\\aracdetay.rpt";
                cryRpt.Load(al);
                gelen.Value = deger1;
                gelen1.Add(gelen);
                cryRpt.DataDefinition.ParameterFields["id"].ApplyCurrentValues(gelen1);
                cryRpt.DataDefinition.ParameterFields["id1"].ApplyCurrentValues(gelen1);

            }
            CrTables = cryRpt.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);

            }
            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();
        }
    }
}