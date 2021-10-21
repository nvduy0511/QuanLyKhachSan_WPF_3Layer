using BUS;
using DAL.Data;
using DAL.DTO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI.UserControls
{
    /// <summary>
    /// Interaction logic for uc_HoaDon.xaml
    /// </summary>
    public partial class uc_HoaDon : UserControl
    {
        ObservableCollection<HoaDonDTO> list;
        List<HoaDonDTO> listHoaDon;
        public uc_HoaDon()
        {
            InitializeComponent();
            TaiDanhSach();
            listHoaDon = new List<HoaDonDTO>();

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lsvHoaDon.ItemsSource);
            view.Filter = HoaDonFilter;
        }

        private bool HoaDonFilter(object obj)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return (obj as HoaDonDTO).TenNHanVienLap.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void TaiDanhSach()
        {
            list = new ObservableCollection<HoaDonDTO>(HoaDonBUS.GetInstance().GetHoaDons());
            lsvHoaDon.ItemsSource = list;
        }

        private void LayHoaDonTheoNgay(DateTime? dt)
        {
            
        }

       

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lsvHoaDon.ItemsSource).Refresh();
        }

        private void dtpChonNgay_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? datepicker = dtpChonNgay.SelectedDate;
            if (datepicker == null)
            {
                MessageBox.Show("Chọn đúng định dạng tháng ngày năm!!!");
                return;
            }
            else
            {
                LayHoaDonTheoNgay(datepicker.Value);
            }
            //TaiDanhSach();
        }
    }
}
