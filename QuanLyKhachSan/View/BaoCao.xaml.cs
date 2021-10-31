using BUS;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for BaoCao.xaml
    /// </summary>
    public partial class BaoCao : Window
    {
        public BaoCao()
        {
            InitializeComponent();
        }

        private void reportViewer_Load(object sender, EventArgs e)
        {
            this.reportViewer.LocalReport.ReportPath = "Report.rdlc";
            var reportDataSource = new ReportDataSource("DataSet1", HoaDonBUS.GetInstance().GetHoaDons());
            this.reportViewer.LocalReport.DataSources.Clear(); //clear 
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer.RefreshReport();
        }
    }
}
