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
            uC_G221.LoadModel(model);
        }

        private void InitializeComponent()
        {
            this.uC_G221 = new AllersGroup.UC_G22();
            this.SuspendLayout();
            // 
            // uC_G221
            // 
            this.uC_G221.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(55)))), ((int)(((byte)(75)))));
            this.uC_G221.Location = new System.Drawing.Point(12, 2);
            this.uC_G221.Name = "uC_G221";
            this.uC_G221.Size = new System.Drawing.Size(1000, 1950);
            this.uC_G221.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1033, 436);
            this.Controls.Add(this.uC_G221);
            this.Name = "Form2";
            this.ResumeLayout(false);

        }
    }
}
