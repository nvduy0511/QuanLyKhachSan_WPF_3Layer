using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class PhongTrong
    {
        private string soPhong;
        private string tenLoaiPhong;

        public string SoPhong { get => soPhong; set => soPhong = value; }
        public string TenLoaiPhong { get => tenLoaiPhong; set => tenLoaiPhong = value; }
    }
}
