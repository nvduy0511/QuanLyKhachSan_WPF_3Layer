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
    /// Interaction logic for ChiTietPhong.xaml
    /// </summary>
    public partial class ChiTietPhong : Window
    {
        public ChiTietPhong()
        {
            InitializeComponent();
        }
        public ChiTietPhong(string maPhong,string tenKH, string soNgay, string soNguoi, DateTime? ngayDen ,string tinhTrang , string donDep)
        {
            InitializeComponent();
            txblTieuDe.Text += maPhong;
            txblTenKH.Text = tenKH;
            txblSoNgay.Text = soNgay;
            txblSoNguoi.Text = soNguoi;
            txblNgayDen.Text = ngayDen.ToString();
            cbTinhTrang.Text = tinhTrang;
            cbDonDep.Text = donDep;

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
