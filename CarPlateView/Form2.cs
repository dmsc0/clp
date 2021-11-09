using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace CarPlateView
{
    public partial class Form2 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr RoundCorner(
          int leftRect,
          int topRect,
          int rightRect,
          int bottomRect,
          int widthEllipse,
          int heightEllipse
        );

        public Form2()
        {
            InitializeComponent();

            Region = System.Drawing.Region.FromHrgn(RoundCorner(0, 0, Width, Height, 20, 20));
            this.Text = "Custom license plate";
            loadper.BackColor = Color.FromArgb(200, 255, 255, 255);
        }

        private void loadscreen_Load(object sender, EventArgs e)
        {
            loadtime.Start();
            loadper.Width = 0;
        }

        private void loadscreen_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush linGrBrush = new LinearGradientBrush(
            new Point(0, 0),
            new Point(1000, 550),
            Color.FromArgb(225, 131, 96, 195),
            Color.FromArgb(225, 46, 191, 145));

            Pen pen = new Pen(linGrBrush);

            e.Graphics.FillRectangle(linGrBrush, 0, 0, 1000, 550);
        }

        int tick = 0;
        Random rand = new Random();
        
        private void loadtime_Tick(object sender, EventArgs e)
        { 
            if (loadper.Width < 1000) loadper.Width += 7;
            else
            {
                tick++;
                if (tick == 7)
                {
                    this.Hide();

                    edit f1 = new edit();
                    f1.Show();
                    loadtime.Stop();
                }
            }
        }
    }
}
