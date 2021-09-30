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
        public static List<Phong_Custom> getDataPhongCustom()
        {
            return PhongDAL.getDataFromDataBase(); 
        }
        public static List<PhongTrong> getPhongTrong()
        {
            return PhongDAL.getPhongTrong();
        }
    }
}
