﻿using System;
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
            uC_G51.LoadModel(model);
        }

        private void InitializeComponent()
        {
            this.uC_G51 = new AllersGroup.UC_G5();
            this.SuspendLayout();
            // 
            // uC_G51
            // 
            this.uC_G51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(55)))), ((int)(((byte)(75)))));
            this.uC_G51.Location = new System.Drawing.Point(0, 0);
            this.uC_G51.Name = "uC_G51";
            this.uC_G51.Size = new System.Drawing.Size(720, 2115);
            this.uC_G51.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(757, 436);
            this.Controls.Add(this.uC_G51);
            this.Name = "Form2";
            this.ResumeLayout(false);

        }
    }
}
