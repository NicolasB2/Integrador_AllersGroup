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
    public partial class UC_MenuP : UserControl
    {
        UC_P11 ucp_1;
        UC_P22 ucp_2;
        UC_P33 ucp_3;
        UC_P44 ucp_4;

        public UC_MenuP(UC_P11 ucp_1, UC_P22 ucp_2, UC_P33 ucp_3, UC_P44 ucp_4)
        {
            InitializeComponent();
            timer1.Start();

            this.ucp_1 = ucp_1;
            this.ucp_2 = ucp_2;
            this.ucp_3 = ucp_3;
            this.ucp_4 = ucp_4;
        }

        public void loadButtons(bool b1, bool b2, bool b3)
        {
            button1.Visible = b1;
            button2.Visible = b2;
            button3.Visible = b3;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Left -= 5;
            panel1.Left -= 5;

            if (panel1.Left <= 25)
            {
                timer1.Stop();
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            button1.Top -= 5;
            if (button1.Top <= 274)
            {
                timer3.Start();
            }

            if (button1.Top <= 104)
            {
                timer2.Stop();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            button2.Top -= 5;

            if (button2.Top <= 274)
            {
                timer4.Start();
            }
            if (button2.Top <= 182)
            {
                timer3.Stop();
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            button3.Top -= 5;
            if (button3.Top <= 274)
            {
                timer4.Stop();
                timer5.Start();
            }
        }
        // 1 CLIENTE 2 depto 3 periodo tiempo 
        //tipo cliente
        private void button2_Click(object sender, EventArgs e)
        {
            ucp_3.Hide();
            ucp_4.Hide();
            ucp_1.Show();
            ucp_2.Hide();

        }

        //periodo
        private void button1_Click(object sender, EventArgs e)
        {
            ucp_3.Show();
            ucp_4.Hide();
            ucp_1.Hide();
            ucp_2.Hide();
        }

        //departamento
        private void button3_Click(object sender, EventArgs e)
        {
            ucp_3.Hide();
            ucp_1.Hide();
            ucp_4.Hide();
            ucp_2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ucp_4.Show();
            ucp_3.Hide();
            ucp_1.Hide();
            ucp_2.Hide();
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            button4.Top -= 5;
            if (button4.Top <= 366)
            {
                timer5.Stop();
            }
        }
    }
}
