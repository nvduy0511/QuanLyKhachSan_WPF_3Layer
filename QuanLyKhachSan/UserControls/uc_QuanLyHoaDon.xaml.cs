using GUI.View;
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

namespace GUI.UserControls
{
    /// <summary>
    /// Interaction logic for uc_QuanLyHoaDon.xaml
    /// </summary>
    public partial class uc_QuanLyHoaDon : UserControl
    {

        List<HoaDon> hoaDons = new List<HoaDon>();

        public uc_QuanLyHoaDon()
        {
            InitializeComponent();

            hoaDons.Add(new HoaDon { MaHD = "HD01", NgayLap = "22/09/2021", MaNV = "NV01", SoPhong = "Phong 1", MaPT = "PT01", TongTien = 10000000 });
            hoaDons.Add(new HoaDon { MaHD = "HD02", NgayLap = "22/09/2021", MaNV = "NV01", SoPhong = "Phong 2", MaPT = "PT02", TongTien = 10000000 });
            hoaDons.Add(new HoaDon { MaHD = "HD03", NgayLap = "22/09/2021", MaNV = "NV01", SoPhong = "Phong 3", MaPT = "PT03", TongTien = 10000000 });
            hoaDons.Add(new HoaDon { MaHD = "HD04", NgayLap = "22/09/2021", MaNV = "NV01", SoPhong = "Phong 4", MaPT = "PT04", TongTien = 10000000 });
            hoaDons.Add(new HoaDon { MaHD = "HD05", NgayLap = "22/09/2021", MaNV = "NV01", SoPhong = "Phong 5", MaPT = "PT05", TongTien = 10000000 });
            lsvHoaDon.ItemsSource = hoaDons;
        }


        #region Event
        private void btnThemHoaDon_Click(object sender, RoutedEventArgs e)
        {
            NhapThongTinHoaDon nhapThongTinHoaDon = new NhapThongTinHoaDon();
            nhapThongTinHoaDon.ShowDialog();
        }

        private void btnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            CapNhatThongTinHoaDon capNhatThongTinHoaDon = new CapNhatThongTinHoaDon();
            capNhatThongTinHoaDon.ShowDialog();
        }
        #endregion
    }

    public class HoaDon
    {
        private int tongTien;
        private string maPT;
        private string maNV;
        private string soPhong;
        private string ngayLap;
        private string maHD;

        public string MaHD { get => maHD; set => maHD = value; }
        public string NgayLap { get => ngayLap; set => ngayLap = value; }
        public string SoPhong { get => soPhong; set => soPhong = value; }
        public string MaPT { get => maPT; set => maPT = value; }
        public int TongTien { get => tongTien; set => tongTien = value; }
        public string MaNV { get => maNV; set => maNV = value; }
    }
}
