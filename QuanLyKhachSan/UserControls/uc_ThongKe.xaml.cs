using BUS;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
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
    /// Interaction logic for uc_ThongKe.xaml
    /// </summary>
    public partial class uc_ThongKe : UserControl
    {
        public SeriesCollection SeriesCollection { get; set; }
        public SeriesCollection SeriesCollectionPierChar { get; set; }
        public Func<ChartPoint, string> PointLabel { get; set; }
        public string[] Labels { get; set; }
        List<int> lsThang;
        List<int> lsNam;
        public uc_ThongKe()
        {
            InitializeComponent();
            initComboBox();
            DataContext = this;

            PointLabel = chartPoint =>
                string.Format("{0} ({1:P})", "", chartPoint.Participation);

            Labels = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10","11","12" };
            cbNam.Text = "2021";
            cbThang.Text = "10";

        }

        private void initComboBox()
        {
            lsThang = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            cbThang.ItemsSource = lsThang;
            lsNam = new List<int>();
            for (int i = 2019; i <= 2050; i++)
            {
                lsNam.Add(i);
            }
            cbNam.ItemsSource = lsNam;
        }

        private void selectionChang_cbThang(object sender, SelectionChangedEventArgs e)
        {
            if(cbNam.SelectedValue != null && cbThang.SelectedValue != null)
            {
                capNhatGiaTriTheoThang();
            }
            
        }
        

        private void cbNam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Làm cho biểu đồ dòng
            if(cbNam.SelectedValue != null)
            {
                List<double> listDoanhThuPhong = new List<double>();
                List<double> listDoanhThuDV = new List<double>();
                List<double> lisTongDoanhThu = new List<double>();
                //Tính toán rồi lưu vào list
                for (int i = 1; i <= 12; i++)
                {
                    decimal doanhThuPhong1 = CT_PhieuThueBUS.GetInstance().tinhDoanhThuTheoThang(i, int.Parse(cbNam.SelectedValue.ToString()));
                    decimal doanhThuDichVu1 = CTSDDV_BUS.GetInstance().tinhDoanhThuDVTheoThang(i, int.Parse(cbNam.SelectedValue.ToString()));
                    listDoanhThuPhong.Add(double.Parse(doanhThuPhong1.ToString()));
                    listDoanhThuDV.Add(double.Parse(doanhThuDichVu1.ToString()));
                    lisTongDoanhThu.Add(double.Parse((doanhThuPhong1 + doanhThuDichVu1).ToString()));
                }
                lsDoanhThuPhong.Values = new ChartValues<double>(listDoanhThuPhong);
                lsDoanhThuDV.Values = new ChartValues<double>(listDoanhThuDV);
                lsTongDoanhThu.Values = new ChartValues<double>(lisTongDoanhThu);
            }
            

            //biểu đồ hình tròn
            if(cbThang.SelectedValue != null)
            {
                capNhatGiaTriTheoThang();
            }
        }
        private void capNhatGiaTriTheoThang()
        {
            decimal doanhThuPhong = CT_PhieuThueBUS.GetInstance().tinhDoanhThuTheoThang(int.Parse(cbThang.SelectedValue.ToString()), int.Parse(cbNam.SelectedValue.ToString()));
            txbDoanhThuPhong.Text = string.Format("{0:0,0 VND}", doanhThuPhong);
            decimal doanhThuDichVu = CTSDDV_BUS.GetInstance().tinhDoanhThuDVTheoThang(int.Parse(cbThang.SelectedValue.ToString()), int.Parse(cbNam.SelectedValue.ToString()));
            txbDoanhThuDV.Text = string.Format("{0:0,0 VND}", doanhThuDichVu);
            int soPhongDat = PhieuThueBUS.GetInstance().tinhTongSoPhongDatTrongThang(int.Parse(cbThang.SelectedValue.ToString()), int.Parse(cbNam.SelectedValue.ToString()));
            txbSoLuongPhongDat.Text = string.Format("{0:0 Phòng}", soPhongDat);
            //set giá trị vào cái biểu đồ hình tròn á
            psDoanhThuDV.Values = new ChartValues<ObservableValue> { new ObservableValue(int.Parse(doanhThuDichVu.ToString())) };
            psDoanhThuPhong.Values = new ChartValues<ObservableValue> { new ObservableValue(int.Parse(doanhThuPhong.ToString())) };
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            capNhatGiaTriTheoThang();
        }
    }
}
