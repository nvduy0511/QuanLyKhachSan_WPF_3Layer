using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class PhongDaChon
    {
        private string soPhong;
        private int soNguoi;
        private DateTime? ngayBD;
        private DateTime? ngayKT;

        public string SoPhong { get => soPhong; set => soPhong = value; }
        public int SoNguoi { get => soNguoi; set => soNguoi = value; }
        public DateTime? NgayBD { get => ngayBD; set => ngayBD = value; }
        public DateTime? NgayKT { get => ngayKT; set => ngayKT = value; }
    }
}
