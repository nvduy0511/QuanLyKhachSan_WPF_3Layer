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
    public class NhanVienBUS
    {
        public static List<NhanVien> getDataNhanVien()
        {
            return NhanVienDAL.getDataNhanVien();
        }
        public static void addNhanVien(NhanVien nv)
        {
            NhanVienDAL.addDataNhanVien(nv);
        }
        public static string genIDNhanVien()
        {
            return GenID.GetInstance().genIDAuto( NhanVienDAL.getMaxMaNV() );
        }
    }
}
