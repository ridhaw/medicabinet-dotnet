namespace MediCabinet.Views.Forms
{
    partial class frmPatientProfil
    {
        private System.ComponentModel.IContainer components = null;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbRecherche = new System.Windows.Forms.GroupBox();
            this.btnRafraichir = new System.Windows.Forms.Button();
            this.btnRechercher = new System.Windows.Forms.Button();
            this.cmbGrpSanguins = new System.Windows.Forms.ComboBox();
            this.txtRechercher = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPatients = new System.Windows.Forms.DataGridView();
            this.gbDetails = new System.Windows.Forms.GroupBox();
            this.txtAllergies = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPersonneContact = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtTelContact = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnNouveau = new System.Windows.Forms.Button();
            this.txtNumMutuelle = new System.Windows.Forms.TextBox();
            this.txtMutuelle = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.txtCodePostal = new System.Windows.Forms.TextBox();
            this.cmbGrpSanguin = new System.Windows.Forms.ComboBox();
            this.txtVille = new System.Windows.Forms.TextBox();
            this.txtAdresse = new System.Windows.Forms.TextBox();
            this.cmbSexe = new System.Windows.Forms.ComboBox();
            this.txtAntecedents = new System.Windows.Forms.TextBox();
            this.dtpNaissance = new System.Windows.Forms.DateTimePicker();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.panelActions = new System.Windows.Forms.Panel();
            this.btnSauvegarder = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.gbRecherche.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).BeginInit();
            this.gbDetails.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbRecherche
            // 
            this.gbRecherche.BackColor = System.Drawing.Color.White;
            this.gbRecherche.Controls.Add(this.btnRafraichir);
            this.gbRecherche.Controls.Add(this.btnRechercher);
            this.gbRecherche.Controls.Add(this.cmbGrpSanguins);
            this.gbRecherche.Controls.Add(this.txtRechercher);
            this.gbRecherche.Controls.Add(this.label3);
            this.gbRecherche.Controls.Add(this.label1);
            this.gbRecherche.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRecherche.Location = new System.Drawing.Point(30, 80);
            this.gbRecherche.Margin = new System.Windows.Forms.Padding(4);
            this.gbRecherche.Name = "gbRecherche";
            this.gbRecherche.Padding = new System.Windows.Forms.Padding(4);
            this.gbRecherche.Size = new System.Drawing.Size(320, 180);
            this.gbRecherche.TabIndex = 0;
            this.gbRecherche.TabStop = false;
            this.gbRecherche.Text = "🔍 Recherche Patients";
            // 
            // btnRafraichir
            // 
            this.btnRafraichir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnRafraichir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRafraichir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRafraichir.ForeColor = System.Drawing.Color.White;
            this.btnRafraichir.Location = new System.Drawing.Point(180, 130);
            this.btnRafraichir.Margin = new System.Windows.Forms.Padding(4);
            this.btnRafraichir.Name = "btnRafraichir";
            this.btnRafraichir.Size = new System.Drawing.Size(120, 35);
            this.btnRafraichir.TabIndex = 5;
            this.btnRafraichir.Text = "🔄 Rafraîchir";
            this.btnRafraichir.UseVisualStyleBackColor = false;
            this.btnRafraichir.Click += new System.EventHandler(this.btnRafraichir_Click);
            // 
            // btnRechercher
            // 
            this.btnRechercher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnRechercher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRechercher.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRechercher.ForeColor = System.Drawing.Color.White;
            this.btnRechercher.Location = new System.Drawing.Point(40, 130);
            this.btnRechercher.Margin = new System.Windows.Forms.Padding(4);
            this.btnRechercher.Name = "btnRechercher";
            this.btnRechercher.Size = new System.Drawing.Size(120, 35);
            this.btnRechercher.TabIndex = 6;
            this.btnRechercher.Text = "🔍 Rechercher";
            this.btnRechercher.UseVisualStyleBackColor = false;
            this.btnRechercher.Click += new System.EventHandler(this.btnRechercher_Click);
            // 
            // cmbGrpSanguins
            // 
            this.cmbGrpSanguins.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrpSanguins.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGrpSanguins.FormattingEnabled = true;
            this.cmbGrpSanguins.Items.AddRange(new object[] {
            "Tous",
            "A+",
            "A-",
            "B+",
            "B-",
            "AB+",
            "AB-",
            "O+",
            "O-"});
            this.cmbGrpSanguins.Location = new System.Drawing.Point(180, 80);
            this.cmbGrpSanguins.Margin = new System.Windows.Forms.Padding(4);
            this.cmbGrpSanguins.Name = "cmbGrpSanguins";
            this.cmbGrpSanguins.Size = new System.Drawing.Size(120, 28);
            this.cmbGrpSanguins.TabIndex = 4;
            this.cmbGrpSanguins.SelectedIndexChanged += new System.EventHandler(this.cmbGrpSanguins_SelectedIndexChanged);
            // 
            // txtRechercher
            // 
            this.txtRechercher.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRechercher.Location = new System.Drawing.Point(180, 35);
            this.txtRechercher.Margin = new System.Windows.Forms.Padding(4);
            this.txtRechercher.Name = "txtRechercher";
            this.txtRechercher.Size = new System.Drawing.Size(120, 27);
            this.txtRechercher.TabIndex = 3;
            this.txtRechercher.Text = "Nom, prénom, téléphone...";
            this.txtRechercher.TextChanged += new System.EventHandler(this.txtRechercher_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Groupe sanguin :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Recherche :";
            // 
            // dgvPatients
            // 
            this.dgvPatients.AllowUserToAddRows = false;
            this.dgvPatients.AllowUserToDeleteRows = false;
            this.dgvPatients.AllowUserToResizeRows = false;
            this.dgvPatients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPatients.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPatients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPatients.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPatients.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPatients.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvPatients.Location = new System.Drawing.Point(370, 80);
            this.dgvPatients.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPatients.MultiSelect = false;
            this.dgvPatients.Name = "dgvPatients";
            this.dgvPatients.ReadOnly = true;
            this.dgvPatients.RowHeadersVisible = false;
            this.dgvPatients.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            this.dgvPatients.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPatients.RowTemplate.Height = 35;
            this.dgvPatients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatients.Size = new System.Drawing.Size(800, 250);
            this.dgvPatients.TabIndex = 1;
            this.dgvPatients.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPatients_CellContentClick);
            // 
            // gbDetails
            // 
            this.gbDetails.BackColor = System.Drawing.Color.White;
            this.gbDetails.Controls.Add(this.txtAllergies);
            this.gbDetails.Controls.Add(this.label14);
            this.gbDetails.Controls.Add(this.txtPersonneContact);
            this.gbDetails.Controls.Add(this.label18);
            this.gbDetails.Controls.Add(this.txtTelContact);
            this.gbDetails.Controls.Add(this.label19);
            this.gbDetails.Controls.Add(this.btnSupprimer);
            this.gbDetails.Controls.Add(this.btnModifier);
            this.gbDetails.Controls.Add(this.btnNouveau);
            this.gbDetails.Controls.Add(this.txtNumMutuelle);
            this.gbDetails.Controls.Add(this.txtMutuelle);
            this.gbDetails.Controls.Add(this.txtEmail);
            this.gbDetails.Controls.Add(this.txtTelephone);
            this.gbDetails.Controls.Add(this.txtCodePostal);
            this.gbDetails.Controls.Add(this.cmbGrpSanguin);
            this.gbDetails.Controls.Add(this.txtVille);
            this.gbDetails.Controls.Add(this.txtAdresse);
            this.gbDetails.Controls.Add(this.cmbSexe);
            this.gbDetails.Controls.Add(this.txtAntecedents);
            this.gbDetails.Controls.Add(this.dtpNaissance);
            this.gbDetails.Controls.Add(this.txtPrenom);
            this.gbDetails.Controls.Add(this.txtNom);
            this.gbDetails.Controls.Add(this.label16);
            this.gbDetails.Controls.Add(this.label15);
            this.gbDetails.Controls.Add(this.label13);
            this.gbDetails.Controls.Add(this.label12);
            this.gbDetails.Controls.Add(this.label11);
            this.gbDetails.Controls.Add(this.label10);
            this.gbDetails.Controls.Add(this.label9);
            this.gbDetails.Controls.Add(this.label8);
            this.gbDetails.Controls.Add(this.label7);
            this.gbDetails.Controls.Add(this.label6);
            this.gbDetails.Controls.Add(this.label5);
            this.gbDetails.Controls.Add(this.label4);
            this.gbDetails.Controls.Add(this.label2);
            this.gbDetails.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDetails.Location = new System.Drawing.Point(30, 350);
            this.gbDetails.Margin = new System.Windows.Forms.Padding(4);
            this.gbDetails.Name = "gbDetails";
            this.gbDetails.Padding = new System.Windows.Forms.Padding(4);
            this.gbDetails.Size = new System.Drawing.Size(1140, 300);
            this.gbDetails.TabIndex = 2;
            this.gbDetails.TabStop = false;
            this.gbDetails.Text = "📋 Détails Patient";
            // 
            // txtAllergies
            // 
            this.txtAllergies.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAllergies.Location = new System.Drawing.Point(760, 80);
            this.txtAllergies.Margin = new System.Windows.Forms.Padding(4);
            this.txtAllergies.Name = "txtAllergies";
            this.txtAllergies.Size = new System.Drawing.Size(250, 27);
            this.txtAllergies.TabIndex = 35;
            this.txtAllergies.Text = "Pénicilline, Pollens...";
            this.txtAllergies.TextChanged += new System.EventHandler(this.txtAllergies_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(640, 85);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 20);
            this.label14.TabIndex = 34;
            this.label14.Text = "Allergies :";
            // 
            // txtPersonneContact
            // 
            this.txtPersonneContact.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPersonneContact.Location = new System.Drawing.Point(760, 180);
            this.txtPersonneContact.Margin = new System.Windows.Forms.Padding(4);
            this.txtPersonneContact.Name = "txtPersonneContact";
            this.txtPersonneContact.Size = new System.Drawing.Size(180, 27);
            this.txtPersonneContact.TabIndex = 33;
            this.txtPersonneContact.Text = "Nom contact urgence";
            this.txtPersonneContact.TextChanged += new System.EventHandler(this.txtPersonneContact_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(640, 185);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(124, 20);
            this.label18.TabIndex = 32;
            this.label18.Text = "Contact urgence :";
            // 
            // txtTelContact
            // 
            this.txtTelContact.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelContact.Location = new System.Drawing.Point(760, 220);
            this.txtTelContact.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelContact.Name = "txtTelContact";
            this.txtTelContact.Size = new System.Drawing.Size(180, 27);
            this.txtTelContact.TabIndex = 31;
            this.txtTelContact.Text = "06XXXXXXXX";
            this.txtTelContact.TextChanged += new System.EventHandler(this.txtTelContact_TextChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(640, 225);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(88, 20);
            this.label19.TabIndex = 30;
            this.label19.Text = "Tél contact :";
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnSupprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupprimer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimer.ForeColor = System.Drawing.Color.White;
            this.btnSupprimer.Location = new System.Drawing.Point(280, 250);
            this.btnSupprimer.Margin = new System.Windows.Forms.Padding(4);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(120, 35);
            this.btnSupprimer.TabIndex = 32;
            this.btnSupprimer.Text = "❌ Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = false;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnModifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifier.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifier.ForeColor = System.Drawing.Color.White;
            this.btnModifier.Location = new System.Drawing.Point(150, 250);
            this.btnModifier.Margin = new System.Windows.Forms.Padding(4);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(120, 35);
            this.btnModifier.TabIndex = 31;
            this.btnModifier.Text = "✏️ Modifier";
            this.btnModifier.UseVisualStyleBackColor = false;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnNouveau
            // 
            this.btnNouveau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnNouveau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNouveau.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNouveau.ForeColor = System.Drawing.Color.White;
            this.btnNouveau.Location = new System.Drawing.Point(20, 250);
            this.btnNouveau.Margin = new System.Windows.Forms.Padding(4);
            this.btnNouveau.Name = "btnNouveau";
            this.btnNouveau.Size = new System.Drawing.Size(120, 35);
            this.btnNouveau.TabIndex = 28;
            this.btnNouveau.Text = "➕ Nouveau";
            this.btnNouveau.UseVisualStyleBackColor = false;
            this.btnNouveau.Click += new System.EventHandler(this.btnNouveau_Click);
            // 
            // txtNumMutuelle
            // 
            this.txtNumMutuelle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumMutuelle.Location = new System.Drawing.Point(760, 35);
            this.txtNumMutuelle.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumMutuelle.Name = "txtNumMutuelle";
            this.txtNumMutuelle.Size = new System.Drawing.Size(140, 27);
            this.txtNumMutuelle.TabIndex = 27;
            this.txtNumMutuelle.Text = "MG123456";
            this.txtNumMutuelle.TextChanged += new System.EventHandler(this.txtNumMutuelle_TextChanged);
            // 
            // txtMutuelle
            // 
            this.txtMutuelle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMutuelle.Location = new System.Drawing.Point(510, 180);
            this.txtMutuelle.Margin = new System.Windows.Forms.Padding(4);
            this.txtMutuelle.Name = "txtMutuelle";
            this.txtMutuelle.Size = new System.Drawing.Size(120, 27);
            this.txtMutuelle.TabIndex = 26;
            this.txtMutuelle.Text = "MGEN";
            this.txtMutuelle.TextChanged += new System.EventHandler(this.txtMutuelle_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(510, 130);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(120, 27);
            this.txtEmail.TabIndex = 25;
            this.txtEmail.Text = "email@exemple.com";
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // txtTelephone
            // 
            this.txtTelephone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelephone.Location = new System.Drawing.Point(510, 80);
            this.txtTelephone.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(120, 27);
            this.txtTelephone.TabIndex = 24;
            this.txtTelephone.Text = "06XXXXXXXX";
            this.txtTelephone.TextChanged += new System.EventHandler(this.txtTelephone_TextChanged);
            // 
            // txtCodePostal
            // 
            this.txtCodePostal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodePostal.Location = new System.Drawing.Point(510, 35);
            this.txtCodePostal.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodePostal.Name = "txtCodePostal";
            this.txtCodePostal.Size = new System.Drawing.Size(120, 27);
            this.txtCodePostal.TabIndex = 23;
            this.txtCodePostal.Text = "75001";
            this.txtCodePostal.TextChanged += new System.EventHandler(this.txtCodePostal_TextChanged);
            // 
            // cmbGrpSanguin
            // 
            this.cmbGrpSanguin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrpSanguin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGrpSanguin.FormattingEnabled = true;
            this.cmbGrpSanguin.Items.AddRange(new object[] {
            "A+",
            "A-",
            "B+",
            "B-",
            "AB+",
            "AB-",
            "O+",
            "O-"});
            this.cmbGrpSanguin.Location = new System.Drawing.Point(510, 220);
            this.cmbGrpSanguin.Margin = new System.Windows.Forms.Padding(4);
            this.cmbGrpSanguin.Name = "cmbGrpSanguin";
            this.cmbGrpSanguin.Size = new System.Drawing.Size(120, 28);
            this.cmbGrpSanguin.TabIndex = 22;
            this.cmbGrpSanguin.SelectedIndexChanged += new System.EventHandler(this.cmbGrpSanguin_SelectedIndexChanged);
            // 
            // txtVille
            // 
            this.txtVille.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVille.Location = new System.Drawing.Point(290, 180);
            this.txtVille.Margin = new System.Windows.Forms.Padding(4);
            this.txtVille.Name = "txtVille";
            this.txtVille.Size = new System.Drawing.Size(120, 27);
            this.txtVille.TabIndex = 21;
            this.txtVille.Text = "Paris";
            this.txtVille.TextChanged += new System.EventHandler(this.txtVille_TextChanged);
            // 
            // txtAdresse
            // 
            this.txtAdresse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdresse.Location = new System.Drawing.Point(290, 130);
            this.txtAdresse.Margin = new System.Windows.Forms.Padding(4);
            this.txtAdresse.Name = "txtAdresse";
            this.txtAdresse.Size = new System.Drawing.Size(120, 27);
            this.txtAdresse.TabIndex = 20;
            this.txtAdresse.Text = "12 Rue de la Paix";
            this.txtAdresse.TextChanged += new System.EventHandler(this.txtAdresse_TextChanged);
            // 
            // cmbSexe
            // 
            this.cmbSexe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSexe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSexe.FormattingEnabled = true;
            this.cmbSexe.Items.AddRange(new object[] {
            "M",
            "F"});
            this.cmbSexe.Location = new System.Drawing.Point(290, 80);
            this.cmbSexe.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSexe.Name = "cmbSexe";
            this.cmbSexe.Size = new System.Drawing.Size(65, 28);
            this.cmbSexe.TabIndex = 19;
            this.cmbSexe.SelectedIndexChanged += new System.EventHandler(this.cmbSexe_SelectedIndexChanged);
            // 
            // txtAntecedents
            // 
            this.txtAntecedents.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAntecedents.Location = new System.Drawing.Point(290, 35);
            this.txtAntecedents.Margin = new System.Windows.Forms.Padding(4);
            this.txtAntecedents.Name = "txtAntecedents";
            this.txtAntecedents.Size = new System.Drawing.Size(120, 27);
            this.txtAntecedents.TabIndex = 18;
            this.txtAntecedents.Text = "Hypertension...";
            this.txtAntecedents.TextChanged += new System.EventHandler(this.txtAntecedents_TextChanged);
            // 
            // dtpNaissance
            // 
            this.dtpNaissance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNaissance.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNaissance.Location = new System.Drawing.Point(145, 220);
            this.dtpNaissance.Margin = new System.Windows.Forms.Padding(4);
            this.dtpNaissance.Name = "dtpNaissance";
            this.dtpNaissance.Size = new System.Drawing.Size(120, 27);
            this.dtpNaissance.TabIndex = 17;
            this.dtpNaissance.ValueChanged += new System.EventHandler(this.dtpNaissance_ValueChanged);
            // 
            // txtPrenom
            // 
            this.txtPrenom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrenom.Location = new System.Drawing.Point(145, 180);
            this.txtPrenom.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(120, 27);
            this.txtPrenom.TabIndex = 16;
            this.txtPrenom.Text = "Jean";
            this.txtPrenom.TextChanged += new System.EventHandler(this.txtPrenom_TextChanged);
            // 
            // txtNom
            // 
            this.txtNom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNom.Location = new System.Drawing.Point(145, 130);
            this.txtNom.Margin = new System.Windows.Forms.Padding(4);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(120, 27);
            this.txtNom.TabIndex = 15;
            this.txtNom.Text = "DUPONT";
            this.txtNom.TextChanged += new System.EventHandler(this.txtNom_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(420, 225);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 20);
            this.label16.TabIndex = 13;
            this.label16.Text = "Groupe S. :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(640, 40);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(95, 20);
            this.label15.TabIndex = 12;
            this.label15.Text = "N° Mutuelle :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(420, 185);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 20);
            this.label13.TabIndex = 10;
            this.label13.Text = "Mutuelle :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(420, 135);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 20);
            this.label12.TabIndex = 9;
            this.label12.Text = "Email :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(420, 85);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 20);
            this.label11.TabIndex = 8;
            this.label11.Text = "Téléphone :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(420, 40);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 20);
            this.label10.TabIndex = 7;
            this.label10.Text = "Code Postal :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(20, 225);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 20);
            this.label9.TabIndex = 6;
            this.label9.Text = "Date Naissance :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(420, 225);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 20);
            this.label8.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(220, 185);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Ville :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(220, 135);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Adresse :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(220, 85);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Sexe :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 185);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Prénom :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 135);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nom :";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.panelHeader.Controls.Add(this.label20);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1200, 70);
            this.panelHeader.TabIndex = 3;
            this.panelHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHeader_Paint);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(25, 15);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(295, 41);
            this.label20.TabIndex = 0;
            this.label20.Text = "🏥 Gestion Patients";
            // 
            // panelActions
            // 
            this.panelActions.Controls.Add(this.btnSauvegarder);
            this.panelActions.Controls.Add(this.btnAnnuler);
            this.panelActions.Location = new System.Drawing.Point(30, 660);
            this.panelActions.Margin = new System.Windows.Forms.Padding(4);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(1140, 50);
            this.panelActions.TabIndex = 4;
            // 
            // btnSauvegarder
            // 
            this.btnSauvegarder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnSauvegarder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSauvegarder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSauvegarder.ForeColor = System.Drawing.Color.White;
            this.btnSauvegarder.Location = new System.Drawing.Point(20, 10);
            this.btnSauvegarder.Margin = new System.Windows.Forms.Padding(4);
            this.btnSauvegarder.Name = "btnSauvegarder";
            this.btnSauvegarder.Size = new System.Drawing.Size(140, 35);
            this.btnSauvegarder.TabIndex = 29;
            this.btnSauvegarder.Text = "💾 Sauvegarder";
            this.btnSauvegarder.UseVisualStyleBackColor = false;
            this.btnSauvegarder.Visible = false;
            this.btnSauvegarder.Click += new System.EventHandler(this.btnSauvegarder_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuler.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.ForeColor = System.Drawing.Color.White;
            this.btnAnnuler.Location = new System.Drawing.Point(180, 10);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(4);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(120, 35);
            this.btnAnnuler.TabIndex = 30;
            this.btnAnnuler.Text = "🚪 Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Visible = false;
            // 
            // frmPatientProfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.panelActions);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.gbDetails);
            this.Controls.Add(this.dgvPatients);
            this.Controls.Add(this.gbRecherche);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPatientProfil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion des Patients - MediCabinet";
            this.Load += new System.EventHandler(this.frmPatientProfil_Load_1);
            this.gbRecherche.ResumeLayout(false);
            this.gbRecherche.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).EndInit();
            this.gbDetails.ResumeLayout(false);
            this.gbDetails.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbRecherche;
        private System.Windows.Forms.Button btnRafraichir;
        private System.Windows.Forms.Button btnRechercher;
        private System.Windows.Forms.ComboBox cmbGrpSanguins;
        private System.Windows.Forms.TextBox txtRechercher;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPatients;
        private System.Windows.Forms.GroupBox gbDetails;
        private System.Windows.Forms.TextBox txtAllergies;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtPersonneContact;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtTelContact;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnNouveau;
        private System.Windows.Forms.TextBox txtNumMutuelle;
        private System.Windows.Forms.TextBox txtMutuelle;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.TextBox txtCodePostal;
        private System.Windows.Forms.ComboBox cmbGrpSanguin;
        private System.Windows.Forms.TextBox txtVille;
        private System.Windows.Forms.TextBox txtAdresse;
        private System.Windows.Forms.ComboBox cmbSexe;
        private System.Windows.Forms.TextBox txtAntecedents;
        private System.Windows.Forms.DateTimePicker dtpNaissance;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Button btnSauvegarder;
        private System.Windows.Forms.Button btnAnnuler;
    }
}