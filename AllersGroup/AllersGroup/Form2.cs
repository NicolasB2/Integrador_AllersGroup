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
            uC_G31.LoadModel(model);
        }

        private void InitializeComponent()
        {
            this.uC_G31 = new AllersGroup.UC_G3();
            this.SuspendLayout();
            // 
            // uC_G31
            // 
            this.uC_G31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(55)))), ((int)(((byte)(75)))));
            this.uC_G31.Location = new System.Drawing.Point(23, 12);
            this.uC_G31.Name = "uC_G31";
            this.uC_G31.Size = new System.Drawing.Size(1000, 2266);
            this.uC_G31.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1271, 436);
            this.Controls.Add(this.uC_G31);
            this.Name = "Form2";
            this.ResumeLayout(false);

        }
    }
}
