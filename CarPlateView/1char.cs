using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace CarPlateView
{
    
    public partial class _1char : UserControl
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
        IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();


        public string letter;
        public bool active;
        public _1char()
        {
            InitializeComponent();
            letter = ch.Text;

            byte[] fontData = fontscoll.BebasKai_Regular;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, fontscoll.BebasKai_Regular.Length);
            AddFontMemResourceEx(fontPtr, (uint)fontscoll.BebasKai_Regular.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            ch.Font = new Font(fonts.Families[0], 160);
        }

        public void init(string l)
        {
            ch.Text = l;
            ch.Location = new Point(this.Width / 2 - ch.Width / 2 + 20, ch.Location.Y);
            letter = l;
        }

    }
}
