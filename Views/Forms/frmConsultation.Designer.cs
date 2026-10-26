namespace MediCabinet.Views.Forms
{
    partial class frmConsultation
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox gbPatient;
        private System.Windows.Forms.TextBox txtNomPatient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPatientId;
        private System.Windows.Forms.Button btnRechercherPatient;
        private System.Windows.Forms.Button btnRechercherRendezVous;
        private System.Windows.Forms.GroupBox gbConstantes;
        private System.Windows.Forms.NumericUpDown numPoids;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numTaille;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblIMC;
        private System.Windows.Forms.NumericUpDown numTemperature;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPressionArterielle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numPouls;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gbConsultation;
        private System.Windows.Forms.DateTimePicker dtpDateConsultation;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbMedecin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMotif;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtObservations;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDiagnostic;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCodeCIM10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTraitement;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtRecommandations;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chkProchaineVisite;
        private System.Windows.Forms.DateTimePicker dtpProchaineVisite;
        private System.Windows.Forms.Button btnSauvegarder;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Button btnImprimer;
        private System.Windows.Forms.GroupBox gbHistorique;
        private System.Windows.Forms.DataGridView dgvHistorique;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label label15;
        

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
            this.gbPatient = new System.Windows.Forms.GroupBox();
            this.btnRechercherRendezVous = new System.Windows.Forms.Button();
            this.btnRechercherPatient = new System.Windows.Forms.Button();
            this.txtNomPatient = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPatientId = new System.Windows.Forms.TextBox();
            this.gbConstantes = new System.Windows.Forms.GroupBox();
            this.numPouls = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPressionArterielle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numTemperature = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.lblIMC = new System.Windows.Forms.Label();
            this.numTaille = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numPoids = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.gbConsultation = new System.Windows.Forms.GroupBox();
            this.dtpProchaineVisite = new System.Windows.Forms.DateTimePicker();
            this.chkProchaineVisite = new System.Windows.Forms.CheckBox();
            this.txtRecommandations = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTraitement = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCodeCIM10 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDiagnostic = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtObservations = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMotif = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbMedecin = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpDateConsultation = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSauvegarder = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnImprimer = new System.Windows.Forms.Button();
            this.gbHistorique = new System.Windows.Forms.GroupBox();
            this.dgvHistorique = new System.Windows.Forms.DataGridView();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.gbPatient.SuspendLayout();
            this.gbConstantes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPouls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTaille)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPoids)).BeginInit();
            this.gbConsultation.SuspendLayout();
            this.gbHistorique.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorique)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPatient
            // 
            this.gbPatient.BackColor = System.Drawing.Color.White;
            this.gbPatient.Controls.Add(this.btnRechercherRendezVous);
            this.gbPatient.Controls.Add(this.btnRechercherPatient);
            this.gbPatient.Controls.Add(this.txtNomPatient);
            this.gbPatient.Controls.Add(this.label1);
            this.gbPatient.Controls.Add(this.txtPatientId);
            this.gbPatient.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPatient.Location = new System.Drawing.Point(20, 80);
            this.gbPatient.Margin = new System.Windows.Forms.Padding(4);
            this.gbPatient.Name = "gbPatient";
            this.gbPatient.Padding = new System.Windows.Forms.Padding(4);
            this.gbPatient.Size = new System.Drawing.Size(800, 90);
            this.gbPatient.TabIndex = 0;
            this.gbPatient.TabStop = false;
            this.gbPatient.Text = "👤 Patient";
            // 
            // btnRechercherRendezVous
            // 
            this.btnRechercherRendezVous.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnRechercherRendezVous.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRechercherRendezVous.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRechercherRendezVous.ForeColor = System.Drawing.Color.White;
            this.btnRechercherRendezVous.Location = new System.Drawing.Point(650, 30);
            this.btnRechercherRendezVous.Margin = new System.Windows.Forms.Padding(4);
            this.btnRechercherRendezVous.Name = "btnRechercherRendezVous";
            this.btnRechercherRendezVous.Size = new System.Drawing.Size(130, 35);
            this.btnRechercherRendezVous.TabIndex = 4;
            this.btnRechercherRendezVous.Text = "📅 Par RDV";
            this.btnRechercherRendezVous.UseVisualStyleBackColor = false;
            this.btnRechercherRendezVous.Click += new System.EventHandler(this.btnRechercherRendezVous_Click);
            // 
            // btnRechercherPatient
            // 
            this.btnRechercherPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnRechercherPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRechercherPatient.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRechercherPatient.ForeColor = System.Drawing.Color.White;
            this.btnRechercherPatient.Location = new System.Drawing.Point(500, 30);
            this.btnRechercherPatient.Margin = new System.Windows.Forms.Padding(4);
            this.btnRechercherPatient.Name = "btnRechercherPatient";
            this.btnRechercherPatient.Size = new System.Drawing.Size(130, 35);
            this.btnRechercherPatient.TabIndex = 3;
            this.btnRechercherPatient.Text = "🔍 Rechercher";
            this.btnRechercherPatient.UseVisualStyleBackColor = false;
            this.btnRechercherPatient.Click += new System.EventHandler(this.btnRechercherPatient_Click);
            // 
            // txtNomPatient
            // 
            this.txtNomPatient.Enabled = false;
            this.txtNomPatient.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomPatient.Location = new System.Drawing.Point(200, 35);
            this.txtNomPatient.Margin = new System.Windows.Forms.Padding(4);
            this.txtNomPatient.Name = "txtNomPatient";
            this.txtNomPatient.Size = new System.Drawing.Size(280, 27);
            this.txtNomPatient.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Patient :";
            // 
            // txtPatientId
            // 
            this.txtPatientId.Enabled = false;
            this.txtPatientId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientId.Location = new System.Drawing.Point(100, 35);
            this.txtPatientId.Margin = new System.Windows.Forms.Padding(4);
            this.txtPatientId.Name = "txtPatientId";
            this.txtPatientId.Size = new System.Drawing.Size(80, 27);
            this.txtPatientId.TabIndex = 0;
            // 
            // gbConstantes
            // 
            this.gbConstantes.BackColor = System.Drawing.Color.White;
            this.gbConstantes.Controls.Add(this.numPouls);
            this.gbConstantes.Controls.Add(this.label6);
            this.gbConstantes.Controls.Add(this.txtPressionArterielle);
            this.gbConstantes.Controls.Add(this.label5);
            this.gbConstantes.Controls.Add(this.numTemperature);
            this.gbConstantes.Controls.Add(this.label4);
            this.gbConstantes.Controls.Add(this.lblIMC);
            this.gbConstantes.Controls.Add(this.numTaille);
            this.gbConstantes.Controls.Add(this.label3);
            this.gbConstantes.Controls.Add(this.numPoids);
            this.gbConstantes.Controls.Add(this.label2);
            this.gbConstantes.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbConstantes.Location = new System.Drawing.Point(20, 180);
            this.gbConstantes.Margin = new System.Windows.Forms.Padding(4);
            this.gbConstantes.Name = "gbConstantes";
            this.gbConstantes.Padding = new System.Windows.Forms.Padding(4);
            this.gbConstantes.Size = new System.Drawing.Size(800, 100);
            this.gbConstantes.TabIndex = 1;
            this.gbConstantes.TabStop = false;
            this.gbConstantes.Text = "📊 Constantes Vitales";
            // 
            // numPouls
            // 
            this.numPouls.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPouls.Location = new System.Drawing.Point(680, 35);
            this.numPouls.Margin = new System.Windows.Forms.Padding(4);
            this.numPouls.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numPouls.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numPouls.Name = "numPouls";
            this.numPouls.Size = new System.Drawing.Size(80, 27);
            this.numPouls.TabIndex = 10;
            this.numPouls.Value = new decimal(new int[] {
            72,
            0,
            0,
            0});
            this.numPouls.ValueChanged += new System.EventHandler(this.numPouls_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(600, 40);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Pouls :";
            // 
            // txtPressionArterielle
            // 
            this.txtPressionArterielle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPressionArterielle.Location = new System.Drawing.Point(500, 35);
            this.txtPressionArterielle.Margin = new System.Windows.Forms.Padding(4);
            this.txtPressionArterielle.Name = "txtPressionArterielle";
            this.txtPressionArterielle.Size = new System.Drawing.Size(80, 27);
            this.txtPressionArterielle.TabIndex = 8;
            this.txtPressionArterielle.Text = "120/80";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(420, 40);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "PA (mm) :";
            // 
            // numTemperature
            // 
            this.numTemperature.DecimalPlaces = 1;
            this.numTemperature.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTemperature.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numTemperature.Location = new System.Drawing.Point(320, 35);
            this.numTemperature.Margin = new System.Windows.Forms.Padding(4);
            this.numTemperature.Maximum = new decimal(new int[] {
            42,
            0,
            0,
            0});
            this.numTemperature.Minimum = new decimal(new int[] {
            34,
            0,
            0,
            0});
            this.numTemperature.Name = "numTemperature";
            this.numTemperature.Size = new System.Drawing.Size(80, 27);
            this.numTemperature.TabIndex = 6;
            this.numTemperature.Value = new decimal(new int[] {
            368,
            0,
            0,
            65536});
            this.numTemperature.ValueChanged += new System.EventHandler(this.numTemperature_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(240, 40);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Temp (°C) :";
            // 
            // lblIMC
            // 
            this.lblIMC.AutoSize = true;
            this.lblIMC.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIMC.Location = new System.Drawing.Point(20, 70);
            this.lblIMC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIMC.Name = "lblIMC";
            this.lblIMC.Size = new System.Drawing.Size(51, 20);
            this.lblIMC.TabIndex = 4;
            this.lblIMC.Text = "IMC: -";
            // 
            // numTaille
            // 
            this.numTaille.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTaille.Location = new System.Drawing.Point(140, 35);
            this.numTaille.Margin = new System.Windows.Forms.Padding(4);
            this.numTaille.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numTaille.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numTaille.Name = "numTaille";
            this.numTaille.Size = new System.Drawing.Size(80, 27);
            this.numTaille.TabIndex = 3;
            this.numTaille.Value = new decimal(new int[] {
            170,
            0,
            0,
            0});
            this.numTaille.ValueChanged += new System.EventHandler(this.numTaille_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(100, 40);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Taille :";
            // 
            // numPoids
            // 
            this.numPoids.DecimalPlaces = 1;
            this.numPoids.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPoids.Location = new System.Drawing.Point(40, 35);
            this.numPoids.Margin = new System.Windows.Forms.Padding(4);
            this.numPoids.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numPoids.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numPoids.Name = "numPoids";
            this.numPoids.Size = new System.Drawing.Size(60, 27);
            this.numPoids.TabIndex = 1;
            this.numPoids.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.numPoids.ValueChanged += new System.EventHandler(this.numPoids_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Poids :";
            // 
            // gbConsultation
            // 
            this.gbConsultation.BackColor = System.Drawing.Color.White;
            this.gbConsultation.Controls.Add(this.dtpProchaineVisite);
            this.gbConsultation.Controls.Add(this.chkProchaineVisite);
            this.gbConsultation.Controls.Add(this.txtRecommandations);
            this.gbConsultation.Controls.Add(this.label14);
            this.gbConsultation.Controls.Add(this.txtTraitement);
            this.gbConsultation.Controls.Add(this.label13);
            this.gbConsultation.Controls.Add(this.txtCodeCIM10);
            this.gbConsultation.Controls.Add(this.label12);
            this.gbConsultation.Controls.Add(this.txtDiagnostic);
            this.gbConsultation.Controls.Add(this.label11);
            this.gbConsultation.Controls.Add(this.txtObservations);
            this.gbConsultation.Controls.Add(this.label10);
            this.gbConsultation.Controls.Add(this.txtMotif);
            this.gbConsultation.Controls.Add(this.label9);
            this.gbConsultation.Controls.Add(this.cmbMedecin);
            this.gbConsultation.Controls.Add(this.label8);
            this.gbConsultation.Controls.Add(this.dtpDateConsultation);
            this.gbConsultation.Controls.Add(this.label7);
            this.gbConsultation.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbConsultation.Location = new System.Drawing.Point(20, 290);
            this.gbConsultation.Margin = new System.Windows.Forms.Padding(4);
            this.gbConsultation.Name = "gbConsultation";
            this.gbConsultation.Padding = new System.Windows.Forms.Padding(4);
            this.gbConsultation.Size = new System.Drawing.Size(800, 300);
            this.gbConsultation.TabIndex = 2;
            this.gbConsultation.TabStop = false;
            this.gbConsultation.Text = "🏥 Consultation";
            // 
            // dtpProchaineVisite
            // 
            this.dtpProchaineVisite.Enabled = false;
            this.dtpProchaineVisite.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpProchaineVisite.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpProchaineVisite.Location = new System.Drawing.Point(650, 250);
            this.dtpProchaineVisite.Margin = new System.Windows.Forms.Padding(4);
            this.dtpProchaineVisite.Name = "dtpProchaineVisite";
            this.dtpProchaineVisite.Size = new System.Drawing.Size(130, 27);
            this.dtpProchaineVisite.TabIndex = 17;
            // 
            // chkProchaineVisite
            // 
            this.chkProchaineVisite.AutoSize = true;
            this.chkProchaineVisite.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkProchaineVisite.Location = new System.Drawing.Point(500, 255);
            this.chkProchaineVisite.Margin = new System.Windows.Forms.Padding(4);
            this.chkProchaineVisite.Name = "chkProchaineVisite";
            this.chkProchaineVisite.Size = new System.Drawing.Size(134, 24);
            this.chkProchaineVisite.TabIndex = 16;
            this.chkProchaineVisite.Text = "Prochaine visite";
            this.chkProchaineVisite.UseVisualStyleBackColor = true;
            this.chkProchaineVisite.CheckedChanged += new System.EventHandler(this.chkProchaineVisite_CheckedChanged);
            // 
            // txtRecommandations
            // 
            this.txtRecommandations.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecommandations.Location = new System.Drawing.Point(500, 200);
            this.txtRecommandations.Margin = new System.Windows.Forms.Padding(4);
            this.txtRecommandations.Name = "txtRecommandations";
            this.txtRecommandations.Size = new System.Drawing.Size(280, 27);
            this.txtRecommandations.TabIndex = 15;
            this.txtRecommandations.TextChanged += new System.EventHandler(this.txtRecommandations_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(500, 180);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(140, 20);
            this.label14.TabIndex = 14;
            this.label14.Text = "Recommandations :";
            // 
            // txtTraitement
            // 
            this.txtTraitement.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTraitement.Location = new System.Drawing.Point(500, 140);
            this.txtTraitement.Margin = new System.Windows.Forms.Padding(4);
            this.txtTraitement.Name = "txtTraitement";
            this.txtTraitement.Size = new System.Drawing.Size(280, 27);
            this.txtTraitement.TabIndex = 13;
            this.txtTraitement.TextChanged += new System.EventHandler(this.txtTraitement_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(500, 120);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 20);
            this.label13.TabIndex = 12;
            this.label13.Text = "Traitement :";
            // 
            // txtCodeCIM10
            // 
            this.txtCodeCIM10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodeCIM10.Location = new System.Drawing.Point(500, 80);
            this.txtCodeCIM10.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodeCIM10.Name = "txtCodeCIM10";
            this.txtCodeCIM10.Size = new System.Drawing.Size(100, 27);
            this.txtCodeCIM10.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(500, 60);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 20);
            this.label12.TabIndex = 10;
            this.label12.Text = "Code CIM10 :";
            // 
            // txtDiagnostic
            // 
            this.txtDiagnostic.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiagnostic.Location = new System.Drawing.Point(500, 30);
            this.txtDiagnostic.Margin = new System.Windows.Forms.Padding(4);
            this.txtDiagnostic.Name = "txtDiagnostic";
            this.txtDiagnostic.Size = new System.Drawing.Size(280, 27);
            this.txtDiagnostic.TabIndex = 9;
            this.txtDiagnostic.TextChanged += new System.EventHandler(this.txtDiagnostic_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(500, 10);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 20);
            this.label11.TabIndex = 8;
            this.label11.Text = "Diagnostic :";
            // 
            // txtObservations
            // 
            this.txtObservations.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservations.Location = new System.Drawing.Point(20, 200);
            this.txtObservations.Margin = new System.Windows.Forms.Padding(4);
            this.txtObservations.Multiline = true;
            this.txtObservations.Name = "txtObservations";
            this.txtObservations.Size = new System.Drawing.Size(460, 80);
            this.txtObservations.TabIndex = 7;
            this.txtObservations.TextChanged += new System.EventHandler(this.txtObservations_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(20, 180);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 20);
            this.label10.TabIndex = 6;
            this.label10.Text = "Observations :";
            // 
            // txtMotif
            // 
            this.txtMotif.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotif.Location = new System.Drawing.Point(20, 140);
            this.txtMotif.Margin = new System.Windows.Forms.Padding(4);
            this.txtMotif.Name = "txtMotif";
            this.txtMotif.Size = new System.Drawing.Size(460, 27);
            this.txtMotif.TabIndex = 5;
            this.txtMotif.TextChanged += new System.EventHandler(this.txtMotif_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(20, 120);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 20);
            this.label9.TabIndex = 4;
            this.label9.Text = "Motif :";
            // 
            // cmbMedecin
            // 
            this.cmbMedecin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedecin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMedecin.FormattingEnabled = true;
            this.cmbMedecin.Location = new System.Drawing.Point(20, 80);
            this.cmbMedecin.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMedecin.Name = "cmbMedecin";
            this.cmbMedecin.Size = new System.Drawing.Size(280, 28);
            this.cmbMedecin.TabIndex = 3;
            this.cmbMedecin.SelectedIndexChanged += new System.EventHandler(this.cmbMedecin_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(20, 60);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "Médecin :";
            // 
            // dtpDateConsultation
            // 
            this.dtpDateConsultation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateConsultation.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateConsultation.Location = new System.Drawing.Point(320, 30);
            this.dtpDateConsultation.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDateConsultation.Name = "dtpDateConsultation";
            this.dtpDateConsultation.Size = new System.Drawing.Size(150, 27);
            this.dtpDateConsultation.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 35);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Date consultation :";
            // 
            // btnSauvegarder
            // 
            this.btnSauvegarder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnSauvegarder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSauvegarder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSauvegarder.ForeColor = System.Drawing.Color.White;
            this.btnSauvegarder.Location = new System.Drawing.Point(20, 620);
            this.btnSauvegarder.Margin = new System.Windows.Forms.Padding(4);
            this.btnSauvegarder.Name = "btnSauvegarder";
            this.btnSauvegarder.Size = new System.Drawing.Size(180, 45);
            this.btnSauvegarder.TabIndex = 3;
            this.btnSauvegarder.Text = "💾 Sauvegarder";
            this.btnSauvegarder.UseVisualStyleBackColor = false;
            this.btnSauvegarder.Click += new System.EventHandler(this.btnSauvegarder_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuler.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.ForeColor = System.Drawing.Color.White;
            this.btnAnnuler.Location = new System.Drawing.Point(220, 620);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(4);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(150, 45);
            this.btnAnnuler.TabIndex = 4;
            this.btnAnnuler.Text = "🚪 Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnImprimer
            // 
            this.btnImprimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnImprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimer.ForeColor = System.Drawing.Color.White;
            this.btnImprimer.Location = new System.Drawing.Point(640, 620);
            this.btnImprimer.Margin = new System.Windows.Forms.Padding(4);
            this.btnImprimer.Name = "btnImprimer";
            this.btnImprimer.Size = new System.Drawing.Size(180, 45);
            this.btnImprimer.TabIndex = 5;
            this.btnImprimer.Text = "🖨️ Imprimer CR";
            this.btnImprimer.UseVisualStyleBackColor = false;
            this.btnImprimer.Click += new System.EventHandler(this.btnImprimer_Click);
            // 
            // gbHistorique
            // 
            this.gbHistorique.BackColor = System.Drawing.Color.White;
            this.gbHistorique.Controls.Add(this.dgvHistorique);
            this.gbHistorique.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbHistorique.Location = new System.Drawing.Point(840, 80);
            this.gbHistorique.Margin = new System.Windows.Forms.Padding(4);
            this.gbHistorique.Name = "gbHistorique";
            this.gbHistorique.Padding = new System.Windows.Forms.Padding(4);
            this.gbHistorique.Size = new System.Drawing.Size(500, 510);
            this.gbHistorique.TabIndex = 6;
            this.gbHistorique.TabStop = false;
            this.gbHistorique.Text = "📋 Historique des Consultations";
            // 
            // dgvHistorique
            // 
            this.dgvHistorique.AllowUserToAddRows = false;
            this.dgvHistorique.AllowUserToDeleteRows = false;
            this.dgvHistorique.AllowUserToResizeRows = false;
            this.dgvHistorique.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorique.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorique.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistorique.Location = new System.Drawing.Point(4, 26);
            this.dgvHistorique.Margin = new System.Windows.Forms.Padding(4);
            this.dgvHistorique.MultiSelect = false;
            this.dgvHistorique.Name = "dgvHistorique";
            this.dgvHistorique.ReadOnly = true;
            this.dgvHistorique.RowHeadersVisible = false;
            this.dgvHistorique.RowHeadersWidth = 51;
            this.dgvHistorique.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorique.Size = new System.Drawing.Size(492, 480);
            this.dgvHistorique.TabIndex = 0;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.panelHeader.Controls.Add(this.label15);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1360, 70);
            this.panelHeader.TabIndex = 7;
            this.panelHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHeader_Paint);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(25, 15);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(381, 41);
            this.label15.TabIndex = 0;
            this.label15.Text = "🏥 Nouvelle Consultation";
            // 
            // frmConsultation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1360, 690);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.gbHistorique);
            this.Controls.Add(this.btnImprimer);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnSauvegarder);
            this.Controls.Add(this.gbConsultation);
            this.Controls.Add(this.gbConstantes);
            this.Controls.Add(this.gbPatient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmConsultation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MediCabinet - Consultation";
            this.Load += new System.EventHandler(this.frmConsultation_Load);
            this.gbPatient.ResumeLayout(false);
            this.gbPatient.PerformLayout();
            this.gbConstantes.ResumeLayout(false);
            this.gbConstantes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPouls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTaille)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPoids)).EndInit();
            this.gbConsultation.ResumeLayout(false);
            this.gbConsultation.PerformLayout();
            this.gbHistorique.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorique)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
            this.dgvHistorique.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistorique_CellDoubleClick);

        }

        #endregion
    }
}