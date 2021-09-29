using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using DAL.Data;
using DAL;


namespace BUS
{
    public class bNhanVien
    {
        public static void SetDataSource(ListView ls)
        {
            ls.ItemsSource = dNhanVien.getDataNhanVien();
        }
        public static void addNhanVien(NhanVien nv)
        {
            dNhanVien.addDataNhanVien(nv);
        }
    }
}
