using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class DichVu_DaChon: INotifyPropertyChanged
    {
        private string tenDV;
        private int? soLuong;
        private decimal? thanhTien;
        private decimal gia;
        private int? maDV;

        public string TenDV { get => tenDV; set => tenDV = value; }
        public int? MaDV { get => maDV; set => maDV = value; }
        public decimal Gia { get => gia; set => gia = value; }

        public int? SoLuong
        {
            get => soLuong;
            set
            {
                soLuong = value;
                OnPropertyChanged("SoLuong");
            }
        }


        public decimal? ThanhTien
        {
            get => thanhTien;
            set
            {
                thanhTien = value;
                OnPropertyChanged("ThanhTien");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string newName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(newName));
            }
        }
    }
}
