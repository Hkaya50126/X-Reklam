using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_Ödevi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string KullanıcıAdı;
        IdariKadro Idari = new IdariKadro();
        IdariKadro Idari1 = new IdariKadro();
        IdariKadro Idari2 = new IdariKadro();
        Oyuncu oyuncu = new Oyuncu();
        Oyuncu oyuncu1 = new Oyuncu();
        Oyuncu oyuncu2 = new Oyuncu();// Bu kısımda constructor'lar eklendi
        Oyuncu oyuncu3 = new Oyuncu();
        Muhasebe muhasebe = new Muhasebe();
        Proje proje = new Proje();
        Firma firmaIsleri = new Firma();
        OfisCalisan OfisIsleri = new OfisCalisan();
        OfisCalisan OfisIsleri1 = new OfisCalisan();
        OfisCalisan OfisIsleri2 = new OfisCalisan();
        OfisCalisan OfisIsleri3 = new OfisCalisan();
       
        DateTime Projebaslangic;
        DateTime Projebitis;
        int isSayisiSayac = 0, toplam = 0;
        decimal indirimliGelir=0;
        public int OyuncuMaas = 10000, OfisalisanMaas = 7500, IdariKadroMaas = 8000, İsGeliri = 0;

        private void Form2_Load(object sender, EventArgs e)
        {
            if (KullanıcıAdı == "MudurYardımcısı")
            {
                oyuncuAd.Enabled = false;
                oyuncuSoyad.Enabled = false;
                oyuncuUzmanlık.Visible = false;
                labelAtifProje.Visible = false;//KuzeyTeKiNoĞlU
                oyuncuProjeVar.Visible = false;
                oyuncuProjeYok.Visible = false;//Bu kısımda giriş ekranındaki kişiye göre gözükecek veya gözükmeyecek 
                //değerler var
                oyuncuCikar.Visible = false;
                oyuncuEkle.Visible = false;
                oyuncuGuncelle.Text = "Ek İzin Ata";
                oyuncuListView.Enabled = false;
                panelİdariKadro.Visible = true;
                listViewİdariKadro.Enabled = false;
                panelMaliRapor.Visible = true;
                FirmaListView.Enabled = false;
                projeAta.Visible = false;
                projeFeshEt.Visible = false;
                textBoxKarZarar.Visible = false;
                maliRaporIndirim.Visible = false;
            }
            else if (KullanıcıAdı == "Dijitalİşler")
            {
                panelOfisÇalışan.Visible = true;
                listViewOfisCalisan.Enabled = false;
                panelİdariKadro.Visible = true;
                listViewİdariKadro.Enabled = false;
                panelMaliRapor.Visible = true;
                labelEkizin.Visible = false;
                EkIzinOfis.Visible = false;
                textBoxKarZarar.Visible = false;
                maliRaporIndirim.Visible = false;
            }

            ListİdariKadroOlustur();
            ListFirmaOlustur();
            ListOyuncuOlustur();
            ListOfisOlustur();
            FirmaListOlustur();
            OyuncuListOlustur();
            ProjeListOlustur();

            Idari1.IdariKadroDeğişkenAta("Timur", "Aksak", 4000, "Pazar");
            listViewİdariKadro.Items.Add(new ListViewItem(Idari1.IdariKadroListele()));
            //Bu kısımda tablolarda örnek veriler gözükmesi için
            Idari2.IdariKadroDeğişkenAta("Beyazid", "Yıldırım", 4000, "Cumartesi");
            listViewİdariKadro.Items.Add(new ListViewItem(Idari2.IdariKadroListele()));

            if (KullanıcıAdı == "MudurYardımcısı" )
            {
                oyuncu1.OyuncuEkle("Haluk", "Bilginar", 4000, "***", "Yok", "Yok", "Yok ", "Yok");
                oyuncu2.OyuncuEkle("İstem", "Betil", 3000, "***", "Yok", "Yok", "Yok ", "Yok");
                oyuncu3.OyuncuEkle("Ali", "Acıman", 3000, "***", "Yok", "Yok", "Yok ", "Yok");//buralarda aynı şekilde 
            }
            else
            {
                oyuncu1.OyuncuEkle("Haluk", "Bilginar", 4000, "Sinema", "Yok", "Yok", "Yok ", "Yok");
                oyuncu2.OyuncuEkle("İstem", "Betil", 3000, "Seslendirme", "Yok", "Yok", "Yok ", "Yok");
                //buralarda aynı şekilde 
                oyuncu3.OyuncuEkle("Ali", "Acıman", 3000, "Reklam", "Yok", "Yok", "Yok ", "Yok");
            }

            listViewOyuncu.Items.Add(new ListViewItem(oyuncu1.OyuncuListele()));
            oyuncuListView.Items.Add(new ListViewItem(oyuncu1.OyuncuListele()));

            listViewOyuncu.Items.Add(new ListViewItem(oyuncu2.OyuncuListele()));
            oyuncuListView.Items.Add(new ListViewItem(oyuncu2.OyuncuListele()));//Bu kısımda tablolara bilgileri eklemek
            //için

            listViewOyuncu.Items.Add(new ListViewItem(oyuncu3.OyuncuListele()));
            oyuncuListView.Items.Add(new ListViewItem(oyuncu3.OyuncuListele()));

            OfisIsleri1.ofisCalisanEkle(" Kadir ", " Kaya ", "Evrak İşleri", "Pazartesi", 2500,"Yok");
            listViewOfisCalisan.Items.Add(new ListViewItem(OfisIsleri1.ofisCalisanListele()));

            OfisIsleri2.ofisCalisanEkle(" Leyla ", " Bayraktar ", "Dijital İşler", "Pazar", 2500, "Yok");
            //buralarda aynı şekilde 
            listViewOfisCalisan.Items.Add(new ListViewItem(OfisIsleri2.ofisCalisanListele()));

            OfisIsleri3.ofisCalisanEkle(" Mert ", " Yılmaz ", "Diğer", "Cumartesi", 2500, "Yok");
            listViewOfisCalisan.Items.Add(new ListViewItem(OfisIsleri3.ofisCalisanListele()));
        }
        private void ofiscalisanEkle_Click(object sender, EventArgs e)
        {

            if (ofiscalisanAd.Text == "" || ofiscalisanSoyad.Text == "" || ofiscalisanGorevi.SelectedItem == null ||ofisCalisanIzinGunu.SelectedItem == null || ofiscalisanMaas.Text == "")
            {
                MessageBox.Show("Lütfen Bilgileri Doldurunuz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OÇKutularıTemizle();//bu kısımda bilgilerin boş geçilmemesini kontrol ediyor
            }
            else
            {
                OfisIsleri.ofisCalisanEkle(ofiscalisanAd.Text, ofiscalisanSoyad.Text, ofiscalisanGorevi.Text, ofisCalisanIzinGunu.Text, Convert.ToDecimal(ofiscalisanMaas.Text),"Yok" );
                // üst kısımda class içerisine verileri atıyoruz
                listViewOfisCalisan.Items.Add(new ListViewItem(OfisIsleri.ofisCalisanListele()));
                OfisalisanMaas += Convert.ToInt32(ofiscalisanMaas.Text);//bu kısımda maaş hesaplama işlemi yapıyor

            }
            OÇKutularıTemizle();//bu kısımda kutucukları temizliyor
        }
        private void ofiscalisanSil_Click_1(object sender, EventArgs e)
        {
            foreach (ListViewItem secilen in listViewOfisCalisan.SelectedItems)
            { secilen.Remove(); }//bu kısımda tablodan tıklanılan kişiyi silme işlemi yapıyor
            OÇKutularıTemizle();
        }
        private void listViewOfisCalisan_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            labelEkizin.Visible = true;
            EkIzinOfis.Visible = true;//bu kısımda tablodan seçilen ifadeyi textboxların içerisine atanıyor
            if (listViewOfisCalisan.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewOfisCalisan.SelectedItems[0];
                ofiscalisanAd.Text = item.SubItems[0].Text;
                ofiscalisanSoyad.Text = item.SubItems[1].Text;
                ofiscalisanGorevi.SelectedItem = item.SubItems[2].Text;
                ofisCalisanIzinGunu.Text = item.SubItems[3].Text;
                ofiscalisanMaas.Text = item.SubItems[4].Text;
                if (item.SubItems[5].Text != "Yok")
                {EkIzinOfis.Value = Convert.ToDateTime(item.SubItems[5].Text);}
                OfisalisanMaas -= Convert.ToInt32(ofiscalisanMaas.Text);
            }
        }
        private void ofiscalisanGuncelle_Click(object sender, EventArgs e)
        {
            if (ofiscalisanAd.Text == "" || ofiscalisanSoyad.Text == "" || ofiscalisanGorevi.SelectedItem == null ||ofisCalisanIzinGunu.SelectedItem == null || ofiscalisanMaas.Text == "")
            {
                MessageBox.Show("Lütfen Bilgileri Doldurunuz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OÇKutularıTemizle();
                // bu kısımda bilgilerin boş geçilmemesini kontrol ediyor
            }
            else
            {
                foreach (ListViewItem secilen in listViewOfisCalisan.SelectedItems)
                { secilen.Remove(); }; //bu kısımda güncelleme işlemi yapıyor

                OfisIsleri.ofisCalisanEkle(ofiscalisanAd.Text, ofiscalisanSoyad.Text, ofiscalisanGorevi.Text, ofisCalisanIzinGunu.Text, Convert.ToDecimal(ofiscalisanMaas.Text),Convert.ToString(EkIzinOfis.Value));
                listViewOfisCalisan.Items.Add(new ListViewItem(OfisIsleri.ofisCalisanListele()));
                
                OfisalisanMaas += Convert.ToInt32(ofiscalisanMaas.Text);
                OÇKutularıTemizle();
                MessageBox.Show("Bilgiler Başarıyla Güncellenilmiştir...", "Güncelle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void idarikadroEkle_Click(object sender, EventArgs e)
        {
            if (idarikadroSoyad.Text == null || idarikadroAd.Text == null)
            {
                MessageBox.Show("Ad veya Soyad boş girilemez");
            }
            else
            {
                Idari.IdariKadroDeğişkenAta(idarikadroAd.Text, idarikadroSoyad.Text, Convert.ToDecimal(İdariKadroMaas.Text), İdariKadroİzin.SelectedItem.ToString());
                listViewİdariKadro.Items.Add(new ListViewItem(Idari.IdariKadroListele()));
                IdariKadroMaas += Convert.ToInt32(İdariKadroMaas.Text);
                İKKutularıTemizle();
            }
        }
        private void idarikadroSil_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem secilen in listViewİdariKadro.SelectedItems)
            { secilen.Remove(); }
            İKKutularıTemizle();
        }
        private void listViewİdariKadro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewİdariKadro.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewİdariKadro.SelectedItems[0];
                idarikadroAd.Text = item.SubItems[0].Text;
                idarikadroSoyad.Text = item.SubItems[1].Text;
                İdariKadroMaas.Text = item.SubItems[2].Text;
                İdariKadroİzin.SelectedItem = item.SubItems[3].Text;

                IdariKadroMaas -= Convert.ToInt32(İdariKadroMaas.Text);
            }
        }
        private void idarikadroGuncelle_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem secilen in listViewİdariKadro.SelectedItems)
            { secilen.Remove(); }

            Idari.IdariKadroDeğişkenAta(idarikadroAd.Text, idarikadroSoyad.Text, Convert.ToDecimal(İdariKadroMaas.Text), İdariKadroİzin.SelectedItem.ToString());
            listViewİdariKadro.Items.Add(new ListViewItem(Idari.IdariKadroListele()));
            
            IdariKadroMaas += Convert.ToInt32(İdariKadroMaas.Text);
            İKKutularıTemizle();
            MessageBox.Show("Bilgiler Başarıyla Güncellenilmiştir...", "Güncelle", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
     
        
        private void oyuncuEkle_Click(object sender, EventArgs e)
        {
            if (oyuncuAd.Text == "" || oyuncuSoyad.Text == "" || oyuncuUzmanlık.Text == "" || oyuncuMaas.Text == "")
            {
                MessageBox.Show("Lütfen eksik bilgileri tamamlayınız.");

            }
            else
            {
                if (oyuncuProjeYok.Checked == true)
                {
                   oyuncu.OyuncuEkle(oyuncuAd.Text, oyuncuSoyad.Text, Convert.ToDecimal(oyuncuMaas.Text), oyuncuUzmanlık.Text, "Yok", "Yok", "Yok", "Yok");
                    listViewOyuncu.Items.Add(new ListViewItem(oyuncu.OyuncuListele())); 
                    oyuncuListView.Items.Add(new ListViewItem(oyuncu.OyuncuListele()));
                    OyuncuMaas += Convert.ToInt32(oyuncuMaas.Text);
                }
                else
                {
                    oyuncu.OyuncuEkle(oyuncuAd.Text, oyuncuSoyad.Text, Convert.ToDecimal(oyuncuMaas.Text), oyuncuUzmanlık.Text, oyuncuProje.Text, dateTimePickerBaş.Text.ToString(), dateTimePickerBitiş.Text.ToString(), "Yok");
                    listViewOyuncu.Items.Add(new ListViewItem(oyuncu.OyuncuListele()));
                    oyuncuListView.Items.Add(new ListViewItem(oyuncu.OyuncuListele()));
                    OyuncuMaas += Convert.ToInt32(oyuncuMaas.Text);
                }
                OKutularıTemizle();
            }
        }
        private void oyuncuCikar_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem secilen in listViewOyuncu.SelectedItems)
            { secilen.Remove(); }
            OKutularıTemizle();
        }
        private void oyuncuProjeYok_CheckedChanged(object sender, EventArgs e)
        {
            if (oyuncuProjeVar.Checked == true)
            {
                labelProjeBaş.Visible = true;
                labelProjeBitiş.Visible = true;
                labelProjeIsmı.Visible = true;
                oyuncuProje.Visible = true;
                dateTimePickerBaş.Visible = true;
                dateTimePickerBitiş.Visible = true;
            }

            else
            {
                labelProjeBaş.Visible = false;
                labelProjeBitiş.Visible = false;
                labelProjeIsmı.Visible = false;
                oyuncuProje.Visible = false;
                dateTimePickerBaş.Visible = false;
                dateTimePickerBitiş.Visible = false;
            }

        }
        private void listViewOyuncu_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelEkizin2.Visible = true;
            EkİzinOyuncu.Visible = true;
                if (listViewOyuncu.SelectedItems.Count > 0)
                {
                    ListViewItem item = listViewOyuncu.SelectedItems[0];
                    oyuncuAd.Text = item.SubItems[0].Text;
                    oyuncuSoyad.Text = item.SubItems[1].Text;
                    oyuncuMaas.Text = item.SubItems[2].Text;
                    oyuncuUzmanlık.SelectedItem = item.SubItems[3].Text;
                }
            OyuncuMaas -= Convert.ToInt32(oyuncuMaas.Text);
        }
        private void oyuncuGuncelle_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem secilen in listViewOyuncu.SelectedItems)
            {secilen.Remove();}
            
            if (oyuncuProjeVar.Checked == true)
            {oyuncu.OyuncuEkle(oyuncuAd.Text, oyuncuSoyad.Text, Convert.ToDecimal(oyuncuMaas.Text), oyuncuUzmanlık.Text, oyuncuProje.Text, dateTimePickerBaş.Value.ToString(), dateTimePickerBitiş.Value.ToString(), EkİzinOyuncu.Value.ToString());}
            else
            {oyuncu.OyuncuEkle(oyuncuAd.Text, oyuncuSoyad.Text, Convert.ToDecimal(oyuncuMaas.Text), oyuncuUzmanlık.Text, "Yok", "Yok", "Yok", EkİzinOyuncu.Value.ToString()); }
           
            listViewOyuncu.Items.Add(new ListViewItem(oyuncu.OyuncuListele()));
            oyuncuListView.Items.Add(new ListViewItem(oyuncu.OyuncuListele()));

            OyuncuMaas += Convert.ToInt32(oyuncuMaas.Text);
            OKutularıTemizle();
            MessageBox.Show("Bilgiler Başarıyla Güncellenilmiştir...", "Güncelle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void oyuncuListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (oyuncuListView.SelectedItems.Count > 0)
            {
                ListViewItem item = oyuncuListView.SelectedItems[0];
                projeAtaAd.Text = item.SubItems[0].Text;
                projeAtaSoyad.Text = item.SubItems[1].Text;
                projeAtaMaas.Text = item.SubItems[2].Text;
                projeAtaUzmanlik.Text = item.SubItems[3].Text;
            }
        }
        private void FirmaListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FirmaListView.SelectedItems.Count > 0)
            {
                ListViewItem item = FirmaListView.SelectedItems[0];
                anlastigiFirmaAd.Text = item.SubItems[0].Text;
                anlastigiFirmaIs.Text = item.SubItems[2].Text;
                anlastigiButce.Text = item.SubItems[3].Text;
                projeBaslangicTarihi.Value = Convert.ToDateTime(item.SubItems[4].Text);
                projeBitisTarihi.Value = Convert.ToDateTime(item.SubItems[5].Text);
                anlastigiIsSayisi.Text = toplam.ToString();
            }
        }



        private void firmaEkle_Click(object sender, EventArgs e)
        {
            if (firmaIsSayisi.Text == "0")
            {
                isSayisiSayac = 1;
            }
            if (firmaAd.Text == "" || firmaSehir.SelectedItem == null)
            {
                MessageBox.Show("Lütfen Bilgileri Doldurunuz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FKutularıTemizle();
            }
            else
            {
                firmaIsleri.FirmaEkle(firmaAd.Text, firmaSehir.Text, firmaIsTuru.Text, Convert.ToInt32(firmaButce.Text), firmaBaslangic.Value.ToString(),firmaBitis.Value.ToString(), Convert.ToInt32(firmaIsSayisi.Text));
                listViewFirmalar.Items.Add(new ListViewItem(firmaIsleri.FirmaListele()));
                FirmaListView.Items.Add(new ListViewItem(firmaIsleri.FirmaListele()));

             
            }
            FKutularıTemizle();
        }
        private void firmaCikar_Click(object sender, EventArgs e)
        {
            DialogResult cevap123 = new DialogResult();

            cevap123 = MessageBox.Show("bilgileri silmek istediğinizden eminmisiniz?", "silme işlemi", MessageBoxButtons.YesNoCancel);
            if (cevap123 == DialogResult.Yes)
            {
                listViewFirmalar.SelectedItems[0].Remove();
            }
        }
        private void listViewFirmalar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewFirmalar.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewFirmalar.SelectedItems[0];
                firmaAd.Text = item.SubItems[0].Text;
                firmaSehir.SelectedItem = item.SubItems[1].Text;
                firmaIsTuru.SelectedItem = item.SubItems[2].Text;
                firmaButce.Text = item.SubItems[3].Text;
                firmaIsSayisi.Text = item.SubItems[6].Text;
                İsGeliri -= Convert.ToInt32(firmaButce.Text);
            }
        }
        private void firmaGuncelle_Click(object sender, EventArgs e)
        {
            if (firmaAd.Text == "" || firmaSehir.SelectedItem == null || firmaIsTuru.SelectedItem == null || firmaButce.Text == "")
            {
                MessageBox.Show("Lütfen Bilgileri Doldurunuz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FKutularıTemizle();
            }
            else
            {
                foreach (ListViewItem secilen in listViewFirmalar.SelectedItems)
                { secilen.Remove(); }

                firmaIsleri.FirmaEkle(firmaAd.Text, firmaSehir.Text, firmaIsTuru.Text, Convert.ToInt32(firmaButce.Text), firmaBaslangic.Value.ToString(), firmaBitis.Value.ToString(), Convert.ToInt32(firmaIsSayisi.Text));
                listViewFirmalar.Items.Add(new ListViewItem(firmaIsleri.FirmaListele()));
                FirmaListView.Items.Add(new ListViewItem(firmaIsleri.FirmaListele()));

                İsGeliri += Convert.ToInt32(firmaButce.Text);
                FKutularıTemizle();
                MessageBox.Show("Bilgiler Başarıyla Güncellenilmiştir...", "Güncelle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void projeAta_Click(object sender, EventArgs e)
        {
            if (oyuncuProjeVar.Checked == true)
            {
                MessageBox.Show("Oyuncu zaten bir projede yer almaktadır.", MessageBoxIcon.Error.ToString());
            }
            else
            {
                if (projeAtaAd.Text == "" || projeAtaSoyad.Text == "" || projeAtaUzmanlik.Text == "" || anlastigiFirmaAd.Text == "" || anlastigiFirmaIs.Text == "")
                {
                    MessageBox.Show("Bilgiler Boşken Atama Yapamazsınız", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PKutuTemizle();
                }
                else
                {
                    toplam = 0;
                    toplam = (Convert.ToInt32(anlastigiIsSayisi.Text)) + 1;
                    anlastigiIsSayisi.Text = toplam.ToString();

                    if (Convert.ToInt32(anlastigiIsSayisi.Text) >= 3)// bu kısımda iş sayısını otomatik olarak hesaplayıp
                        // 3 çalışmadan fazla sayıda ise indirim uyguluyor
                    {
                        İsGeliri += Convert.ToInt32(anlastigiButce.Text) * 80 / 100;
                        indirimliGelir = Convert.ToDecimal(anlastigiButce.Text)  * 80 / 100;
                        maliRaporIndirim.Text = indirimliGelir.ToString();

                        proje.ProjeAtama(projeAtaAd.Text, projeAtaSoyad.Text, Convert.ToInt32(projeAtaMaas.Text), anlastigiFirmaAd.Text, projeAtaUzmanlik.Text, anlastigiFirmaIs.Text, Projebaslangic.ToString(), Projebitis.ToString(), Convert.ToInt32(anlastigiButce.Text)*80/100, isSayisiSayac);
                        projeAtaListView.Items.Add(new ListViewItem(proje.ProjeListele()));

                    }
                    else
                    {
                        maliRaporIndirim.Text = anlastigiButce.Text;
                        İsGeliri += Convert.ToInt32(anlastigiButce.Text) ;
                        proje.ProjeAtama(projeAtaAd.Text, projeAtaSoyad.Text, Convert.ToInt32(projeAtaMaas.Text), anlastigiFirmaAd.Text,projeAtaUzmanlik.Text, anlastigiFirmaIs.Text, Projebaslangic.ToString(), Projebitis.ToString(), Convert.ToInt32(anlastigiButce.Text), isSayisiSayac);
                        projeAtaListView.Items.Add(new ListViewItem(proje.ProjeListele()));
                    }
                    isSayisiSayac = isSayisiSayac + 1;

                }
                PKutuTemizle();
            }
        }
        private void projeFeshEt_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem secilen in projeAtaListView.SelectedItems)
                { secilen.Remove(); }
                PKutuTemizle();
        }

        private void MaliRaporGoster_Click(object sender, EventArgs e)
        {
            //bu kısımda mali rapor işlemlerini tabloda ve textboxlarda gösteriyor
            maliRaporLB.Items.Clear();
            muhasebe.BrutGelirAl(İsGeliri);
            maliRaporGider.Text ="-"+ muhasebe.GiderHesapla(IdariKadroMaas, OyuncuMaas ,OfisalisanMaas).ToString();
            maliRaporBrutGelir.Text = Convert.ToString(İsGeliri);
            maliRaporGelir.Text = muhasebe.NetGelirHesapla().ToString();

            maliRaporLB.Items.Add("İdari Kadronun Maaş Gideri: " + IdariKadroMaas);
            maliRaporLB.Items.Add("Oyuncuların Maaş Gideri: " + OyuncuMaas);
            maliRaporLB.Items.Add("Ofis Çalışanlarının Maaş Gideri: " + OfisalisanMaas);
            maliRaporLB.Items.Add("Yapılan İşlerin Geliri: " + İsGeliri);

            if (muhasebe.NetGelirHesapla() > 0)
            {
                labelKarZarar.Text = "Kazancınız= ";
                textBoxKarZarar.Text = muhasebe.NetGelirHesapla().ToString();
            }
            else
            {
                labelKarZarar.Text = "Zararınız= ";
                textBoxKarZarar.Text = muhasebe.NetGelirHesapla().ToString();
            }



        }

        public void İKKutularıTemizle()
        {
            idarikadroAd.Text = "";
            idarikadroSoyad.Text = "";//bu fonksiyonda textboxları temizleme işlemi yapıyor
            İdariKadroMaas.Text = "";
            İdariKadroİzin.SelectedItem = null;
        }
        public void OKutularıTemizle()
        {
            oyuncuAd.Text = "";
            oyuncuSoyad.Text = "";
            oyuncuMaas.Text = "";
            oyuncuUzmanlık.SelectedItem = null;
            oyuncuProje.Text = "";
        }
        public void OÇKutularıTemizle()
        {
            ofiscalisanAd.Text = "";
            ofiscalisanSoyad.Text = "";
            ofiscalisanGorevi.SelectedItem = null;
            ofisCalisanIzinGunu.SelectedItem = null;
            ofiscalisanMaas.Text = "";
        }
        public void FKutularıTemizle()
        {
            firmaAd.Clear();
            firmaSehir.SelectedItem = null;
            firmaIsTuru.SelectedItem = null;
            firmaButce.Clear();
        }
        public void PKutuTemizle()
        {
            projeAtaAd.Text = "";
            projeAtaSoyad.Text = "";
            anlastigiFirmaIs.Text = "";
            projeAtaUzmanlik.Text = "";
            anlastigiFirmaAd.Text = "";
            projeAtaMaas.Text = "";
            anlastigiButce.Text = "";
        }


        public void ListİdariKadroOlustur()
        {
            listViewİdariKadro.View = View.Details;
            listViewİdariKadro.FullRowSelect = true;
            listViewİdariKadro.Columns.Add("Ad", 100);
            listViewİdariKadro.Columns.Add("Soyad", 100);
            listViewİdariKadro.Columns.Add("Maaş", 100);
            listViewİdariKadro.Columns.Add("İzin Günü", 98);
        }
        public void ListFirmaOlustur()
        {
            listViewFirmalar.View = View.Details;// bu kısımda tabloların içindeki satırların başlıklarını giriyor
            listViewFirmalar.FullRowSelect = true;
            listViewFirmalar.Columns.Add("firma adı", 125, HorizontalAlignment.Left);
            listViewFirmalar.Columns.Add("bulunduğu şehir", 125, HorizontalAlignment.Left);
            listViewFirmalar.Columns.Add("iş türü", 125, HorizontalAlignment.Left);
            listViewFirmalar.Columns.Add("belirlenen bütçe", 125, HorizontalAlignment.Left);
            listViewFirmalar.Columns.Add("Proje başlangıç tarihi", 125, HorizontalAlignment.Left);
            listViewFirmalar.Columns.Add("Proje bitiş tarihi", 125, HorizontalAlignment.Left);
            listViewFirmalar.Columns.Add("iş sayısı", 125, HorizontalAlignment.Left);
        }
        public void ListOyuncuOlustur()
        {
            listViewOyuncu.View = View.Details;
            listViewOyuncu.FullRowSelect = true;
            listViewOyuncu.Columns.Add("Ad", 100);
            listViewOyuncu.Columns.Add("Soyad", 100);
            listViewOyuncu.Columns.Add("Maaş", 50);
            listViewOyuncu.Columns.Add("Uzmanlık Alanı", 100);
            listViewOyuncu.Columns.Add("Proje", 100);
            listViewOyuncu.Columns.Add("Proje Başlangıç", 125);
            listViewOyuncu.Columns.Add("Proje Bitiş", 125);
            listViewOyuncu.Columns.Add("Ekİzin", 125);
        }

        private void panelİdariKadro_Paint(object sender, PaintEventArgs e)
        {

        }

        public void ListOfisOlustur()
        {
            listViewOfisCalisan.View = View.Details;
            listViewOfisCalisan.FullRowSelect = true;
            listViewOfisCalisan.Columns.Add("Ad", 100);
            listViewOfisCalisan.Columns.Add("Soyad", 100);
            listViewOfisCalisan.Columns.Add("Görevi", 170);
            listViewOfisCalisan.Columns.Add("İzin Günleri", 100);
            listViewOfisCalisan.Columns.Add("Maaş", 110);
            listViewOfisCalisan.Columns.Add("Ek İzin", 100);
        }
        public void OyuncuListOlustur()
        {
            oyuncuListView.View = View.Details;
            oyuncuListView.FullRowSelect = true;
            oyuncuListView.Columns.Add("Ad", 50);
            oyuncuListView.Columns.Add("Soyad", 50);
            oyuncuListView.Columns.Add("Maaş", 50);
            oyuncuListView.Columns.Add("Uzmanlık Alanı", 100);
            oyuncuListView.Columns.Add("İş Yaptığı Firma", 100);
        }
        public void FirmaListOlustur()
        {
            FirmaListView.View = View.Details;
            FirmaListView.FullRowSelect = true;
            FirmaListView.Columns.Add("Firma Adı", 70);
            FirmaListView.Columns.Add("Şehir", 70);
            FirmaListView.Columns.Add("İş Türü", 100);
            FirmaListView.Columns.Add("Belirlenen Bütçe", 70);
            FirmaListView.Columns.Add("Proje Başlangıç Tarihi", 70);
            FirmaListView.Columns.Add("Proje Bitiş Tarihi", 70);
            FirmaListView.Columns.Add("İş Sayısı", 70);
        }
        public void ProjeListOlustur()
        {
            projeAtaListView.View = View.Details;
            projeAtaListView.FullRowSelect = true;
            projeAtaListView.Columns.Add("Ad", 100);
            projeAtaListView.Columns.Add("Soyad", 130);
            projeAtaListView.Columns.Add("Maaş", 100);
            projeAtaListView.Columns.Add("Firma Adı", 100);
            projeAtaListView.Columns.Add("Uzmanlık Alanı", 100);
            projeAtaListView.Columns.Add("İş Türü", 100);
            projeAtaListView.Columns.Add("Proje Başlangıç Tarihi", 100);
            projeAtaListView.Columns.Add("Proje Bitiş Tarihi", 100);
            projeAtaListView.Columns.Add("Belirlenen Bütçe", 100);
            projeAtaListView.Columns.Add("İş Sayısı", 70);
        }
    }
}

