namespace AllersGroup
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uC_P11 = new AllersGroup.UC_P1();
            this.SuspendLayout();
            // 
            // uC_P11
            // 
            this.uC_P11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(55)))), ((int)(((byte)(75)))));
            this.uC_P11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.uC_P11.ForeColor = System.Drawing.Color.BurlyWood;
            this.uC_P11.Location = new System.Drawing.Point(23, 12);
            this.uC_P11.Name = "uC_P11";
            this.uC_P11.Size = new System.Drawing.Size(738, 486);
            this.uC_P11.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(847, 441);
            this.Controls.Add(this.uC_P11);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private UC_P1 uC_P11;
    }
}