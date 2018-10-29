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
    public partial class UC_Groups : UserControl
    {
        
        public UC_Groups()
        {
            InitializeComponent();
            
        }

        public void Load_UC_Groups()
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            pictureBox1.Left -= 8;
            pictureBox2.Left -= 8;
            pictureBox3.Left -= 8;

            if (pictureBox1.Left <= 86)
            {
                timer1.Stop();
                timer2.Start();
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void UC_Groups_Load(object sender, EventArgs e)
        {
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            panel2.Top -= 3;
            panel3.Top -= 3;
            panel4.Top -= 3;

            if (panel2.Top <= 267)
            {
                timer2.Stop();
            }
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        internal void UC_Groups_Load()
        {
            throw new NotImplementedException();
        }
    }
}
