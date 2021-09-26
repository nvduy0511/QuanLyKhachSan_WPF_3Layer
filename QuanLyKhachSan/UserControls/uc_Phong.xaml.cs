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

namespace GUI.UserControls
{
    /// <summary>
    /// Interaction logic for uc_Phong.xaml
    /// </summary>
    public partial class uc_Phong : UserControl
    {
        #region Khai bao bien
        List<Phong> listKhoiTao = new List<Phong>();
        List<Phong> list = new List<Phong>();
        List<Phong> lsTrong = new List<Phong>();
        List<Phong> lsPhongDon = new List<Phong>();
        List<Phong> lsPhongDoi = new List<Phong>();
        List<Phong> lsPhongGiaDinh = new List<Phong>();

        #endregion
        public uc_Phong()
        {
            InitializeComponent();
            initListPhong();
            initList();
            loadList();
        }

        private void loadList()
        {
            foreach(Phong i in list)
            {
                foreach(Phong j in listKhoiTao)
                {
                    if (i.MaPhong.Equals(j.MaPhong))
                    {
                        j.MaPhong = i.MaPhong;
                        j.LoaiPhong = i.LoaiPhong;
                        j.NgayDen = i.NgayDen;
                        j.SoNgayO = i.SoNgayO;
                        j.SoNguoi = i.SoNguoi;
                        j.TenKH = i.TenKH;
                        j.TinhTrang = i.TinhTrang;
                    }
                }
            }
            lsPhongDon = listKhoiTao.Where(p => p.LoaiPhong.Equals("Phòng đơn")).ToList();
            lsPhongDoi = listKhoiTao.Where(p => p.LoaiPhong.Equals("Phòng đôi")).ToList();
            lsPhongGiaDinh = listKhoiTao.Where(p => p.LoaiPhong.Equals("Phòng gia đình")).ToList();
            lvPhongDon.ItemsSource = lsPhongDon;
            lvPhongDoi.ItemsSource = lsPhongDoi;
            lvPhongGiaDinh.ItemsSource = lsPhongGiaDinh;
        }

