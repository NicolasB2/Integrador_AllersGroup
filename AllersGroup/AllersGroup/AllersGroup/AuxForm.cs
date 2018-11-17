using System;
using System.Windows.Forms;
using Model;

namespace AllersGroup
{
    public partial class AuxForm : Form
    {
        public Consult model;
        int panelWidth;
        bool Hidden;

        public AuxForm()
        {
            InitializeComponent();
            model = new Consult();

            panelWidth = PanelSlide.Width;
            Hidden = false;

            uC_AnalysisTools1.Hide();
            uC_MenuGroups1.Hide();
            uC_MenuPredictions1.Hide();
            uC_MenuRecommendations1.Hide();
            uC_G21.Hide();
            uC_G31.Hide();
            uC_G41.Hide();
            uC_P11.Hide();
            uC_P21.Hide();
            uC_P31.Hide();
            uC_P41.Hide();
            

            load_UserControls();

        }
        public void load_UserControls()
        {
            uC_G21.LoadModel(model);
            uC_G31.LoadModel(model);
            uC_G41.LoadModel(model);
            uC_P11.loadModel(model);
            uC_P21.loadModel(model);
            uC_P31.loadModel(model);
            uC_P41.loadModel(model);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            uC_MenuPredictions1.Hide();
            uC_MenuRecommendations1.Hide();
            uC_MenuGroups1.Hide();
            uC_G21.Hide();
            uC_G31.Hide();
            uC_G41.Hide();
            uC_P11.Hide();
            uC_P21.Hide();
            uC_P31.Hide();
            uC_P41.Hide();

            if (!Hidden)
            {
                uC_AnalysisTools1.Show();
            }
            else
            {
                uC_AnalysisTools1.Hide();
            }
            timer1.Start();
            mini_slide.Height = button1.Height;
            mini_slide.Top = button1.Top;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Hidden)
            {
                PanelSlide.Width = PanelSlide.Width + 10;
                if (PanelSlide.Width >= panelWidth)
                {
                    timer1.Stop();
                    Hidden = false;
                    this.Refresh();
                }
            }
            else
            {
                PanelSlide.Width = PanelSlide.Width - 10;
                if (PanelSlide.Width <= 0)
                {
                    timer1.Stop();
                    Hidden = true;
                    this.Refresh();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            uC_MenuPredictions1.Hide();
            uC_MenuRecommendations1.Hide();
            uC_AnalysisTools1.Hide();
            uC_G21.Hide();
            uC_G31.Hide();
            uC_G41.Hide();
            uC_P11.Hide();
            uC_P21.Hide();
            uC_P31.Hide();
            uC_P41.Hide();

            if (!Hidden)
            {
                uC_MenuGroups1.Hide();
            }
            else
            {
                uC_MenuGroups1 = new UC_MenuGroups(uC_G31, uC_G21, uC_G41);
                PanelSlide.Controls.Add(uC_MenuGroups1);
                uC_MenuGroups1.Show();
                uC_MenuGroups1.loadButtonsGroups(uC_AnalysisTools1.b1, uC_AnalysisTools1.b2, uC_AnalysisTools1.b3);
            }

            mini_slide.Height = button2.Height;
            mini_slide.Top = button2.Top;
            timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            uC_MenuGroups1.Hide();
            uC_MenuRecommendations1.Hide();
            uC_AnalysisTools1.Hide();
            uC_G21.Hide();
            uC_G31.Hide();
            uC_G41.Hide();


            if (!Hidden)
            {
                uC_MenuPredictions1.Hide();
            }
            else
            {
                uC_MenuPredictions1 = new UC_MenuPredictions(uC_P11, uC_P21, uC_P31, uC_P41);
                PanelSlide.Controls.Add(uC_MenuPredictions1);
                uC_MenuPredictions1.Show();
                uC_MenuPredictions1.loadButtons(uC_AnalysisTools1.b4, uC_AnalysisTools1.b5, uC_AnalysisTools1.b6);
            }


            mini_slide.Height = button3.Height;
            mini_slide.Top = button3.Top;
            timer1.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            uC_MenuGroups1.Hide();
            uC_MenuPredictions1.Hide();
            uC_AnalysisTools1.Hide();
            uC_G21.Hide();
            uC_G31.Hide();
            uC_G41.Hide();
            uC_P11.Hide();
            uC_P21.Hide();
            uC_P31.Hide();
            uC_P41.Hide();

            if (!Hidden)
            {
                uC_MenuRecommendations1.Hide();
            }
            else
            {
                uC_MenuRecommendations1 = new UC_MenuRecommendations();
                PanelSlide.Controls.Add(uC_MenuRecommendations1);
                uC_MenuRecommendations1.Show();
                uC_MenuRecommendations1.loadButtons(uC_AnalysisTools1.b7, uC_AnalysisTools1.b8, uC_AnalysisTools1.b9);
            }

            mini_slide.Height = button4.Height;
            mini_slide.Top = button4.Top;
            timer1.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            uC_MenuGroups1.Hide();
            uC_MenuPredictions1.Hide();
            uC_MenuRecommendations1.Hide();
            uC_AnalysisTools1.Hide();
            uC_G21.Hide();
            uC_G31.Hide();
            uC_G41.Hide();
            uC_P11.Hide();
            uC_P21.Hide();
            uC_P31.Hide();
            uC_P41.Hide();

            mini_slide.Height = button5.Height;
            mini_slide.Top = button5.Top;
            timer1.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            uC_MenuGroups1.Hide();
            uC_MenuPredictions1.Hide();
            uC_MenuRecommendations1.Hide();
            uC_AnalysisTools1.Hide();
            uC_G21.Hide();
            uC_G31.Hide();
            uC_G41.Hide();
            uC_P11.Hide();
            uC_P21.Hide();
            uC_P31.Hide();
            uC_P41.Hide();


            mini_slide.Height = button6.Height;
            mini_slide.Top = button6.Top;
            timer1.Start();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
