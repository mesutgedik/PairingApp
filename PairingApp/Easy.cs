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
    public partial class Easy : Form
    {
        int[] Indexs = { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8}; // using for mix the pictures
        PictureBox firstBox;
        int firstIndex,matched=0,score=0;
        int count = 0,time=3;

        Image[] Images =
        {
           Properties.Resources._1,
           Properties.Resources._2,
           Properties.Resources._3,
           Properties.Resources._4,
           Properties.Resources._5,
           Properties.Resources._6,
           Properties.Resources._7,
           Properties.Resources._8

        };
        

        
        public Easy()
        {
            InitializeComponent();
        }
        List<PictureBox> pictureBoxes = new List<PictureBox>();
        private void Form1_Load(object sender, EventArgs e)
        {
            Mix_Pictures();
            show_pictures();

        }
        public void Mix_Pictures()
        {
            Random rnd = new Random();
            for(int i=0; i < 16; i++)
            {
                int random = rnd.Next(16);
                int temp = Indexs[i];
                Indexs[i] = Indexs[random];
                Indexs[random] = temp;
            }
        }
        private void show_pictures()
        {

            Control[] matches;
            for (int i = 1; i <= 16; i++)
            {
                matches = this.Controls.Find("pictureBox" + i.ToString(), true);
                if (matches.Length > 0 && matches[0] is PictureBox)
                {
                    pictureBoxes.Add((PictureBox)matches[0]);
                }
            }
            foreach (PictureBox item in pictureBoxes)
            {
                ++count;
                int Index_No = Indexs[count - 1];
                item.Image = Images[Index_No - 1];
                item.Refresh();

            }
            count = 0;

        }

        private void ShowImageTimer_Tick(object sender, EventArgs e)
        {
            time--;
            lblTime.Text = time.ToString();
            if (time == 0)
            {
                foreach (PictureBox item in pictureBoxes)
                {

                    time = 3;
                    item.Image = null;
                    item.Refresh();

                }
                ShowImageTimer.Enabled = false;
                lblTime.Visible = false;
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
            label4.Visible = true;
            label3.Visible = true;
            lblTime.Visible = true;
            score = 0;
            label4.Text = score.ToString();

            Mix_Pictures();
            show_pictures();
            ShowImageTimer.Enabled = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox Box = (PictureBox)sender; // give me which box choosed
            int Box_No = int.Parse(Box.Name.Substring(10));
            int Index_No = Indexs[Box_No-1];
            Box.Image = Images[Index_No-1];
            Box.Refresh();
            if (firstBox==null)
            {
                firstBox = Box;
                firstIndex = Index_No;
            }
            else
            {

                System.Threading.Thread.Sleep(500);
                
                if (firstIndex == Index_No)
                {
                    matched++;
                    score += 15;
                    label4.Text = score.ToString();
                    firstBox.Visible = false;
                    Box.Visible = false;
                    if (matched == 8)
                    {
                        matched = 0;
                        button1.Visible = true;
                        label1.Visible = true;
                        label4.Visible = false;
                        label3.Visible = false;
                        label2.Text="YOUR SCORE: "+ score;
                        label2.Visible = true;
                    }
                }
                score -= 5;
                label4.Text = score.ToString();
                firstBox.Image = null;
                Box.Image = null;
                firstBox = null;
            }
        }

    }
}
