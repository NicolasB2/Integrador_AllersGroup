using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace AllersGroup
{
    public partial class UC_G1 : UserControl
    {
        public Consult model;

        public UC_G1()
        {
            InitializeComponent();
        }

        public void LoadModel(Consult model)
        {
            this.model = model;
        }

        private void loadComboBox1()
        {
            var x = model.ClientsByDepartment().Select(n => n.Key).ToArray();
            comboBox1.Items.AddRange(x);
        }
    }
}
