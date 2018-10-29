using System;
using Model;
using System.Windows.Forms;
using System.Linq;

namespace AllersGroup
{
    public partial class UC_G_Department : UserControl
    {
        public Consult model;
        public UC_G_Department()
        {
            InitializeComponent();
         
        }

        public void Load_UC_G_Department()
        {
            this.Show();
            this.BringToFront();
        }

        public void LoadModel(Consult model)
        {
            this.model = model;
        }

        public void cargarComboBox()
        {
            var x = model.ClientsByDepartment().Select(n=>n.Key).ToArray();
                comboBox1.Items.AddRange(x);

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var x = model.ItemsByDepartment().First(n=>n.Key == comboBox1.SelectedItem.ToString()).Value;
           
            label3.Text = x.Distinct().Count()+"";
        }
    }
}
