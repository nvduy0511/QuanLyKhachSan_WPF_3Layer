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
    /// Interaction logic for uc_Phong.xaml
    /// </summary>
    public partial class uc_Phong : UserControl
    {
        public uc_Phong()
        {
            InitializeComponent();
            initListPhong();
        }

        private void initListPhong()
        {
            List<Phong> lsPhong = new List<Phong>();
            lsPhong.Add(new Phong() { MaPhong = "P.101", TinhTrang = "Đang thuê", TenKH = "Nguyễn Văn Duy", SoNgayO = 2, DonDep = "Chưa dọn dẹp" });
            lsPhong.Add(new Phong() { MaPhong = "P.102", TinhTrang = "Phòng trống", TenKH = "Phòng trống", SoNgayO = 2, DonDep = "Chưa dọn dẹp" });
            lsPhong.Add(new Phong() { MaPhong = "P.103", TinhTrang = "Đang thuê", TenKH = "Nguyễn Việt Quang", SoNgayO = 2, DonDep = "Đã dọn dẹp" });
            lsPhong.Add(new Phong() { MaPhong = "P.104", TinhTrang = "Đã đặt", TenKH = "Trần Hải Quang", SoNgayO = 2, DonDep = "Đã dọn dẹp" });
            lsPhong.Add(new Phong() { MaPhong = "P.105", TinhTrang = "Đang thuê", TenKH = "Bùi Thị Hồng Hường", SoNgayO = 2, DonDep = "Đã dọn dẹp" });
            lsPhong.Add(new Phong() { MaPhong = "P.102", TinhTrang = "Phòng trống", TenKH = "Phòng trống", SoNgayO = 2, DonDep = "Sửa chữa" });
            lvPhong.ItemsSource = lsPhong;
        }

        private void lvPhong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show((lvPhong.SelectedItem as Phong).MaPhong);
        }
    }
    public class Phong
    {
        private string maPhong;
        private string tinhTrang;
        private string tenKH;
        private int soNgayO;
        private string donDep;

        public string MaPhong { get => maPhong; set => maPhong = value; }
        public string TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public int SoNgayO { get => soNgayO; set => soNgayO = value; }
        public string DonDep { get => donDep; set => donDep = value; }
    }
}
