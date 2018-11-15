using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Model;

namespace AllersGroup
{
    public partial class UC_G5 : UserControl
    {
        public Consult model;

        public UC_G5()
        {
            InitializeComponent();


            var x = model.ClientTypes().ToArray();
            comboBox1.Items.AddRange(x);
        }

        public void LoadModel(Consult model)
        {
            this.model = model;
        }

    }
}
