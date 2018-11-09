using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace AllersGroup
{
    public partial class UC_G3 : UserControl
    {

        public Consult model;
        public int month1, month2;
        public Dictionary<String, int> months;

        public UC_G3()
        {
            InitializeComponent();

            months = new Dictionary<string, int>();
            months.Add("Enero", 1);
            months.Add("Febrero", 2);
            months.Add("Marzo", 3);
            months.Add("Abril", 4);
            months.Add("Mayo", 5);
            months.Add("Junio", 6);

            comboBox1.Items.AddRange(months.Keys.ToArray());
            comboBox2.Items.AddRange(months.Keys.ToArray());

            label8.Visible = label9.Visible = label10.Visible = false;
        }

        public void loadModel(Consult model)
        {
            this.model = model;
        }

        private void loadListView1(IEnumerable<string[]> clients)
        {
            for (int i = 0; i < clients.Count(); i++)
            {
                ListViewItem list = new ListViewItem(clients.ElementAt(i)[0]);
                list.SubItems.Add(clients.ElementAt(i)[1]);

                listView1.Items.Add(list);
            }

        }

        private void loadListView2(IEnumerable<string[]> items)
        {
            for (int i = 0; i < items.Count(); i++)
            {
                ListViewItem list = new ListViewItem(items.ElementAt(i)[0]);
                list.SubItems.Add(items.ElementAt(i)[1]);

                listView2.Items.Add(list);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String m1 = comboBox1.SelectedItem.ToString();
            month1 = months[m1];

            if (month2 != 0 && month2 < month1)
            {
                MessageBox.Show("El segundo mes seleccionado no puede ser menor que el primero.");
                comboBox1.SelectedItem = "Enero";
            }
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            String m2 = comboBox2.SelectedItem.ToString();
            month2 = months[m2];

            if (month2 < month1)
            {
                MessageBox.Show("El segundo mes seleccionado no puede ser menor que el primero.");
                comboBox1.SelectedItem = "Enero";
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            IEnumerable<string[]> clients, items;

            if (month1 == 0 || month2 == 0)
            {
                MessageBox.Show("Se deben seleccionar ambos meses.");
            }
            else
            {
                if (month1 == month2)
                {
                    items = model.Frequent_Items_ByMonth(month1);
                    clients = model.Frequent_Clients_ByMonth(month1);

                }
                else
                {
                    items = model.ItemsByTimePeriod(month1, month2);
                    clients = model.ClientsByTimePeriod(month1, month2);
                }

    
                label8.Text = clients.ElementAt(0)[0];
                label9.Text = items.ElementAt(0)[0];
                label10.Text = items.ElementAt(items.Count()-1)[0];

                label8.Visible = label9.Visible = label10.Visible = true;
                MessageBox.Show("oki");
                //loadListView2(items);
                //loadListView1(clients);
            }
        }
    }
}
