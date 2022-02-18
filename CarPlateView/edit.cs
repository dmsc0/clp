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
    public partial class edit : Form
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

        public edit()
        {
            InitializeComponent();

            this.Size = new Size(Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Width * 0.84), Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Height * 0.45));


            Region = System.Drawing.Region.FromHrgn(RoundCorner(0, 0, this.Size.Width, this.Size.Height, 20, 20));

            init();

            byte[] fontData = fontscoll.theboldfont;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, fontscoll.theboldfont.Length);
            AddFontMemResourceEx(fontPtr, (uint)fontscoll.theboldfont.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            title.Font = new Font(fonts.Families[0], 10, FontStyle.Bold);

            fontData = fontscoll.KREDIT1;
            fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            dummy = 0;
            fonts.AddMemoryFont(fontPtr, fontscoll.KREDIT1.Length);
            AddFontMemResourceEx(fontPtr, (uint)fontscoll.KREDIT1.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            editb.Font = new Font(fonts.Families[0], 8, FontStyle.Regular);
            cntry.Font = new Font(fonts.Families[0], 14, FontStyle.Regular);

            fontData = fontscoll.Neon;
            fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            dummy = 0;
            fonts.AddMemoryFont(fontPtr, fontscoll.Neon.Length);
            AddFontMemResourceEx(fontPtr, (uint)fontscoll.Neon.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            info.Font = new Font(fonts.Families[1], 10, FontStyle.Bold);
            info2.Font = new Font(fonts.Families[1], 10, FontStyle.Bold);
            info3.Font = new Font(fonts.Families[1], 10, FontStyle.Bold);

            exit.Location = new Point(this.Size.Width-exit.Width-10, exit.Location.Y);
            cplate.Location = new Point((this.Size.Width - cplate.Width)/2, cplate.Location.Y);
            edtext.Location = new Point(cplate.Location.X + cplate.Width - edtext.Width - 10, edtext.Location.Y);
            screen.Location = new Point(edtext.Location.X - screen.Width - 20, screen.Location.Y);

            info.Location = new Point(cplate.Location.X, cplate.Location.Y + cplate.Height + 30);
            info2.Location = new Point(cplate.Location.X + info.Width + 40, cplate.Location.Y + cplate.Height + 30);
            info3.Location = new Point(info2.Location.X + info2.Width + 40, cplate.Location.Y + cplate.Height + 30);

        }
        private void titlebar_Paint(object sender, PaintEventArgs e)
        {
            
            LinearGradientBrush linGrBrush = new LinearGradientBrush(
            new Point(0, 0),
            new Point(this.Size.Width, this.Size.Height),
            Color.FromArgb(225, 201, 75, 75),
            Color.FromArgb(225, 75, 19, 79));

            Pen pen = new Pen(linGrBrush);

            e.Graphics.FillRectangle(linGrBrush, 0, 0, this.Size.Width, this.Size.Height);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush linGrBrush = new LinearGradientBrush(
            new Point(0, 0),
            new Point(this.Size.Width, this.Size.Height),
            Color.FromArgb(225, 254, 164, 127),
            Color.FromArgb(225, 179, 55, 113));

            Pen pen = new Pen(linGrBrush);
    
            e.Graphics.FillRectangle(linGrBrush, 0, 0, this.Size.Width, this.Size.Height);
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

        private void title_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void title_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void title_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void exit_Paint(object sender, PaintEventArgs e)
        {
            Pen white = new Pen(Color.White, 3);
            white.SetLineCap(LineCap.Round, LineCap.Round, DashCap.Round);

            int w = exit.Size.Width*95/100;
            int x = exit.Size.Width * 5 / 100;

            e.Graphics.DrawLine(white, x, x, w, w);
            e.Graphics.DrawLine(white, w, x, x, w);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        List<string> country = new List<string>();

        private void init()
        {
            
            country.Add("Bosnia and Herzegovina");
            country.Add("Montenegro");
            country.Add("North Macedonia");
            country.Add("Serbia"); // 3

            country.Add("Austria");
            country.Add("Belgium");
            country.Add("Bulgaria");
            country.Add("Croatia");
            country.Add("Cyprus");
            country.Add("Czech Republic");
            country.Add("Denmark");
            country.Add("Estonia");
            country.Add("Finland");
            country.Add("France");
            country.Add("Germany");
            country.Add("Greece");
            country.Add("Hungary");
            country.Add("Ireland");
            country.Add("Italy");
            country.Add("Latvia");
            country.Add("Lithuania");
            country.Add("Luxembourg");
            country.Add("Malta");
            country.Add("Netherlands");
            country.Add("Poland");
            country.Add("Portugal");
            country.Add("Romania");
            country.Add("Slovakia");
            country.Add("Slovenia");
            country.Add("Spain");
            country.Add("Sweden"); // 30


            country.Add("Albania");
            country.Add("United Kingdom");
            country.Add("Ukraine");
            country.Add("Moldova");
            country.Add("Norway");

            cntry.Text = country[0];
            editb.Text = edsa2;

            editb.Width = cntry.Width;
            cntry.Location = new Point(titlebar.Width / 2 - cntry.Width / 2, cntry.Location.Y);
            editb.Location = new Point(titlebar.Width / 2 - editb.Width / 2, cntry.Location.Y + cntry.Height - 3);
        }

        string edsa2 = "edit";
        private void editb_KeyDown(object sender, KeyEventArgs e)
        {
            if (edsa2 == "save")
            {
                int pos = country.IndexOf(cntry.Text);
              
                switch (e.KeyCode)
                {
                    case Keys.D: cntry.Text = country[(pos + 1) % country.Count]; break;
                    case Keys.A:
                        if (pos - 1 < 0) pos = country.Count;
                        cntry.Text = country[pos - 1]; break;
                }

                editb.Width = cntry.Width;
                cntry.Location = new Point(titlebar.Width / 2 - cntry.Width / 2, cntry.Location.Y);
                editb.Location = new Point(titlebar.Width / 2 - editb.Width / 2, cntry.Location.Y + cntry.Height - 3);

                switch (pos)
                {
                    case 21: cplate.chcntry(pos, e); break;
                    case 23: cplate.chcntry(pos, e); break;
                    case 32: cplate.chcntry(pos, e); break;
                    default: cplate.chcntry(pos, e); break;
                }
            }
        }

        private void editb_Click(object sender, EventArgs e)
        {
            if (edsa2 == "edit")
            {
                edsa2 = "save";
                editb.Refresh();
            }
            else
            {
                edsa2 = "edit";
                editb.Refresh();
            }
            editb.Text = edsa2;
        }

        private void editb_Leave(object sender, EventArgs e)
        {
            if (edsa2 == "save")
            {
                edsa2 = "edit";
                editb.Refresh();
            }
            editb.Text = edsa2;
        }

        char[] text;

        private void edtext_Click(object sender, EventArgs e)
        {
            using (edittext etxt = new edittext())
            {
                etxt.modlen(cplate.verifyblason());

                int k;
                if (cplate.verifyblason()) k = 8;
                else k = 9;

                if (etxt.ShowDialog() == DialogResult.OK)
                {
                    string t = etxt.txt;
                        for (int i = 0; i <= k; i++)
                            t += " ";

                    text = (t).ToCharArray();
                    if (cplate.verchar(text, k) == false) this.edtext_Click(sender, e);
                    else cplate.edtext(text);
                }
            }
        }

        bool ed = true;
        private void screen_Click(object sender, EventArgs e)
        {
            cplate.disedit();
            if (ed == true)
            {
                ed = false;
                screen.BackColor = Color.FromArgb(100, 230, 126, 34);
            }
            else
            {
                ed = true;
                screen.BackColor = Color.Transparent;
            }
           
        }
    }
}
