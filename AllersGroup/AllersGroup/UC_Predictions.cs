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
    public partial class UC_Predictions : UserControl
    {
        public UC_Predictions()
        {
            InitializeComponent();
        }

        public void Load_UC_Predictions()
        {
            timer1.Start();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Left -= 8;
            pictureBox2.Left -= 8;
            pictureBox3.Left -= 8;

            if (pictureBox1.Left <= 87)
            {
                timer1.Stop();
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            panel1.Top -= 3;
            panel2.Top -= 3;
            panel3.Top -= 3;

            if (panel1.Top <= 267)
            {
                timer2.Stop();
            }
        }
    }
}
