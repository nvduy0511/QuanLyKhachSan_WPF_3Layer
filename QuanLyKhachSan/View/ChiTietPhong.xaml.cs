using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using DAL.DTO;
namespace GUI.View
{
    /// <summary>
    /// Interaction logic for ChiTietPhong.xaml
    /// </summary>
    public partial class ChiTietPhong : Window
    {
        
        public delegate void truyenDataPhong(Phong_Custom phong);
        public truyenDataPhong truyenData;
        private string maCTPhieuThue;
        ObservableCollection<DichVu_DaChon> obDichVu;

        private int soThuTu;
        public ChiTietPhong()
        {
            InitializeComponent();
            soThuTu = 1;
            obDichVu = new ObservableCollection<DichVu_DaChon>();
            lvSuDungDV.ItemsSource = obDichVu;
            truyenData = new truyenDataPhong(setDataPhongCustom);
        }
        void setDataPhongCustom(Phong_Custom phong)
        {
            txblTieuDe.Text = phong.MaPhong;
            txblTenKH.Text = phong.TenKH;
            txblSoNgay.Text = phong.SoNgayO.ToString();
            txblSoNguoi.Text = phong.SoNguoi.ToString();
            txblNgayDen.Text = phong.NgayDen.ToString();
            cbTinhTrang.Text = phong.TinhTrang;
            cbDonDep.Text = phong.DonDep;

            maCTPhieuThue = phong.MaCTPT.ToString();
        }
        ~ChiTietPhong()
        {
            Console.WriteLine("Huy CTP");
        }

        private void click_Thoat(object sender, RoutedEventArgs e)
        {
            Window wd = Window.GetWindow(sender as Button);
            wd.Close();
        }
        

        private void click_NhanPhong(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Nhận phòng");
        }

        private void click_ThanhToan(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thanh toán");
        }

        private void click_ThemDV(object sender, RoutedEventArgs e)
        {
            CTP_ThemDV cTP_ThemDV = new CTP_ThemDV(maCTPhieuThue);
            cTP_ThemDV.truyenData = new CTP_ThemDV.Delegate_CTPDV(nhanData);
            cTP_ThemDV.ShowDialog();
        }

        void nhanData(ObservableCollection<DichVu_DaChon> obDVCT)
        {
            foreach (var item in obDVCT)
            {
                item.STT = soThuTu++;
                obDichVu.Add(item);
            }
        }

    }
}
