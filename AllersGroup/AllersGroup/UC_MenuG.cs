using System;
using System.Windows.Forms;

namespace AllersGroup
{

    public partial class UC_MenuG : UserControl
    {
        private UC_G22 uc_g22;
        private UC_G3 uc_g3;
        private UC_G4 uc_g4;
        private UC_G5 uc_g5;

        public UC_MenuG(UC_G22 uc_g22, UC_G3 uc_g3, UC_G4 uc_g4, UC_G5 uc_g5)
        {
            InitializeComponent();
            timer1.Start();

            this.uc_g22 = uc_g22;
            this.uc_g3 = uc_g3;
            this.uc_g4 = uc_g4;
            this.uc_g5 = uc_g5;
        }


        public void loadButtonsGroups(bool b1, bool b2, bool b3)
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
            if (button2.Top <= 189)
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

        //Departamento
        private void button1_Click(object sender, EventArgs e)
        {
            uc_g22.Show();
            uc_g3.Hide();
            uc_g5.Hide();
            uc_g4.Hide();
        }

        //Periodo de tiempo
        private void button2_Click(object sender, EventArgs e)
        {
            uc_g22.Hide();
            uc_g3.Show();
            uc_g5.Hide();
            uc_g4.Hide();
        }

        //Similitud en compras
        private void button3_Click(object sender, EventArgs e)
        {
            uc_g22.Hide();
            uc_g3.Hide();
            uc_g5.Hide();
            uc_g4.Show();
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            button4.Top -= 5;
            if (button4.Top <= 366)
            {
                timer5.Stop();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            uc_g22.Hide();
            uc_g3.Hide();
            uc_g4.Hide();
            uc_g5.Show();
        }
    }
}
