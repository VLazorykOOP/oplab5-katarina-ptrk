using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BezierCurveApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            // Зчитування координат точок
            PointF p1 = new PointF(float.Parse(txtX1.Text), float.Parse(txtY1.Text));
            PointF p2 = new PointF(float.Parse(txtX2.Text), float.Parse(txtY2.Text));
            PointF p3 = new PointF(float.Parse(txtX3.Text), float.Parse(txtY3.Text));
            PointF p4 = new PointF(float.Parse(txtX4.Text), float.Parse(txtY4.Text));

            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
                DrawBezier(g, p1, p2, p3, p4);
            }
            pictureBox1.Image = bitmap;
        }

        private void DrawBezier(Graphics g, PointF p1, PointF p2, PointF p3, PointF p4)
        {
            Pen pen = new Pen(Color.Black, 2);
            for (float t = 0; t <= 1; t += 0.01f)
            {
                float x = (float)(Math.Pow(1 - t, 3) * p1.X + 3 * Math.Pow(1 - t, 2) * t * p2.X + 3 * (1 - t) * Math.Pow(t, 2) * p3.X + Math.Pow(t, 3) * p4.X);
                float y = (float)(Math.Pow(1 - t, 3) * p1.Y + 3 * Math.Pow(1 - t, 2) * t * p2.Y + 3 * (1 - t) * Math.Pow(t, 2) * p3.Y + Math.Pow(t, 3) * p4.Y);
                g.FillRectangle(Brushes.Black, x, y, 1, 1);
            }
        }


    }
}
