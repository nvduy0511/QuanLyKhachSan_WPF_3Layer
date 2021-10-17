using DAL;
using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class HoaDonBUS
    {
        private static HoaDonBUS Instance;

        private HoaDonBUS()
        {

        }

        public static HoaDonBUS GetInstance()
        {
            if (Instance == null)
            {
                Instance = new HoaDonBUS();
            }
            return Instance;
        }

        public bool themHoaDon(HoaDon hd, out string error)
        {
            return HoaDonDAL.GetInstance().themHoaDon(hd, out error);
        }
    }
}
