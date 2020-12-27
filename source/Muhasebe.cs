using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje_Ödevi
{
    class Muhasebe
    {
        //bu kısımda mali raporda istenilen verilerin hesaplamasını yapıyor 
        private const int SabitGider = 18000;
        private int Gelir { get; set; }
        private int BrutGelir { get; set; }
        private int Gider { get; set; }
        //Fonksiyonlar
        public void BrutGelirAl(int gelir) 
        {
            this.BrutGelir = gelir;
        }
        public int NetGelirHesapla()
        {
            Gelir = BrutGelir - Gider - SabitGider;
            return Gelir;
        }
        public int GiderHesapla(int gider1,int gider2, int gider3)
        {
            Gider = gider1 + gider2 + gider3;
            return this.Gider;

        }
       
       
    }
}
