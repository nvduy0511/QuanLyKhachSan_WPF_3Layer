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
using DAL.DTO;
using BUS;
using System.Globalization;
using System.Collections.ObjectModel;

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for DatPhong.xaml
    /// </summary>
    public partial class DatPhong : Window
    {
        ObservableCollection<PhongTrong> lsPhongTrongs;
        ObservableCollection<PhongDaChon> lsPDaChons;
        List<PhongTrong> lsPhongCaches;
        public DatPhong()
        {
            InitializeComponent();
        }
        #region method

        #endregion

        #region event
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lsPhongTrongs = new ObservableCollection<PhongTrong>( PhongBUS.GetInstance().getPhongTrong() );
            lsPDaChons = new ObservableCollection<PhongDaChon>();
            lsPhongCaches = new List<PhongTrong>();
            lvPhongTrong.ItemsSource = lsPhongTrongs;
            lvPhongDaChon.ItemsSource = lsPDaChons;
            dtpNgayBD.Text = DateTime.Now.ToShortDateString();
            dtpNgayKT.Text = DateTime.Now.ToShortDateString();
            tpGioBD.Text = DateTime.Now.ToShortTimeString();
            tpGioKT.Text = DateTime.Now.ToShortTimeString();
        }
        private void click_Huy(object sender, RoutedEventArgs e)
        {
            Button huy = sender as Button;
            Window wd = Window.GetWindow(huy);
            wd.Close();
        }

        private void click_Luu(object sender, RoutedEventArgs e)
        {
            Button luu = sender as Button;
            Window wd = Window.GetWindow(luu);
            wd.Close();
        }

        private void click_ThemPhong(object sender, RoutedEventArgs e)
        {
            PhongTrong ephongTrong = (sender as Button).DataContext as PhongTrong;
            lsPhongCaches.Add(ephongTrong);
            lsPhongTrongs.Remove(ephongTrong);
            PhongDaChon phongDaChon = new PhongDaChon()
            {
                SoPhong = ephongTrong.SoPhong,
                SoNguoi = 1,
                NgayBD = DateTime.Parse(dtpNgayBD.Text + " " + tpGioBD.Text),
                NgayKT = DateTime.Parse(dtpNgayKT.Text + " " + tpGioKT.Text)
            };
            lsPDaChons.Add(phongDaChon);
        }

        private void click_Delete(object sender, RoutedEventArgs e)
        {
            PhongDaChon phongDaChon = (sender as Button).DataContext as PhongDaChon;
            foreach (PhongTrong pt in lsPhongCaches)
            {
                if (pt.SoPhong.Equals(phongDaChon.SoPhong))
                {
                    lsPhongTrongs.Add(pt);
                    lsPhongCaches.Remove(pt);
                    break;
                }
            }
            lsPDaChons.Remove(phongDaChon);
        }
        #endregion



    }
}
