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
using System.Drawing.Text;

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

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
        IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();

        public edittext()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(RoundCorner(0, 0, Width, Height, 20, 20));

            byte[] fontData = fontscoll.Vulpes;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, fontscoll.Vulpes.Length);
            AddFontMemResourceEx(fontPtr, (uint)fontscoll.Vulpes.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            info.Font = new Font(fonts.Families[0], 9, FontStyle.Bold);

            fontData = fontscoll.Neon;
            fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            dummy = 0;
            fonts.AddMemoryFont(fontPtr, fontscoll.Neon.Length);
            AddFontMemResourceEx(fontPtr, (uint)fontscoll.Neon.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            done.Font = new Font(fonts.Families[0], 9);

            int k = titlebar.Height - 10;
            exit.Size = new Size(k , k);
            exit.Location = new Point(titlebar.Width - (int)(titlebar.Width / 100) - k, titlebar.Height * 10 / 100);
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
            Pen white = new Pen(Color.White, 2);
            white.SetLineCap(LineCap.Round, LineCap.Round, DashCap.Round);

            int w = exit.Size.Width * 90 / 100;
            int x = exit.Size.Width * 10 / 100;

            e.Graphics.DrawLine(white, x, x, w, w);
            e.Graphics.DrawLine(white, w, x, x, w);
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
