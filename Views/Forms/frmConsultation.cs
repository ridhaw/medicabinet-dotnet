using MediCabinet.Controllers;
using MediCabinet.Models;
using MediCabinet.Models.ADO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MediCabinet.Views.Forms
{
    public partial class frmConsultation : Form
    {
        private readonly ConsultationController _consultationController;
        private readonly RendezVousController _rendezVousController;
        private readonly PatientADO _patientADO;
        private readonly UtilisateurController _utilisateurController;

        private Consultation _currentConsultation;
        private List<RendezVous> _rendezVousDisponibles;
        private List<Patient> _patientsList;
        private bool    _isNouvelleConsultation;

        public frmConsultation(int? patientId = null, int? rendezVousId = null)
        {
            InitializeComponent();
            _consultationController = new ConsultationController();
            _rendezVousController = new RendezVousController();
            _patientADO = new PatientADO();
            _utilisateurController = new UtilisateurController();

            _currentConsultation = new Consultation();
            _rendezVousDisponibles = new List<RendezVous>();
            _patientsList = new List<Patient>();
            //_isNouvelleConsultation = true;

            InitialiserForm(patientId, rendezVousId);

            // Initialiser les boutons supplémentaires si vous avez un panelOutils
            // Si vous n'avez pas panelOutils, commentez ou supprimez cette ligne
            // InitialiserBoutonsSupplementaires();
        }

        private void InitialiserForm(int? patientId, int? rendezVousId)
        {
            // Charger les médecins
            ChargerMedecins();

            // Si un patient est spécifié
            if (patientId.HasValue)
            {
                ChargerPatient(patientId.Value);
            }

            // Si un rendez-vous est spécifié
            if (rendezVousId.HasValue)
            {
                ChargerRendezVous(rendezVousId.Value);
            }

            // Configuration initiale
            dtpDateConsultation.Value = DateTime.Now;
            ClearValidation();
        }

        private void ChargerPatient(int patientId)
        {
            try
            {
                var patient = _patientADO.GetPatientById(patientId);
                if (patient != null)
                {
                    txtPatientId.Text = patient.Id.ToString();
                    txtNomPatient.Text = $"{patient.Nom} {patient.Prenom}";
                    _currentConsultation.PatientId = patient.Id;

                    // Charger les consultations précédentes
                    ChargerHistoriqueConsultations(patient.Id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur chargement patient: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChargerMedecins()
        {
            try
            {
                var medecins = _utilisateurController.RechercherUtilisateurs("", "Medecin")
                    .Where(u => u.EstActif)
                    .ToList();

                cmbMedecin.DataSource = null;
                cmbMedecin.DisplayMember = "NomComplet";
                cmbMedecin.ValueMember = "Id";
                cmbMedecin.DataSource = medecins;

                if (medecins.Count > 0)
                {
                    _currentConsultation.MedecinId = medecins[0].Id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur chargement médecins: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChargerRendezVous(int rendezVousId)
        {
            try
            {
                var rdv = _rendezVousController.GetRendezVousParDate(DateTime.Today)
                    .FirstOrDefault(r => r.Id == rendezVousId);

                if (rdv != null)
                {
                    _currentConsultation.RendezVousId = rdv.Id;
                    _currentConsultation.PatientId = rdv.PatientId;
                    _currentConsultation.MedecinId = rdv.MedecinId;
                    _currentConsultation.MotifConsultation = rdv.Motif;

                    txtPatientId.Text = rdv.PatientId.ToString();
                    txtNomPatient.Text = rdv.NomPatient;
                    cmbMedecin.SelectedValue = rdv.MedecinId;

                    ChargerHistoriqueConsultations(rdv.PatientId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur chargement rendez-vous: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChargerHistoriqueConsultations(int patientId)
        {
            try
            {
                var result = _consultationController.GetConsultationsParPatient(patientId);
                if (result.Success && result.Data is List<Consultation> consultations)
                {
                    dgvHistorique.DataSource = null;
                    dgvHistorique.DataSource = consultations.Select(c => new
                    {
                        c.Id,
                        Date = c.DateConsultation.ToString("dd/MM/yyyy HH:mm"),
                        Medecin = "Dr. " + c.MedecinId,
                        Diagnostic = c.Diagnostic ?? "Non spécifié",
                        Motif = c.MotifConsultation
                    }).ToList();

                    dgvHistorique.Columns["Id"].Visible = false;
                    FormatDataGridView();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur historique: {ex.Message}");
            }
        }

        private void FormatDataGridView()
        {
            if (dgvHistorique.Columns.Count > 0)
            {
                dgvHistorique.Columns["Date"].Width = 120;
                dgvHistorique.Columns["Medecin"].Width = 150;
                dgvHistorique.Columns["Diagnostic"].Width = 200;
                dgvHistorique.Columns["Motif"].Width = 200;
            }
        }

        // Validation
        private bool ValiderFormulaire()
        {
            ClearValidation();

            bool isValid = true;

            // Validation patient
            if (_currentConsultation.PatientId <= 0)
            {
                txtNomPatient.BackColor = Color.LightPink;
                isValid = false;
            }

            // Validation médecin
            if (_currentConsultation.MedecinId <= 0)
            {
                cmbMedecin.BackColor = Color.LightPink;
                isValid = false;
            }

            // Validation motif
            if (string.IsNullOrWhiteSpace(txtMotif.Text))
            {
                txtMotif.BackColor = Color.LightPink;
                isValid = false;
            }

            if (!isValid)
            {
                MessageBox.Show("Veuillez remplir tous les champs obligatoires (marqués en rouge)",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isValid;
        }

        private void ClearValidation()
        {
            txtNomPatient.BackColor = SystemColors.Window;
            cmbMedecin.BackColor = SystemColors.Window;
            txtMotif.BackColor = SystemColors.Window;
        }

        // Événements
        private void btnRechercherPatient_Click(object sender, EventArgs e)
        {
            using (var form = new frmSelectionPatient())
            {
                if (form.ShowDialog() == DialogResult.OK && form.PatientSelectionne != null)
                {
                    ChargerPatient(form.PatientSelectionne.Id);
                }
            }
        }

        private void btnRechercherRendezVous_Click(object sender, EventArgs e)
        {
            using (var form = new frmSelectionRendezVous())
            {
                if (form.ShowDialog() == DialogResult.OK && form.RendezVousSelectionne != null)
                {
                    ChargerRendezVous(form.RendezVousSelectionne.Id);
                }
            }
        }

        private void cmbMedecin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMedecin.SelectedValue != null && int.TryParse(cmbMedecin.SelectedValue.ToString(), out int medecinId))
            {
                _currentConsultation.MedecinId = medecinId;
            }
        }

        private void txtMotif_TextChanged(object sender, EventArgs e)
        {
            _currentConsultation.MotifConsultation = txtMotif.Text;
        }

        private void txtObservations_TextChanged(object sender, EventArgs e)
        {
            _currentConsultation.Observations = txtObservations.Text;
        }

        private void txtDiagnostic_TextChanged(object sender, EventArgs e)
        {
            _currentConsultation.Diagnostic = txtDiagnostic.Text;
        }

        private void txtTraitement_TextChanged(object sender, EventArgs e)
        {
            _currentConsultation.TraitementPrescrit = txtTraitement.Text;
        }

        private void txtRecommandations_TextChanged(object sender, EventArgs e)
        {
            _currentConsultation.Recommandations = txtRecommandations.Text;
        }

        private void numPoids_ValueChanged(object sender, EventArgs e)
        {
            _currentConsultation.Poids = numPoids.Value > 0 ? (decimal?)numPoids.Value : null;
            CalculerIMC();
        }

        private void numTaille_ValueChanged(object sender, EventArgs e)
        {
            _currentConsultation.Taille = numTaille.Value > 0 ? (decimal?)numTaille.Value / 100 : null; // Convertir cm en m
            CalculerIMC();
        }

        private void dgvHistorique_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvHistorique.Rows[e.RowIndex].DataBoundItem != null)
            {
                // Récupérer l'ID de la consultation sélectionnée
                var consultationId = Convert.ToInt32(dgvHistorique.Rows[e.RowIndex].Cells["Id"].Value);

                // Vérifier s'il y a des prescriptions pour cette consultation
                VoirPrescriptionsConsultation(consultationId);
            }
        }
        private void VoirPrescriptionsConsultation(int consultationId)
        {
            try
            {
                // Créer le contrôleur de prescriptions
                var prescriptionController = new PrescriptionController();

                // Récupérer les prescriptions de cette consultation
                var result = prescriptionController.GetPrescriptionsParConsultation(consultationId);

                if (result.Success && result.Data != null && result.Data.Count > 0)
                {
                    // Il y a des prescriptions, afficher la liste
                    using (var form = new frmListePrescriptionsParConsultation(consultationId))
                    {
                        form.ShowDialog();
                    }
                }
                else
                {
                    // Aucune prescription trouvée
                    MessageBox.Show("Aucune prescription n'a été créée pour cette consultation.",
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CalculerIMC()
        {
            if (_currentConsultation.IMC.HasValue)
            {
                lblIMC.Text = $"IMC: {_currentConsultation.IMC.Value:F2}";

                // Colorer selon la catégorie IMC
                var imc = _currentConsultation.IMC.Value;
                if (imc < 18.5m)
                    lblIMC.ForeColor = Color.Blue; // Maigreur
                else if (imc < 25m)
                    lblIMC.ForeColor = Color.Green; // Normal
                else if (imc < 30m)
                    lblIMC.ForeColor = Color.Orange; // Surpoids
                else
                    lblIMC.ForeColor = Color.Red; // Obésité
            }
            else
            {
                lblIMC.Text = "IMC: N/A";
                lblIMC.ForeColor = SystemColors.ControlText;
            }
        }

        private void btnSauvegarder_Click(object sender, EventArgs e)
        {
            if (!ValiderFormulaire())
                return;

            try
            {
                // Mettre à jour les données de la consultation
                _currentConsultation.DateConsultation = dtpDateConsultation.Value;
                _currentConsultation.Temperature = numTemperature.Value > 0 ? (decimal?)numTemperature.Value : null;
                _currentConsultation.PressionArterielle = txtPressionArterielle.Text;
                _currentConsultation.Pouls = numPouls.Value > 0 ? (int?)numPouls.Value : null;
                _currentConsultation.CodeCIM10 = txtCodeCIM10.Text;
                _currentConsultation.DateProchaineVisite = chkProchaineVisite.Checked ? dtpProchaineVisite.Value : (DateTime?)null;

                // Sauvegarder
                var result = _consultationController.CreerConsultation(_currentConsultation);

                if (result.Success)
                {
                    int consultationId = result.Data != null && result.Data is int id ? id : _currentConsultation.Id;

                    MessageBox.Show("Consultation enregistrée avec succès!", "Succès",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Optionnel: Ouvrir la prescription
                    if (MessageBox.Show("Voulez-vous créer une prescription?", "Prescription",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (var prescriptionForm = new frmPrescription(consultationId))
                        {
                            prescriptionForm.ShowDialog();
                        }
                    }

                    // Préparer pour une nouvelle consultation avec le même patient
                    PreparerNouvelleConsultation();
                }
                else
                {
                    MessageBox.Show(result.Message, "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreparerNouvelleConsultation()
        {
            // Conserver le patient
            int patientId = _currentConsultation.PatientId;
            string nomPatient = txtNomPatient.Text;

            // Réinitialiser la consultation
            _currentConsultation = new Consultation();
            _currentConsultation.PatientId = patientId;

            // Réinitialiser les champs
            txtMotif.Clear();
            txtObservations.Clear();
            txtDiagnostic.Clear();
            txtTraitement.Clear();
            txtRecommandations.Clear();
            txtCodeCIM10.Clear();
            txtPressionArterielle.Clear();

            numPoids.Value = 0;
            numTaille.Value = 0;
            numTemperature.Value = 0;
            numPouls.Value = 0;

            dtpDateConsultation.Value = DateTime.Now;
            chkProchaineVisite.Checked = false;
            dtpProchaineVisite.Enabled = false;

            // Garder le patient
            if (patientId > 0)
            {
                txtPatientId.Text = patientId.ToString();
                txtNomPatient.Text = nomPatient;
                ChargerHistoriqueConsultations(patientId);
            }

            ClearValidation();
            txtMotif.Focus();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            // Implémentation de l'impression du compte rendu
            MessageBox.Show("Fonction d'impression à implémenter", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void chkProchaineVisite_CheckedChanged(object sender, EventArgs e)
        {
            dtpProchaineVisite.Enabled = chkProchaineVisite.Checked;
        }

        private void numTemperature_ValueChanged(object sender, EventArgs e)
        {
            _currentConsultation.Temperature = numTemperature.Value > 0 ? (decimal?)numTemperature.Value : null;
        }

        private void numPouls_ValueChanged(object sender, EventArgs e)
        {
            _currentConsultation.Pouls = numPouls.Value > 0 ? (int?)numPouls.Value : null;
        }

        private void frmConsultation_Load(object sender, EventArgs e)
        {
            // Code de chargement si nécessaire
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {
            // Code de peinture si nécessaire
        }

        // ========== MÉTHODES OPTIONNELLES ==========
        // Si vous avez un panelOutils dans votre formulaire, décommentez ces méthodes

        /*
        private void InitialiserBoutonsSupplementaires()
        {
            // Créer un panel si nécessaire
            if (panelOutils == null)
            {
                panelOutils = new Panel
                {
                    Dock = DockStyle.Bottom,
                    Height = 50,
                    BackColor = SystemColors.Control
                };
                this.Controls.Add(panelOutils);
                panelOutils.BringToFront();
            }

            var btnVoirPrescriptions = new Button
            {
                Text = "Voir Prescriptions",
                Size = new Size(140, 35),
                Location = new Point(btnImprimer.Right + 10, 10)
            };
            btnVoirPrescriptions.Click += BtnVoirPrescriptions_Click;
            panelOutils.Controls.Add(btnVoirPrescriptions);
        }

        private void BtnVoirPrescriptions_Click(object sender, EventArgs e)
        {
            if (_currentConsultation.PatientId <= 0)
            {
                MessageBox.Show("Veuillez sélectionner un patient", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Créer d'abord frmListePrescriptions
            // using (var form = new frmListePrescriptions(_currentConsultation.PatientId))
            // {
            //     form.ShowDialog();
            // }
            
            MessageBox.Show("Fonctionnalité à implémenter", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        */

        // ========== GESTION DES PRESCRIPTIONS ==========
        // Méthode simplifiée pour ouvrir les prescriptions

        private void OuvrirPrescriptions()
        {
            if (_currentConsultation.PatientId > 0)
            {
                // Créez d'abord frmPrescription en lui passant le patientId
                // ou récupérez la dernière consultation
                using (var form = new frmPrescription(0)) // Passer 0 temporairement
                {
                    form.ShowDialog();
                }
            }
        }
    }
}