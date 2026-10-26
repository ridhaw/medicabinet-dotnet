using MediCabinet.Controllers;
using MediCabinet.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MediCabinet.Views.Forms
{
    public partial class frmSelectionRendezVous : Form
    {
        private readonly RendezVousController _rendezVousController;
        private readonly UtilisateurController _utilisateurController;
        private List<RendezVous> _rendezVousList;

        public RendezVous RendezVousSelectionne { get; private set; }

        // Contrôles
        private DateTimePicker dtpDate;
        private ComboBox cmbMedecin;
        private ComboBox cmbStatut;
        private TextBox txtRecherchePatient;
        private Button btnRechercher;
        private Button btnSelect;
        private Button btnAnnuler;
        private DataGridView dgvRendezVous;
        private Panel panelHeader;
        private Label lblTitre;

        public frmSelectionRendezVous()
        {
            InitializeComponent();

            _rendezVousController = new RendezVousController();
            _utilisateurController = new UtilisateurController();
            _rendezVousList = new List<RendezVous>();
            RendezVousSelectionne = null;

            InitialiserForm();
        }

        private void InitialiserForm()
        {
            this.Size = new Size(1000, 700);
            this.Text = "Sélectionner un Rendez-vous";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Panel Header
            panelHeader = new Panel();
            panelHeader.BackColor = Color.FromArgb(255, 193, 7); // Orange pour RDV
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 70;

            lblTitre = new Label();
            lblTitre.Text = "📅 Sélectionner un Rendez-vous";
            lblTitre.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitre.ForeColor = Color.White;
            lblTitre.Location = new Point(20, 15);
            lblTitre.AutoSize = true;

            panelHeader.Controls.Add(lblTitre);

            // Panel Filtres
            Panel panelFiltres = new Panel();
            panelFiltres.Dock = DockStyle.Top;
            panelFiltres.Height = 100;
            panelFiltres.Padding = new Padding(10);

            // Date
            Label lblDate = new Label();
            lblDate.Text = "Date :";
            lblDate.Location = new Point(10, 15);
            lblDate.AutoSize = true;

            dtpDate = new DateTimePicker();
            dtpDate.Value = DateTime.Today;
            dtpDate.Location = new Point(60, 10);
            dtpDate.Size = new Size(120, 25);
            dtpDate.ValueChanged += dtpDate_ValueChanged;

            // Médecin
            Label lblMedecin = new Label();
            lblMedecin.Text = "Médecin :";
            lblMedecin.Location = new Point(200, 15);
            lblMedecin.AutoSize = true;

            cmbMedecin = new ComboBox();
            cmbMedecin.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMedecin.Location = new Point(270, 10);
            cmbMedecin.Size = new Size(200, 25);
            cmbMedecin.SelectedIndexChanged += cmbMedecin_SelectedIndexChanged;

            // Statut
            Label lblStatut = new Label();
            lblStatut.Text = "Statut :";
            lblStatut.Location = new Point(490, 15);
            lblStatut.AutoSize = true;

            cmbStatut = new ComboBox();
            cmbStatut.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatut.Location = new Point(540, 10);
            cmbStatut.Size = new Size(120, 25);
            cmbStatut.Items.AddRange(new object[] { "Tous", "Planifié", "Confirmé", "Terminé", "Annulé" });
            cmbStatut.SelectedIndex = 0;
            cmbStatut.SelectedIndexChanged += cmbStatut_SelectedIndexChanged;

            // Recherche Patient
            Label lblRecherche = new Label();
            lblRecherche.Text = "Patient :";
            lblRecherche.Location = new Point(10, 55);
            lblRecherche.AutoSize = true;

            txtRecherchePatient = new TextBox();
            txtRecherchePatient.Location = new Point(70, 50);
            txtRecherchePatient.Size = new Size(300, 25);
            txtRecherchePatient.Text = "";

            btnRechercher = new Button();
            btnRechercher.Text = "🔍 Rechercher";
            btnRechercher.BackColor = Color.FromArgb(0, 102, 204);
            btnRechercher.ForeColor = Color.White;
            btnRechercher.FlatStyle = FlatStyle.Flat;
            btnRechercher.Location = new Point(380, 48);
            btnRechercher.Size = new Size(120, 30);
            btnRechercher.Click += btnRechercher_Click;

            panelFiltres.Controls.AddRange(new Control[]
            {
                lblDate, dtpDate,
                lblMedecin, cmbMedecin,
                lblStatut, cmbStatut,
                lblRecherche, txtRecherchePatient, btnRechercher
            });

            // DataGridView - DÉSACTIVER la génération automatique des colonnes
            dgvRendezVous = new DataGridView();
            dgvRendezVous.Dock = DockStyle.Fill;
            dgvRendezVous.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRendezVous.MultiSelect = false;
            dgvRendezVous.RowHeadersVisible = false;
            dgvRendezVous.AutoGenerateColumns = false; // IMPORTANT : Désactiver la génération auto
            dgvRendezVous.ReadOnly = true;
            dgvRendezVous.CellDoubleClick += dgvRendezVous_CellDoubleClick;

            // Créer les colonnes MANUELLEMENT
            CreerColonnesDataGridView();

            // Panel Boutons
            Panel panelBoutons = new Panel();
            panelBoutons.Dock = DockStyle.Bottom;
            panelBoutons.Height = 70;
            panelBoutons.Padding = new Padding(10);

            btnSelect = new Button();
            btnSelect.Text = "✅ Sélectionner";
            btnSelect.BackColor = Color.FromArgb(76, 175, 80);
            btnSelect.ForeColor = Color.White;
            btnSelect.FlatStyle = FlatStyle.Flat;
            btnSelect.Size = new Size(150, 40);
            btnSelect.Location = new Point(600, 15);
            btnSelect.Click += btnSelect_Click;

            btnAnnuler = new Button();
            btnAnnuler.Text = "❌ Annuler";
            btnAnnuler.BackColor = Color.FromArgb(158, 158, 158);
            btnAnnuler.ForeColor = Color.White;
            btnAnnuler.FlatStyle = FlatStyle.Flat;
            btnAnnuler.Size = new Size(150, 40);
            btnAnnuler.Location = new Point(760, 15);
            btnAnnuler.Click += btnAnnuler_Click;

            panelBoutons.Controls.Add(btnSelect);
            panelBoutons.Controls.Add(btnAnnuler);

            // Ajouter les contrôles au formulaire
            this.Controls.Add(dgvRendezVous);
            this.Controls.Add(panelFiltres);
            this.Controls.Add(panelBoutons);
            this.Controls.Add(panelHeader);

            // Initialiser les données
            ChargerMedecins();
            ChargerRendezVous();
        }

        private void CreerColonnesDataGridView()
        {
            // Créer les colonnes manuellement pour éviter les problèmes de noms
            dgvRendezVous.Columns.Clear();

            // Colonne ID (cachée)
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "Id";
            colId.DataPropertyName = "Id";
            colId.HeaderText = "ID";
            colId.Visible = false;
            dgvRendezVous.Columns.Add(colId);

            // Colonne Patient
            DataGridViewTextBoxColumn colPatient = new DataGridViewTextBoxColumn();
            colPatient.Name = "Patient";
            colPatient.DataPropertyName = "Patient";
            colPatient.HeaderText = "Patient";
            colPatient.Width = 150;
            dgvRendezVous.Columns.Add(colPatient);

            // Colonne Médecin
            DataGridViewTextBoxColumn colMedecin = new DataGridViewTextBoxColumn();
            colMedecin.Name = "Medecin";
            colMedecin.DataPropertyName = "Medecin";
            colMedecin.HeaderText = "Médecin";
            colMedecin.Width = 150;
            dgvRendezVous.Columns.Add(colMedecin);

            // Colonne Date
            DataGridViewTextBoxColumn colDate = new DataGridViewTextBoxColumn();
            colDate.Name = "Date";
            colDate.DataPropertyName = "Date";
            colDate.HeaderText = "Date";
            colDate.Width = 100;
            dgvRendezVous.Columns.Add(colDate);

            // Colonne Heure
            DataGridViewTextBoxColumn colHeure = new DataGridViewTextBoxColumn();
            colHeure.Name = "Heure";
            colHeure.DataPropertyName = "Heure";
            colHeure.HeaderText = "Heure";
            colHeure.Width = 120;
            dgvRendezVous.Columns.Add(colHeure);

            // Colonne Type
            DataGridViewTextBoxColumn colType = new DataGridViewTextBoxColumn();
            colType.Name = "Type";
            colType.DataPropertyName = "Type";
            colType.HeaderText = "Type";
            colType.Width = 150;
            dgvRendezVous.Columns.Add(colType);

            // Colonne Motif
            DataGridViewTextBoxColumn colMotif = new DataGridViewTextBoxColumn();
            colMotif.Name = "Motif";
            colMotif.DataPropertyName = "Motif";
            colMotif.HeaderText = "Motif";
            colMotif.Width = 200;
            dgvRendezVous.Columns.Add(colMotif);

            // Colonne Statut
            DataGridViewTextBoxColumn colStatut = new DataGridViewTextBoxColumn();
            colStatut.Name = "Statut";
            colStatut.DataPropertyName = "Statut";
            colStatut.HeaderText = "Statut";
            colStatut.Width = 100;
            dgvRendezVous.Columns.Add(colStatut);

            // Colonne Priorité
            DataGridViewTextBoxColumn colPriorite = new DataGridViewTextBoxColumn();
            colPriorite.Name = "Priorite";
            colPriorite.DataPropertyName = "Priorite";
            colPriorite.HeaderText = "Priorité";
            colPriorite.Width = 80;
            dgvRendezVous.Columns.Add(colPriorite);
        }

        private void ChargerMedecins()
        {
            try
            {
                var medecins = _utilisateurController.RechercherUtilisateurs("", "Medecin")
                    .Where(u => u.EstActif)
                    .ToList();

                cmbMedecin.Items.Clear();
                cmbMedecin.Items.Add(new { Id = 0, NomComplet = "Tous les médecins" });

                foreach (var medecin in medecins)
                {
                    cmbMedecin.Items.Add(new { medecin.Id, NomComplet = $"Dr. {medecin.Nom} {medecin.Prenom}" });
                }

                cmbMedecin.DisplayMember = "NomComplet";
                cmbMedecin.ValueMember = "Id";
                cmbMedecin.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur chargement médecins: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChargerRendezVous()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                // Récupérer les rendez-vous pour la date sélectionnée
                var rendezVous = _rendezVousController.GetRendezVousParDate(dtpDate.Value);

                // Filtrer par médecin si sélectionné
                if (cmbMedecin.SelectedItem != null)
                {
                    var selectedMedecin = (dynamic)cmbMedecin.SelectedItem;
                    if (selectedMedecin.Id > 0)
                    {
                        rendezVous = rendezVous.Where(r => r.MedecinId == selectedMedecin.Id).ToList();
                    }
                }

                // Filtrer par statut
                if (cmbStatut.SelectedIndex > 0)
                {
                    string statut = cmbStatut.Text.Replace("é", "e").Replace("ê", "e"); // Normaliser
                    rendezVous = rendezVous.Where(r => r.Statut != null &&
                        r.Statut.Equals(statut, StringComparison.OrdinalIgnoreCase)).ToList();
                }

                // Filtrer par nom de patient
                if (!string.IsNullOrWhiteSpace(txtRecherchePatient.Text))
                {
                    string recherche = txtRecherchePatient.Text.ToLower();
                    rendezVous = rendezVous.Where(r =>
                        r.NomPatient != null && r.NomPatient.ToLower().Contains(recherche)).ToList();
                }

                _rendezVousList = rendezVous;
                AfficherRendezVous();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur chargement rendez-vous: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void AfficherRendezVous()
        {
            try
            {
                if (_rendezVousList == null || _rendezVousList.Count == 0)
                {
                    dgvRendezVous.DataSource = null;
                    lblTitre.Text = "📅 Aucun rendez-vous trouvé";
                    return;
                }

                var dataSource = _rendezVousList.Select(r => new
                {
                    Id = r.Id,
                    Patient = r.NomPatient ?? "N/A",
                    Medecin = r.NomMedecin ?? "N/A",
                    Date = r.DateRendezVous.ToString("dd/MM/yyyy"),
                    Heure = $"{r.HeureDebut:hh\\:mm} - {r.HeureFin:hh\\:mm}",
                    Type = r.TypeConsultation ?? "Consultation",
                    Motif = r.Motif ?? "",
                    Statut = r.Statut ?? "Planifié",
                    Priorite = r.Priorite ?? "Normal"
                }).ToList();

                dgvRendezVous.DataSource = dataSource;

                // Colorer les statuts
                foreach (DataGridViewRow row in dgvRendezVous.Rows)
                {
                    var statutCell = row.Cells["Statut"];
                    if (statutCell != null && statutCell.Value != null)
                    {
                        string statut = statutCell.Value.ToString().ToLower();
                        switch (statut)
                        {
                            case "planifie":
                            case "planifié":
                                statutCell.Style.ForeColor = Color.Orange;
                                break;
                            case "confirme":
                            case "confirmé":
                                statutCell.Style.ForeColor = Color.Green;
                                break;
                            case "termine":
                            case "terminé":
                                statutCell.Style.ForeColor = Color.Blue;
                                break;
                            case "annule":
                            case "annulé":
                                statutCell.Style.ForeColor = Color.Red;
                                break;
                        }
                    }
                }

                lblTitre.Text = $"📅 Rendez-vous ({_rendezVousList.Count})";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur affichage: {ex.Message}");
                MessageBox.Show($"Erreur lors de l'affichage des rendez-vous: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Gestionnaires d'événements
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            ChargerRendezVous();
        }

        private void cmbMedecin_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChargerRendezVous();
        }

        private void cmbStatut_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChargerRendezVous();
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            ChargerRendezVous();
        }

        private void dgvRendezVous_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectionnerRendezVous();
            }
        }

        private void SelectionnerRendezVous()
        {
            try
            {
                if (dgvRendezVous.SelectedRows.Count > 0 && dgvRendezVous.SelectedRows[0] != null)
                {
                    var selectedRow = dgvRendezVous.SelectedRows[0];

                    // Vérifier que la cellule "Id" existe
                    var idCell = selectedRow.Cells["Id"];
                    if (idCell != null && idCell.Value != null)
                    {
                        int rdvId = Convert.ToInt32(idCell.Value);

                        RendezVousSelectionne = _rendezVousList.FirstOrDefault(r => r.Id == rdvId);

                        if (RendezVousSelectionne != null)
                        {
                            // Vérifier que le rendez-vous est approprié pour une consultation
                            string statut = RendezVousSelectionne.Statut ?? "";
                            if (statut != "Termine" && statut != "Planifie" &&
                                statut != "Terminé" && statut != "Planifié")
                            {
                                MessageBox.Show($"Ce rendez-vous est '{RendezVousSelectionne.Statut}'. " +
                                    "Seuls les rendez-vous 'Planifié' ou 'Terminé' peuvent être convertis en consultation.",
                                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez sélectionner un rendez-vous", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la sélection: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectionnerRendezVous();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmSelectionRendezVous_Load(object sender, EventArgs e)
        {
            // Laisser vide ou initialisation supplémentaire
        }
    }
}