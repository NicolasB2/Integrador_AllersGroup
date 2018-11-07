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
            label_client.Visible = label8.Visible = label9.Visible = label10.Visible = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {          
            
        }
    }
}
