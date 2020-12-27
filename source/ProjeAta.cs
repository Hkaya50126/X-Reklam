using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje_Ödevi
{
    class Proje
    {
        //bu kısımda calisan classından kalıtım alıp proje atama işlemlerini kaydedip listeliyor
        private string ad { get; set; }
        private string soyad { get; set; }
        private string firmaAdi { get; set; }
        private int Maas { get; set; }
        private string uzmanlikAlani { get; set; }
        private string isTuru { get; set; }
        private string ProjeBaslangic { get; set; }
        private string ProjeBitis { get; set; }
        private decimal firmaButce { get; set; }
        private int isTuruSayaci { get; set; }

        public void ProjeAtama(string ad, string soyad, int maas, string firmaAdi, string uzmanlikAlani, string isTuru,
            string ProjeBaslangic, string ProjeBitis, decimal FirmaButce, int isturuSayaci)
        {
            this.ad = ad;
            this.soyad = soyad;
            this.Maas = maas;
            this.firmaAdi = firmaAdi;
            this.uzmanlikAlani = uzmanlikAlani;
            this.isTuru = isTuru;
            this.ProjeBaslangic = ProjeBaslangic;
            this.ProjeBitis = ProjeBitis;
            this.firmaButce = FirmaButce;
            this.isTuruSayaci = isturuSayaci;

        }
        public string[] ProjeListele()
        {
            string[] bilgiler= { this.ad, this.soyad, this.Maas.ToString(), this.firmaAdi, this.uzmanlikAlani, this.isTuru, this.ProjeBaslangic, this.ProjeBitis, this.firmaButce.ToString(),this.isTuruSayaci.ToString()};

            return bilgiler;
        }
    }
}
