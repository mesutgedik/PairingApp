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
    public partial class Hard : Form
    {
        int[] Indexs = { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12, 12 }; // using for mix the pictures
        PictureBox firstBox;
        int firstIndex, matched=0,score=0;
        int count = 0;
        int time = 3;

        Image[] Images =
        {
           Properties.Resources._1,
           Properties.Resources._2,
           Properties.Resources._3,
           Properties.Resources._4,
           Properties.Resources._5,
           Properties.Resources._6,
           Properties.Resources._7,
           Properties.Resources._8,
           Properties.Resources._9,
           Properties.Resources._10,
           Properties.Resources._11,
           Properties.Resources._12

        };
        public Hard()
        {
            InitializeComponent();
        }
        List<PictureBox> pictureBoxes = new List<PictureBox>();
        private void Form3_Load(object sender, EventArgs e)
        {
            Mix_Pictures(); // resimleri karıştır fonksiyonunu çağırıyoruz.
 
            show_pictures();
        }


        public void Mix_Pictures()
        {
            Random rnd = new Random(); // random tipinde bir rnd oluşturuyoruz.
            for (int i = 0; i < 24; i++) // ve 24 kere yapıyoruz bu işlemi
            {
                int random = rnd.Next(24); // 0 ile 24 arasında random bir değer alıyoruz.
                int temp = Indexs[i]; // tempin içine index[i]'nin içindeki değeri atıyoruz.
                Indexs[i] = Indexs[random];//indexs[i]'nin içene indexs[random] dan gelen değeri atıyoruz.
                Indexs[random] = temp; // en son ilk tuttugumuz indexs[i] değerini randoma atıyoruz.
            }

        }
        private void show_pictures()
        {
            Control[] matches;
            for (int i = 1; i <= 24; i++)
            {
                matches = this.Controls.Find("pictureBox" + i.ToString(), true); //burda picturebox[i] ' yi buluyoruz.
                pictureBoxes.Add((PictureBox)matches[0]); // listeye buldugumuz pictureboı ekle.
              
            }

            foreach (PictureBox item in pictureBoxes)
            {
                ++count; // hangi pictureBox oldugunu anlamak için bir değer alıyorum.
                int Index_No = Indexs[count - 1];
                item.Image = Images[Index_No - 1];
                item.Refresh();

            }
            count = 0; // eger tekrar oyna dersem 0 dan başlasın diye

        }

        private void showImageTimer_Tick(object sender, EventArgs e)
        {
            time--; // oyun start verdiği anda her 1 sanyiede 1 eksiliyor.
            lblTime.Text = time.ToString(); // saniyeyi her seferinde ekranda gösteriyorum.
            
            if (time == 0) // eğer saniye 0 olursa resimleri gizle.
            {
                foreach (PictureBox item in pictureBoxes) // bütün kutuların içi boş oldu.
                {

                    item.Image = null; // kutunun içini boşaltıyorum.
                    item.Refresh(); // tekrar yeniliyorum.

                }
                time = 3; // tekrar oyunu başlatırsam diye timeı 3 e eşitliyorum.
                lblTime.Visible = false; // time gösteren sayıyı ekrandan gizliyorum.
                showImageTimer.Enabled = false; // timerı durduruyorum. Çünkü işim kalmadı.

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control item in Controls)
            {
                item.Visible = true;
            }
            label1.Visible = false;
            button1.Visible = false;
            label2.Visible = false;

            score = 0;
            label4.Text = score.ToString();
            Mix_Pictures();
            show_pictures();
            showImageTimer.Enabled = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox Box = (PictureBox)sender; // tıklanan kutuyu boxa atıyoruz.
            int Box_No = int.Parse(Box.Name.Substring(10)); // hangi kutu oldugunun numarasını alıyoruz.
            int Index_No = Indexs[Box_No - 1]; //indexin içindeki sayıları alıyoruz.
            Box.Image = Images[Index_No - 1]; // indexin içindeki sayıdan 1 ççıkararak image içindeki resimi atama işlemini yapıyoruz.
            Box.Refresh(); // sadece tıklanan kutunun resmini o kutuda hemen gözükmesini sağlıyoruz.
            if (firstBox == null) // önce hiç kutu seçmişmiyim ona bakıyorum. // eğerki seçmediysem firstbox a Boxı atıyorum. ve index no yu da atıyorum.
            {
                firstBox = Box;
                firstIndex = Index_No;
            }
            else // ikinci kutuya tıklanma durumuna geçiyoruz.
            {
                
                System.Threading.Thread.Sleep(500); // yarım saniye gözükmesi için bekletiyoruz.
                firstBox.Image = null;
                Box.Image = null;
                if (firstIndex == Index_No)
                {
                    matched++;
                    score += 15;
                    label4.Text = score.ToString();
                    firstBox.Visible = false;
                    Box.Visible = false;
                    if(matched==12)
                    {
                        matched = 0;
                        label2.Text = "YOUR SCORE: "+ score;
                        label2.Visible = true;
                        button1.Visible = true;
                        label1.Visible = true;
                        label4.Visible = false;
                        label3.Visible = false;
                    }
                 
                }
                
                score -= 5;
                label4.Text = score.ToString();
                firstBox = null;
            }

        }
    }

     
 }
