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
    public partial class Form1 : Form
    {
        public Consult model;
        public Form1()
        {
            InitializeComponent();
            model = new Consult();

            //uC_P11.loadModel(model);

            uC_P21.loadModel(model);
            uC_P21.loadDepartments();

            //uC_P31.loadModel(model);
            //uC_P31.loadMonth();
        }

    }
}
