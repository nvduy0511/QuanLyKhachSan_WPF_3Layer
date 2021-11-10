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
        List<int> lsThang;
        List<int> lsNam;
        public BaoCao()
        {
            InitializeComponent();
            lsThang = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            cbThang.ItemsSource = lsThang;
            lsNam = new List<int>();
            for (int i = 2019; i <= 2050; i++)
            {
                lsNam.Add(i);
            }
            cbNam.ItemsSource = lsNam;
            cbThang.Text = "10";
            cbNam.Text = "2021";
        }

        private void reportViewer_Load(object sender, EventArgs e)
        {
            this.reportViewer.LocalReport.ReportPath = "Report.rdlc";
            var reportDataSource = new ReportDataSource("DataSet1", HoaDonBUS.GetInstance().layHoaDonTheoThangNam(10, 2021));
            this.reportViewer.LocalReport.DataSources.Clear(); //clear 
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer.RefreshReport();
        }

        private void cbThang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int thang = int.Parse(cbThang.SelectedValue.ToString());
            int nam;
            if(cbNam.SelectedValue == null)
            {
                nam = 2020;
            }
            else
            {
                nam = int.Parse(cbNam.SelectedValue.ToString());
            }
            
            var reportDataSource = new ReportDataSource("DataSet1", HoaDonBUS.GetInstance().layHoaDonTheoThangNam(thang,nam));
            this.reportViewer.LocalReport.DataSources.Clear(); //clear 
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer.RefreshReport();
        }

        private void cbNam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int thang = int.Parse(cbThang.SelectedValue.ToString());
            int nam;
            if (cbNam.SelectedValue == null)
            {
                nam = 2020;
            }
            else
            {
                nam = int.Parse(cbNam.SelectedValue.ToString());
            }
            var reportDataSource = new ReportDataSource("DataSet1", HoaDonBUS.GetInstance().layHoaDonTheoThangNam(thang, nam));
            this.reportViewer.LocalReport.DataSources.Clear(); //clear 
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer.RefreshReport();
        }
    }
}
