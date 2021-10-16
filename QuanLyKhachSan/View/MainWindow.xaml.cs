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
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.IO;

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region uc_view
        private uc_Home Home;
        private uc_Phong Phong_UC;
        private uc_PhieuThue ThuePhong_UC;
        private uc_NhanVien NhanVien_UC;
        #endregion
        #region Khai báo biến
        public List<ItemMenuMainWindow> listMenu { get; set; }
        private string title_Main;
        private int minHeight_ucControlbar;
        private int maNV;
        private int capDoQuyen;

        public string Title_Main
        {
            get => title_Main;
            set
            {
                title_Main = value;
                OnPropertyChanged("Title_Main");
            }
        }
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
        public int CapDoQuyen { get => capDoQuyen; set => capDoQuyen = value; }
        public int MaNV { get => maNV; set => maNV = value; }
        #endregion
        public MainWindow()
        {
            InitializeComponent();

            
        }

        public MainWindow(int maNV, int capDoQuyen):this()
        {
            this.MaNV = maNV;
            this.CapDoQuyen = capDoQuyen;
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

        private void load_Windows(object sender, RoutedEventArgs e)
        {
            this.DataContext = this;
            initListViewMenu();
            Home = new uc_Home();
            contenDisplayMain.Content = Home;
            string staupPath = Environment.CurrentDirectory + "\\Res";
            string filePath = Path.Combine(staupPath, "NV3.jpg");
            if (File.Exists(filePath))
            {
                Uri uri = new Uri(filePath);
                ImageBrush imageBrush = new ImageBrush(new BitmapImage(uri));
                imgAvatar.Fill = imageBrush;

            }
            else
            {
                Uri uri = new Uri("pack://application:,,,/Res/mountains.jpg");
                ImageBrush imageBrush = new ImageBrush(new BitmapImage(uri));
                imgAvatar.Fill = imageBrush;
            }
            
        }

        private void lisviewMenu_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
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
                    if(Phong_UC == null)
                    {
                        Phong_UC = new uc_Phong(MaNV);
                    }
                    contenDisplayMain.Content = Phong_UC;
                    break;
                case 2:
                    if (ThuePhong_UC == null)
                    {
                        ThuePhong_UC = new uc_PhieuThue(MaNV);
                    }
                    contenDisplayMain.Content = ThuePhong_UC;
                    break;
                case 3:
                    if (NhanVien_UC == null)
                    {
                        NhanVien_UC = new uc_NhanVien();
                    }
                    contenDisplayMain.Content = NhanVien_UC;
                    break;
            }
            if (lisviewMenu.SelectedValue != null)
            {
                Title_Main = lisviewMenu.SelectedValue.ToString();
                //Tự động hóa việc click Button toggleBtnMenu_Close
                btnCloseLVMenu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }
        #endregion

        private void click_ThayDoiAnh(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;
            if (openFile.ShowDialog()  == true)
            {
                //xử lý đổi tên file truyền vào
                string [] arr = openFile.FileName.Split('\\');
                string[] arrFileName = arr[arr.Length - 1].Split('.');
                string newNameFile = "NV" + maNV + "." + arrFileName[arrFileName.Length - 1];

                try
                {
                    string sourceFile = openFile.FileName;
                    string targetPath = Environment.CurrentDirectory+"\\Res";
                    //Combine file và đường dẫn
                    string destFile = Path.Combine(targetPath, newNameFile);
                    //Kiểm tra sự tồn tại
                    if (File.Exists(destFile))
                    {
                        // Xóa file
                        File.Delete(destFile);

                    }
                    //Copy file từ file nguồn đến file đích
                    File.Copy(sourceFile, destFile, true);
                    //gán ngược lại giao diện
                    Uri uri = new Uri(destFile);
                    ImageBrush imageBrush = new ImageBrush(new BitmapImage(uri));
                    imgAvatar.Fill = imageBrush;

                    new DialogCustoms("Copy done successfully !", "Thông báo", DialogCustoms.OK).ShowDialog();
                    
                }
                catch (Exception ex)
                {
                    new DialogCustoms("Lỗi: "+ ex.Message, "Thông báo", DialogCustoms.OK).ShowDialog();
                }
            }

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
