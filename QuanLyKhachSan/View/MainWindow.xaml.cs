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
        private uc_Controlbar ctl_bar;
        private uc_Home Home;
        private uc_PhieuThue ThuePhong_UC;
        private uc_Phong Phong_UC;
        private uc_NhanVien NhanVien_UC;
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

            //DangNhap dangNhap = new DangNhap();
            //dangNhap.ShowDialog();
            
            
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
            listMenu.Add(new ItemMenuMainWindow() { name = "Trang Chủ", foreColor = "Gray", kind_Icon = "Home" });
            listMenu.Add(new ItemMenuMainWindow() { name = "Phòng", foreColor = "#FFF08033", kind_Icon = "HomeCity" });
            listMenu.Add(new ItemMenuMainWindow() { name = "Đặt Phòng", foreColor = "Green", kind_Icon = "BookAccount" });
            listMenu.Add(new ItemMenuMainWindow() { name = "QL nhân Viên", foreColor = "#FFD41515", kind_Icon = "Account" });
            listMenu.Add(new ItemMenuMainWindow() { name = "Hóa đơn", foreColor = "#FFD41515", kind_Icon = "Receipt" });
            listMenu.Add(new ItemMenuMainWindow() { name = "QL phòng", foreColor = "#FFE6A701", kind_Icon = "StarCircle" });
            listMenu.Add(new ItemMenuMainWindow() { name = "QL dịch vụ", foreColor = "Blue", kind_Icon = "FaceAgent" });
            listMenu.Add(new ItemMenuMainWindow() { name = "QL tiện nghi", foreColor = "#FFF08033", kind_Icon = "Fridge" });
            listMenu.Add(new ItemMenuMainWindow() { name = "Thống kê", foreColor = "#FF0069C1", kind_Icon = "ChartAreaspline" });

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
                    
                    if (Phong_UC == null)
                        Phong_UC = new uc_Phong();
                    contenDisplayMain.Content = Phong_UC;
                    break;
                case 2:
                    if (ThuePhong_UC == null)
                        ThuePhong_UC = new uc_PhieuThue();
                    contenDisplayMain.Content = ThuePhong_UC;
                    break;
                case 3:
                    if (NhanVien_UC == null)
                        NhanVien_UC = new uc_NhanVien();
                    contenDisplayMain.Content = NhanVien_UC;
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

        #endregion

        private void load_Windows(object sender, RoutedEventArgs e)
        {
            this.DataContext = this;
            initListViewMenu();
            Home = new uc_Home();
            contenDisplayMain.Content = Home;
        }
    }


    public class ItemMenuMainWindow
    {
        public string name { get; set; }
        public string foreColor { get; set; }
        public string kind_Icon { get; set; }

        public ItemMenuMainWindow() { }

    }
}
