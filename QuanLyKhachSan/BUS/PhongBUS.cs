using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;
using DAL;
using DAL.Data;

namespace BUS
{
    public class PhongBUS
    {
        private static PhongBUS Instance;

        private PhongBUS()
        {

        }

        public static PhongBUS GetInstance()
        {
            if (Instance == null)
            {
                Instance = new PhongBUS();
            }
            return Instance;
        }
        

        public List<Phong_Custom> getDataPhongCustomTheoNgay(DateTime? ngayChon)
        {
            return PhongDAL.GetInstance().getDataPhongTheoNgay(ngayChon);
        }

        public List<PhongTrong> getPhongTrong()
        {
            return PhongDAL.GetInstance().getPhongTrong();
        }
    }
}
