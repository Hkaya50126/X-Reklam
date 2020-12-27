using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje_Ödevi
{
    class Oyuncu : Calisan
    {
        //bu kısımda calisan classından kalıtım alıp oyuncu bilgilerini kaydedip listeliyor
        private string ProjeIsim { get; set; }
        private string UzmanlikAlani { get; set; }
        private string ProjeBaslangic { get; set; }
        private string ProjeBitis { get; set; }

        //Fonksiyonlar
        public void OyuncuEkle(string ad, string soyad, decimal maas, string uzmanlikAlani,string projeisim, string projebaş,string projebitiş,string ekizin)
        {
            this.Ad = ad;
            this.Soyad = soyad;
            this.Maas = Convert.ToInt32(maas);
            this.UzmanlikAlani = uzmanlikAlani;
            this.ProjeIsim = projeisim;
            this.ProjeBaslangic = projebaş;
            this.ProjeBitis = projebitiş;
            this.Ekizin= ekizin ;
           
       

        }
        public string[] OyuncuListele()
        {
            string[] bilgiler = { this.Ad, this.Soyad,this.Maas.ToString(),this.UzmanlikAlani,this.ProjeIsim,this.ProjeBaslangic,this.ProjeBitis,this.Ekizin };
            return bilgiler;
        }


    }
}
