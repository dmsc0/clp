using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarPlateView
{
    
    public partial class _1char : UserControl
    {
        public string letter;
        public bool active;
        public _1char()
        {
            InitializeComponent();
            letter = ch.Text;
        }

        public void init(string l)
        {
            ch.Text = l;
            ch.Location = new Point(this.Width / 2 - ch.Width / 2 + 20, ch.Location.Y);
            letter = l;
        }

    }
}
