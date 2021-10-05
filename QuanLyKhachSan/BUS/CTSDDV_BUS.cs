using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;
using DAL;

namespace BUS
{
    public class CTSDDV_BUS
    {
        private static CTSDDV_BUS Instance;

        private CTSDDV_BUS()
        {

        }

        public static CTSDDV_BUS GetInstance()
        {
            if (Instance == null)
            {
                Instance = new CTSDDV_BUS();
            }
            return Instance;
        }
        public bool addDataCTSDDC(CT_SDDichVu ctsddv)
        {
            return CTSDDV_DAL.GetInstance().addDataCTSDDC(ctsddv);
        }

        public string getMaxCTSDDV()
        {
            return CTSDDV_DAL.GetInstance().getMaxCTSDDV();
        }


    }
}
