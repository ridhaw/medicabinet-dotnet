namespace MediCabinet.Views.Forms
{
    partial class frmDetailPrescription
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnFermer;
        private System.Windows.Forms.Button btnImprimer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblId = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnFermer = new System.Windows.Forms.Button();
            this.btnImprimer = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblId
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(20, 20);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(35, 13);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "label1";

            // lblInfo
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(20, 50);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(35, 13);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "label2";

            // btnFermer
            this.btnFermer.Location = new System.Drawing.Point(200, 200);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(75, 23);
            this.btnFermer.TabIndex = 2;
            this.btnFermer.Text = "Fermer";
            this.btnFermer.UseVisualStyleBackColor = true;
            this.btnFermer.Click += new System.EventHandler(this.btnFermer_Click);

            // btnImprimer
            this.btnImprimer.Location = new System.Drawing.Point(100, 200);
            this.btnImprimer.Name = "btnImprimer";
            this.btnImprimer.Size = new System.Drawing.Size(75, 23);
            this.btnImprimer.TabIndex = 3;
            this.btnImprimer.Text = "Imprimer";
            this.btnImprimer.UseVisualStyleBackColor = true;
            this.btnImprimer.Click += new System.EventHandler(this.btnImprimer_Click);

            // frmDetailPrescription
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 250);
            this.Controls.Add(this.btnImprimer);
            this.Controls.Add(this.btnFermer);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblId);
            this.Name = "frmDetailPrescription";
            this.Text = "Détails Prescription";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}