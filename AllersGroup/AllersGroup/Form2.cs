using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace AllersGroup
{
    public partial class Form2 : Form
    {

        
        public Form2()
        {

            InitializeComponent();

            Consult model = new Consult();
            uC_P111.loadModel(model);
        }

        private void InitializeComponent()
        {
            this.uC_P111 = new AllersGroup.UC_P11();
            this.SuspendLayout();
            // 
            // uC_P111
            // 
            this.uC_P111.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(55)))), ((int)(((byte)(75)))));
            this.uC_P111.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.uC_P111.ForeColor = System.Drawing.Color.BurlyWood;
            this.uC_P111.Location = new System.Drawing.Point(12, 12);
            this.uC_P111.Name = "uC_P111";
            this.uC_P111.Size = new System.Drawing.Size(1000, 1439);
            this.uC_P111.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1271, 436);
            this.Controls.Add(this.uC_P111);
            this.Name = "Form2";
            this.ResumeLayout(false);

        }
    }
}
