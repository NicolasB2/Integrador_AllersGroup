using System;
using System.Windows.Forms;

namespace AllersGroup
{

    public partial class UC_MenuGroups : UserControl
    {
        public UC_G2 ucg2;
        public UC_G3 ucg3; 
        public UC_G4 ucg4;

        public UC_MenuGroups(UC_G3 ucg3, UC_G2 ucg2, UC_G4 ucg4)
        {
            InitializeComponent();
            timer1.Start();

            this.ucg3 = ucg3;
            this.ucg2 = ucg2;
            this.ucg4 = ucg4;
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
            }
        }

        //Departamento
        private void button1_Click(object sender, EventArgs e)
        {
            ucg2.Hide();
            ucg4.Hide();
            ucg2.Show();

        }

        //Periodo de tiempo
        private void button2_Click(object sender, EventArgs e)
        {
            ucg2.Hide();
            ucg4.Hide();
            ucg3.Show();
        }

        //Similitud en compras
        private void button3_Click(object sender, EventArgs e)
        {
            ucg2.Hide();
            ucg3.Hide();
            ucg4.Show();
        }
    }
}
