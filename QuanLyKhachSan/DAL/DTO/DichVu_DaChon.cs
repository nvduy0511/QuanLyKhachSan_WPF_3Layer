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
        private int sTT;
        private string tenDV;
        private int soLuong;
        private int maDV;

        public string TenDV { get => tenDV; set => tenDV = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public int MaDV { get => maDV; set => maDV = value; }
        public int STT { get => sTT;
            set
            { 
                sTT = value;
                OnPropertyChanged("STT");
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
