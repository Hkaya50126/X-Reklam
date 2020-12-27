using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje_Ödevi
{
    class Firma
    {
        //bu kısımda firmaları kaydedip listeleme işlemi yapıyor 
        public string FirmaAdi { get; set; }
        private string BulunduguSehir { get; set; }
        private string IsTuru { get; set; }
        private string ProjeBaslangic { get; set; }
        private string ProjeBitis { get; set; }
        private int BelirlenenButce { get; set; }
        private int IsSayisi { get; set; }
        //Fonksiyonlar
        public void FirmaEkle(string firmaAdi, string bulunduguSehir, string isTuru, int belirlenenButce,string projebas,string projebitiş,int isSayisi)
        {
            this.FirmaAdi = firmaAdi;
            this.BulunduguSehir = bulunduguSehir;
            this.IsTuru = isTuru;
            this.BelirlenenButce = belirlenenButce;
            this.IsSayisi = Convert.ToInt32(isSayisi);
            this.ProjeBaslangic = projebas;
            this.ProjeBitis = projebitiş;
        }

        public string[] FirmaListele()
        {
            string[] bilgiler = { this.FirmaAdi, this.BulunduguSehir, this.IsTuru, this.BelirlenenButce.ToString(), this.ProjeBaslangic, this.ProjeBitis,this.IsSayisi.ToString() };
            return bilgiler;
        }

    }
}
