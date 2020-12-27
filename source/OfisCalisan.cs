using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje_Ödevi
{
    class OfisCalisan : Calisan
    {
        //bu sınıfta calisandan kalıtım alıp ekleme ve listeleme işlemleri yapıyor
        private string Gorev { get; set; }
        //Fonksiyonlar
        public void ofisCalisanEkle(string ofisCalisanAd, string ofisCalisanSoyad, string
              ofisCalisanGorev, string ofisCalisanIzin, decimal ofisCalisanMaas,string ekizin)
        {
            this.Ad = ofisCalisanAd;
            this.Soyad = ofisCalisanSoyad;
            this.Gorev = ofisCalisanGorev;
            this.IzınGunu = ofisCalisanIzin;
            this.Maas = ofisCalisanMaas;
            this.Ekizin = ekizin;
        }
        public string[] ofisCalisanListele()
        {
            string[] bilgiler = { this.Ad, this.Soyad, this.Gorev, this.IzınGunu, this.Maas.ToString(),this.Ekizin };
            return bilgiler;
        }
    
    }
}


