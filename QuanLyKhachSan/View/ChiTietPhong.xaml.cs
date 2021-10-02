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
using DAL.DTO;
namespace GUI.View
{
    /// <summary>
    /// Interaction logic for ChiTietPhong.xaml
    /// </summary>
    public partial class ChiTietPhong : Window
    {
        public ChiTietPhong()
        {
            InitializeComponent();
        }
        public ChiTietPhong(Phong_Custom phong)
        {
            InitializeComponent();
            txblTieuDe.Text += phong.MaPhong;
            txblTenKH.Text = phong.TenKH;
            txblSoNgay.Text = phong.SoNgayO.ToString();
            txblSoNguoi.Text = phong.SoNguoi.ToString();
            txblNgayDen.Text = phong.NgayDen.ToString();
            cbTinhTrang.Text = phong.TinhTrang;
            cbDonDep.Text = phong.DonDep;

        }

        private void click_Thoat(object sender, RoutedEventArgs e)
        {
            Window wd = Window.GetWindow(sender as Button);
            wd.Close();
        }
        ~ChiTietPhong()
        {
            Console.WriteLine("Huy CTP");
        }

        private void click_NhanPhong(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Nhận phòng");
        }

        private void click_ThanhToan(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thanh toán");
        }
    }
}
