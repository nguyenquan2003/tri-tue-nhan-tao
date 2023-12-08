using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baitoantamgiac
{
    public partial class Form2 : Form
    {
        Pen Mypen = new Pen(Color.Green, 4);
        Pen Mypen_1 = new Pen(Color.YellowGreen, 4);
        Pen Mypen_2 = new Pen(Color.CadetBlue, 4);
        Pen Mypen_3 = new Pen(Color.DeepPink, 4);
        Pen Mypen_4 = new Pen(Color.DarkViolet, 4);
        Pen Mypen_5 = new Pen(Color.Orange, 4);
        Timer mytime = new Timer();
        Graphics g;

        public Form2()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }
        //Vẽ lên mạng ngữ nghĩa

        public void LoaiHinh(int loai)
        {
            switch (loai)
            {
                case 0:
                {
                    g.DrawLine(Mypen, 97, 139, 55, 183);
                    g.DrawLine(Mypen, 102, 105, 103, 53);
                    g.DrawLine(Mypen, 130, 118, 339, 42);
                    break;
                }

                case 1:
                {
                    g.DrawLine(Mypen_1, 181, 52, 285, 109);
                    g.DrawLine(Mypen_1, 285, 122, 128, 186);
                    g.DrawLine(Mypen_1, 327, 120, 467, 186);
                    g.DrawLine(Mypen_1, 319, 103, 418, 55);
                    break;
                }
                case 2:
                {
                    g.DrawLine(Mypen_2, 270, 42, 483, 114);
                    g.DrawLine(Mypen_2, 503, 53, 509, 103);
                    g.DrawLine(Mypen_2, 522, 133, 547, 183);
                    g.DrawLine(Mypen_2, 484, 132, 318, 196);
                    break;
                }
                case 3:
                {
                    g.DrawLine(Mypen_3, 46, 228, 101, 280);
                    g.DrawLine(Mypen_3, 140, 283, 225, 226);
                    g.DrawLine(Mypen_3, 103, 304, 59, 372);
                    g.DrawLine(Mypen_3, 141, 298, 189, 386);
                    break;
                }
                case 4:
                {
                    g.DrawLine(Mypen_4, 310, 273, 309, 226);
                    g.DrawLine(Mypen_4, 127, 208, 290, 286);
                    g.DrawLine(Mypen_4, 111, 374, 291, 302);
                    g.DrawLine(Mypen_4, 308, 315, 309, 372);
                    g.DrawLine(Mypen_4, 333, 290, 465, 206);
                    break;
                }
                case 5:
                {
                    g.DrawLine(Mypen_5, 510, 287, 364, 229);
                    g.DrawLine(Mypen_5, 540, 285, 544, 227);
                    g.DrawLine(Mypen_5, 542, 309, 547, 371);
                    g.DrawLine(Mypen_5, 509, 309, 360, 374);
                    g.DrawLine(Mypen_5, 503, 299, 104, 373);
                    break;
                }
                case 6:
                {
                    g.DrawLine(Mypen, 102, 493, 75, 418);
                    g.DrawLine(Mypen, 141, 485, 228, 417);
                    g.DrawLine(Mypen, 130, 513, 145, 559);
                    g.DrawLine(Mypen, 144, 504, 367, 586);
                    break;
                }
                case 7:
                {
                    g.DrawLine(Mypen_1, 323, 475, 322, 417);
                    g.DrawLine(Mypen_2, 327, 514, 365, 599);
                    g.DrawLine(Mypen_3, 342, 493, 488, 417);
                    break;
                }
                case 8:
                {
                    g.DrawLine(Mypen_4, 530, 478, 551, 415);
                    g.DrawLine(Mypen_4, 515, 515, 473, 583);
                    break;
                }
            }
        }
        
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
            this.Hide();
        }  
    }
}
