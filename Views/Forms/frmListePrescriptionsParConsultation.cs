using MediCabinet.Controllers;
using MediCabinet.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MediCabinet.Views.Forms
{
    public partial class frmListePrescriptionsParConsultation : Form
    {
        private readonly PrescriptionController _prescriptionController;
        private readonly ConsultationController _consultationController;
        private int _consultationId;
        private List<Prescription> _prescriptions;

        public frmListePrescriptionsParConsultation(int consultationId)
        {
            _prescriptionController = new PrescriptionController();
            _consultationController = new ConsultationController();
            _consultationId = consultationId;
            _prescriptions = new List<Prescription>();

            InitializeInterface();
            ChargerDonnees();
        }

        private void InitializeInterface()
        {
            this.Text = $"Prescriptions - Consultation #{_consultationId}";
            this.Size = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.White;

            // En-tête
            var panelHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = Color.FromArgb(0, 123, 255)
            };

            var lblTitre = new Label
            {
                Text = $"Prescriptions - Consultation #{_consultationId}",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 20),
                AutoSize = true
            };
            panelHeader.Controls.Add(lblTitre);

            // Information sur la consultation
            var lblInfoConsultation = new Label
            {
                Location = new Point(20, 80),
                Size = new Size(750, 40),
                AutoSize = true
            };
            this.Controls.Add(lblInfoConsultation);
            _lblInfoConsultation = lblInfoConsultation;

            // DataGridView pour les prescriptions
            var dgvPrescriptions = new DataGridView
            {
                Location = new Point(20, 130),
                Size = new Size(740, 280),
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                RowHeadersVisible = false
            };

            // Configurer les colonnes
            dgvPrescriptions.Columns.Add("Id", "ID");
            dgvPrescriptions.Columns.Add("Medicament", "Médicament");
            dgvPrescriptions.Columns.Add("Dosage", "Dosage");
            dgvPrescriptions.Columns.Add("Posologie", "Posologie");
            dgvPrescriptions.Columns.Add("DateDebut", "Date début");
            dgvPrescriptions.Columns.Add("DateFin", "Date fin");
            dgvPrescriptions.Columns.Add("Renouvellements", "Renouv.");

            dgvPrescriptions.Columns["Id"].Visible = false;
            dgvPrescriptions.Columns["Medicament"].Width = 200;
            dgvPrescriptions.Columns["Dosage"].Width = 100;
            dgvPrescriptions.Columns["Posologie"].Width = 200;
            dgvPrescriptions.Columns["DateDebut"].Width = 100;
            dgvPrescriptions.Columns["DateFin"].Width = 100;
            dgvPrescriptions.Columns["Renouvellements"].Width = 70;

            dgvPrescriptions.CellDoubleClick += DgvPrescriptions_CellDoubleClick;
            this.Controls.Add(dgvPrescriptions);
            _dgvPrescriptions = dgvPrescriptions;

            // Label pour message "pas de prescription"
            var lblAucunePrescription = new Label
            {
                Text = "Aucune prescription n'a été créée pour cette consultation.",
                Font = new Font("Segoe UI", 11, FontStyle.Italic),
                ForeColor = Color.Gray,
                Location = new Point(20, 200),
                Size = new Size(740, 30),
                TextAlign = ContentAlignment.MiddleCenter,
                Visible = false
            };
            this.Controls.Add(lblAucunePrescription);
            _lblAucunePrescription = lblAucunePrescription;

            // Boutons
            var panelBoutons = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                BackColor = SystemColors.Control
            };

            var btnVoirDetail = new Button
            {
                Text = "Voir Détail",
                Size = new Size(120, 35),
                Location = new Point(20, 10),
                BackColor = Color.FromArgb(0, 123, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnVoirDetail.Click += BtnVoirDetail_Click;

            var btnImprimer = new Button
            {
                Text = "Imprimer",
                Size = new Size(120, 35),
                Location = new Point(150, 10),
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnImprimer.Click += BtnImprimer_Click;

            var btnFermer = new Button
            {
                Text = "Fermer",
                Size = new Size(120, 35),
                Location = new Point(640, 10),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnFermer.Click += (s, e) => this.Close();

            panelBoutons.Controls.AddRange(new Control[] { btnVoirDetail, btnImprimer, btnFermer });

            // Ajouter les panels au formulaire
            this.Controls.AddRange(new Control[] { panelHeader, panelBoutons });
        }

        private Label _lblInfoConsultation;
        private DataGridView _dgvPrescriptions;
        private Label _lblAucunePrescription;

        private void ChargerDonnees()
        {
            try
            {
                // Récupérer les informations de la consultation
                var consultationResult = _consultationController.GetConsultationParId(_consultationId);
                if (consultationResult.Success && consultationResult.Data != null)
                {
                    var consultation = consultationResult.Data as Consultation;
                    if (consultation != null)
                    {
                        _lblInfoConsultation.Text =
                            $"Date: {consultation.DateConsultation:dd/MM/yyyy HH:mm} | " +
                            $"Motif: {consultation.MotifConsultation} | " +
                            $"Diagnostic: {consultation.Diagnostic ?? "Non spécifié"}";
                    }
                }

                // Récupérer les prescriptions
                var prescriptionResult = _prescriptionController.GetPrescriptionsParConsultation(_consultationId);
                if (prescriptionResult.Success && prescriptionResult.Data != null)
                {
                    _prescriptions = prescriptionResult.Data;

                    if (_prescriptions.Count > 0)
                    {
                        // Afficher les prescriptions dans le DataGridView
                        AfficherPrescriptions();
                        _lblAucunePrescription.Visible = false;
                        _dgvPrescriptions.Visible = true;
                    }
                    else
                    {
                        // Aucune prescription
                        _lblAucunePrescription.Visible = true;
                        _dgvPrescriptions.Visible = false;
                    }
                }
                else
                {
                    // Erreur ou aucune prescription
                    _lblAucunePrescription.Visible = true;
                    _dgvPrescriptions.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur chargement données: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AfficherPrescriptions()
        {
            _dgvPrescriptions.Rows.Clear();

            foreach (var prescription in _prescriptions)
            {
                _dgvPrescriptions.Rows.Add(
                    prescription.Id,
                    prescription.NomMedicament,
                    prescription.Dosage,
                    prescription.Posologie,
                    prescription.DateDebut.ToString("dd/MM/yyyy"),
                    prescription.DateFin?.ToString("dd/MM/yyyy") ?? "",
                    prescription.Renouvellements
                );
            }
        }

        private void DgvPrescriptions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                VoirDetailPrescription(e.RowIndex);
            }
        }

        private void BtnVoirDetail_Click(object sender, EventArgs e)
        {
            if (_dgvPrescriptions.SelectedRows.Count > 0)
            {
                VoirDetailPrescription(_dgvPrescriptions.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une prescription", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void VoirDetailPrescription(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < _prescriptions.Count)
            {
                var prescription = _prescriptions[rowIndex];
                using (var form = new frmDetailPrescription(prescription.Id))
                {
                    form.ShowDialog();
                }
            }
        }

        private void BtnImprimer_Click(object sender, EventArgs e)
        {
            if (_prescriptions.Count == 0)
            {
                MessageBox.Show("Aucune prescription à imprimer", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Ici vous pouvez implémenter l'impression
            // Par exemple, générer un PDF avec toutes les prescriptions
            MessageBox.Show("Fonction d'impression à implémenter", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}