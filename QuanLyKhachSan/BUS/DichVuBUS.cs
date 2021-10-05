using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;
using DAL.Data;

namespace BUS
{
    public class DichVuBUS
    {
        private static DichVuBUS Instance;

        private DichVuBUS()
        {

        }

        public static DichVuBUS GetInstance()
        {
            if (Instance == null)
            {
                Instance = new DichVuBUS();
            }
            return Instance;
        }

        public List<DichVu_Custom> getDichVu_Custom()
        {
            return DichVuDAL.GetInstance().getDataDichVu_Custom();
        }

        public List<string> getLoaiDichVu()
        {
            return DichVuDAL.GetInstance().getDataLoaiDichVu();
        }
    }
}