        private void initList()
        {
            for (int i = 0; i < 5; i++)
            {
                listKhoiTao.Add(new Phong()
                {
                    MaPhong = "P.10"+i,
                    TinhTrang = "Phòng trống",
                    DonDep = "Đã dọn dẹp",
                    LoaiPhong = "Phòng đơn"
                });
            }
            for (int i = 0; i < 5; i++)
            {
                listKhoiTao.Add(new Phong()
                {
                    MaPhong = "P.20" + i,
                    TinhTrang = "Phòng trống",
                    DonDep = "Đã dọn dẹp",
                    LoaiPhong = "Phòng đôi"
                });
            }
            for (int i = 0; i < 5; i++)
            {
                listKhoiTao.Add(new Phong()
                {
                    MaPhong = "P.30" + i,
                    TinhTrang = "Phòng trống",
                    DonDep = "Đã dọn dẹp",
                    LoaiPhong = "Phòng gia đình"
                });
            }
        }
        #region Method
        private void initListPhong()
        {
            list.Add(new Phong() { MaPhong = "P.101", TinhTrang = "Phòng đang thuê", 
                TenKH = "Nguyễn Văn Duy", SoNgayO = 2, 
                DonDep = "Đã dọn dẹp", SoNguoi=1 , 
                LoaiPhong="Phòng đơn" ,
                NgayDen = new DateTime(2021,09,24)});
            list.Add(new Phong() { MaPhong = "P.102",
                TinhTrang = "Phòng trống", 
                DonDep = "Chưa dọn dẹp",
                LoaiPhong = "Phòng đơn" });
            list.Add(new Phong() { MaPhong = "P.103",
                TinhTrang = "Phòng đang thuê",
                TenKH = "Nguyễn Việt Quang", SoNgayO = 2, 
                DonDep = "Đã dọn dẹp",  SoNguoi = 1 , 
                LoaiPhong = "Phòng đơn", 
                NgayDen = new DateTime(2021, 09, 24) });
            list.Add(new Phong() { MaPhong = "P.104", 
                TinhTrang = "Phòng đã đặt", 
                TenKH = "Trần Hải Quang", SoNgayO = 2, 
                DonDep = "Đã dọn dẹp", SoNguoi = 1, 
                LoaiPhong = "Phòng đơn", 
                NgayDen = new DateTime(2021, 09, 24) });
            //list.Add(new Phong() { MaPhong = "P.201", 
            //    TinhTrang = "Phòng đang thuê", 
            //    TenKH = "Bùi Thị Hồng Hường", 
            //    SoNgayO = 2, DonDep = "Đã dọn dẹp", 
            //    SoNguoi = 2, LoaiPhong = "Phòng đôi", 
            //    NgayDen = new DateTime(2021, 09, 24) });
            //list.Add(new Phong() { MaPhong = "P.202", 
            //    TinhTrang = "Phòng trống", SoNgayO = 2, 
            //    DonDep = "Sửa chữa", SoNguoi = 2, 
            //    LoaiPhong = "Phòng đôi" });
            //list.Add(new Phong() { MaPhong = "P.203", 
            //    TinhTrang = "Phòng đang thuê", 
            //    TenKH = "Bùi Thị Hồng Hường", SoNgayO = 2, 
            //    DonDep = "Đã dọn dẹp", SoNguoi = 2, 
            //    LoaiPhong = "Phòng đôi", NgayDen = new DateTime(2021, 09, 24) });
            //list.Add(new Phong() { MaPhong = "P.204", 
            //    TinhTrang = "Phòng trống",
            //    DonDep = "Đã dọn dẹp", 
            //    LoaiPhong = "Phòng đôi" });
            //list.Add(new Phong() { MaPhong = "P.205", 
            //    TinhTrang = "Phòng đang thuê",
            //    TenKH = "Bùi Thị Hồng Hường", 
            //    SoNgayO = 2, DonDep = "Đã dọn dẹp", 
            //    SoNguoi = 4, LoaiPhong = "Phòng gia đình",
            //    NgayDen = new DateTime(2021, 09, 24) });
            //list.Add(new Phong() { MaPhong = "P.301", 
            //    TinhTrang = "Phòng đang thuê", 
            //    TenKH = "Bùi Thị Hồng Hường", SoNgayO = 2,
            //    DonDep = "Đã dọn dẹp", SoNguoi = 4, 
            //    LoaiPhong = "Phòng gia đình", NgayDen = new DateTime(2021, 09, 24) });
            //list.Add(new Phong() { MaPhong = "P.302", 
            //    TinhTrang = "Phòng trống", 
            //    DonDep = "Đã dọn dẹp", 
            //    LoaiPhong = "Phòng gia đình"});
            //list.Add(new Phong() { MaPhong = "P.303", 
            //    TinhTrang = "Phòng đã đặt", TenKH = "Trần Hải Quang",
            //    SoNgayO = 2, DonDep = "Đã dọn dẹp", SoNguoi = 3, 
            //    LoaiPhong = "Phòng gia đình", NgayDen = new DateTime(2021, 09, 24) });

            //lsPhongDon = list.Where(p => p.LoaiPhong.Equals("Phòng đơn")).ToList();
            //lsPhongDoi = list.Where(p => p.LoaiPhong.Equals("Phòng đôi")).ToList();
            //lsPhongGiaDinh = list.Where(p => p.LoaiPhong.Equals("Phòng gia đình")).ToList();

            //lvPhongDon.ItemsSource = lsPhongDon;
            //lvPhongDoi.ItemsSource = lsPhongDoi;
            //lvPhongGiaDinh.ItemsSource = lsPhongGiaDinh;

            lvPhongDon.PreviewMouseLeftButtonUp += LvPhongDon_PreviewMouseLeftButtonUp;
            lvPhongDoi.PreviewMouseLeftButtonUp += LvPhongDon_PreviewMouseLeftButtonUp;
            lvPhongGiaDinh.PreviewMouseLeftButtonUp += LvPhongDon_PreviewMouseLeftButtonUp;
            initEvent();

        }

