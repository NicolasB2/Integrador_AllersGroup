using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AllersGroup
{
    public partial class UC_MenuPredictions : UserControl
    {
        public UC_MenuPredictions()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Left -= 5;
            panel1.Left -= 5;

            if (panel1.Left <= 25)
            {
                timer1.Stop();
            }
        }
    }
}
