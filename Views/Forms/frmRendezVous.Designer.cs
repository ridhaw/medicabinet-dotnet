namespace MediCabinet.Views.Forms
{
    partial class frmRendezVous
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbRecherche = new System.Windows.Forms.GroupBox();
            this.btnTous = new System.Windows.Forms.Button();
            this.btnAujourdhui = new System.Windows.Forms.Button();
            this.btnRechercher = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMedecinRecherche = new System.Windows.Forms.ComboBox();
            this.dtpDateRecherche = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.gbListe = new System.Windows.Forms.GroupBox();
            this.dgvRendezVous = new System.Windows.Forms.DataGridView();
            this.gbDetails = new System.Windows.Forms.GroupBox();
            this.lblId = new System.Windows.Forms.Label();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnNouveau = new System.Windows.Forms.Button();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbPriorite = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbStatut = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMotif = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbTypeConsultation = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpHeureFin = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpHeureDebut = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpDateRDV = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbMedecin = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPatient = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbRecherche.SuspendLayout();
            this.gbListe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRendezVous)).BeginInit();
            this.gbDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbRecherche
            // 
            this.gbRecherche.Controls.Add(this.btnTous);
            this.gbRecherche.Controls.Add(this.btnAujourdhui);
            this.gbRecherche.Controls.Add(this.btnRechercher);
            this.gbRecherche.Controls.Add(this.label2);
            this.gbRecherche.Controls.Add(this.cmbMedecinRecherche);
            this.gbRecherche.Controls.Add(this.dtpDateRecherche);
            this.gbRecherche.Controls.Add(this.label1);
            this.gbRecherche.Location = new System.Drawing.Point(16, 15);
            this.gbRecherche.Margin = new System.Windows.Forms.Padding(4);
            this.gbRecherche.Name = "gbRecherche";
            this.gbRecherche.Padding = new System.Windows.Forms.Padding(4);
            this.gbRecherche.Size = new System.Drawing.Size(1147, 98);
            this.gbRecherche.TabIndex = 0;
            this.gbRecherche.TabStop = false;
            this.gbRecherche.Text = "Recherche";
            this.gbRecherche.Enter += new System.EventHandler(this.gbRecherche_Enter);
            // 
            // btnTous
            // 
            this.btnTous.Location = new System.Drawing.Point(920, 37);
            this.btnTous.Margin = new System.Windows.Forms.Padding(4);
            this.btnTous.Name = "btnTous";
            this.btnTous.Size = new System.Drawing.Size(133, 28);
            this.btnTous.TabIndex = 6;
            this.btnTous.Text = "Tous";
            this.btnTous.UseVisualStyleBackColor = true;
            this.btnTous.Click += new System.EventHandler(this.btnTous_Click);
            // 
            // btnAujourdhui
            // 
            this.btnAujourdhui.Location = new System.Drawing.Point(773, 37);
            this.btnAujourdhui.Margin = new System.Windows.Forms.Padding(4);
            this.btnAujourdhui.Name = "btnAujourdhui";
            this.btnAujourdhui.Size = new System.Drawing.Size(133, 28);
            this.btnAujourdhui.TabIndex = 5;
            this.btnAujourdhui.Text = "Aujourd\'hui";
            this.btnAujourdhui.UseVisualStyleBackColor = true;
            this.btnAujourdhui.Click += new System.EventHandler(this.btnAujourdhui_Click);
            // 
            // btnRechercher
            // 
            this.btnRechercher.Location = new System.Drawing.Point(627, 37);
            this.btnRechercher.Margin = new System.Windows.Forms.Padding(4);
            this.btnRechercher.Name = "btnRechercher";
            this.btnRechercher.Size = new System.Drawing.Size(133, 28);
            this.btnRechercher.TabIndex = 4;
            this.btnRechercher.Text = "Rechercher";
            this.btnRechercher.UseVisualStyleBackColor = true;
            this.btnRechercher.Click += new System.EventHandler(this.btnRechercher_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Médecin:";
            // 
            // cmbMedecinRecherche
            // 
            this.cmbMedecinRecherche.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedecinRecherche.FormattingEnabled = true;
            this.cmbMedecinRecherche.Location = new System.Drawing.Point(333, 38);
            this.cmbMedecinRecherche.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMedecinRecherche.Name = "cmbMedecinRecherche";
            this.cmbMedecinRecherche.Size = new System.Drawing.Size(265, 24);
            this.cmbMedecinRecherche.TabIndex = 2;
            // 
            // dtpDateRecherche
            // 
            this.dtpDateRecherche.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateRecherche.Location = new System.Drawing.Point(80, 39);
            this.dtpDateRecherche.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDateRecherche.Name = "dtpDateRecherche";
            this.dtpDateRecherche.Size = new System.Drawing.Size(159, 22);
            this.dtpDateRecherche.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date:";
            // 
            // gbListe
            // 
            this.gbListe.Controls.Add(this.dgvRendezVous);
            this.gbListe.Location = new System.Drawing.Point(16, 121);
            this.gbListe.Margin = new System.Windows.Forms.Padding(4);
            this.gbListe.Name = "gbListe";
            this.gbListe.Padding = new System.Windows.Forms.Padding(4);
            this.gbListe.Size = new System.Drawing.Size(1147, 246);
            this.gbListe.TabIndex = 1;
            this.gbListe.TabStop = false;
            this.gbListe.Text = "Liste des rendez-vous";
            // 
            // dgvRendezVous
            // 
            this.dgvRendezVous.AllowUserToAddRows = false;
            this.dgvRendezVous.AllowUserToDeleteRows = false;
            this.dgvRendezVous.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvRendezVous.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRendezVous.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRendezVous.BackgroundColor = System.Drawing.Color.White;
            this.dgvRendezVous.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRendezVous.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRendezVous.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRendezVous.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRendezVous.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRendezVous.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvRendezVous.Location = new System.Drawing.Point(4, 19);
            this.dgvRendezVous.Margin = new System.Windows.Forms.Padding(4);
            this.dgvRendezVous.MultiSelect = false;
            this.dgvRendezVous.Name = "dgvRendezVous";
            this.dgvRendezVous.ReadOnly = true;
            this.dgvRendezVous.RowHeadersVisible = false;
            this.dgvRendezVous.RowHeadersWidth = 51;
            this.dgvRendezVous.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRendezVous.Size = new System.Drawing.Size(1139, 223);
            this.dgvRendezVous.TabIndex = 0;
            this.dgvRendezVous.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRendezVous_CellContentClick);
            this.dgvRendezVous.SelectionChanged += new System.EventHandler(this.dgvRendezVous_SelectionChanged);
            // 
            // gbDetails
            // 
            this.gbDetails.Controls.Add(this.lblId);
            this.gbDetails.Controls.Add(this.btnAnnuler);
            this.gbDetails.Controls.Add(this.btnSupprimer);
            this.gbDetails.Controls.Add(this.btnEnregistrer);
            this.gbDetails.Controls.Add(this.btnNouveau);
            this.gbDetails.Controls.Add(this.txtNotes);
            this.gbDetails.Controls.Add(this.label12);
            this.gbDetails.Controls.Add(this.cmbPriorite);
            this.gbDetails.Controls.Add(this.label11);
            this.gbDetails.Controls.Add(this.cmbStatut);
            this.gbDetails.Controls.Add(this.label10);
            this.gbDetails.Controls.Add(this.txtMotif);
            this.gbDetails.Controls.Add(this.label9);
            this.gbDetails.Controls.Add(this.cmbTypeConsultation);
            this.gbDetails.Controls.Add(this.label8);
            this.gbDetails.Controls.Add(this.dtpHeureFin);
            this.gbDetails.Controls.Add(this.label7);
            this.gbDetails.Controls.Add(this.dtpHeureDebut);
            this.gbDetails.Controls.Add(this.label6);
            this.gbDetails.Controls.Add(this.dtpDateRDV);
            this.gbDetails.Controls.Add(this.label5);
            this.gbDetails.Controls.Add(this.cmbMedecin);
            this.gbDetails.Controls.Add(this.label4);
            this.gbDetails.Controls.Add(this.cmbPatient);
            this.gbDetails.Controls.Add(this.label3);
            this.gbDetails.Location = new System.Drawing.Point(16, 374);
            this.gbDetails.Margin = new System.Windows.Forms.Padding(4);
            this.gbDetails.Name = "gbDetails";
            this.gbDetails.Padding = new System.Windows.Forms.Padding(4);
            this.gbDetails.Size = new System.Drawing.Size(1147, 308);
            this.gbDetails.TabIndex = 2;
            this.gbDetails.TabStop = false;
            this.gbDetails.Text = "Détails du rendez-vous";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.ForeColor = System.Drawing.Color.Blue;
            this.lblId.Location = new System.Drawing.Point(27, 42);
            this.lblId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(28, 17);
            this.lblId.TabIndex = 26;
            this.lblId.Text = "ID:";
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(1027, 258);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(4);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(107, 37);
            this.btnAnnuler.TabIndex = 25;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Location = new System.Drawing.Point(880, 258);
            this.btnSupprimer.Margin = new System.Windows.Forms.Padding(4);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(133, 37);
            this.btnSupprimer.TabIndex = 24;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.Location = new System.Drawing.Point(733, 258);
            this.btnEnregistrer.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(133, 37);
            this.btnEnregistrer.TabIndex = 23;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // btnNouveau
            // 
            this.btnNouveau.Location = new System.Drawing.Point(587, 258);
            this.btnNouveau.Margin = new System.Windows.Forms.Padding(4);
            this.btnNouveau.Name = "btnNouveau";
            this.btnNouveau.Size = new System.Drawing.Size(133, 37);
            this.btnNouveau.TabIndex = 22;
            this.btnNouveau.Text = "Nouveau";
            this.btnNouveau.UseVisualStyleBackColor = true;
            this.btnNouveau.Click += new System.EventHandler(this.btnNouveau_Click);
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(587, 148);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(4);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(532, 98);
            this.txtNotes.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(587, 128);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 16);
            this.label12.TabIndex = 20;
            this.label12.Text = "Notes:";
            // 
            // cmbPriorite
            // 
            this.cmbPriorite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriorite.FormattingEnabled = true;
            this.cmbPriorite.Items.AddRange(new object[] {
            "Normal",
            "Urgent",
            "Controle"});
            this.cmbPriorite.Location = new System.Drawing.Point(867, 86);
            this.cmbPriorite.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPriorite.Name = "cmbPriorite";
            this.cmbPriorite.Size = new System.Drawing.Size(252, 24);
            this.cmbPriorite.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(867, 66);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 16);
            this.label11.TabIndex = 18;
            this.label11.Text = "Priorité:";
            // 
            // cmbStatut
            // 
            this.cmbStatut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatut.FormattingEnabled = true;
            this.cmbStatut.Items.AddRange(new object[] {
            "Planifie",
            "Confirme",
            "Annule",
            "Reporte",
            "Termine"});
            this.cmbStatut.Location = new System.Drawing.Point(587, 86);
            this.cmbStatut.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStatut.Name = "cmbStatut";
            this.cmbStatut.Size = new System.Drawing.Size(252, 24);
            this.cmbStatut.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(587, 66);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 16);
            this.label10.TabIndex = 16;
            this.label10.Text = "Statut:";
            // 
            // txtMotif
            // 
            this.txtMotif.Location = new System.Drawing.Point(27, 148);
            this.txtMotif.Margin = new System.Windows.Forms.Padding(4);
            this.txtMotif.Multiline = true;
            this.txtMotif.Name = "txtMotif";
            this.txtMotif.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMotif.Size = new System.Drawing.Size(532, 98);
            this.txtMotif.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 128);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 16);
            this.label9.TabIndex = 14;
            this.label9.Text = "Motif:";
            // 
            // cmbTypeConsultation
            // 
            this.cmbTypeConsultation.FormattingEnabled = true;
            this.cmbTypeConsultation.Items.AddRange(new object[] {
            "Consultation générale",
            "Suivi",
            "Contrôle",
            "Urgence",
            "Spécialiste",
            "Autre"});
            this.cmbTypeConsultation.Location = new System.Drawing.Point(307, 86);
            this.cmbTypeConsultation.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTypeConsultation.Name = "cmbTypeConsultation";
            this.cmbTypeConsultation.Size = new System.Drawing.Size(252, 24);
            this.cmbTypeConsultation.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(307, 66);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 16);
            this.label8.TabIndex = 12;
            this.label8.Text = "Type consultation:";
            // 
            // dtpHeureFin
            // 
            this.dtpHeureFin.CustomFormat = "HH:mm";
            this.dtpHeureFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHeureFin.Location = new System.Drawing.Point(867, 37);
            this.dtpHeureFin.Margin = new System.Windows.Forms.Padding(4);
            this.dtpHeureFin.Name = "dtpHeureFin";
            this.dtpHeureFin.ShowUpDown = true;
            this.dtpHeureFin.Size = new System.Drawing.Size(105, 22);
            this.dtpHeureFin.TabIndex = 11;
            this.dtpHeureFin.Value = new System.DateTime(2024, 1, 1, 16, 30, 0, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(787, 42);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Heure fin:";
            // 
            // dtpHeureDebut
            // 
            this.dtpHeureDebut.CustomFormat = "HH:mm";
            this.dtpHeureDebut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHeureDebut.Location = new System.Drawing.Point(653, 37);
            this.dtpHeureDebut.Margin = new System.Windows.Forms.Padding(4);
            this.dtpHeureDebut.Name = "dtpHeureDebut";
            this.dtpHeureDebut.ShowUpDown = true;
            this.dtpHeureDebut.Size = new System.Drawing.Size(105, 22);
            this.dtpHeureDebut.TabIndex = 9;
            this.dtpHeureDebut.Value = new System.DateTime(2024, 1, 1, 14, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(573, 42);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Heure début:";
            // 
            // dtpDateRDV
            // 
            this.dtpDateRDV.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateRDV.Location = new System.Drawing.Point(440, 37);
            this.dtpDateRDV.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDateRDV.Name = "dtpDateRDV";
            this.dtpDateRDV.Size = new System.Drawing.Size(119, 22);
            this.dtpDateRDV.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(387, 42);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Date:";
            // 
            // cmbMedecin
            // 
            this.cmbMedecin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedecin.FormattingEnabled = true;
            this.cmbMedecin.Location = new System.Drawing.Point(200, 86);
            this.cmbMedecin.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMedecin.Name = "cmbMedecin";
            this.cmbMedecin.Size = new System.Drawing.Size(79, 24);
            this.cmbMedecin.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(120, 91);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Médecin:";
            // 
            // cmbPatient
            // 
            this.cmbPatient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPatient.FormattingEnabled = true;
            this.cmbPatient.Location = new System.Drawing.Point(200, 37);
            this.cmbPatient.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPatient.Name = "cmbPatient";
            this.cmbPatient.Size = new System.Drawing.Size(79, 24);
            this.cmbPatient.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(120, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Patient:";
            // 
            // frmRendezVous
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 697);
            this.Controls.Add(this.gbDetails);
            this.Controls.Add(this.gbListe);
            this.Controls.Add(this.gbRecherche);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRendezVous";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion des rendez-vous";
            this.Load += new System.EventHandler(this.frmRendezVous_Load);
            this.gbRecherche.ResumeLayout(false);
            this.gbRecherche.PerformLayout();
            this.gbListe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRendezVous)).EndInit();
            this.gbDetails.ResumeLayout(false);
            this.gbDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbRecherche;
        private System.Windows.Forms.Button btnTous;
        private System.Windows.Forms.Button btnAujourdhui;
        private System.Windows.Forms.Button btnRechercher;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMedecinRecherche;
        private System.Windows.Forms.DateTimePicker dtpDateRecherche;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbListe;
        private System.Windows.Forms.DataGridView dgvRendezVous;
        private System.Windows.Forms.GroupBox gbDetails;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnNouveau;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbPriorite;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbStatut;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMotif;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbTypeConsultation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpHeureFin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpHeureDebut;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpDateRDV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbMedecin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPatient;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblId;
    }
}