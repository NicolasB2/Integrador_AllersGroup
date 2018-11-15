
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
            uC_P21.loadModel(model);
        }

    }
}
