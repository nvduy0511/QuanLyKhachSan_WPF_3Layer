using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Diagnostics;
using System;
using GUI.UserControls;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;
using System.Threading;
using MaterialDesignThemes.Wpf;

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region uc_view
        public uc_Controlbar ctl_bar;
        public uc_Home Home;
        public uc_PhieuThue ThuePhong_View;
        public uc_QuanLyPhong QuanLyPhong_View;
        public uc_QuanLyThongTinKhachHang QuanLyThongTinKhachHang_View;
        public uc_QuanLyHoaDon QuanLyHoaDon_View;
        #endregion
        public List<ItemMenuMainWindow> listMenu { get; set; }
        private string title_Main;
        public string Title_Main
        {
            get => title_Main;
            set
            {
                title_Main = value;
                OnPropertyChanged("Title_Main");
            }
        }
        private int minHeight_ucControlbar;
        public int MinHeight_ucControlbar
        {
            get => minHeight_ucControlbar;
            set
            {
                minHeight_ucControlbar = value;
                OnPropertyChanged("MinHeight_ucControlbar");
                if (value == 1)
                {
                    boGoc.Rect = new Rect(0, 0, SystemParameters.MaximizedPrimaryScreenWidth, SystemParameters.MaximizedPrimaryScreenHeight);
                }
                else
                {
                    boGoc.Rect = new Rect(0, 0, 1300, 700);
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            DangNhap dangNhap = new DangNhap();
            dangNhap.ShowDialog();
            initListViewMenu();

            Home = new uc_Home();
            contenDisplayMain.Content = Home;
            this.DataContext = this;
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
        }
        #region method
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string newName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(newName));
            }
        }
        private void initListViewMenu()
        {
            //Khoi tao Menu
            listMenu = new List<ItemMenuMainWindow>();
            listMenu.Add(new ItemMenuMainWindow() { name = "Trang Chủ", foreColor = "Gray", kind_Icon = "Recycle" });
            listMenu.Add(new ItemMenuMainWindow() { name = "Thuê Phòng", foreColor = "#FFF08033", kind_Icon = "HelpCircleOutline" });
            listMenu.Add(new ItemMenuMainWindow() { name = "Send Feedback", foreColor = "Green", kind_Icon = "Lightbulb" });
            listMenu.Add(new ItemMenuMainWindow() { name = "Recommend", foreColor = "#FFD41515", kind_Icon = "Heart" });
            listMenu.Add(new ItemMenuMainWindow() { name = "Premium Subscription", foreColor = "#FFE6A701", kind_Icon = "StarCircle" });
            listMenu.Add(new ItemMenuMainWindow() { name = "Settings", foreColor = "#FF0069C1", kind_Icon = "Settings" });
            listMenu.Add(new ItemMenuMainWindow() { name = "Quản Lý Phòng", foreColor = "#FF0069C1", kind_Icon = "Settings" });
            listMenu.Add(new ItemMenuMainWindow() { name = "Quản Lý Thông Tin Khách Hàng", foreColor = "#FF0069C1", kind_Icon = "Settings" });
            listMenu.Add(new ItemMenuMainWindow() { name = "Quản Lý Hóa Đơn", foreColor = "#FF0069C1", kind_Icon = "Settings" });
            listMenu.Add(new ItemMenuMainWindow() { name = "Settings", foreColor = "#FF0069C1", kind_Icon = "Settings" });
            listMenu.Add(new ItemMenuMainWindow() { name = "Settings", foreColor = "#FF0069C1", kind_Icon = "Settings" });
            listMenu.Add(new ItemMenuMainWindow() { name = "Settings", foreColor = "#FF0069C1", kind_Icon = "Settings" });
            listMenu.Add(new ItemMenuMainWindow() { name = "Settings", foreColor = "#FF0069C1", kind_Icon = "Settings" });
            lisviewMenu.ItemsSource = listMenu;
            lisviewMenu.SelectedValuePath = "name";
            Title_Main = "Trang Chủ";
        }
        #endregion

        #region event
        private void selectionChanged_Menu(object sender, SelectionChangedEventArgs e)
        {
            switch (lisviewMenu.SelectedIndex)
            {
                case 0:
                    //Đang là Home rồi thì không set nữa
                    if (Title_Main.Equals(lisviewMenu.SelectedValue.ToString()))
                    {
                        break;
                    }
                    contenDisplayMain.Content = Home;
                    break;
                case 1:
                    if (ThuePhong_View == null)
                        ThuePhong_View = new uc_PhieuThue();
                    contenDisplayMain.Content = ThuePhong_View;
                    break;
                case 6:
                    if (QuanLyPhong_View == null)
                        QuanLyPhong_View = new uc_QuanLyPhong();
                    contenDisplayMain.Content = QuanLyPhong_View;
                    break;
                case 7:
                    if (QuanLyThongTinKhachHang_View == null)
                        QuanLyThongTinKhachHang_View = new uc_QuanLyThongTinKhachHang();
                    contenDisplayMain.Content = QuanLyThongTinKhachHang_View;
                    break;
                case 8:
                    if (QuanLyHoaDon_View == null)
                        QuanLyHoaDon_View = new uc_QuanLyHoaDon();
                    contenDisplayMain.Content = QuanLyHoaDon_View;
                    break;
            }
            if (lisviewMenu.SelectedValue != null)
            {
                Title_Main = lisviewMenu.SelectedValue.ToString();
                //Tự động hóa việc click Button toggleBtnMenu_Close
                toggleBtnMenu_Close.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                toggleBtnMenu_Close.IsChecked = !toggleBtnMenu_Close.IsChecked;
            }

        }

        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            contenDisplayMain.Content = Home;
            Title_Main = "Trang chủ";
            lisviewMenu.UnselectAll();
        }
        #endregion
    }


    public class ItemMenuMainWindow
    {
        public string name { get; set; }
        public string foreColor { get; set; }
        public string kind_Icon { get; set; }
        public ItemMenuMainWindow() { }

    }
}
