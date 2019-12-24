using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PairingApp
{
    public partial class Start : Form
    {
        Easy f1;
        Hard f3;
        public Start()
        {
            InitializeComponent();
        }
       

         private void button2_Click(object sender, EventArgs e)
        {
            this.Hide(); //giriş ekranınnı gizle
            f1 =new Easy(); // easy formunu yarat.
            f1.FormClosing += new FormClosingEventHandler(f1_FormClosing); // fonskiyon tanımlama işlemi
            f1.Show(); // easy formunu göster.
        }

        private void f1_FormClosing(object sender, FormClosingEventArgs e)
        {
           this.Show(); //easy formu kapanınca start formunun tekrar görünmesini sağlıyor
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide(); // start ekranını gizle
            f3 = new Hard(); // yeni bir tane zor bölümü oluştur
            f3.FormClosing += f3_FormClosing; // formclosing fonksiyonunu ekle
            f3.Show(); // zor formunu göster.
            

        }

        private void f3_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show(); // hard formu kapatılınca start ekranını göster
        }
    }
}
