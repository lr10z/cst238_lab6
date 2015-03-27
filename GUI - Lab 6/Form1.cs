using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI___Lab_6
{
    public partial class Form1 : Form
    {
        private int x, y;
        private int deltax, deltay;
        private int x1, x2;
        private int previousX;
        private int pressCount;
        public Form1()
        {
            InitializeComponent();

            x = this.ClientRectangle.Width / 2;
            y = this.ClientRectangle.Height / 2;
            deltax = 5;
            deltay = 5;

            x1 = 32;
            x2 = 200;
            ResizeRedraw = true;
            DoubleBuffered = true;

            pressCount = 0;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect1 = new Rectangle(x1, 50, 50, 50);
            Rectangle rect2 = new Rectangle(x2, 50, 50, 50);
            g.FillEllipse(Brushes.White, rect1);
            g.FillEllipse(Brushes.Black, rect2);

            Graphics gM = e.Graphics;
            Rectangle rect = new Rectangle(x, y, 100, 100);
            Bitmap image = Properties.Resources.mario;
            image.MakeTransparent(Color.White);
            gM.DrawImage(image, rect);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //assuming x1 is less than x2
            x1 += 10;
            x2 -= 10;
            if (x2 == previousX)
                timer1.Stop();
            this.Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int pressed = 0;

            if (e.KeyCode == Keys.Up)
                y -= 5;
            else if (e.KeyCode == Keys.Down)
                y += 5;
            else if (e.KeyCode == Keys.Left)
                x -= 5;
            else if (e.KeyCode == Keys.Right)
                x += 5;
            else if (e.KeyCode == Keys.Space)
            {
                if( pressCount == pressed )
                {
                    ++pressCount;
                    timer1.Start();
                }
                else
                {
                    --pressCount;
                    timer1.Stop();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                timer2.Stop();
            }
            else if(e.KeyCode == Keys.B)
            {
                timer2.Start();
            }
            else if(e.KeyCode == Keys.S)
            {
                timer2.Stop();
            }

            this.Invalidate();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (x + deltax > this.ClientRectangle.Width - 100 || x < 0)
                deltax = -deltax;
            if (y + deltay > this.ClientRectangle.Height - 100 || y < 0)
                deltay = -deltay;
            x += deltax;
            y += deltay;
            this.Invalidate();
        }
    }
}
