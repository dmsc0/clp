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

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
        IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();

        Font myFont;
        public Form2()
        {
            InitializeComponent();

            this.Size = new Size(Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Width * 0.35), Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Height * 0.3));

            Region = System.Drawing.Region.FromHrgn(RoundCorner(0, 0, this.Size.Width, this.Size.Height, 20, 20));
            this.Text = "Custom license plate";
            loadper.BackColor = Color.FromArgb(200, 255, 255, 255);

            byte[] fontData = fontscoll.VerminVV;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, fontscoll.VerminVV.Length);
            AddFontMemResourceEx(fontPtr, (uint)fontscoll.VerminVV.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            myFont = new Font(fonts.Families[0], 20, FontStyle.Bold);

            title.Font = myFont;
            vers.Font = myFont;

            //SizeF size = new SizeF(Screen.PrimaryScreen.WorkingArea.Width / this.Size.Width, Screen.PrimaryScreen.WorkingArea.Height / this.Size.Height);
            //this.Scale(size);

            loadbar.Location = new Point(0, this.Height-loadbar.Height);
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
            new Point(this.Size.Width, this.Size.Height),
            Color.FromArgb(225, 131, 96, 195),
            Color.FromArgb(225, 46, 191, 145));

            Pen pen = new Pen(linGrBrush);

            e.Graphics.FillRectangle(linGrBrush, 0, 0, this.Size.Width, this.Size.Height);
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
