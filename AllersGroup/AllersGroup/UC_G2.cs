using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Model;

namespace AllersGroup
{
    public partial class UC_G2 : UserControl
    {
        GMapOverlay markers;
        public Consult model;

        public UC_G2()
        {
            InitializeComponent();
            markers = new GMapOverlay("markers");

            if (model != null)
            {
                loadComboBox1();
            }
            label_dep.Visible = label5.Visible = label10.Visible = false;
            label27.Visible = label28.Visible = label29.Visible = false;
            label8.Visible = label18.Visible = label19.Visible = label20.Visible = false;
        }

        public void LoadModel(Consult model)
        {
            this.model = model;
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {

            gMapControl1.SetPositionByKeywords("Cali, Colombia.");
            gMapControl1.MapProvider = GoogleMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gMapControl1.ShowCenter = false;

            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                if (model.ClientsByDepartment1().Select(n => n.Key).ToArray()[i] != "No indica departamento")
                {

                    GMapMarker marker = new GMarkerGoogle(new PointLatLng
                        (model.context.Locations[model.ClientsByDepartment1().Select(n => n.Key).ToArray()[i] + ""]
                        [1], (model.context.Locations[model.ClientsByDepartment1().Select(n => n.Key).ToArray()[i] + ""]
                        [0])), GMarkerGoogleType.red_pushpin);
                    markers.Markers.Add(marker);
                }
            }

            gMapControl1.Overlays.Add(markers);
        }

        private void loadComboBox1()
        {            
            comboBox1.Items.AddRange(model.list_departments().ToArray());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String department = comboBox1.SelectedItem.ToString();

        }
    }
}
