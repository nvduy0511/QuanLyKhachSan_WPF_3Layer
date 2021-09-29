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
        ObservableCollection<NhanVien> list;
        public uc_NhanVien()
        {
            InitializeComponent();
            list = new ObservableCollection<NhanVien>(NhanVienBUS.getDataNhanVien());
            lvNhanVien.ItemsSource = list;

        }

        private void click_ThemNV(object sender, RoutedEventArgs e)
        {
            ThemNhanVien tnv = new ThemNhanVien();
            tnv.truyenNhanVien = new ThemNhanVien.truyenData(nhanData);
            tnv.ShowDialog();
        }
        void nhanData(NhanVien nv)
        {
            list.Add(nv);
            NhanVienBUS.addNhanVien(nv);
            MessageBox.Show("Thêm thành công!");
        }

        private void click_XoaNV(object sender, RoutedEventArgs e)
        {
            NhanVien nv = (sender as Button).DataContext as NhanVien;
            list.Remove(nv);
        }

    }

}
