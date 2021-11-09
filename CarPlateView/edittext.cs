﻿using System;
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
    public partial class edittext : Form
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

        
        public edittext()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(RoundCorner(0, 0, Width, Height, 20, 20));
        }
        
        private void titlebar_Paint(object sender, PaintEventArgs e)
        {

            LinearGradientBrush linGrBrush = new LinearGradientBrush(
            new Point(0, 0),
            new Point(2500, 860),
            Color.FromArgb(225, 201, 75, 75),
            Color.FromArgb(225, 75, 19, 79));

            Pen pen = new Pen(linGrBrush);

            e.Graphics.FillRectangle(linGrBrush, 0, 0, 2500, 860);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush linGrBrush = new LinearGradientBrush(
            new Point(0, 0),
            new Point(2500, 860),
            Color.FromArgb(225, 254, 164, 127),
            Color.FromArgb(225, 179, 55, 113));

            Pen pen = new Pen(linGrBrush);

            e.Graphics.FillRectangle(linGrBrush, 0, 0, 2500, 860);
        }


        private bool mouseDown;
        private Point lastLocation;

        private void titlebar_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void titlebar_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void titlebar_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void exit_Paint(object sender, PaintEventArgs e)
        {
            Pen white = new Pen(Color.White, 3);
            white.SetLineCap(LineCap.Round, LineCap.Round, DashCap.Round);

            e.Graphics.DrawLine(white, 5, 5, 15, 15);
            e.Graphics.DrawLine(white, 15, 5, 5, 15);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string txt
        { 
            get
            {
                return text.Text;
            }
        }

        public void modlen(bool res)
        {
            if (res) text.MaxLength = 8;
            else text.MaxLength = 9;
        }
    }
}