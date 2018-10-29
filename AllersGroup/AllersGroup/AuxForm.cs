using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace AllersGroup
{
    public partial class AuxForm : Form
    {
        public AuxForm(Consult m)
        {
            InitializeComponent();
            cargar(m);
        }

        public void cargar(Consult m)
        {
            uC_G_Department1.LoadModel(m);
            uC_G_Department1.cargarComboBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uC_G_Department1.Show();
        }
    }
}
