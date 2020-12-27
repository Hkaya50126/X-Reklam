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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {


        }
  
        private void gozIcon_MouseHover(object sender, EventArgs e)
        {
            sifreText.PasswordChar = '\0';
        }

        private void gozIcon_MouseLeave_1(object sender, EventArgs e)
        {
            sifreText.PasswordChar = '*';
        }

        private void girisYap_Click(object sender, EventArgs e)
        {
            
            Form2 form2 = new Form2();

            if (kadiText.Text == "" || sifreText.Text == "")
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Boş Girilemez");
            }
           else if ( kadiText.Text=="Mudur" && sifreText.Text == "M123")
            {
               form2.KullanıcıAdı = kadiText.Text;
                MessageBox.Show("Giriş Başarılı!" + Environment.NewLine + "Hoşgeldiniz Müdür Bey", "Hoşgeldiniz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                form2.Show();
            }
            else if (kadiText.Text == "MudurYardımcısı" && sifreText.Text == "MY123")
            {
                form2.KullanıcıAdı = kadiText.Text;
                MessageBox.Show("Giriş Başarılı!" + Environment.NewLine + "Hoşgeldiniz Sayın Müdür Yardımcısı", "Hoşgeldiniz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                form2.Show();
            }
            else if (kadiText.Text == "MudurYardımcısı" && sifreText.Text == "2MY123")
            {
                form2.KullanıcıAdı = kadiText.Text;
                MessageBox.Show("Giriş Başarılı!" + Environment.NewLine + "Hoşgeldiniz Sayın Müdür Yardımcısı", "Hoşgeldiniz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                form2.Show();
            }
            else if (kadiText.Text == "Dijitalİşler" && sifreText.Text == "Dİ123")
            {
                form2.KullanıcıAdı = kadiText.Text;
                MessageBox.Show("Giriş Başarılı!" + Environment.NewLine + "Hoşgeldiniz", "Hoşgeldiniz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                form2.Show();
            }
            else 
            {
            MessageBox.Show("Yanlış Giriş" + Environment.NewLine + "Lütfen Yeniden Deneyiniz");
            }
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                girisYap.PerformClick();
            }
        }
    }
}
