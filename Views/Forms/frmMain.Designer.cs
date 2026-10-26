namespace MediCabinet.Views.Forms
{
    partial class frmMain
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFichier = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDeconnexion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuQuitter = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGestion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGestionPatients = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGestionUtilisateurs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGestionRendezVous = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuConsultations = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRapports = new System.Windows.Forms.ToolStripMenuItem();
            this.menuParametres = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAide = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAPropos = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblBienvenue = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelMain = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFichier,
            this.menuGestion,
            this.menuAide});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1333, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // menuFichier
            // 
            this.menuFichier.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDeconnexion,
            this.toolStripSeparator1,
            this.menuQuitter});
            this.menuFichier.Name = "menuFichier";
            this.menuFichier.Size = new System.Drawing.Size(66, 24);
            this.menuFichier.Text = "&Fichier";
            // 
            // menuDeconnexion
            // 
            this.menuDeconnexion.Name = "menuDeconnexion";
            this.menuDeconnexion.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.menuDeconnexion.Size = new System.Drawing.Size(232, 26);
            this.menuDeconnexion.Text = "&Déconnexion";
            this.menuDeconnexion.Click += new System.EventHandler(this.menuDeconnexion_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(229, 6);
            // 
            // menuQuitter
            // 
            this.menuQuitter.Name = "menuQuitter";
            this.menuQuitter.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.menuQuitter.Size = new System.Drawing.Size(232, 26);
            this.menuQuitter.Text = "&Quitter";
            this.menuQuitter.Click += new System.EventHandler(this.menuQuitter_Click);
            // 
            // menuGestion
            // 
            this.menuGestion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuGestionPatients,
            this.menuGestionUtilisateurs,
            this.menuGestionRendezVous,
            this.toolStripSeparator2,
            this.menuConsultations,
            this.menuRapports,
            this.menuParametres});
            this.menuGestion.Name = "menuGestion";
            this.menuGestion.Size = new System.Drawing.Size(73, 24);
            this.menuGestion.Text = "&Gestion";
            // 
            // menuGestionPatients
            // 
            this.menuGestionPatients.Name = "menuGestionPatients";
            this.menuGestionPatients.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.menuGestionPatients.Size = new System.Drawing.Size(228, 26);
            this.menuGestionPatients.Text = "&Patients";
            this.menuGestionPatients.Click += new System.EventHandler(this.menuGestionPatients_Click);
            // 
            // menuGestionUtilisateurs
            // 
            this.menuGestionUtilisateurs.Name = "menuGestionUtilisateurs";
            this.menuGestionUtilisateurs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.menuGestionUtilisateurs.Size = new System.Drawing.Size(228, 26);
            this.menuGestionUtilisateurs.Text = "&Utilisateurs";
            this.menuGestionUtilisateurs.Click += new System.EventHandler(this.menuGestionUtilisateurs_Click);
            // 
            // menuGestionRendezVous
            // 
            this.menuGestionRendezVous.Name = "menuGestionRendezVous";
            this.menuGestionRendezVous.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.menuGestionRendezVous.Size = new System.Drawing.Size(228, 26);
            this.menuGestionRendezVous.Text = "&Rendez-vous";
            this.menuGestionRendezVous.Click += new System.EventHandler(this.menuGestionRendezVous_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(225, 6);
            // 
            // menuConsultations
            // 
            this.menuConsultations.Name = "menuConsultations";
            this.menuConsultations.Size = new System.Drawing.Size(228, 26);
            this.menuConsultations.Text = "&Consultations";
            this.menuConsultations.Click += new System.EventHandler(this.menuConsultations_Click);
            // 
            // menuRapports
            // 
            this.menuRapports.Name = "menuRapports";
            this.menuRapports.Size = new System.Drawing.Size(228, 26);
            this.menuRapports.Text = "Rappor&ts";
            this.menuRapports.Click += new System.EventHandler(this.menuRapports_Click);
            // 
            // menuParametres
            // 
            this.menuParametres.Name = "menuParametres";
            this.menuParametres.Size = new System.Drawing.Size(228, 26);
            this.menuParametres.Text = "&Paramètres";
            this.menuParametres.Click += new System.EventHandler(this.menuParametres_Click);
            // 
            // menuAide
            // 
            this.menuAide.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAPropos});
            this.menuAide.Name = "menuAide";
            this.menuAide.Size = new System.Drawing.Size(54, 24);
            this.menuAide.Text = "&Aide";
            // 
            // menuAPropos
            // 
            this.menuAPropos.Name = "menuAPropos";
            this.menuAPropos.Size = new System.Drawing.Size(153, 26);
            this.menuAPropos.Text = "À &propos";
            this.menuAPropos.Click += new System.EventHandler(this.menuAPropos_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 774);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1333, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(164, 20);
            this.lblStatus.Text = "MediCabinet v1.0 - Prêt";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.SteelBlue;
            this.panelHeader.Controls.Add(this.lblDate);
            this.panelHeader.Controls.Add(this.lblRole);
            this.panelHeader.Controls.Add(this.lblBienvenue);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 28);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1333, 98);
            this.panelHeader.TabIndex = 2;
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(933, 37);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(373, 25);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Date: 00/00/0000 00:00:00";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.ForeColor = System.Drawing.Color.White;
            this.lblRole.Location = new System.Drawing.Point(27, 55);
            this.lblRole.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(59, 24);
            this.lblRole.TabIndex = 1;
            this.lblRole.Text = "Rôle:";
            // 
            // lblBienvenue
            // 
            this.lblBienvenue.AutoSize = true;
            this.lblBienvenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenue.ForeColor = System.Drawing.Color.White;
            this.lblBienvenue.Location = new System.Drawing.Point(27, 18);
            this.lblBienvenue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBienvenue.Name = "lblBienvenue";
            this.lblBienvenue.Size = new System.Drawing.Size(150, 29);
            this.lblBienvenue.TabIndex = 0;
            this.lblBienvenue.Text = "Bienvenue, ";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 126);
            this.panelMain.Margin = new System.Windows.Forms.Padding(4);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1333, 648);
            this.panelMain.TabIndex = 3;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1333, 800);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MediCabinet - Gestion de Cabinet Médical";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFichier;
        private System.Windows.Forms.ToolStripMenuItem menuDeconnexion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuQuitter;
        private System.Windows.Forms.ToolStripMenuItem menuGestion;
        private System.Windows.Forms.ToolStripMenuItem menuGestionPatients;
        private System.Windows.Forms.ToolStripMenuItem menuGestionUtilisateurs;
        private System.Windows.Forms.ToolStripMenuItem menuGestionRendezVous;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuConsultations;
        private System.Windows.Forms.ToolStripMenuItem menuRapports;
        private System.Windows.Forms.ToolStripMenuItem menuParametres;
        private System.Windows.Forms.ToolStripMenuItem menuAide;
        private System.Windows.Forms.ToolStripMenuItem menuAPropos;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblBienvenue;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panelMain;
    }
}