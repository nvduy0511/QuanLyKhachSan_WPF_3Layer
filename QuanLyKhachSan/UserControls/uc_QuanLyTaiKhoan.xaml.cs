using BUS;
using DAL.DTO;
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
    /// Interaction logic for uc_QuanLyTaiKhoan.xaml
    /// </summary>
    public partial class uc_QuanLyTaiKhoan : UserControl
    {
        public uc_QuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        private void btnThemTaiKhoan_Click(object sender, RoutedEventArgs e)
        {
            Them_SuaTaiKhoan themTaiKhoan = new Them_SuaTaiKhoan(true);
            themTaiKhoan.ShowDialog();
            loadDanhSachTaiKhoan();
        }

        private void sua_Click(object sender, RoutedEventArgs e)
        {
            TaiKhoanDTO tk = (sender as Button).DataContext as TaiKhoanDTO;
            if(tk != null)
            {
                Them_SuaTaiKhoan themTaiKhoan = new Them_SuaTaiKhoan(tk);
                themTaiKhoan.ShowDialog();
                loadDanhSachTaiKhoan();
            }
            
        }

        private void xoa_Click(object sender, RoutedEventArgs e)
        {
            DialogCustoms dl = new DialogCustoms("Bạn có muốn xóa!", "Thông báo", DialogCustoms.YesNo);
            if(dl.ShowDialog()== true)
            {
                TaiKhoanDTO tk = (sender as Button).DataContext as TaiKhoanDTO;
                string error = string.Empty;
                if (TaiKhoanBUS.GetInstance().xoaTaiKhoan(tk, out error))
                {
                    new DialogCustoms("Xóa tài khoản thành công !", "Thông báo", DialogCustoms.OK).ShowDialog();
                    loadDanhSachTaiKhoan();
                }
                else
                {
                    new DialogCustoms("Lỗi: " + error, "Thông báo", DialogCustoms.OK).ShowDialog();
                }
            }
            
        }
        private void loadDanhSachTaiKhoan()
        {
            lvTaiKhoan.ItemsSource = TaiKhoanBUS.GetInstance().layDanhSachTaiKhoan();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            loadDanhSachTaiKhoan();
        }

        private void txbTimKiem_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionView viewNV = (CollectionView)CollectionViewSource.GetDefaultView(lvTaiKhoan.ItemsSource);
            viewNV.Filter = filterTimKiem;
        }

        private bool filterTimKiem(object obj)
        {
            if (String.IsNullOrEmpty(txbTimKiem.Text))
                return true;
            else
            {

                return (obj as TaiKhoanDTO).TenTaiKhoan.Contains(txbTimKiem.Text);
            }
        }
    }
}
