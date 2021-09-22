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
    /// Interaction logic for uc_QuanLyPhong.xaml
    /// </summary>
    public partial class uc_QuanLyPhong : UserControl
    {

        List<Phong> listPhong = new List<Phong>();

        public uc_QuanLyPhong()
        {
            InitializeComponent();

            listPhong.Add(new Phong() { SoPhong = 1, DonGia = 200000, SoNguoi = 2, TinhTrang = "Trong", LoaiPhong = "binh thuong" });
            listPhong.Add(new Phong() { SoPhong = 1, DonGia = 200000, SoNguoi = 2, TinhTrang = "Trong", LoaiPhong = "binh thuong" });
            listPhong.Add(new Phong() { SoPhong = 1, DonGia = 200000, SoNguoi = 2, TinhTrang = "Trong", LoaiPhong = "binh thuong" });
            listPhong.Add(new Phong() { SoPhong = 3, DonGia = 200000, SoNguoi = 2, TinhTrang = "Co nguoi", LoaiPhong = "Phong Gia Dinh" });
            listPhong.Add(new Phong() { SoPhong = 1, DonGia = 200000, SoNguoi = 2, TinhTrang = "Trong", LoaiPhong = "binh thuong" });
            listPhong.Add(new Phong() { SoPhong = 1, DonGia = 200000, SoNguoi = 2, TinhTrang = "Trong", LoaiPhong = "binh thuong" });
            listPhong.Add(new Phong() { SoPhong = 1, DonGia = 200000, SoNguoi = 2, TinhTrang = "Trong", LoaiPhong = "binh thuong" });
            listPhong.Add(new Phong() { SoPhong = 3, DonGia = 200000, SoNguoi = 2, TinhTrang = "Co nguoi", LoaiPhong = "Phong Gia Dinh" });
            listPhong.Add(new Phong() { SoPhong = 1, DonGia = 200000, SoNguoi = 2, TinhTrang = "Trong", LoaiPhong = "binh thuong" });
            listPhong.Add(new Phong() { SoPhong = 1, DonGia = 200000, SoNguoi = 2, TinhTrang = "Trong", LoaiPhong = "binh thuong" });
            listPhong.Add(new Phong() { SoPhong = 1, DonGia = 200000, SoNguoi = 2, TinhTrang = "Trong", LoaiPhong = "binh thuong" });
            listPhong.Add(new Phong() { SoPhong = 3, DonGia = 200000, SoNguoi = 2, TinhTrang = "Co nguoi", LoaiPhong = "Phong Gia Dinh" });

            listPhong.Add(new Phong() { SoPhong = 1, DonGia = 200000, SoNguoi = 2, TinhTrang = "Trong", LoaiPhong = "binh thuong" });
            listPhong.Add(new Phong() { SoPhong = 1, DonGia = 200000, SoNguoi = 2, TinhTrang = "Trong", LoaiPhong = "binh thuong" });
            listPhong.Add(new Phong() { SoPhong = 1, DonGia = 200000, SoNguoi = 2, TinhTrang = "Trong", LoaiPhong = "binh thuong" });
            listPhong.Add(new Phong() { SoPhong = 3, DonGia = 200000, SoNguoi = 2, TinhTrang = "Co nguoi", LoaiPhong = "Phong Gia Dinh" });
            listPhong.Add(new Phong() { SoPhong = 1, DonGia = 200000, SoNguoi = 2, TinhTrang = "Trong", LoaiPhong = "binh thuong" });
            listPhong.Add(new Phong() { SoPhong = 1, DonGia = 200000, SoNguoi = 2, TinhTrang = "Trong", LoaiPhong = "binh thuong" });
            listPhong.Add(new Phong() { SoPhong = 1, DonGia = 200000, SoNguoi = 2, TinhTrang = "Trong", LoaiPhong = "binh thuong" });
            listPhong.Add(new Phong() { SoPhong = 3, DonGia = 200000, SoNguoi = 2, TinhTrang = "Co nguoi", LoaiPhong = "Phong Gia Dinh" });
            lsvPhong.ItemsSource = listPhong;
        }

        private void btnThemPhong_Click(object sender, RoutedEventArgs e)
        {
            NhapThemPhong nhapThemPhong = new NhapThemPhong();
            nhapThemPhong.ShowDialog();
        }

        private void btnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            CapNhatThongTinPhong capNhatThongTinPhong = new CapNhatThongTinPhong();
            capNhatThongTinPhong.ShowDialog();
        }
    }

    public class Phong
    {

        private string loaiPhong;
        private string tinhTrang;
        private int soNguoi;
        private int donGia;
        private int soPhong;


        public int SoPhong { get => soPhong; set => soPhong = value; }
        public int DonGia { get => donGia; set => donGia = value; }
        public int SoNguoi { get => soNguoi; set => soNguoi = value; }
        public string TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public string LoaiPhong { get => loaiPhong; set => loaiPhong = value; }
    }
}
