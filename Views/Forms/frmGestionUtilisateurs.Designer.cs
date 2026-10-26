namespace MediCabinet.Views.Forms
{
    partial class frmGestionUtilisateurs
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
            this.btnRechercher = new System.Windows.Forms.Button();
            this.cmbRoleRecherche = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRecherche = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbListe = new System.Windows.Forms.GroupBox();
            this.dgvUtilisateurs = new System.Windows.Forms.DataGridView();
            this.gbDetails = new System.Windows.Forms.GroupBox();
            this.lblId = new System.Windows.Forms.Label();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnNouveau = new System.Windows.Forms.Button();
            this.chkEstActif = new System.Windows.Forms.CheckBox();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSpecialite = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtConfirmerPassword = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbRecherche.SuspendLayout();
            this.gbListe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUtilisateurs)).BeginInit();
            this.gbDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbRecherche
            // 
            this.gbRecherche.Controls.Add(this.btnRechercher);
            this.gbRecherche.Controls.Add(this.cmbRoleRecherche);
            this.gbRecherche.Controls.Add(this.label2);
            this.gbRecherche.Controls.Add(this.txtRecherche);
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
            // btnRechercher
            // 
            this.btnRechercher.Location = new System.Drawing.Point(800, 37);
            this.btnRechercher.Margin = new System.Windows.Forms.Padding(4);
            this.btnRechercher.Name = "btnRechercher";
            this.btnRechercher.Size = new System.Drawing.Size(133, 28);
            this.btnRechercher.TabIndex = 4;
            this.btnRechercher.Text = "Rechercher";
            this.btnRechercher.UseVisualStyleBackColor = true;
            this.btnRechercher.Click += new System.EventHandler(this.btnRechercher_Click);
            // 
            // cmbRoleRecherche
            // 
            this.cmbRoleRecherche.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoleRecherche.FormattingEnabled = true;
            this.cmbRoleRecherche.Items.AddRange(new object[] {
            "Tous",
            "Admin",
            "Medecin",
            "Secretaire"});
            this.cmbRoleRecherche.Location = new System.Drawing.Point(600, 38);
            this.cmbRoleRecherche.Margin = new System.Windows.Forms.Padding(4);
            this.cmbRoleRecherche.Name = "cmbRoleRecherche";
            this.cmbRoleRecherche.Size = new System.Drawing.Size(172, 24);
            this.cmbRoleRecherche.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(547, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Role:";
            // 
            // txtRecherche
            // 
            this.txtRecherche.Location = new System.Drawing.Point(200, 39);
            this.txtRecherche.Margin = new System.Windows.Forms.Padding(4);
            this.txtRecherche.Name = "txtRecherche";
            this.txtRecherche.Size = new System.Drawing.Size(332, 22);
            this.txtRecherche.TabIndex = 1;
            this.txtRecherche.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRecherche_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nom, prénom ou email:";
            // 
            // gbListe
            // 
            this.gbListe.Controls.Add(this.dgvUtilisateurs);
            this.gbListe.Location = new System.Drawing.Point(16, 121);
            this.gbListe.Margin = new System.Windows.Forms.Padding(4);
            this.gbListe.Name = "gbListe";
            this.gbListe.Padding = new System.Windows.Forms.Padding(4);
            this.gbListe.Size = new System.Drawing.Size(1147, 308);
            this.gbListe.TabIndex = 1;
            this.gbListe.TabStop = false;
            this.gbListe.Text = "Liste des utilisateurs";
            // 
            // dgvUtilisateurs
            // 
            this.dgvUtilisateurs.AllowUserToAddRows = false;
            this.dgvUtilisateurs.AllowUserToDeleteRows = false;
            this.dgvUtilisateurs.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvUtilisateurs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUtilisateurs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUtilisateurs.BackgroundColor = System.Drawing.Color.White;
            this.dgvUtilisateurs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUtilisateurs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUtilisateurs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUtilisateurs.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUtilisateurs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUtilisateurs.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvUtilisateurs.Location = new System.Drawing.Point(4, 19);
            this.dgvUtilisateurs.Margin = new System.Windows.Forms.Padding(4);
            this.dgvUtilisateurs.MultiSelect = false;
            this.dgvUtilisateurs.Name = "dgvUtilisateurs";
            this.dgvUtilisateurs.ReadOnly = true;
            this.dgvUtilisateurs.RowHeadersVisible = false;
            this.dgvUtilisateurs.RowHeadersWidth = 51;
            this.dgvUtilisateurs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUtilisateurs.Size = new System.Drawing.Size(1139, 285);
            this.dgvUtilisateurs.TabIndex = 0;
            this.dgvUtilisateurs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUtilisateurs_CellContentClick);
            this.dgvUtilisateurs.SelectionChanged += new System.EventHandler(this.dgvUtilisateurs_SelectionChanged);
            // 
            // gbDetails
            // 
            this.gbDetails.Controls.Add(this.lblId);
            this.gbDetails.Controls.Add(this.btnAnnuler);
            this.gbDetails.Controls.Add(this.btnSupprimer);
            this.gbDetails.Controls.Add(this.btnEnregistrer);
            this.gbDetails.Controls.Add(this.btnNouveau);
            this.gbDetails.Controls.Add(this.chkEstActif);
            this.gbDetails.Controls.Add(this.txtTelephone);
            this.gbDetails.Controls.Add(this.label10);
            this.gbDetails.Controls.Add(this.txtEmail);
            this.gbDetails.Controls.Add(this.label9);
            this.gbDetails.Controls.Add(this.txtSpecialite);
            this.gbDetails.Controls.Add(this.label8);
            this.gbDetails.Controls.Add(this.cmbRole);
            this.gbDetails.Controls.Add(this.label7);
            this.gbDetails.Controls.Add(this.txtPrenom);
            this.gbDetails.Controls.Add(this.label6);
            this.gbDetails.Controls.Add(this.txtNom);
            this.gbDetails.Controls.Add(this.label5);
            this.gbDetails.Controls.Add(this.txtUsername);
            this.gbDetails.Controls.Add(this.label4);
            this.gbDetails.Controls.Add(this.txtConfirmerPassword);
            this.gbDetails.Controls.Add(this.label11);
            this.gbDetails.Controls.Add(this.txtPassword);
            this.gbDetails.Controls.Add(this.label3);
            this.gbDetails.Location = new System.Drawing.Point(16, 436);
            this.gbDetails.Margin = new System.Windows.Forms.Padding(4);
            this.gbDetails.Name = "gbDetails";
            this.gbDetails.Padding = new System.Windows.Forms.Padding(4);
            this.gbDetails.Size = new System.Drawing.Size(1147, 345);
            this.gbDetails.TabIndex = 2;
            this.gbDetails.TabStop = false;
            this.gbDetails.Text = "Détails de l\'utilisateur";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.ForeColor = System.Drawing.Color.Blue;
            this.lblId.Location = new System.Drawing.Point(27, 37);
            this.lblId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(28, 17);
            this.lblId.TabIndex = 26;
            this.lblId.Text = "ID:";
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(1027, 283);
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
            this.btnSupprimer.Location = new System.Drawing.Point(880, 283);
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
            this.btnEnregistrer.Location = new System.Drawing.Point(733, 283);
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
            this.btnNouveau.Location = new System.Drawing.Point(587, 283);
            this.btnNouveau.Margin = new System.Windows.Forms.Padding(4);
            this.btnNouveau.Name = "btnNouveau";
            this.btnNouveau.Size = new System.Drawing.Size(133, 37);
            this.btnNouveau.TabIndex = 22;
            this.btnNouveau.Text = "Nouveau";
            this.btnNouveau.UseVisualStyleBackColor = true;
            this.btnNouveau.Click += new System.EventHandler(this.btnNouveau_Click);
            // 
            // chkEstActif
            // 
            this.chkEstActif.AutoSize = true;
            this.chkEstActif.Location = new System.Drawing.Point(960, 222);
            this.chkEstActif.Margin = new System.Windows.Forms.Padding(4);
            this.chkEstActif.Name = "chkEstActif";
            this.chkEstActif.Size = new System.Drawing.Size(75, 20);
            this.chkEstActif.TabIndex = 21;
            this.chkEstActif.Text = "Est actif";
            this.chkEstActif.UseVisualStyleBackColor = true;
            // 
            // txtTelephone
            // 
            this.txtTelephone.Location = new System.Drawing.Point(960, 172);
            this.txtTelephone.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(159, 22);
            this.txtTelephone.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(960, 153);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 16);
            this.label10.TabIndex = 19;
            this.label10.Text = "Téléphone:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(960, 111);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(159, 22);
            this.txtEmail.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(960, 91);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 16);
            this.label9.TabIndex = 17;
            this.label9.Text = "Email:";
            // 
            // txtSpecialite
            // 
            this.txtSpecialite.Location = new System.Drawing.Point(960, 49);
            this.txtSpecialite.Margin = new System.Windows.Forms.Padding(4);
            this.txtSpecialite.Name = "txtSpecialite";
            this.txtSpecialite.Size = new System.Drawing.Size(159, 22);
            this.txtSpecialite.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(960, 30);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Spécialité:";
            // 
            // cmbRole
            // 
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Items.AddRange(new object[] {
            "Admin",
            "Medecin",
            "Secretaire"});
            this.cmbRole.Location = new System.Drawing.Point(613, 222);
            this.cmbRole.Margin = new System.Windows.Forms.Padding(4);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(159, 24);
            this.cmbRole.TabIndex = 14;
            this.cmbRole.SelectedIndexChanged += new System.EventHandler(this.cmbRole_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(613, 202);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Role:";
            // 
            // txtPrenom
            // 
            this.txtPrenom.Location = new System.Drawing.Point(613, 172);
            this.txtPrenom.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(159, 22);
            this.txtPrenom.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(613, 153);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Prénom:";
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(613, 111);
            this.txtNom.Margin = new System.Windows.Forms.Padding(4);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(159, 22);
            this.txtNom.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(613, 91);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Nom:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(613, 49);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(159, 22);
            this.txtUsername.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(613, 30);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Nom d\'utilisateur:";
            // 
            // txtConfirmerPassword
            // 
            this.txtConfirmerPassword.Location = new System.Drawing.Point(267, 222);
            this.txtConfirmerPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtConfirmerPassword.Name = "txtConfirmerPassword";
            this.txtConfirmerPassword.PasswordChar = '*';
            this.txtConfirmerPassword.Size = new System.Drawing.Size(159, 22);
            this.txtConfirmerPassword.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(267, 202);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(166, 16);
            this.label11.TabIndex = 5;
            this.label11.Text = "Confirmer le mot de passe:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(267, 172);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(159, 22);
            this.txtPassword.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 153);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mot de passe:";
            // 
            // frmGestionUtilisateurs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 795);
            this.Controls.Add(this.gbDetails);
            this.Controls.Add(this.gbListe);
            this.Controls.Add(this.gbRecherche);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGestionUtilisateurs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion des utilisateurs";
            this.Load += new System.EventHandler(this.frmGestionUtilisateurs_Load);
            this.gbRecherche.ResumeLayout(false);
            this.gbRecherche.PerformLayout();
            this.gbListe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUtilisateurs)).EndInit();
            this.gbDetails.ResumeLayout(false);
            this.gbDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbRecherche;
        private System.Windows.Forms.Button btnRechercher;
        private System.Windows.Forms.ComboBox cmbRoleRecherche;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRecherche;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbListe;
        private System.Windows.Forms.DataGridView dgvUtilisateurs;
        private System.Windows.Forms.GroupBox gbDetails;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnNouveau;
        private System.Windows.Forms.CheckBox chkEstActif;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSpecialite;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtConfirmerPassword;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
    }
}