        private void LvPhongDon_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ListView lv = sender as ListView;
            MessageBox.Show((lv.SelectedItem as Phong).MaPhong);
            ChiTietPhong ct = new ChiTietPhong();
            ct.ShowDialog();
            lv.UnselectAll();
        }

        private void initEvent()
        {
            //Khởi tạo sự kiện click cho RadioButton
            rdPhongTrong.Click += rb_Click;
            rdPhongDaDat.Click += rb_Click;
            rdPhongDangThue.Click += rb_Click;
            rdPhongDon.Click += rb_Click;
            rdPhongDoi.Click += rb_Click;
            rdPhongGiaDinh.Click += rb_Click;
            rdDaDonDep.Click += rb_Click;
            rdChuaDonDep.Click += rb_Click;
            rdSuaChua.Click += rb_Click;
            rdTatCaPhong.Click += rb_Click;
            rdTatCaLoaiPhong.Click += rb_Click;
            rdTatCa.Click += rb_Click;

        }

        private bool PhongFilter(object obj)
        {
            Phong ph = obj as Phong;
            RadioButton radioTinhTrang = null;
            RadioButton radioDonDep = null;

            foreach (RadioButton i in spTrangThai.Children)
            {
                if (i.IsChecked.Value == true)
                {
                    radioTinhTrang = i;
                }
            }
            foreach (RadioButton j in spDonDep.Children)
            {
                if ( j.IsChecked.Value == true)
                {
                    radioDonDep = j;
                }
            }
            if (radioDonDep != null && radioTinhTrang != null)
            {
                if (radioDonDep.Content.ToString().Equals("Tất cả") && radioTinhTrang.Content.ToString().Equals("Tất cả phòng"))
                {
                    return true;
                }
                else if (radioTinhTrang.Content.ToString().Equals("Tất cả phòng"))
                {
                    return ph.DonDep.Equals(radioDonDep.Content.ToString());
                }
                else if (radioDonDep.Content.ToString().Equals("Tất cả"))
                {
                    return ph.TinhTrang.Equals(radioTinhTrang.Content.ToString());
                }
                else
                {
                    return ph.TinhTrang.Equals(radioTinhTrang.Content.ToString()) && ph.DonDep.Equals(radioDonDep.Content.ToString());
                }
            }
            else if (radioDonDep != null)
            {
                if (radioDonDep.Content.ToString().Equals("Tất cả"))
                    return true;
                else
                    return ph.DonDep.Equals(radioDonDep.Content.ToString());
            }
            else if (radioTinhTrang != null)
            {
                if (radioTinhTrang.Content.ToString().Equals("Tất cả phòng"))
                    return true;
                else
                    return ph.TinhTrang.Equals(radioTinhTrang.Content.ToString());
            }
            return true;
        }

        private void timKiemTheomaPhong()
        {
            CollectionView viewPhongDon = (CollectionView)CollectionViewSource.GetDefaultView(lvPhongDon.ItemsSource);
            viewPhongDon.Filter = filterTimKiem;
            CollectionView viewPhongDoi = (CollectionView)CollectionViewSource.GetDefaultView(lvPhongDoi.ItemsSource);
            viewPhongDoi.Filter = filterTimKiem;
            CollectionView viewPhongGiaDinh = (CollectionView)CollectionViewSource.GetDefaultView(lvPhongGiaDinh.ItemsSource);
            viewPhongGiaDinh.Filter = filterTimKiem;
            refreshListView();
        }

        private bool filterTimKiem(object obj)
        {
            if (String.IsNullOrEmpty(txbTimKiem.Text))
                return true;
            else
                return (obj as Phong).MaPhong.Equals(txbTimKiem.Text);
        }

