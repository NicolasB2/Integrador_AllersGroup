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
        public Consult model;
        public AuxForm()
        {
            InitializeComponent();
            model = new Consult();

            uC_Menu1.LoadModel(model);

        }
       
        
        private void AuxForm_Load(object sender, EventArgs e)
        {

        }
    }
}
