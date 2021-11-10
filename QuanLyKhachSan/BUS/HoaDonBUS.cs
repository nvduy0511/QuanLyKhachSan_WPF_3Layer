﻿using DAL;
using DAL.Data;
using DAL.DTO;
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

        public List<HoaDonDTO> GetHoaDons()
        {
            return HoaDonDAL.GetInstance().LayDuLieuHoaDon();
        }
        public bool themHoaDon(HoaDon hd, out string error)
        {
            return HoaDonDAL.GetInstance().themHoaDon(hd, out error);
        }

        public HoaDon layHoaDonTheoMaHoaDon(int mahd)
        {
            return HoaDonDAL.GetInstance().layHoaDonTheoMaHoaDon(mahd);
        }

        public List<HoaDonDTO> layHoaDonTheoThangNam(int thang, int nam)
        {
            try
            {
                DateTime dtDauThang = new DateTime(nam, thang, 1);
                DateTime dtCuoiThang = new DateTime(nam, thang, 1).AddMonths(1).AddDays(-1);
                return HoaDonDAL.GetInstance().layHoaDonTheoThangNam(dtDauThang, dtCuoiThang);
            }
            catch (Exception)
            {
                return null;
            }
            
        }
    }
}
