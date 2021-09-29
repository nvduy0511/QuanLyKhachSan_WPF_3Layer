using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;
using DAL.Data;

namespace BUS
{
    public class PhongBUS
    {
        public static List<Phong_Custom> getDataPhongCustom()
        {
            List<Phong_Custom> ls = new List<Phong_Custom>();
            ls = PhongDAL.getDataFromDataBase();
            return ls;
        }
    }
}
