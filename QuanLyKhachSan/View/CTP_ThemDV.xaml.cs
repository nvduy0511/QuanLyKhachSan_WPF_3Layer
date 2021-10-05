using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using BUS;
using DAL.DTO;
using DAL;

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for CTP_ThemDV.xaml
    /// </summary>
    public partial class CTP_ThemDV : Window
    {
        public delegate void Delegate_CTPDV (ObservableCollection<DichVu_DaChon> obDVCT);
        public Delegate_CTPDV truyenData;

        ObservableCollection<DichVu_Custom> lsdichVu_Customs;
        ObservableCollection<DichVu_DaChon> lsDichVu_DaChon;
        List<string> lsLoaiDV;
        List<DichVu_Custom> lsCache;
        private int soThuTu;

        private string maCTPhieuThue;
        public CTP_ThemDV()
        {
            InitializeComponent();
        }
        public CTP_ThemDV(string mactpt): this()
        {
            maCTPhieuThue = mactpt;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            soThuTu = 1;
            lsdichVu_Customs = new ObservableCollection<DichVu_Custom>( DichVuBUS.GetInstance().getDichVu_Custom() );
            lsDichVu_DaChon = new ObservableCollection<DichVu_DaChon>();
            lsCache = new List<DichVu_Custom>();
            lsLoaiDV = new List<string>();
            lsLoaiDV = DichVuBUS.GetInstance().getLoaiDichVu();
            lsLoaiDV.Add("Tất cả");
            lvDanhSachDV.ItemsSource = lsdichVu_Customs;
            lvDichVuDaChon.ItemsSource = lsDichVu_DaChon;
            cbTimKiemLoaiDV.ItemsSource = lsLoaiDV;
        }

        private void click_Them(object sender, RoutedEventArgs e)
        {
            DichVu_Custom dvct = (sender as Button).DataContext as DichVu_Custom;
            lsDichVu_DaChon.Add(new DichVu_DaChon() { STT = soThuTu++,  TenDV = dvct.TenDV, SoLuong = 1, MaDV = dvct.MaDV });
            lsCache.Add(dvct);
            lsdichVu_Customs.Remove(dvct);

        }

        private void click_Xoa(object sender, RoutedEventArgs e)
        {
            DichVu_DaChon dvdachon = (sender as Button).DataContext as DichVu_DaChon;
            DichVu_Custom dichVu_Custom = (lsCache.Where(p => p.MaDV.Equals(dvdachon.MaDV) ) ).FirstOrDefault() ;
            lsdichVu_Customs.Add(dichVu_Custom);
            lsDichVu_DaChon.Remove(dvdachon);
            updateSTT();

        }

        private void updateSTT()
        {
            int index = 1;
            foreach(var item in lsDichVu_DaChon)
            {
                item.STT = index++;
            }
            soThuTu = index;
        }

        private void txbTimKiem_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void click_Thoat(object sender, RoutedEventArgs e)
        {
            Window wd = Window.GetWindow(sender as Button);
            wd.Close();
        }

        private void click_Luu(object sender, RoutedEventArgs e)
        {
            //CT_SDDichVu ctsddv = new CT_SDDichVu() 
            //{ MaCTSDDV = GenID.GetInstance().genIDAuto(( CTSDDV_BUS.GetInstance().getMaxCTSDDV() )),

            //}
            
            if (truyenData != null)
            {
                truyenData(lsDichVu_DaChon);
            }
            Window wd = Window.GetWindow(sender as Button);
            wd.Close();
        }

        
    }
}
