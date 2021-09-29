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
    /// <summary>
    /// Interaction logic for uc_NhanVien.xaml
    /// </summary>
    public partial class uc_NhanVien : UserControl
    {
        ObservableCollection<NhanVien> list = new ObservableCollection<NhanVien>();
        public uc_NhanVien()
        {
            InitializeComponent();

            bNhanVien.SetDataSource(lvNhanVien);
        }

        //private void intitListNV()
        //{
        //    list.Add(new NhanVien() { CCCD = "251212908", ChucVu = "Giám đốc", DiaChi = "Quận 10", GioiTinh = "Nam", HoTenNV = "Nguyễn Văn Duy", Luong = 22000000F, MaNV = "NV001", NTNS = new DateTime(2001, 11, 05).Date, SDT = "0917654234" });
        //    list.Add(new NhanVien() { CCCD = "251234551", ChucVu = "Nhân viên", DiaChi = "46/1, đường 26, Bình Thạnh, Tp.HCM", GioiTinh = "Nữ", HoTenNV = "Phạm Thị Tuyết", Luong = 10000000F, MaNV = "NV002", NTNS = new DateTime(2002, 09, 01).Date, SDT = "0123987678" });
        //    list.Add(new NhanVien() { CCCD = "151212345", ChucVu = "Thu ngân", DiaChi = "Quận 7", GioiTinh = "Nam", HoTenNV = "Nguyễn Việt Quang", Luong = 15000000F, MaNV = "NV003", NTNS = new DateTime(2000, 12, 01).Date, SDT = "0987658789" });
        //    list.Add(new NhanVien() { CCCD = "231414356", ChucVu = "Tiếp tân", DiaChi = "Quận 8", GioiTinh = "Nam", HoTenNV = "Trần Mạnh Hùng", Luong = 16000000F, MaNV = "NV004", NTNS = new DateTime(2000, 08, 06).Date, SDT = "087987564" });
        //    list.Add(new NhanVien() { CCCD = "124242445", ChucVu = "Thư ký", DiaChi = "Quận 10", GioiTinh = "Nam", HoTenNV = "Bá Văn Kiệt", Luong = 17000000F, MaNV = "NV005", NTNS = new DateTime(2002, 12, 07).Date, SDT = "01235769867" });
        //    lvNhanVien.ItemsSource = list;
        //}

        private void click_ThemNV(object sender, RoutedEventArgs e)
        {
            ThemNhanVien tnv = new ThemNhanVien();
            tnv.truyenNhanVien = new ThemNhanVien.truyenData(nhanData);
            tnv.ShowDialog();
        }
        void nhanData(NhanVien nv)
        {
            list.Add(nv);
            bNhanVien.addNhanVien(nv);
            MessageBox.Show("Thêm thành công!");
        }

        private void click_XoaNV(object sender, RoutedEventArgs e)
        {
            NhanVien nv = (sender as Button).DataContext as NhanVien;
            list.Remove(nv);
        }

    }

}
