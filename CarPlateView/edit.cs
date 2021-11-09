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

        public edit()
        {
            InitializeComponent();

            Region = System.Drawing.Region.FromHrgn(RoundCorner(0, 0, Width, Height, 20, 20));

            init();
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

            e.Graphics.DrawLine(white, 5, 5, 35, 35);
            e.Graphics.DrawLine(white, 35, 5, 5, 35);
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
