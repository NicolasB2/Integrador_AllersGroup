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
            this.uC_MenuRecommendations1 = new AllersGroup.UC_MenuRecommendations();
            this.SuspendLayout();
            // 
            // uC_MenuRecommendations1
            // 
            this.uC_MenuRecommendations1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(55)))), ((int)(((byte)(65)))));
            this.uC_MenuRecommendations1.Location = new System.Drawing.Point(114, 43);
            this.uC_MenuRecommendations1.Name = "uC_MenuRecommendations1";
            this.uC_MenuRecommendations1.Size = new System.Drawing.Size(239, 487);
            this.uC_MenuRecommendations1.TabIndex = 0;
            // 
            // AuxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 580);
            this.Controls.Add(this.uC_MenuRecommendations1);
            this.Name = "AuxForm";
            this.Text = "AuxForm";
            this.Load += new System.EventHandler(this.AuxForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UC_MenuRecommendations uC_MenuRecommendations1;
    }
}