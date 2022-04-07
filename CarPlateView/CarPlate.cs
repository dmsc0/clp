using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Runtime;
// v 1.2

namespace CarPlateView
{
    public partial class CarPlate : UserControl
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
        public CarPlate()
        {
            InitializeComponent();

            Region = System.Drawing.Region.FromHrgn(RoundCorner(0, 0, Width, Height, 50, 50));

            init();

            byte[] fontData = fontscoll.BEBAS;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, fontscoll.BEBAS.Length);
            AddFontMemResourceEx(fontPtr, (uint)fontscoll.BEBAS.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            rosign.Font = new Font(fonts.Families[0], 28);

            fontData = fontscoll.KREDIT1;
            fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            dummy = 0;
            fonts.AddMemoryFont(fontPtr, fontscoll.KREDIT1.Length);
            AddFontMemResourceEx(fontPtr, (uint)fontscoll.KREDIT1.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            myFont = new Font(fonts.Families[1], 5);

            edit.Size = new Size(letters.Width * 5 / 100, letters.Height * 10 / 100);
            edit.Location = new Point((int)(letters.Width * 102.5 / 100), -(edit.Height * 5 / 100));
        }

        List<string> chars = new List<string>();
        List<_1char> objs = new List<_1char>();
        List<string> ctry = new List<string>();
        List<Image> flag = new List<Image>();
        List<Color> backcols = new List<Color>();

        const int noflag = 4;
        const int euflag = 27;
        const int customflag = 5;

        private void init()
        {
            chars.Add(" ");
            chars.Add("'");
            chars.Add("+");
            chars.Add("-");
            chars.Add("/");
            chars.Add("|");
            chars.Add("!");
            chars.Add("?");
            chars.Add(".");
            chars.Add(">");
            chars.Add("<");
            chars.Add("=");
            chars.Add("\"");
            chars.Add("#");
            chars.Add("*");
            chars.Add("(");
            chars.Add(")");
            chars.Add("[");
            chars.Add("]");
            chars.Add("{");
            chars.Add("}");   //21 chars (0 - 20)

            for (int i = 48; i <= 57; i++) // nums // +10 -> 31 (21 - 30) 
                chars.Add(Convert.ToChar(i).ToString());
            for (int i = 65; i <= 90; i++) // upps // +26 -> 57 (31 - 56)
                chars.Add(Convert.ToChar(i).ToString());


            objs.Add(c0);
            objs.Add(c1);
            objs.Add(c2);
            objs.Add(c3);
            objs.Add(c4);
            objs.Add(c5);
            objs.Add(c6);
            objs.Add(c7);
            objs.Add(c8);
       
            ctry.Add("BIH"); 
            ctry.Add("MNE");
            ctry.Add("NMK");
            ctry.Add("SRB"); // 3

            ctry.Add("A");
            ctry.Add("B");
            ctry.Add("BG");
            ctry.Add("HR");
            ctry.Add("CY"); 
            ctry.Add("CZ");
            ctry.Add("DK");
            ctry.Add("EST"); 
            ctry.Add("FIN"); 
            ctry.Add("F");
            ctry.Add("D");
            ctry.Add("GR");
            ctry.Add("H");
            ctry.Add("IRL"); 
            ctry.Add("I");
            ctry.Add("LV");
            ctry.Add("LT");
            ctry.Add("L");
            ctry.Add("M");
            ctry.Add("NL");
            ctry.Add("PL");
            ctry.Add("P");
            ctry.Add("RO");
            ctry.Add("SK");
            ctry.Add("SLO");
            ctry.Add("E");
            ctry.Add("S"); // 30


            ctry.Add("AL");
            ctry.Add("UK");
            ctry.Add("UA");
            ctry.Add("MD"); 
            ctry.Add("N");

            flag.Add(CarPlateView.flags.blank);
            flag.Add(CarPlateView.flags.eu);
            flag.Add(CarPlateView.flags.albania);
            flag.Add(CarPlateView.flags.uk);
            flag.Add(CarPlateView.flags.ukraine);
            flag.Add(CarPlateView.flags.moldova);
            flag.Add(CarPlateView.flags.norway);

            backcols.Add(Color.White);
            backcols.Add(Color.FromArgb(251, 197, 49)); // yellow
            backcols.Add(Color.FromArgb(47, 54, 64)); //
            //rgb(30, 39, 46)
            eustars.BackgroundImage = flag[0];
            rosign.Text = ctry[0];

            switch(rosign.Text.Length)
            {
                case 1: rosign.Font = new Font(rosign.Font.FontFamily, 42); break;
                case 2: rosign.Font = new Font(rosign.Font.FontFamily, 32); break;
                case 3: rosign.Font = new Font(rosign.Font.FontFamily, 22); break;
            }
        }

        string edsa = "edit";
        private void edit_Paint(object sender, PaintEventArgs e)
        {
            Font f1 = myFont;
            SolidBrush col = new SolidBrush(Color.Black);

            SolidBrush brush = new SolidBrush(Color.FromArgb(225, 254, 164, 127));

            Point p1 = new Point(0, 0);
            Point p2 = new Point(edit.Width * 90 / 100, 0);
            Point p3 = new Point(edit.Width * 90 / 100, edit.Height * 90 / 100);

            Point[] points =
            {
                p1,
                p2,
                p3
            };

            e.Graphics.FillPolygon(brush, points);

            double k = Math.Asin(Convert.ToDouble(edit.Height) / Convert.ToDouble(edit.Width));
            k = k / (Math.PI / 180);

            e.Graphics.RotateTransform((float)k);
            e.Graphics.DrawString(edsa, f1, col, edit.Width / 2 - edit.Width* 5 / 100 , -(edit.Height / 2 - edit.Height * 5 / 100));
        }

        private void edit_KeyDown(object sender, KeyEventArgs e)
        {
            if (edsa == "save")
            {
                _1char obj = null;
                int i = 0;
                for (i = 0; i <= 8; i++)
                    if (objs[i].active == true)
                    {
                        obj = objs[i];
                        break;
                    }

                if (obj != null)
                {
                    int pos = chars.IndexOf(obj.letter);
                    switch (e.KeyCode)
                    {
                        case Keys.W:
                            obj.init(chars[(pos + 1) % chars.Count]);
                            break;
                        case Keys.S:
                            if (pos - 1 < 0) pos = chars.Count;
                            obj.init(chars[pos - 1]);
                            break;
                        case Keys.D:
                            if (obj == c1 && c2.BackgroundImage != null)
                            {
                                obj = objs[i + 2];
                                chchange(obj, i + 2);
                                break;
                            }
                            if (i + 1 > 8) i = -1;
                            obj = objs[i + 1];
                            chchange(obj, i + 1);
                            break;
                        case Keys.A:
                            if (obj == c3 && c2.BackgroundImage != null)
                            {
                                obj = objs[i - 2];
                                chchange(obj, i - 2);
                                break;
                            }
                            if (i - 1 < 0) i = 9;
                            obj = objs[i - 1];
                            chchange(obj, i - 1);
                            break;
                    }
                }
            }
        }

        public void chcntry (int pos, KeyEventArgs e)
        {
            Image img = flag[0];
            switch (e.KeyCode)
            {
                case Keys.D:
                    rosign.Text = ctry[(pos + 1) % ctry.Count];

                    if (pos + 1 <= (noflag + euflag - 1) && pos + 1 > (noflag - 1)) img = flag[1];

                    const int num = (noflag + euflag);
                    switch (pos + 1)
                    {
                        case num: img = flag[2]; break;
                        case num + 1: img = flag[3]; break;
                        case num + 2: img = flag[4]; break;
                        case num + 3: img = flag[5]; break;
                        case num + 4: img = flag[6]; break;
                    }

                    switch (rosign.Text)
                    {
                        case "A": c2.BackgroundImage = CarPlateView.blasons.austria; break;
                        case "HR": c2.BackgroundImage = CarPlateView.blasons.croatia; break;
                        case "MNE": c2.BackgroundImage = CarPlateView.blasons.montenegro; break;
                        case "SRB": c2.BackgroundImage = CarPlateView.blasons.serbia; break;
                        case "SK": c2.BackgroundImage = CarPlateView.blasons.slovakia; break;
                        case "SLO": c2.BackgroundImage = CarPlateView.blasons.slovenia; break;

                        default: c2.BackgroundImage = null; break;
                    }

                    if (c2.BackgroundImage != null) c2.init("");

                    eustars.BackgroundImage = img;
                    break;

                case Keys.A:
                    if (pos - 1 < 0) pos = ctry.Count;
                    rosign.Text = ctry[pos - 1];
                    if (pos - 1 <= (noflag + euflag - 1) && pos - 1 > (noflag - 1)) img = flag[1];

                    switch (pos - 1)
                    {
                        case num: img = flag[2]; break;
                        case num + 1: img = flag[3]; break;
                        case num + 2: img = flag[4]; break;
                        case num + 3: img = flag[5]; break;
                        case num + 4: img = flag[6]; break;
                    }

                    switch (rosign.Text)
                    {
                        case "A": c2.BackgroundImage = CarPlateView.blasons.austria; break;
                        case "HR": c2.BackgroundImage = CarPlateView.blasons.croatia; break;
                        case "MNE": c2.BackgroundImage = CarPlateView.blasons.montenegro; break;
                        case "SRB": c2.BackgroundImage = CarPlateView.blasons.serbia; break;
                        case "SK": c2.BackgroundImage = CarPlateView.blasons.slovakia; break;
                        case "SLO": c2.BackgroundImage = CarPlateView.blasons.slovenia; break;

                        default: c2.BackgroundImage = null; break;
                    }

                    if (c2.BackgroundImage != null) c2.init("");

                    eustars.BackgroundImage = img;
                    break;
            }

            switch (rosign.Text.Length)
            {
                case 1: rosign.Font = new Font(rosign.Font.FontFamily, 42); break;
                case 2: rosign.Font = new Font(rosign.Font.FontFamily, 32); break;
                case 3: rosign.Font = new Font(rosign.Font.FontFamily, 22); break;
            }
            rosign.Location = new Point(blueband.Width / 2 - rosign.Width / 2 + 8, rosign.Location.Y);
        }

        private void edit_Click(object sender, EventArgs e)
        {
            if (led.Visible == false)
            {
                chchange(c0, 0);
                edsa = "save";
                edit.Refresh();
            }
            else
            {
                chchange(c0, -1);
                edsa = "edit";
                edit.Refresh();
                rosign.Focus();
            }
        }

        private void chchange(_1char obj, int i)
        {
            for (int j = 0; j <= 8; j++)
                objs[j].active = false;

            if (i == -1) led.Visible = false;
            else
            {
                objs[i].active = true;

                led.Visible = true;
                led.Location = new Point(i * c0.Width + (c0.Width / 2) - 10 + blueband.Width, c0.Height + 45);
            }
        }

        private void edit_Leave(object sender, EventArgs e)
        {
            if (led.Visible == true)
            {
                chchange(c0, -1);
                edsa = "edit";
                edit.Refresh();
            }
        }

        public void disedit()
        {
            if(edit.Visible == true) edit.Visible = false;
            else edit.Visible = true;
        }

        public bool verifyblason()
        {
            if (c2.BackgroundImage == null) return false;
            else return true;
        }

        public bool verchar(char[] txt, int k)
        {
            bool ok = true;
            for (int i = 0; i < k; i++) if (chars.Contains(txt[i].ToString().ToUpper()) == false) { ok = false; break; }

            return ok;
        }

        public void edtext(char[] txt)
        {
            if(c2.BackgroundImage == null)
            {
                c0.init(txt[0].ToString());
                c1.init(txt[1].ToString());
                c2.init(txt[2].ToString());
                c3.init(txt[3].ToString());
                c4.init(txt[4].ToString());
                c5.init(txt[5].ToString());
                c6.init(txt[6].ToString());
                c7.init(txt[7].ToString());
                c8.init(txt[8].ToString());
            }
            else
            {
                c0.init(txt[0].ToString());
                c1.init(txt[1].ToString());
                c3.init(txt[2].ToString());
                c4.init(txt[3].ToString());
                c5.init(txt[4].ToString());
                c6.init(txt[5].ToString());
                c7.init(txt[6].ToString());
                c8.init(txt[7].ToString());
            }
        }

    }
}

