using System;
using System.Windows.Forms;
using Model;

namespace AllersGroup
{
    public partial class MainForm : Form
    {
        public Consult model;

        public MainForm()
        {
            InitializeComponent();
            model = new Consult();

            uC_G221.Visible = false;
            uC_G31.Visible = false;
            uC_G41.Visible = false;
            uC_G51.Visible = false;
            uC_P111.Visible = false;

            uC_G221.LoadModel(model);
            uC_G31.LoadModel(model);
            uC_G41.LoadModel(model);
            uC_G51.LoadModel(model); 
            uC_P111.loadModel(model);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            uC_G221.Visible = false;
            uC_G31.Visible = false;
            uC_G41.Visible = false;
            uC_G51.Visible = true;
            uC_P111.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            uC_G221.Visible = true;
            uC_G31.Visible = false;
            uC_G41.Visible = false;
            uC_G51.Visible = false;
            uC_P111.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            uC_G221.Visible = false;
            uC_G31.Visible = true;
            uC_G41.Visible = false;
            uC_G51.Visible = false;
            uC_P111.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            uC_G221.Visible = false;
            uC_G31.Visible = false;
            uC_G41.Visible = false;
            uC_G51.Visible = false;
            uC_P111.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            uC_G221.Visible = false;
            uC_G31.Visible = false;
            uC_G41.Visible = true;
            uC_G51.Visible = false;
            uC_P111.Visible = false;
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PanelSlide_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mini_slide_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
