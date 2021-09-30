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
using DAL;


namespace GUI.View
{
    
    public partial class Them_SuaNhanVien : Window
    {
        public delegate void truyenData(NhanVien nv);

        public truyenData truyenNhanVien;

        public Them_SuaNhanVien()
        {
            InitializeComponent();
        }
        public Them_SuaNhanVien(NhanVien nv)
        {
            InitializeComponent();
            txbHoTenNV.Text = nv.HoTen;
            txbCCCD.Text = nv.CCCD;
            txbChucVu.Text = nv.ChucVu;
            txbDiaChi.Text = nv.DiaChi;
            txbLuong.Text = nv.Luong.ToString();
            txbSDT.Text = nv.SDT;
            cbGioiTinh.Text = nv.GioiTinh;
            dtNTNS.Text = nv.NTNS.ToString();
            txbTitle.Text = "Sửa nhân viên " + nv.MaNV;
        }

        private void click_Huy(object sender, RoutedEventArgs e)
        {
            Window wd = Window.GetWindow(sender as Button);
            wd.Close();
            
        }

        private void click_ThemNV(object sender, RoutedEventArgs e)
        {
            NhanVien nhanVien = new NhanVien()
            {   HoTen = txbHoTenNV.Text, 
                CCCD = txbCCCD.Text,
                ChucVu = txbChucVu.Text ,
                DiaChi = txbDiaChi.Text,
                GioiTinh= cbGioiTinh.Text ,
                Luong = (decimal.Parse(txbLuong.Text)), 
                NTNS =  DateTime.Parse( dtNTNS.SelectedDate.ToString()),
                SDT = txbSDT.Text
            };

            if(truyenNhanVien != null)
            {
                truyenNhanVien(nhanVien);
            }

            Window wd = Window.GetWindow(sender as Button);
            wd.Close();
        }
    }
}
