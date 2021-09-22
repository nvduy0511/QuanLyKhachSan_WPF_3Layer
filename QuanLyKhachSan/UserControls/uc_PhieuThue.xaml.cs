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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GUI.View;

namespace GUI.UserControls
{

    public partial class uc_PhieuThue : UserControl
    {
        public uc_PhieuThue()
        {
            InitializeComponent();
            List<QL_PhieuThue> items = new List<QL_PhieuThue>();
            items.Add(new QL_PhieuThue() { soPT = "PT001", soPhong = "P.101", tenKH = "Nguyen Van A", ngayLapPhieu = DateTime.Now,ngayBatDau= new DateTime(2021,09,19)});
            items.Add(new QL_PhieuThue() { soPT = "PT001", soPhong = "P.101", tenKH = "Nguyen Van A", ngayLapPhieu = DateTime.Now, ngayBatDau = new DateTime(2021, 09, 19) });
            items.Add(new QL_PhieuThue() { soPT = "PT001", soPhong = "P.101", tenKH = "Nguyen Van A", ngayLapPhieu = DateTime.Now, ngayBatDau = new DateTime(2021, 09, 19) });
            items.Add(new QL_PhieuThue() { soPT = "PT001", soPhong = "P.101", tenKH = "Nguyen Van A", ngayLapPhieu = DateTime.Now, ngayBatDau = new DateTime(2021, 09, 19) });
            items.Add(new QL_PhieuThue() { soPT = "PT001", soPhong = "P.101", tenKH = "Nguyen Van A", ngayLapPhieu = DateTime.Now, ngayBatDau = new DateTime(2021, 09, 19) });
            items.Add(new QL_PhieuThue() { soPT = "PT001", soPhong = "P.101", tenKH = "Nguyen Van A", ngayLapPhieu = DateTime.Now, ngayBatDau = new DateTime(2021, 09, 19) });
            items.Add(new QL_PhieuThue() { soPT = "PT001", soPhong = "P.101", tenKH = "Nguyen Van A", ngayLapPhieu = DateTime.Now, ngayBatDau = new DateTime(2021, 09, 19) });
            items.Add(new QL_PhieuThue() { soPT = "PT001", soPhong = "P.101", tenKH = "Nguyen Van A", ngayLapPhieu = DateTime.Now, ngayBatDau = new DateTime(2021, 09, 19) });
            items.Add(new QL_PhieuThue() { soPT = "PT001", soPhong = "P.101", tenKH = "Nguyen Van A", ngayLapPhieu = DateTime.Now, ngayBatDau = new DateTime(2021, 09, 19) });
            items.Add(new QL_PhieuThue() { soPT = "PT001", soPhong = "P.101", tenKH = "Nguyen Van A", ngayLapPhieu = DateTime.Now, ngayBatDau = new DateTime(2021, 09, 19) });
            items.Add(new QL_PhieuThue() { soPT = "PT001", soPhong = "P.101", tenKH = "Nguyen Van A", ngayLapPhieu = DateTime.Now, ngayBatDau = new DateTime(2021, 09, 19) });
            items.Add(new QL_PhieuThue() { soPT = "PT001", soPhong = "P.101", tenKH = "Nguyen Van A", ngayLapPhieu = DateTime.Now, ngayBatDau = new DateTime(2021, 09, 19) });
            items.Add(new QL_PhieuThue() { soPT = "PT001", soPhong = "P.101", tenKH = "Nguyen Van A", ngayLapPhieu = DateTime.Now, ngayBatDau = new DateTime(2021, 09, 19) });
            items.Add(new QL_PhieuThue() { soPT = "PT001", soPhong = "P.101", tenKH = "Nguyen Van A", ngayLapPhieu = DateTime.Now, ngayBatDau = new DateTime(2021, 09, 19) });
            items.Add(new QL_PhieuThue() { soPT = "PT001", soPhong = "P.101", tenKH = "Nguyen Van A", ngayLapPhieu = DateTime.Now, ngayBatDau = new DateTime(2021, 09, 19) });
            items.Add(new QL_PhieuThue() { soPT = "PT001", soPhong = "P.101", tenKH = "Nguyen Van A", ngayLapPhieu = DateTime.Now, ngayBatDau = new DateTime(2021, 09, 19) });
            items.Add(new QL_PhieuThue() { soPT = "PT001", soPhong = "P.101", tenKH = "Nguyen Van A", ngayLapPhieu = DateTime.Now, ngayBatDau = new DateTime(2021, 09, 19) });
            items.Add(new QL_PhieuThue() { soPT = "PT001", soPhong = "P.101", tenKH = "Nguyen Van A", ngayLapPhieu = DateTime.Now, ngayBatDau = new DateTime(2021, 09, 19) });
            items.Add(new QL_PhieuThue() { soPT = "PT001", soPhong = "P.101", tenKH = "Nguyen Van A", ngayLapPhieu = DateTime.Now, ngayBatDau = new DateTime(2021, 09, 19) });
            items.Add(new QL_PhieuThue() { soPT = "PT001", soPhong = "P.101", tenKH = "Nguyen Van A", ngayLapPhieu = DateTime.Now, ngayBatDau = new DateTime(2021, 09, 19) });
            items.Add(new QL_PhieuThue() { soPT = "PT001", soPhong = "P.101", tenKH = "Nguyen Van A", ngayLapPhieu = DateTime.Now, ngayBatDau = new DateTime(2021, 09, 19) });
            items.Add(new QL_PhieuThue() { soPT = "PT001", soPhong = "P.101", tenKH = "Nguyen Van A", ngayLapPhieu = DateTime.Now, ngayBatDau = new DateTime(2021, 09, 19) });
            items.Add(new QL_PhieuThue() { soPT = "PT001", soPhong = "P.101", tenKH = "Nguyen Van A", ngayLapPhieu = DateTime.Now, ngayBatDau = new DateTime(2021, 09, 19) });
            items.Add(new QL_PhieuThue() { soPT = "PT001", soPhong = "P.101", tenKH = "Nguyen Van A", ngayLapPhieu = DateTime.Now, ngayBatDau = new DateTime(2021, 09, 19) });
            lvUsers.ItemsSource = items;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            QL_PhieuThue us = (sender as Button).DataContext as QL_PhieuThue;
            MessageBox.Show(us.tenKH);
        }

        private void click_DatPhong(object sender, RoutedEventArgs e)
        {
            DatPhong dp = new DatPhong();
            dp.ShowDialog();
        }
    }

    public class QL_PhieuThue
    {
        public string soPT { get; set; }

        public string soPhong { get; set; }

        public string tenKH { get; set; }

        public DateTime ngayLapPhieu { get; set; }

        public DateTime ngayBatDau { get; set; }

        public DateTime? ngayKetThuc { get; set; }
    }
}
