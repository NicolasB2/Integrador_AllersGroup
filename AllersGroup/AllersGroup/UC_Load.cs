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
    public partial class UC_Load : UserControl
    {
        public UC_Load()
        {
            InitializeComponent();
            panel2.Left = 0;
            panel2.Top = 0;

            timer1.Start();

            panel3.Left = 117;
            panel3.Top = 182;

            panel1.Left = 117;
            panel1.Top = 182;

            pictureBox2.Visible = false;
        }

        int time = 0; 
        int plus = 4;

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Left += plus;

            if (panel2.Left > 302)
            {
                plus = -4;
                time += 1;

            }
            if (panel2.Left < 118)
            {
                plus = 4;

            }

            if (time == 2)
            {
                
                panel2.Visible = false;
                panel1.Visible = false;
                
                timer2.Start();
                timer1.Stop();
            }
        }

        int tp = 1;
        private void timer2_Tick(object sender, EventArgs e)
        {
            panel3.BringToFront();
            pictureBox2.Visible = true;
            label1.Visible = false;
            panel3.Top -= tp;

            if (panel3.Top < -140)
            {
                panel3.Top += tp;
                timer2.Stop();
                
            }
            
        }
    }
}