        private void checkLoaiPhong(RadioButton rd)
        {
            if (rd.Content.Equals("Phòng đơn"))
            {
                lvPhongDon.ItemsSource = lsPhongDon;
                lvPhongDoi.ItemsSource = lsTrong;
                lvPhongGiaDinh.ItemsSource = lsTrong;
                refreshListView();
            }
            else if (rd.Content.Equals("Phòng đôi"))
            {
                lvPhongDoi.ItemsSource = lsPhongDoi;
                lvPhongDon.ItemsSource = lsTrong;
                lvPhongGiaDinh.ItemsSource = lsTrong;
                refreshListView();
            }
            else if (rd.Content.Equals("Phòng gia đình"))
            {
                lvPhongGiaDinh.ItemsSource = lsPhongGiaDinh;
                lvPhongDoi.ItemsSource = lsTrong;
                lvPhongDon.ItemsSource = lsTrong;
                refreshListView();
            }
            else if (rd.Content.Equals("Tất cả loại phòng"))
            {
                lvPhongGiaDinh.ItemsSource = lsPhongGiaDinh;
                lvPhongDoi.ItemsSource = lsPhongDoi;
                lvPhongDon.ItemsSource = lsPhongDon;
                refreshListView();
            }

        }

        private void refreshListView()
        {
            CollectionViewSource.GetDefaultView(lvPhongDon.ItemsSource).Refresh();
            CollectionViewSource.GetDefaultView(lvPhongDoi.ItemsSource).Refresh();
            CollectionViewSource.GetDefaultView(lvPhongGiaDinh.ItemsSource).Refresh();
        }

        #endregion

        #region Event
        private void rb_Click(object sender, RoutedEventArgs e)
        {

            if ( ( (sender as RadioButton).Parent as StackPanel ).Name.ToString().Equals("spLoaiPhong") ){
                checkLoaiPhong(sender as RadioButton);
            }
            else
            {
                CollectionView viewPhongDon = (CollectionView)CollectionViewSource.GetDefaultView(lvPhongDon.ItemsSource);
                CollectionView viewPhongDoi = (CollectionView)CollectionViewSource.GetDefaultView(lvPhongDoi.ItemsSource);
                CollectionView viewPhongGiaDinh = (CollectionView)CollectionViewSource.GetDefaultView(lvPhongGiaDinh.ItemsSource);
                viewPhongDon.Filter = PhongFilter;
                viewPhongDoi.Filter = PhongFilter;
                viewPhongGiaDinh.Filter = PhongFilter;
                refreshListView();
            }
            
        }

       
        //Tìm kiếm theo mã phòng
        private void click_EnterSearch(object sender, RoutedEventArgs e)
        {
            timKiemTheomaPhong();
        }
        private void enter_TxbTimKiem(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;
            
            // thực hiện
            e.Handled = true;
            timKiemTheomaPhong();
        }
        // Filter theo ngày tháng năm
        private void selectedDateChang_DatePicker(object sender, SelectionChangedEventArgs e)
        {
            DateTime? datepicker = dtpChonNgay.SelectedDate;
            MessageBox.Show(datepicker.Value.ToString());
        }
        #endregion


    }
    public class Phong
    {
        private string maPhong;
        private string tinhTrang;
        private string tenKH;
        private int soNgayO;
        private int soNguoi;
        private string donDep;
        private string loaiPhong;
        private DateTime? ngayDen;

        public string MaPhong { get => maPhong; set => maPhong = value; }
        public string TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public int SoNgayO { get => soNgayO; set => soNgayO = value; }
        public string DonDep { get => donDep; set => donDep = value; }
        public int SoNguoi { get => soNguoi; set => soNguoi = value; }
        public string LoaiPhong { get => loaiPhong; set => loaiPhong = value; }
        public DateTime? NgayDen { get => ngayDen; set => ngayDen = value; }
    }
}
