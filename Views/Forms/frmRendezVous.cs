using MediCabinet.Controllers;
using MediCabinet.Models;
using MediCabinet.Models.ADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MediCabinet.Views.Forms
{
    public partial class frmRendezVous : Form
    {
        private readonly RendezVousController _rdvController;
        private readonly PatientADO _patientADO;
        private readonly UtilisateurADO _utilisateurADO;
        private List<RendezVous> _rendezVousList;
        private RendezVous _currentRdv;
        private bool _isNew;

        public frmRendezVous()
        {
            InitializeComponent();
            _rdvController = new RendezVousController();
            _patientADO = new PatientADO();
            _utilisateurADO = new UtilisateurADO();
            _rendezVousList = new List<RendezVous>();
            _currentRdv = new RendezVous();
            _isNew = true;
        }

        private void frmRendezVous_Load(object sender, EventArgs e)
        {
            LoadCombos();
            LoadRendezVousAujourdhui();
            SetFormState();
        }

        private void LoadCombos()
        {
            try
            {
                // Charger les patients actifs
                var patients = _patientADO.GetAllPatients();
                cmbPatient.DataSource = patients;
                cmbPatient.DisplayMember = "NomComplet";
                cmbPatient.ValueMember = "Id";

                // Charger les médecins
                var medecins = _utilisateurADO.GetMedecins();
                cmbMedecin.DataSource = medecins;
                cmbMedecin.DisplayMember = "NomComplet";
                cmbMedecin.ValueMember = "Id";

                // Charger pour la recherche
                cmbMedecinRecherche.DataSource = new List<Utilisateur>(medecins);
                cmbMedecinRecherche.DisplayMember = "NomComplet";
                cmbMedecinRecherche.ValueMember = "Id";

                // Ajouter option "Tous les médecins"
                var tousMedecins = new List<Utilisateur> { new Utilisateur { Id = 0, Nom = "Tous", Prenom = "les médecins" } };
                tousMedecins.AddRange(medecins);
                cmbMedecinRecherche.DataSource = tousMedecins;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des données: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRendezVousAujourdhui()
        {
            dtpDateRecherche.Value = DateTime.Today;
            cmbMedecinRecherche.SelectedIndex = 0;
            LoadRendezVous(DateTime.Today, null);
        }

        private void LoadRendezVous(DateTime date, int? medecinId)
        {
            try
            {
                _rendezVousList = _rdvController.GetRendezVousParDate(date, medecinId);
                BindDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindDataGridView()
        {
            dgvRendezVous.DataSource = null;

            if (_rendezVousList.Count > 0)
            {
                var dataTable = new DataTable();
                dataTable.Columns.Add("ID", typeof(int));
                dataTable.Columns.Add("Patient", typeof(string));
                dataTable.Columns.Add("Médecin", typeof(string));
                dataTable.Columns.Add("Date", typeof(DateTime));
                dataTable.Columns.Add("Heure", typeof(string));
                dataTable.Columns.Add("Type", typeof(string));
                dataTable.Columns.Add("Motif", typeof(string));
                dataTable.Columns.Add("Statut", typeof(string));
                dataTable.Columns.Add("Priorité", typeof(string));

                foreach (var rdv in _rendezVousList.OrderBy(r => r.DateRendezVous).ThenBy(r => r.HeureDebut))
                {
                    string heure = $"{rdv.HeureDebut:hh\\:mm} - {rdv.HeureFin:hh\\:mm}";
                    dataTable.Rows.Add(
                        rdv.Id,
                        rdv.NomPatient,
                        rdv.NomMedecin,
                        rdv.DateRendezVous,
                        heure,
                        rdv.TypeConsultation,
                        rdv.Motif.Length > 30 ? rdv.Motif.Substring(0, 30) + "..." : rdv.Motif,
                        rdv.Statut,
                        rdv.Priorite
                    );
                }

                dgvRendezVous.DataSource = dataTable;
                FormatDataGridView();
            }
        }

        private void FormatDataGridView()
        {
            if (dgvRendezVous.Columns.Count > 0)
            {
                dgvRendezVous.Columns["ID"].Width = 40;
                dgvRendezVous.Columns["Patient"].Width = 120;
                dgvRendezVous.Columns["Médecin"].Width = 120;
                dgvRendezVous.Columns["Date"].Width = 70;
                dgvRendezVous.Columns["Heure"].Width = 80;
                dgvRendezVous.Columns["Type"].Width = 100;
                dgvRendezVous.Columns["Motif"].Width = 150;
                dgvRendezVous.Columns["Statut"].Width = 70;
                dgvRendezVous.Columns["Priorité"].Width = 70;

                dgvRendezVous.Columns["Date"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }

        private void ClearForm()
        {
            _currentRdv = new RendezVous();
            _isNew = true;

            if (cmbPatient.Items.Count > 0) cmbPatient.SelectedIndex = 0;
            if (cmbMedecin.Items.Count > 0) cmbMedecin.SelectedIndex = 0;

            dtpDateRDV.Value = DateTime.Today;
            dtpHeureDebut.Value = DateTime.Today.Date.AddHours(9);
            dtpHeureFin.Value = DateTime.Today.Date.AddHours(9).AddMinutes(30);
            cmbTypeConsultation.Text = "Consultation générale";
            txtMotif.Text = string.Empty;
            cmbStatut.SelectedIndex = 0;
            cmbPriorite.SelectedIndex = 0;
            txtNotes.Text = string.Empty;

            lblId.Text = "ID: Nouveau";
        }

        private void LoadRdvDetails(RendezVous rdv)
        {
            if (rdv != null)
            {
                _currentRdv = rdv;
                _isNew = false;

                lblId.Text = $"ID: {rdv.Id}";

                cmbPatient.SelectedValue = rdv.PatientId;
                cmbMedecin.SelectedValue = rdv.MedecinId;
                dtpDateRDV.Value = rdv.DateRendezVous;
                dtpHeureDebut.Value = DateTime.Today.Date.Add(rdv.HeureDebut);
                dtpHeureFin.Value = DateTime.Today.Date.Add(rdv.HeureFin);
                cmbTypeConsultation.Text = rdv.TypeConsultation;
                txtMotif.Text = rdv.Motif;
                cmbStatut.Text = rdv.Statut;
                cmbPriorite.Text = rdv.Priorite;
                txtNotes.Text = rdv.Notes;
            }
        }

        private void SetFormState()
        {
            bool isExisting = !_isNew;

            btnEnregistrer.Text = _isNew ? "Ajouter" : "Modifier";
            btnSupprimer.Enabled = isExisting;
            btnAnnuler.Enabled = isExisting;
        }

        private RendezVous GetFormData()
        {
            return new RendezVous
            {
                Id = _currentRdv.Id,
                PatientId = Convert.ToInt32(cmbPatient.SelectedValue),
                MedecinId = Convert.ToInt32(cmbMedecin.SelectedValue),
                DateRendezVous = dtpDateRDV.Value.Date,
                HeureDebut = dtpHeureDebut.Value.TimeOfDay,
                HeureFin = dtpHeureFin.Value.TimeOfDay,
                TypeConsultation = cmbTypeConsultation.Text,
                Motif = txtMotif.Text.Trim(),
                Statut = cmbStatut.Text,
                Priorite = cmbPriorite.Text,
                Notes = txtNotes.Text.Trim()
            };
        }

        private bool ValidateForm()
        {
            if (cmbPatient.SelectedValue == null || Convert.ToInt32(cmbPatient.SelectedValue) <= 0)
            {
                MessageBox.Show("Veuillez sélectionner un patient", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbMedecin.SelectedValue == null || Convert.ToInt32(cmbMedecin.SelectedValue) <= 0)
            {
                MessageBox.Show("Veuillez sélectionner un médecin", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpDateRDV.Value < DateTime.Today)
            {
                MessageBox.Show("La date ne peut pas être dans le passé", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpHeureFin.Value.TimeOfDay <= dtpHeureDebut.Value.TimeOfDay)
            {
                MessageBox.Show("L'heure de fin doit être après l'heure de début", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMotif.Text))
            {
                MessageBox.Show("Veuillez saisir un motif", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // Événements
        private void btnRechercher_Click(object sender, EventArgs e)
        {
            DateTime date = dtpDateRecherche.Value.Date;
            int? medecinId = null;

            if (cmbMedecinRecherche.SelectedValue != null && Convert.ToInt32(cmbMedecinRecherche.SelectedValue) > 0)
            {
                medecinId = Convert.ToInt32(cmbMedecinRecherche.SelectedValue);
            }

            LoadRendezVous(date, medecinId);
        }

        private void btnAujourdhui_Click(object sender, EventArgs e)
        {
            LoadRendezVousAujourdhui();
        }

        private void btnTous_Click(object sender, EventArgs e)
        {
            try
            {
                var result = _rdvController.GetRendezVousParDate(DateTime.Today.AddDays(-30), null);
                _rendezVousList = result.Where(r => r.DateRendezVous >= DateTime.Today.AddDays(-30)).ToList();
                BindDataGridView();

                dtpDateRecherche.Value = DateTime.Today;
                cmbMedecinRecherche.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRendezVous_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRendezVous.SelectedRows.Count > 0)
            {
                var selectedRow = dgvRendezVous.SelectedRows[0];
                if (selectedRow.Cells["ID"].Value != DBNull.Value)
                {
                    int rdvId = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                    var rdv = _rendezVousList.FirstOrDefault(r => r.Id == rdvId);
                    if (rdv != null)
                    {
                        LoadRdvDetails(rdv);
                        SetFormState();
                    }
                }
            }
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            ClearForm();
            SetFormState();
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                var rdv = GetFormData();
                var result = _isNew ?
                    _rdvController.AjouterRendezVous(rdv) :
                    _rdvController.ModifierRendezVous(rdv);

                if (result.Success)
                {
                    MessageBox.Show(result.Message, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recharger la liste
                    LoadRendezVous(dtpDateRecherche.Value.Date,
                        cmbMedecinRecherche.SelectedValue != null && Convert.ToInt32(cmbMedecinRecherche.SelectedValue) > 0 ?
                        Convert.ToInt32(cmbMedecinRecherche.SelectedValue) : (int?)null);

                    ClearForm();
                }
                else
                {
                    MessageBox.Show(result.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (_currentRdv == null || _currentRdv.Id <= 0)
            {
                MessageBox.Show("Aucun rendez-vous sélectionné", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Voulez-vous vraiment supprimer ce rendez-vous?", "Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var result = _rdvController.AnnulerRendezVous(_currentRdv.Id, "Supprimé par l'utilisateur");

                    if (result.Success)
                    {
                        MessageBox.Show("Rendez-vous supprimé avec succès", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Recharger la liste
                        LoadRendezVous(dtpDateRecherche.Value.Date,
                            cmbMedecinRecherche.SelectedValue != null && Convert.ToInt32(cmbMedecinRecherche.SelectedValue) > 0 ?
                            Convert.ToInt32(cmbMedecinRecherche.SelectedValue) : (int?)null);

                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show(result.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            if (_currentRdv == null || _currentRdv.Id <= 0)
            {
                MessageBox.Show("Aucun rendez-vous sélectionné", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Voulez-vous annuler ce rendez-vous?", "Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var result = _rdvController.AnnulerRendezVous(_currentRdv.Id, "Annulé par l'utilisateur");

                    if (result.Success)
                    {
                        MessageBox.Show("Rendez-vous annulé avec succès", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Recharger la liste
                        LoadRendezVous(dtpDateRecherche.Value.Date,
                            cmbMedecinRecherche.SelectedValue != null && Convert.ToInt32(cmbMedecinRecherche.SelectedValue) > 0 ?
                            Convert.ToInt32(cmbMedecinRecherche.SelectedValue) : (int?)null);

                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show(result.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvRendezVous_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gbRecherche_Enter(object sender, EventArgs e)
        {

        }
    }
}