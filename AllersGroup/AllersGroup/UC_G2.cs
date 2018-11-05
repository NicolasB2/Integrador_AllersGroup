using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using GMap.NET.MapProviders;
using GMap.NET;
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
        }

        public void LoadModel(Consult model)
        {
            this.model = model;
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            
                //gMapControl1.SetPositionByKeywords("Cali, Colombia.");
                //gMapControl1.MapProvider = GoogleMapProvider.Instance;
                //GMaps.Instance.Mode = AccessMode.ServerOnly;
                //gMapControl1.ShowCenter = false;

                //for (int i = 0; i < comboBox1.Items.Count; i++)
                //{
                //    //MessageBox.Show(model.ClientsByDepartment().Select(n => n.Key).ToArray()[i]+"");
                //    if (model.ClientsByDepartment().Select(n => n.Key).ToArray()[i] != "No indica departamento")
                //    {

                //        GMapMarker marker = new GMarkerGoogle(new PointLatLng
                //            (model.context.Locations[model.ClientsByDepartment().Select(n => n.Key).ToArray()[i] + ""]
                //            [1], (model.context.Locations[model.ClientsByDepartment().Select(n => n.Key).ToArray()[i] + ""]
                //            [0])), GMarkerGoogleType.red_pushpin);
                //        markers.Markers.Add(marker);
                //    }
                //}

                //gMapControl1.Overlays.Add(markers);



          
        }
    }
}
