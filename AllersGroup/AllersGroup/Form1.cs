
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

            LoadModels();
        }

        private void LoadModels()
        {
            uC_G51.LoadModel(model);
        }
    }
}
