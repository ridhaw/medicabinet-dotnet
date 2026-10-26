using MediCabinet.Models;
using MediCabinet.Models.ADO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediCabinet.Views.Forms
{
    public partial class frmSelectionPatient : Form
    {
        private readonly PatientADO _patientADO;
        public Patient PatientSelectionne { get; private set; }

        private TextBox txtRecherche;
        private Button btnRechercher;
        private Button btnSelect;
        private Button btnAnnuler;
        private DataGridView dgvPatients;
        private Panel panelHeader;
        private Label lblTitre;
        public frmSelectionPatient()
        {
            InitializeComponent();
            _patientADO = new PatientADO();
            PatientSelectionne = null;
            InitialiserForm();
        }

        private void InitialiserForm()
        {
            this.Size = new Size(800, 600);
            this.Text = "Sélectionner un Patient";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Panel Header
            panelHeader = new Panel();
            panelHeader.BackColor = Color.FromArgb(0, 102, 204);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 70;

            lblTitre = new Label();
            lblTitre.Text = "🔍 Sélectionner un Patient";
            lblTitre.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitre.ForeColor = Color.White;
            lblTitre.Location = new Point(20, 15);
            lblTitre.AutoSize = true;

            panelHeader.Controls.Add(lblTitre);

            // Recherche
            Panel panelRecherche = new Panel();
            panelRecherche.Dock = DockStyle.Top;
            panelRecherche.Height = 60;
            panelRecherche.Padding = new Padding(10);

            Label lblRecherche = new Label();
            lblRecherche.Text = "Recherche :";
            lblRecherche.Location = new Point(10, 20);
            lblRecherche.AutoSize = true;

            txtRecherche = new TextBox();
            txtRecherche.Location = new Point(100, 15);
            txtRecherche.Size = new Size(400, 30);
            txtRecherche.Font = new Font("Segoe UI", 10F);

            btnRechercher = new Button();
            btnRechercher.Text = "🔍 Rechercher";
            btnRechercher.BackColor = Color.FromArgb(0, 102, 204);
            btnRechercher.ForeColor = Color.White;
            btnRechercher.FlatStyle = FlatStyle.Flat;
            btnRechercher.Location = new Point(510, 15);
            btnRechercher.Size = new Size(120, 30);
            btnRechercher.Click += btnRechercher_Click;

            panelRecherche.Controls.Add(lblRecherche);
            panelRecherche.Controls.Add(txtRecherche);
            panelRecherche.Controls.Add(btnRechercher);

            // DataGridView
            dgvPatients = new DataGridView();
            dgvPatients.Dock = DockStyle.Fill;
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatients.MultiSelect = false;
            dgvPatients.RowHeadersVisible = false;
            dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPatients.ReadOnly = true;
            dgvPatients.CellDoubleClick += dgvPatients_CellDoubleClick;

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
            btnSelect.Location = new Point(400, 15);
            btnSelect.Click += btnSelect_Click;

            btnAnnuler = new Button();
            btnAnnuler.Text = "❌ Annuler";
            btnAnnuler.BackColor = Color.FromArgb(158, 158, 158);
            btnAnnuler.ForeColor = Color.White;
            btnAnnuler.FlatStyle = FlatStyle.Flat;
            btnAnnuler.Size = new Size(150, 40);
            btnAnnuler.Location = new Point(560, 15);
            btnAnnuler.Click += btnAnnuler_Click;

            panelBoutons.Controls.Add(btnSelect);
            panelBoutons.Controls.Add(btnAnnuler);

            // Ajouter les contrôles
            this.Controls.Add(dgvPatients);
            this.Controls.Add(panelRecherche);
            this.Controls.Add(panelBoutons);
            this.Controls.Add(panelHeader);

            ChargerPatients();
        }
        private void ChargerPatients(string recherche = "")
        {
            try
            {
                List<Patient> patients;
                if (string.IsNullOrWhiteSpace(recherche))
                {
                    patients = _patientADO.GetAllPatients();
                }
                else
                {
                    patients = _patientADO.SearchPatients(recherche);
                }

                dgvPatients.DataSource = patients.Select(p => new
                {
                    p.Id,
                    p.Nom,
                    p.Prenom,
                    DateNaissance = p.DateNaissance.ToString("dd/MM/yyyy"),
                    p.Telephone,
                    p.Email,
                    Age = CalculateAge(p.DateNaissance)
                }).ToList();

                // Formater les colonnes
                if (dgvPatients.Columns.Count > 0)
                {
                    dgvPatients.Columns["Id"].Visible = false;
                    dgvPatients.Columns["Nom"].HeaderText = "Nom";
                    dgvPatients.Columns["Prenom"].HeaderText = "Prénom";
                    dgvPatients.Columns["DateNaissance"].HeaderText = "Naissance";
                    dgvPatients.Columns["Age"].HeaderText = "Âge";
                    dgvPatients.Columns["Telephone"].HeaderText = "Téléphone";
                    dgvPatients.Columns["Email"].HeaderText = "Email";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int CalculateAge(DateTime dateNaissance)
        {
            var today = DateTime.Today;
            var age = today.Year - dateNaissance.Year;
            if (dateNaissance.Date > today.AddYears(-age)) age--;
            return age;
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            ChargerPatients(txtRecherche.Text);
        }

        private void dgvPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectionnerPatient();
            }
        }

        private void SelectionnerPatient()
        {
            if (dgvPatients.SelectedRows.Count > 0)
            {
                var selectedRow = dgvPatients.SelectedRows[0];
                int patientId = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                PatientSelectionne = _patientADO.GetPatientById(patientId);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un patient", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectionnerPatient();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void frmSelectionPatient_Load(object sender, EventArgs e)
        {

        }
    }
}
