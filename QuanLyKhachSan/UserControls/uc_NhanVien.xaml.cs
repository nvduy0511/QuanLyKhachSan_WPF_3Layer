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
using System.Collections.ObjectModel;
using BUS;
using DAL;

namespace GUI.UserControls
{

    public partial class uc_NhanVien : UserControl
    {
        ObservableCollection<NhanVien> list;
        public uc_NhanVien()
        {
            InitializeComponent();
            list = new ObservableCollection<NhanVien>(NhanVienBUS.GetInstance().getDataNhanVien());
            lvNhanVien.ItemsSource = list;

        }
        #region method
        void nhanData(NhanVien nv)
        {
            list.Add(nv);
            if (NhanVienBUS.GetInstance().addNhanVien(nv))
                MessageBox.Show("Thêm thành công!");
        }

        void SuaThongTinNhanVien(NhanVien nv)
        {
            // sửa để update lên list view
            NhanVien nhanVien_Sua = list.Where(s => s.MaNV.Equals(nv.MaNV)).FirstOrDefault();
            nhanVien_Sua.HoTen = nv.HoTen;
            nhanVien_Sua.GioiTinh = nv.GioiTinh;
            nhanVien_Sua.NTNS = nv.NTNS;
            nhanVien_Sua.Luong = nv.Luong;
            nhanVien_Sua.SDT = nv.SDT;
            nhanVien_Sua.CCCD = nv.CCCD;
            nhanVien_Sua.ChucVu = nv.ChucVu;
            nhanVien_Sua.DiaChi = nv.DiaChi;

            if (NhanVienBUS.GetInstance().updateNhanVien(nv))
            {
                MessageBox.Show("Update nhân viên thành công !");
            }

        }
        #endregion

        #region event
        private void click_ThemNV(object sender, RoutedEventArgs e)
        {
            Them_SuaNhanVien tnv = new Them_SuaNhanVien();
            tnv.themNhanVien = new Them_SuaNhanVien.CRUD(nhanData);
            tnv.ShowDialog();
        }
        

        private void click_XoaNV(object sender, RoutedEventArgs e)
        {
            NhanVien nv = (sender as Button).DataContext as NhanVien;
            var result = MessageBox.Show("Bạn có muốn xóa nhân viên " + nv.MaNV, "Thông báo", MessageBoxButton.YesNo);
            if(result == MessageBoxResult.Yes)
            {
                if (NhanVienBUS.GetInstance().deleteNhanVien(nv))
                {
                    list.Remove(nv);
                    MessageBox.Show("Xóa nhân viên thành công !");
                }
                    
            }
        }

        private void click_SuaNV(object sender, RoutedEventArgs e)
        {
            NhanVien nv = (sender as Button).DataContext as NhanVien;
            Them_SuaNhanVien themNhanVien = new Them_SuaNhanVien();
            themNhanVien.truyenNhanVien(nv);
            themNhanVien.suaNhanVien = new Them_SuaNhanVien.CRUD(SuaThongTinNhanVien);
            themNhanVien.ShowDialog();
        }
        #endregion



    }

}
