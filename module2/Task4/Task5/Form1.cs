using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = false;
            timer1.Interval = 100;
            timer2.Enabled = true;
            timer2.Interval = 100;
        }

        float xz, yz;
        float one;
        float rz;
        float wz, hz;
        int k = 0;
        float teta0 = (float)(5 * Math.PI / 4);
        float R0;
        float rs;
        float ws, hs;
        float dt = (float)(Math.PI / 100);
        int kz = 15, ks = 4, kr = 1, kOne = 100;

        private void Button1_Click(object sender, System.EventArgs e)
        {
            if (button1.Text == "Запуск")
            {
                button1.Text = "Посадка";
                timer1.Enabled = true;
                timer2.Enabled = false;
            }
            else if (button1.Text == "Посадка")
            {
                button1.Text = "Запуск";
                timer1.Enabled = false;
                timer2.Enabled = true;
            }
        }

        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (!timer1.Enabled)
                PictureData();
            else if (!timer2.Enabled)
                PictureData();
            pictureBox1.Refresh();
        }

        private void Timer1_Tick(object sender, System.EventArgs e)
        {
            PictureData();
            k++;
            pictureBox1.Refresh();
        }

        private void Timer2_Tick(object sender, System.EventArgs e)
        {
            PictureData();
            k--;
            pictureBox1.Refresh();
        }

        private void PictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen blackPen = new Pen(Color.Black);
            Pen greenPen = new Pen(Color.Green);
            graphics.FillEllipse(blackPen.Brush, ws, hs, 2 * rs, 2 * rs);
            graphics.FillEllipse(greenPen.Brush, wz, hz, 2 * rz, 2 * rz);
        }

        private void PictureData()
        {
            xz = pictureBox1.Size.Width / 2;
            yz = pictureBox1.Size.Height / 2;
            one = Math.Min(xz, yz) / kOne;
            rz = one * kz;
            wz = xz - rz; hz = yz - rz;
            rs = one * ks;
            ws = wz;
            hs = hz;
            float R;
            R0 = (float)Math.Sqrt((ws - xz) * (ws - xz) + (hs - yz) * (hs - yz));
            float dR = one * kr;
            R = Math.Min(R0 + k * dR, one * 80);
            if (R > rz + rs)
            {
                ws = (float)(R * Math.Cos(teta0 + k * dt)) + xz;
                hs = (float)(R * Math.Sin(teta0 + k * dt)) + yz;
            }
        }

    }
}
