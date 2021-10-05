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
        public delegate void CRUD(NhanVien nv);

        public CRUD themNhanVien;
        public CRUD suaNhanVien;
        public CRUD truyenNhanVien;
        private string maNV;

        public Them_SuaNhanVien()
        {
            InitializeComponent();
            truyenNhanVien = new CRUD(nhanData);
        }
        public void nhanData(NhanVien nv)
        {
            txbTitle.Text = "Sửa nhân viên";
            txbHoTenNV.Text = nv.HoTen;
            txbCCCD.Text = nv.CCCD;
            txbChucVu.Text = nv.ChucVu;
            txbDiaChi.Text = nv.DiaChi;
            txbLuong.Text = nv.Luong.ToString();
            txbSDT.Text = nv.SDT;
            cbGioiTinh.Text = nv.GioiTinh;
            dtNTNS.Text = nv.NTNS.ToString();
            maNV = nv.MaNV.ToString();
        }

        #region event
        private void click_Huy(object sender, RoutedEventArgs e)
        {
            Window wd = Window.GetWindow(sender as Button);
            wd.Close();
            
        }

        private void click_ThemNV(object sender, RoutedEventArgs e)
        {
            NhanVien nhanVien = new NhanVien()
            {   
                HoTen = txbHoTenNV.Text,
                CCCD = txbCCCD.Text,
                ChucVu = txbChucVu.Text,
                DiaChi = txbDiaChi.Text,
                GioiTinh = cbGioiTinh.Text,
                Luong = (decimal.Parse(txbLuong.Text)),
                NTNS = DateTime.Parse(dtNTNS.SelectedDate.ToString()),
                SDT = txbSDT.Text
            };


            if (themNhanVien != null)
            {
                themNhanVien(nhanVien);
            }

            Window wd = Window.GetWindow(sender as Button);
            wd.Close();
        }

        private void click_Sua(object sender, RoutedEventArgs e)
        {
            NhanVien nhanVien = new NhanVien()
            {
                MaNV = int.Parse(maNV),
                HoTen = txbHoTenNV.Text,
                CCCD = txbCCCD.Text,
                ChucVu = txbChucVu.Text,
                DiaChi = txbDiaChi.Text,
                GioiTinh = cbGioiTinh.Text,
                Luong = (decimal.Parse(txbLuong.Text)),
                NTNS = DateTime.Parse(dtNTNS.SelectedDate.ToString()),
                SDT = txbSDT.Text
            };


            if (suaNhanVien != null)
            {
                suaNhanVien(nhanVien);
            }

            Window wd = Window.GetWindow(sender as Button);
            wd.Close();
        }
        #endregion
    }
}
