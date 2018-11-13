using System;
using System.Windows.Forms;

namespace AllersGroup
{

    public partial class UC_MenuGroups : UserControl
    {
        public UC_G3 ucg3; 

        public UC_MenuGroups(UC_G3 ucg3)
        {
            InitializeComponent();
            timer1.Start();

            this.ucg3 = ucg3;
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
            ucg3.Hide();
        }

        //Periodo de tiempo
        private void button2_Click(object sender, EventArgs e)
        {
            ucg3.Show();
        }

        //Similitud en compras
        private void button3_Click(object sender, EventArgs e)
        {
            ucg3.Hide();
        }
    }
}
