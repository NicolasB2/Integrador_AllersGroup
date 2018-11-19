using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Model;
using System.Windows.Forms.DataVisualization.Charting;

namespace AllersGroup
{
    public partial class UC_G5 : UserControl
    {
        public Consult model;

        public UC_G5()
        {
            InitializeComponent();
            label8.Visible = label18.Visible = label9.Visible = label5.Visible  = false;
            label27.Visible = label28.Visible = label29.Visible = false;

        }

        public void LoadModel(Consult model)
        {
            this.model = model;
            LoadComboBox();
            String[]a = new String[]{ "a", "b", "c" };
            int[] b = new int[] { 50, 20, 20 };

            chart1.Series.Clear();

            for(int i =0;i<a.Length;i++)
            {
                Series serie = chart1.Series.Add(a[i]);
                serie.Label = b[i].ToString();
                serie.Points.Add(b[i]);

            }
            //chart1.Series.Add("a");
            //chart1.Series["a"].Points.AddXY("nico",10);
            //chart1.Series["a"].Points.AddXY("ale", 20);
            //chart1.Series["a"].Points.AddXY("sara", 20);
            //chart1.Series["a"].Points.AddXY("diana", 50);
            //chart1.Series.Add("b");
            //chart1.Series.Add("c");
            //chart1.Series.Add("d");
            //chart1.Series.Add("e");



        }

        private void LoadComboBox()
        {
            var x = model.ClientTypes().ToArray();
            comboBox1.Items.AddRange(x);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //String x = comboBox1.SelectedItem.ToString();
            //label27.Visible = label28.Visible = label29.Visible = true;
            //label29.Text = model.Transactions_ByClientsType(x).Count()+"";
            //label27.Text = model.Clients_ByType(x).Count()+"";
            //label28.Text = "$ "+model.totalSellsListClients(model.Clients_ByType(x).Select(c=>c.Code).ToList());

            //label27.Visible = label28.Visible = label29.Visible = true;
            //label8.Visible = label18.Visible = label9.Visible = label5.Visible = true;

            //label8.Text = model.Items_ClientsType(x).Last()+"";
            //label18.Text = model.Items_ClientsType(x).First() + "";
            //label5.Text = model.ClientsOrderListByType(x).Last() + "";
            //label9.Text = model.ClientsOrderListByType(x).First() + "";

            chart1.Series.Clear();
            chart1.Series.Add("a");
            chart1.Series["a"].Points.AddXY("nico", 10);
            chart1.Series["a"].Points.AddXY("ale", 20);
            chart1.Series["a"].Points.AddXY("sara", 20);
            chart1.Series["a"].Points.AddXY("diana", 50);
        }

    }
}
