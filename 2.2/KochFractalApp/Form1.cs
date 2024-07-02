using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KochFractalApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            // Зчитування координат точок і порядку фрактала
            PointF p1 = new PointF(float.Parse(txtX1.Text), float.Parse(txtY1.Text));
            PointF p2 = new PointF(float.Parse(txtX2.Text), float.Parse(txtY2.Text));
            PointF p3 = new PointF(float.Parse(txtX3.Text), float.Parse(txtY3.Text));
            int k = int.Parse(txtOrder.Text);

            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
                DrawKoch(g, p1, p2, k);
                DrawKoch(g, p2, p3, k);
                DrawKoch(g, p3, p1, k);
            }
            pictureBox1.Image = bitmap;
        }

        private void DrawKoch(Graphics g, PointF p1, PointF p2, int k)
        {
            if (k == 0)
            {
                g.DrawLine(Pens.Black, p1, p2);
            }
            else
            {
                PointF pA = new PointF((2 * p1.X + p2.X) / 3, (2 * p1.Y + p2.Y) / 3);
                PointF pB = new PointF((p1.X + 2 * p2.X) / 3, (p1.Y + 2 * p2.Y) / 3);
                PointF pC = new PointF(
                    (float)(0.5 * (p1.X + p2.X) + Math.Sqrt(3) * (p1.Y - p2.Y) / 6),
                    (float)(0.5 * (p1.Y + p2.Y) + Math.Sqrt(3) * (p2.X - p1.X) / 6));

                DrawKoch(g, p1, pA, k - 1);
                DrawKoch(g, pA, pC, k - 1);
                DrawKoch(g, pC, pB, k - 1);
                DrawKoch(g, pB, p2, k - 1);
            }
        }
    }
}
