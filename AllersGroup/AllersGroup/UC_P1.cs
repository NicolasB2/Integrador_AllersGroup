using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Model;

namespace AllersGroup
{
    public partial class UC_P1 : UserControl
    {
        Consult model;
        public UC_P1()
        {
            InitializeComponent();
            string[] supports = new string[] {"0.5", "0.6", "0.7", "0.8", "0.9", "1", "2", "4", "5", "10", "20"
            , "30", "40", "50", "60", "70", "80", "90" , "95"};
            comboBox1.Items.AddRange(supports);
            comboBox2.Items.AddRange(supports);
        }

        public void loadModel(Consult model)
        {
            this.model = model;
            loadClients();

            label_client.Visible = label8.Visible = label9.Visible = label10.Visible = false;
        }

        private void loadClients()
        {
            listBox1.Items.AddRange(model.clientsCodes());      
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_client.Text = listBox1.SelectedItem.ToString();
            label8.Text = model.totalTransactionsClient(listBox1.SelectedItem.ToString()) + "";
            label9.Text =;
            label10.Text =;


            label_client.Visible = label8.Visible = label9.Visible = label10.Visible = true;
            listBox2.Items.AddRange(model.itemsbyClient(listBox1.SelectedItem.ToString()).ToArray());
            listBox3.Items.AddRange(model.itemsbyClient(listBox1.SelectedItem.ToString()).ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Se debe seleccionar un porcentaje.");
            }
            if (listBox2.SelectedItem == null)
            {
                MessageBox.Show("Se debe seleccionar un producto.");

            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        //Generar predicciones.
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Se debe seleccionar un porcentaje.");
            }
            if (listBox3.SelectedItem == null)
            {
                MessageBox.Show("Se debe seleccionar un producto.");

            }

        }

        private void UC_P1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
