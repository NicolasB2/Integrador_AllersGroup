using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Windows.Forms;
using GMap.NET.MapProviders;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace AllersGroup
{
    public partial class UC_Menu : UserControl
    {
        public Consult model;
        GMapOverlay markers;
        
        public UC_Menu()
        {
            InitializeComponent();
            markers = new GMapOverlay("markers");

            Controls.Remove(panel_2);

            button1.BackColor = Color.FromArgb(11, 91, 111);
            button2.BackColor = Color.FromArgb(41, 121, 145);
            button3.BackColor = Color.FromArgb(41, 121, 145);
            button4.BackColor = Color.FromArgb(41, 121, 145);

            label_dep.Visible = false;
        }
        public void LoadModel(Consult model)
        {
            this.model = model;

            loadComboBox1();
            loadLabels();
        }

        private void loadCharts()
        {
           
            double a = Math.Round((((double)model.ClientsByDepartment().Select(n => n.Key).ToArray().Count() - 1) / 32.0) * 100.0, 2);
            double b = Math.Round(100 - a, 2);


        }

        private void loadLabels()
        {
            label5.Text = model.ClientsByDepartment().Select(n => n.Key).ToArray().Count()-1 + "";
            double text = Math.Round((((double)model.ClientsByDepartment().Select(n => n.Key).ToArray().Count() - 1) / 32.0) * 100.0,2);
            label10.Text = text + "%";

        }
        private void loadComboBox1()
        {
            var x = model.ClientsByDepartment().Select(n => n.Key).ToArray();
            comboBox1.Items.AddRange(x);
        }

        private void UC_Menu_Load(object sender, EventArgs e)
        {

        }

        //panel_info
        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(11, 91, 111);
            button2.BackColor = Color.FromArgb(41, 121, 145);
            button3.BackColor = Color.FromArgb(41, 121, 145);
            button4.BackColor = Color.FromArgb(41, 121, 145);

            panel_info.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(11, 91, 111);
            button1.BackColor = Color.FromArgb(41, 121, 145);
            button3.BackColor = Color.FromArgb(41, 121, 145);
            button4.BackColor = Color.FromArgb(41, 121, 145);

            panel_info.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(11, 91, 111);
            button2.BackColor = Color.FromArgb(41, 121, 145);
            button1.BackColor = Color.FromArgb(41, 121, 145);
            button4.BackColor = Color.FromArgb(41, 121, 145);

            panel_info.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(11, 91, 111);
            button2.BackColor = Color.FromArgb(41, 121, 145);
            button1.BackColor = Color.FromArgb(41, 121, 145);
            button3.BackColor = Color.FromArgb(41, 121, 145);

            panel_info.Hide();

        }

        private void left_Click(object sender, EventArgs e)
        {

        }

        private void right_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_dep.Text = comboBox1.SelectedItem + "";
            label_dep.Visible = true;
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            gMapControl1.SetPositionByKeywords("Cali, Colombia.");
            gMapControl1.MapProvider = GoogleMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gMapControl1.ShowCenter = false;

            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                //MessageBox.Show(model.ClientsByDepartment().Select(n => n.Key).ToArray()[i]+"");
                if (model.ClientsByDepartment().Select(n => n.Key).ToArray()[i] != "No indica departamento")
                {

                GMapMarker marker = new GMarkerGoogle(new PointLatLng
                    (model.context.Locations[model.ClientsByDepartment().Select(n => n.Key).ToArray()[i] + ""]
                    [1], (model.context.Locations[model.ClientsByDepartment().Select(n => n.Key).ToArray()[i] + ""]
                    [0])), GMarkerGoogleType.red_pushpin);
                markers.Markers.Add(marker);
                }
            }

            gMapControl1.Overlays.Add(markers);



        }


    }
}
