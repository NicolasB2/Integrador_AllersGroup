namespace AllersGroup
{
    partial class AuxForm
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
            this.uc_menu1 = new AllersGroup.UC_Menu();
            this.SuspendLayout();
            // 
            // uc_menu1
            // 
            this.uc_menu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.uc_menu1.Location = new System.Drawing.Point(43, 28);
            this.uc_menu1.Name = "uc_menu1";
            this.uc_menu1.Size = new System.Drawing.Size(754, 487);
            this.uc_menu1.TabIndex = 0;
            // 
            // AuxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 580);
            this.Controls.Add(this.uc_menu1);
            this.Name = "AuxForm";
            this.Text = "AuxForm";
            this.Load += new System.EventHandler(this.AuxForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UC_Menu uc_menu1;
    }
}