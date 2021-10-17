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
using DAL.DTO;
using BUS;
using DAL;

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for XuatHoaDon.xaml
    /// </summary>
    public partial class XuatHoaDon : Window
    {
        private Phong_Custom phong;
        private int maNV;
        private List<DichVu_DaChon> ls;
        public Phong_Custom Phong { get => phong; set => phong = value; }
        public int MaNV { get => maNV; set => maNV = value; }

        public XuatHoaDon()
        {
            InitializeComponent();
        }
        public XuatHoaDon(int maNV, Phong_Custom ph, ObservableCollection<DichVu_DaChon> lsDV) : this()
        {
            txbNhanVien.Text = maNV.ToString();
            this.MaNV = maNV;
            this.Phong = ph;
            ls = lsDV.ToList();
            
        }

        private void hoaDon_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                decimal? tienPhong = PhongBUS.GetInstance().tinhTienPhong(Phong);
                decimal? tienDV = CTSDDV_BUS.GetInstance().tinhTongTienDichVuTheoMaCTPT(Phong.MaCTPT);
                txbSoPhong.Text = Phong.MaPhong;
                if (Phong.IsDay == true)
                {
                    txbSoNgayOrGio.Text = "Số ngày: ";
                    txbSoNgay.Text = Phong.SoNgayO.ToString();
                }
                else
                {
                    txbSoNgayOrGio.Text = "Số giờ: ";
                    txbSoNgay.Text = Phong.SoGio.ToString();
                }
                txbTenKH.Text = Phong.TenKH;
                txbSoNguoi.Text = Phong.SoNguoi.ToString();
                txbNhanVien.Text = NhanVienBUS.GetInstance().layNhanVienTheoMaNV(MaNV);
                txbNgayLapHD.Text = DateTime.Now.ToString();
                txbTongTien.Text = string.Format("{0:0,0 VND}", ((tienDV == null ? 0 : tienDV) + tienPhong));

                //Thêm hóa đơn vào DB
                HoaDon hd = new HoaDon()
                {
                    MaNV = this.MaNV,
                    MaCTPT = Phong.MaCTPT,
                    NgayLap = DateTime.Now,
                    TongTien = decimal.Parse(((tienDV == null ? 0 : tienDV) + tienPhong).ToString())
                };
                string error = string.Empty;
                if (!HoaDonBUS.GetInstance().themHoaDon(hd,out error))
                {
                    new DialogCustoms("Thêm hóa đơn thất bại!\nLỗi:"+error, "Thông báo", DialogCustoms.OK).ShowDialog();
                }
                txbSoHoaDon.Text = hd.MaHD.ToString();
                //Sửa trạng thái của ctpt
                string errorSuaCTPT = string.Empty;
                if(!CT_PhieuThueBUS.GetInstance().suaTinhTrangThuePhong(Phong.MaCTPT,"Đã thanh toán",out errorSuaCTPT))
                {
                    new DialogCustoms("Lỗi sửa CTPT\nLỗi:" + errorSuaCTPT, "Thông báo", DialogCustoms.OK).ShowDialog();
                }
                // Thêm 1 dịch vụ là thuê phòng vào 
                DichVu_DaChon dv = new DichVu_DaChon()
                {
                    SoLuong = Phong.IsDay == true ? Phong.SoNgayO : Phong.SoGio,
                    TenDV = "Thuê phòng",
                    Gia = PhongBUS.GetInstance().layTienPhongTheoSoPhong(Phong),
                    ThanhTien = tienPhong
                };
                ls.Add(dv);
                lvDichVuDaSD.ItemsSource = ls;
            }
            catch (Exception)
            {

                new DialogCustoms("Lỗi load thông tin!", "Thông báo", DialogCustoms.OK).ShowDialog();
            }
        }


        private void click_InHoaDon(object sender, RoutedEventArgs e)
        {
            try
            {
                btnInHoaDon.Visibility = Visibility.Hidden;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "In Hóa đơn");
                    new DialogCustoms("In hóa đơn thành công!", "Thông báo", DialogCustoms.OK).ShowDialog();
                }
            }
            catch(Exception ex)
            {
                new DialogCustoms("In hóa đơn thất bại! \n Lỗi: "+ex.Message, "Thông báo", DialogCustoms.OK).ShowDialog();
            }
            finally
            {
                btnInHoaDon.Visibility = Visibility.Visible;
            }
        }

        
    }
}
