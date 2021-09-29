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
using BUS;
using DAL.DTO;

namespace GUI.UserControls
{
    /// <summary>
    /// Interaction logic for uc_Phong.xaml
    /// </summary>
    public partial class uc_Phong : UserControl
    {
        #region Khai bao bien
        List<Phong_Custom> lsPhong;
        List<Phong_Custom> lsPhongDon;
        List<Phong_Custom> lsPhongDoi;
        List<Phong_Custom> lsPhongGiaDinh;
        List<Phong_Custom> lsTrong;
        #endregion
        public uc_Phong()
        {
            InitializeComponent();
            lsPhong = new List<Phong_Custom>();
            lsPhongDon = new List<Phong_Custom>();
            lsPhongDoi = new List<Phong_Custom>();
            lsPhongGiaDinh = new List<Phong_Custom>();
            lsTrong = new List<Phong_Custom>();
            init();
        }

        private void init()
        {
            lsPhong = PhongBUS.getDataPhongCustom();

            lsPhongDon = lsPhong.Where(p => p.LoaiPhong.Equals("Phòng đơn")).ToList();
            lsPhongDoi = lsPhong.Where(p => p.LoaiPhong.Equals("Phòng đôi")).ToList();
            lsPhongGiaDinh = lsPhong.Where(p => p.LoaiPhong.Equals("Phòng gia đình")).ToList();

            lvPhongDon.ItemsSource = lsPhongDon;
            lvPhongDoi.ItemsSource = lsPhongDoi;
            lvPhongGiaDinh.ItemsSource = lsPhongGiaDinh;

            lvPhongDon.PreviewMouseLeftButtonUp += LvPhongDon_PreviewMouseLeftButtonUp;
            lvPhongDoi.PreviewMouseLeftButtonUp += LvPhongDon_PreviewMouseLeftButtonUp;
            lvPhongGiaDinh.PreviewMouseLeftButtonUp += LvPhongDon_PreviewMouseLeftButtonUp;
            initEvent();
        }


        #region Method
        

        private void LvPhongDon_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ListView lv = sender as ListView;
            MessageBox.Show((lv.SelectedItem as Phong_Custom).MaPhong);
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
            Phong_Custom ph = obj as Phong_Custom;
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
                return (obj as Phong_Custom).MaPhong.Contains(txbTimKiem.Text);
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
}
