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

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for DatPhong.xaml
    /// </summary>
    public partial class DatPhong : Window
    {
        List<PhongTrong> lsPhong;
        public DatPhong()
        {
            InitializeComponent();
            lsPhong = new List<PhongTrong>();
            lsPhong = PhongBUS.getPhongTrong();
            lvPhongTrong.ItemsSource = lsPhong;
            
        }

        private void click_Huy(object sender, RoutedEventArgs e)
        {
            Button huy = sender as Button;
            Window dP = Window.GetWindow(huy);
            dP.Close();
        }

        private void click_Luu(object sender, RoutedEventArgs e)
        {
            Button luu = sender as Button;
            Window dP = Window.GetWindow(luu);
            dP.Close();
        }
    }
}
