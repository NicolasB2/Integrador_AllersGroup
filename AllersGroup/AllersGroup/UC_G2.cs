using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Model;

namespace AllersGroup
{
    public partial class UC_G2 : UserControl
    {
        List<Model.Client> clients;
        public Consult model;

        public UC_G2()
        {
            clients = new List<Client>();
            InitializeComponent();

            label_dep.Visible = label5.Visible = label10.Visible = false;
            label27.Visible = label28.Visible = label29.Visible = false;
            label8.Visible = label18.Visible = label19.Visible = label20.Visible = false;
        }
        
        public void LoadModel(Consult model)
        {
            this.model = model;
            loadComboBox1();
        }

        private void LoadListView1()
        {
            for (int i = 0; i < clients.Count(); i++)
            {
                ListViewItem list = new ListViewItem(clients.ElementAt(i).Code);               

                listView1.Items.Add(list);
            }

        }
        private void loadComboBox1()
        {            
            comboBox1.Items.AddRange(model.list_departments().ToArray());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String department = comboBox1.SelectedItem.ToString();

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
            label_dep.Text = comboBox1.SelectedItem.ToString();
            label5.Text = (comboBox1.Items.Count - 1) + "";
            double p = Math.Round(((comboBox1.Items.Count - 1) / 32.0)*100.0,2);
            label10.Text = p + " %";
            label_dep.Visible = label5.Visible = label10.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label29.Text = model.TransactionsByDepartment(comboBox1.SelectedItem.ToString()).ToList().Count() + "";
            label27.Text = model.ClientsByDepartment(comboBox1.SelectedItem.ToString()).ToList().Count() + "";
            label28.Text = model.ItemsByDepartment(comboBox1.SelectedItem.ToString()).ToList().Count() + ""; 
            label29.Visible = label28.Visible = label27.Visible = true; 
        }

        private void gMapControl1_Load_1(object sender, EventArgs e)
        {
            //gMapControl1.SetPositionByKeywords("Cali, Colombia.");
            //gMapControl1.MapProvider = GoogleMapProvider.Instance;
            //GMaps.Instance.Mode = AccessMode.ServerOnly;
            //gMapControl1.ShowCenter = false;

            //for (int i = 0; i < comboBox1.Items.Count; i++)
            //{
            //    if (model.ClientsByDepartment1().Select(n => n.Key).ToArray()[i] != "No indica departamento")
            //    {

            //        GMapMarker marker = new GMarkerGoogle(new PointLatLng
            //            (model.context.Locations[model.ClientsByDepartment1().Select(n => n.Key).ToArray()[i] + ""]
            //            [1], (model.context.Locations[model.ClientsByDepartment1().Select(n => n.Key).ToArray()[i] + ""]
            //            [0])), GMarkerGoogleType.red_pushpin);
            //        markers.Markers.Add(marker);
            //    }
            //}

            //gMapControl1.Overlays.Add(markers);
        }
    }
}
