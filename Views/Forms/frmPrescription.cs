using MediCabinet.Controllers;
using MediCabinet.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MediCabinet.Views.Forms
{
    public partial class frmPrescription : Form
    {
        private readonly PrescriptionController _prescriptionController;
        private int _consultationId;
        private Prescription _currentPrescription;
        private List<Prescription> _prescriptionsExistant;

        public frmPrescription(int consultationId)
        {
            _prescriptionController = new PrescriptionController();
            _consultationId = consultationId;
            _currentPrescription = new Prescription();
            _prescriptionsExistant = new List<Prescription>();

            InitializeComponent(); // Supprimez cette ligne temporairement
            InitialiserInterface();
            ChargerPrescriptionsExistantes();
        }

        private void InitialiserInterface()
        {
            this.Text = "Prescription Médicale";
            this.Size = new Size(900, 700);
            this.StartPosition = FormStartPosition.CenterParent;

            // Panel header
            var panelHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = Color.FromArgb(0, 123, 255)
            };

            var lblTitre = new Label
            {
                Text = "Prescription Médicale",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 20),
                AutoSize = true
            };
            panelHeader.Controls.Add(lblTitre);

            // Panel principal avec SplitContainer
            var splitContainer = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Horizontal,
                SplitterDistance = 280
            };

            // Panel formulaire (haut)
            var panelForm = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(15)
            };

            var groupBoxForm = new GroupBox
            {
                Text = "Nouvelle Prescription",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            // Créer les contrôles du formulaire
            InitializeFormControls(groupBoxForm);

            // Panel liste (bas)
            var panelList = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(15)
            };

            var groupBoxList = new GroupBox
            {
                Text = "Prescriptions existantes",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            // DataGridView
            _dataGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            groupBoxList.Controls.Add(_dataGridView);

            panelList.Controls.Add(groupBoxList);

            // Panel boutons
            var panelBoutons = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                BackColor = SystemColors.Control,
                Padding = new Padding(10)
            };

            // Boutons
            var btnAjouter = new Button
            {
                Text = "Ajouter",
                Size = new Size(120, 40),
                Location = new Point(20, 10),
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnAjouter.Click += BtnAjouter_Click;

            var btnImprimer = new Button
            {
                Text = "Imprimer",
                Size = new Size(120, 40),
                Location = new Point(150, 10),
                BackColor = Color.FromArgb(23, 162, 184),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnImprimer.Click += BtnImprimer_Click;

            var btnFermer = new Button
            {
                Text = "Fermer",
                Size = new Size(120, 40),
                Location = new Point(744, 10),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnFermer.Click += BtnFermer_Click;

            panelBoutons.Controls.AddRange(new Control[] { btnAjouter, btnImprimer, btnFermer });

            // Assembler le formulaire
            groupBoxForm.Controls.Add(_formPanel);
            panelForm.Controls.Add(groupBoxForm);

            splitContainer.Panel1.Controls.Add(panelForm);
            splitContainer.Panel2.Controls.Add(panelList);

            this.Controls.AddRange(new Control[] { splitContainer, panelBoutons, panelHeader });
        }

        private Panel _formPanel;
        private TextBox _txtMedicament;
        private TextBox _txtDosage;
        private TextBox _txtPosologie;
        private TextBox _txtInstructions;
        private DateTimePicker _dtpDatePrescription;
        private DateTimePicker _dtpDateDebut;
        private ComboBox _cmbDuree;
        private ComboBox _cmbRenouvellements;
        private DataGridView _dataGridView;

        private void InitializeFormControls(GroupBox groupBox)
        {
            _formPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20)
            };

            int y = 40;
            int labelWidth = 150;
            int controlWidth = 200;
            int spacing = 40;

            // Médicament
            var lblMedicament = new Label
            {
                Text = "Nom du médicament:*",
                Location = new Point(30, y),
                Size = new Size(labelWidth, 20)
            };

            _txtMedicament = new TextBox
            {
                Location = new Point(30, y + 20),
                Size = new Size(380, 23)
            };

            // Dosage
            var lblDosage = new Label
            {
                Text = "Dosage:*",
                Location = new Point(450, y),
                Size = new Size(labelWidth, 20)
            };

            _txtDosage = new TextBox
            {
                Location = new Point(450, y + 20),
                Size = new Size(380, 23),
                Text = "500 mg"
            };

            y += spacing;

            // Posologie
            var lblPosologie = new Label
            {
                Text = "Posologie:*",
                Location = new Point(30, y),
                Size = new Size(labelWidth, 20)
            };

            _txtPosologie = new TextBox
            {
                Location = new Point(30, y + 20),
                Size = new Size(150, 23),
                Text = "1 comprimé matin et soir"
            };

            // Date prescription
            var lblDatePrescription = new Label
            {
                Text = "Date prescription:",
                Location = new Point(30, y + 60),
                Size = new Size(labelWidth, 20)
            };

            _dtpDatePrescription = new DateTimePicker
            {
                Location = new Point(30, y + 80),
                Size = new Size(150, 23),
                Format = DateTimePickerFormat.Short
            };

            // Date début
            var lblDateDebut = new Label
            {
                Text = "Date début:",
                Location = new Point(240, y),
                Size = new Size(labelWidth, 20)
            };

            _dtpDateDebut = new DateTimePicker
            {
                Location = new Point(240, y + 20),
                Size = new Size(150, 23),
                Format = DateTimePickerFormat.Short
            };

            // Durée
            var lblDuree = new Label
            {
                Text = "Durée (jours) - Optionnel:",
                Location = new Point(240, y + 60),
                Size = new Size(labelWidth, 20)
            };

            _cmbDuree = new ComboBox
            {
                Location = new Point(240, y + 80),
                Size = new Size(150, 23)
            };
            _cmbDuree.Items.AddRange(new object[] { 7, 14, 21, 28, 30, 60, 90 });

            // Renouvellements
            var lblRenouvellements = new Label
            {
                Text = "Renouvellements:",
                Location = new Point(450, y),
                Size = new Size(labelWidth, 20)
            };

            _cmbRenouvellements = new ComboBox
            {
                Location = new Point(450, y + 20),
                Size = new Size(150, 23),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            _cmbRenouvellements.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5" });
            _cmbRenouvellements.SelectedIndex = 0;

            // Instructions
            var lblInstructions = new Label
            {
                Text = "Instructions spéciales:",
                Location = new Point(450, y + 60),
                Size = new Size(labelWidth, 20)
            };

            _txtInstructions = new TextBox
            {
                Location = new Point(450, y + 80),
                Size = new Size(380, 60),
                Multiline = true
            };

            // Ajouter tous les contrôles au panel
            _formPanel.Controls.AddRange(new Control[]
            {
                lblMedicament, _txtMedicament,
                lblDosage, _txtDosage,
                lblPosologie, _txtPosologie,
                lblDatePrescription, _dtpDatePrescription,
                lblDateDebut, _dtpDateDebut,
                lblDuree, _cmbDuree,
                lblRenouvellements, _cmbRenouvellements,
                lblInstructions, _txtInstructions
            });
        }

        private void ChargerPrescriptionsExistantes()
        {
            try
            {
                var result = _prescriptionController.GetPrescriptionsParConsultation(_consultationId);
                if (result.Success && result.Data != null)
                {
                    _prescriptionsExistant = result.Data;
                    _dataGridView.DataSource = null;
                    _dataGridView.DataSource = _prescriptionsExistant.Select(p => new
                    {
                        p.Id,
                        Medicament = p.NomMedicament,
                        p.Dosage,
                        p.Posologie,
                        Debut = p.DateDebut.ToString("dd/MM/yyyy"),
                        Fin = p.DateFin?.ToString("dd/MM/yyyy") ?? "Non spécifiée",
                        p.DureeTraitement,
                        p.Renouvellements
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur chargement prescriptions: {ex.Message}");
            }
        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            if (!ValiderFormulaire())
                return;

            try
            {
                // Préparer la prescription
                _currentPrescription.ConsultationId = _consultationId;
                _currentPrescription.DatePrescription = _dtpDatePrescription.Value;
                _currentPrescription.DateDebut = _dtpDateDebut.Value;
                _currentPrescription.NomMedicament = _txtMedicament.Text;
                _currentPrescription.Dosage = _txtDosage.Text;
                _currentPrescription.Posologie = _txtPosologie.Text;
                _currentPrescription.DureeTraitement = _cmbDuree.SelectedItem != null ?
                    (int?)Convert.ToInt32(_cmbDuree.SelectedItem) : null;
                _currentPrescription.Renouvellements = _cmbRenouvellements.SelectedIndex;
                _currentPrescription.Instructions = _txtInstructions.Text;

                // Calculer la date de fin si durée spécifiée
                if (_currentPrescription.DureeTraitement.HasValue)
                {
                    _currentPrescription.DateFin = _currentPrescription.DateDebut
                        .AddDays(_currentPrescription.DureeTraitement.Value);
                }

                // Sauvegarder
                var result = _prescriptionController.CreerPrescription(_currentPrescription);

                if (result.Success)
                {
                    MessageBox.Show("Prescription ajoutée avec succès!", "Succès",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Réinitialiser pour une nouvelle prescription
                    _currentPrescription = new Prescription();
                    _txtMedicament.Clear();
                    _txtDosage.Clear();
                    _txtPosologie.Clear();
                    _txtInstructions.Clear();
                    _cmbDuree.SelectedIndex = -1;
                    _cmbRenouvellements.SelectedIndex = 0;
                    _dtpDatePrescription.Value = DateTime.Now;
                    _dtpDateDebut.Value = DateTime.Now;

                    // Recharger la liste
                    ChargerPrescriptionsExistantes();

                    // Focus sur le premier champ
                    _txtMedicament.Focus();
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

        private bool ValiderFormulaire()
        {
            bool isValid = true;

            // Réinitialiser les couleurs
            _txtMedicament.BackColor = SystemColors.Window;
            _txtDosage.BackColor = SystemColors.Window;
            _txtPosologie.BackColor = SystemColors.Window;

            if (string.IsNullOrWhiteSpace(_txtMedicament.Text))
            {
                _txtMedicament.BackColor = Color.LightPink;
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(_txtDosage.Text))
            {
                _txtDosage.BackColor = Color.LightPink;
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(_txtPosologie.Text))
            {
                _txtPosologie.BackColor = Color.LightPink;
                isValid = false;
            }

            if (!isValid)
            {
                MessageBox.Show("Veuillez remplir les champs obligatoires (marqués en rouge)",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isValid;
        }

        private void BtnImprimer_Click(object sender, EventArgs e)
        {
            if (_prescriptionsExistant.Count == 0)
            {
                MessageBox.Show("Aucune prescription à imprimer", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show("Fonction d'impression à implémenter", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnFermer_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}