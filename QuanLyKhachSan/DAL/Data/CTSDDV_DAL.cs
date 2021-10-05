using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace DAL.Data
{
    public class CTSDDV_DAL
    {
        private static CTSDDV_DAL Instance;

        private CTSDDV_DAL()
        {

        }

        public static CTSDDV_DAL GetInstance()
        {
            if (Instance == null)
            {
                Instance = new CTSDDV_DAL();
            }
            return Instance;
        }
        //Thêm mới chi tiết sử dụng dịch vụ
        public bool addDataCTSDDC(CT_SDDichVu ctsddv)
        {
            try
            {
                using (QLKhachSanEntities db = new QLKhachSanEntities())
                {
                    db.CT_SDDichVu.Add(ctsddv);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        //Lấy ra mã CTSDDV lớn nhất
        public string getMaxCTSDDV()
        {
            CT_SDDichVu ctsdMax;
            using (QLKhachSanEntities db = new QLKhachSanEntities())
            {
                ctsdMax = db.CT_SDDichVu.OrderByDescending(n => n.MaCTSDDV).FirstOrDefault();

            }
            return ctsdMax.MaCTSDDV;
        }
    }
}
