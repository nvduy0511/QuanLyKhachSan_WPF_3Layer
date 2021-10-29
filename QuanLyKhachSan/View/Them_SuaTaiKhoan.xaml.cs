using BUS;
using DAL;
using DAL.DTO;
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

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for Them_SuaTaiKhoan.xaml
    /// </summary>
    public partial class Them_SuaTaiKhoan : Window
    {
        public Them_SuaTaiKhoan()
        {
            InitializeComponent();
        }
        public Them_SuaTaiKhoan(bool them):this()
        {
            if (them)
            {
                cbMaNV.ItemsSource = TaiKhoanBUS.GetInstance().layDanhSachNhanVienChuaCoTaiKhoan();
            }
        }
        public Them_SuaTaiKhoan(TaiKhoanDTO taiKhoanDTO):this()
        {
            txbTitle.Text = "Sửa tài khoản " + taiKhoanDTO.TenTaiKhoan;
            txbTaiKhoan.Text = taiKhoanDTO.TenTaiKhoan;
            cbCapDoQuyen.Text = taiKhoanDTO.CapDoQuyen.ToString();
            cbMaNV.ItemsSource = new List<int>() { taiKhoanDTO.MaNV };
            cbMaNV.Text = taiKhoanDTO.MaNV.ToString();
            txbTaiKhoan.IsReadOnly = true;

        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            string error = string.Empty;
            TaiKhoan taiKhoanThem = new TaiKhoan();
            try
            {
                taiKhoanThem.username = txbTaiKhoan.Text;
                taiKhoanThem.password = txbMatKhau.Text;
                taiKhoanThem.CapDoQuyen = int.Parse(cbCapDoQuyen.Text);
                taiKhoanThem.MaNV = int.Parse(cbMaNV.Text);
            }
            catch (Exception ex)
            {
                new DialogCustoms("Lỗi thêm tài khoản : "+ex.Message, "Thông báo", DialogCustoms.OK).ShowDialog();
            }
            if (TaiKhoanBUS.GetInstance().themTaiKhoan(taiKhoanThem, out error))
            {
                new DialogCustoms("Thêm tài khoản thành công !", "Thông báo", DialogCustoms.OK).ShowDialog();
            }
            else
            {
                new DialogCustoms("Lỗi: "+error, "Thông báo", DialogCustoms.OK).ShowDialog();
            }
        }

        private void btnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            string error = string.Empty;
            TaiKhoan taiKhoanCapNhat = new TaiKhoan();
            try
            {
                taiKhoanCapNhat.username = txbTaiKhoan.Text;
                taiKhoanCapNhat.password = txbMatKhau.Text;
                taiKhoanCapNhat.CapDoQuyen = int.Parse(cbCapDoQuyen.Text);
                taiKhoanCapNhat.MaNV = int.Parse(cbMaNV.Text);
            }
            catch (Exception ex)
            {
                new DialogCustoms("Lỗi sửa tài khoản !\n Lỗi: "+ex.Message, "Thông báo", DialogCustoms.OK).ShowDialog();
            }
            if(TaiKhoanBUS.GetInstance().suaTaiKhoan(taiKhoanCapNhat,out error))
            {
                new DialogCustoms("Cập nhật tài khoản thành công !", "Thông báo", DialogCustoms.OK).ShowDialog();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
