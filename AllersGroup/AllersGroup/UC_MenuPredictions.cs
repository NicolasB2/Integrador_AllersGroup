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
        public UC_P1 ucp1;
        public UC_P2 ucp2;
        public UC_P3 ucp3;
        public UC_P4 ucp4;


        public UC_MenuPredictions(UC_P1 ucp1, UC_P2 ucp2, UC_P3 ucp3, UC_P4 ucp4)
        {
            InitializeComponent();
            timer1.Start();

            this.ucp1 = ucp1;
            this.ucp2 = ucp2;
            this.ucp3 = ucp3;
            this.ucp4 = ucp4;
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
            }
        }
        // 1 CLIENTE 2 depto 3 periodo tiempo 
        //tipo cliente
        private void button2_Click(object sender, EventArgs e)
        {

            ucp1.Show();
            ucp2.Hide();
            ucp3.Hide();
            ucp4.Hide();
        }

        //periodo
        private void button1_Click(object sender, EventArgs e)
        {
            ucp2.Hide();
            ucp1.Hide();
            ucp4.Hide();
            ucp3.Show();

        }

        //departamento
        private void button3_Click(object sender, EventArgs e)
        {
            ucp1.Hide();
            ucp2.Show();
            ucp4.Hide();
            ucp3.Hide();

        }
    }
}
