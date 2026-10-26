using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediCabinet.Models;
using MediCabinet.Models.ADO;

namespace MediCabinet.Views.Forms
{
    public partial class frmPatientProfil : Form
    {
        // Variables pour la gestion des données
        private PatientADO patientADO;
        private List<Patient> patientsList;
        private bool isEditing = false;
        private bool isAddingNew = false;
        private int currentPatientId = -1;
        private DataGridViewRow currentSelectedRow = null;

        // ErrorProvider pour la validation
        private ErrorProvider errorProvider1 = new ErrorProvider();

        public frmPatientProfil()
        {
            InitializeComponent();
            patientADO = new PatientADO();
            InitializeForm();
        }

        private void InitializeForm()
        {
            // Initialiser l'ErrorProvider
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            // Configurer le DataGridView
            ConfigureDataGridView();

            // Charger les données initiales
            LoadPatients();

            // Désactiver les champs de détails initialement
            SetDetailsEnabled(false);

            // Cacher les boutons d'action
            btnSauvegarder.Visible = false;
            btnAnnuler.Visible = false;

            // Configurer les valeurs par défaut
            cmbGrpSanguins.SelectedIndex = 0;
            cmbSexe.SelectedIndex = 0;
            cmbGrpSanguin.SelectedIndex = 0;
           

            // Désactiver les boutons Modifier et Supprimer initialement
            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;

            // Configurer le texte d'aide de la recherche
            txtRechercher.Text = "Nom, prénom, téléphone...";
            txtRechercher.ForeColor = SystemColors.GrayText;

            // Ajouter l'événement SelectionChanged au DataGridView
            dgvPatients.SelectionChanged += new EventHandler(dgvPatients_SelectionChanged);
            dgvPatients.CellContentClick += new DataGridViewCellEventHandler(dgvPatients_CellContentClick);
        }

        private void ConfigureDataGridView()
        {
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatients.MultiSelect = false;
            dgvPatients.RowHeadersVisible = false;
            dgvPatients.AutoGenerateColumns = false;

            // Configurer les colonnes manuellement
            dgvPatients.Columns.Clear();

            // Colonne ID (cachée)
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "Id";
            colId.DataPropertyName = "Id";
            colId.Visible = false;
            dgvPatients.Columns.Add(colId);

            // Colonne Numéro Sécurité Sociale
            DataGridViewTextBoxColumn colNSS = new DataGridViewTextBoxColumn();
            colNSS.Name = "NumeroSecuriteSociale";
            colNSS.DataPropertyName = "NumeroSecuriteSociale";
            colNSS.HeaderText = "N° Sécurité Sociale";
            colNSS.Width = 150;
            dgvPatients.Columns.Add(colNSS);

            // Colonne Nom
            DataGridViewTextBoxColumn colNom = new DataGridViewTextBoxColumn();
            colNom.Name = "Nom";
            colNom.DataPropertyName = "Nom";
            colNom.HeaderText = "Nom";
            colNom.Width = 120;
            dgvPatients.Columns.Add(colNom);

            // Colonne Prénom
            DataGridViewTextBoxColumn colPrenom = new DataGridViewTextBoxColumn();
            colPrenom.Name = "Prenom";
            colPrenom.DataPropertyName = "Prenom";
            colPrenom.HeaderText = "Prénom";
            colPrenom.Width = 120;
            dgvPatients.Columns.Add(colPrenom);

            // Colonne Date de Naissance
            DataGridViewTextBoxColumn colDateNaissance = new DataGridViewTextBoxColumn();
            colDateNaissance.Name = "DateNaissance";
            colDateNaissance.DataPropertyName = "DateNaissance";
            colDateNaissance.HeaderText = "Date Naissance";
            colDateNaissance.Width = 120;
            colDateNaissance.DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvPatients.Columns.Add(colDateNaissance);

            // Colonne Téléphone
            DataGridViewTextBoxColumn colTelephone = new DataGridViewTextBoxColumn();
            colTelephone.Name = "Telephone";
            colTelephone.DataPropertyName = "Telephone";
            colTelephone.HeaderText = "Téléphone";
            colTelephone.Width = 120;
            dgvPatients.Columns.Add(colTelephone);

            // Colonne Email
            DataGridViewTextBoxColumn colEmail = new DataGridViewTextBoxColumn();
            colEmail.Name = "Email";
            colEmail.DataPropertyName = "Email";
            colEmail.HeaderText = "Email";
            colEmail.Width = 180;
            dgvPatients.Columns.Add(colEmail);

            // Colonne Groupe Sanguin
            DataGridViewTextBoxColumn colGroupeSanguin = new DataGridViewTextBoxColumn();
            colGroupeSanguin.Name = "GroupeSanguin";
            colGroupeSanguin.DataPropertyName = "GroupeSanguin";
            colGroupeSanguin.HeaderText = "Groupe Sanguin";
            colGroupeSanguin.Width = 100;
            dgvPatients.Columns.Add(colGroupeSanguin);

           
        }

        private void LoadPatients()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                // Charger les patients depuis la base de données
                patientsList = patientADO.GetAllPatients();

                // Lier les données au DataGridView
                dgvPatients.DataSource = patientsList;

                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des patients: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void dgvPatients_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count > 0 && !isEditing)
            {
                DataGridViewRow row = dgvPatients.SelectedRows[0];
                currentSelectedRow = row;

                // Récupérer l'ID du patient sélectionné
                currentPatientId = Convert.ToInt32(row.Cells["Id"].Value);

                // Charger les détails du patient
                LoadPatientDetails(currentPatientId);

                // Activer les boutons Modifier et Supprimer
                btnModifier.Enabled = true;
                btnSupprimer.Enabled = true;
            }
        }

        private void LoadPatientDetails(int patientId)
        {
            try
            {
                Patient patient = patientADO.GetPatientById(patientId);
                if (patient != null)
                {
                    txtNom.Text = patient.Nom;
                    txtPrenom.Text = patient.Prenom;
                    dtpNaissance.Value = patient.DateNaissance;

                    // Sélectionner le sexe
                    if (cmbSexe.Items.Contains(patient.Sexe))
                        cmbSexe.SelectedItem = patient.Sexe;
                    else
                        cmbSexe.SelectedIndex = 0;

                    txtTelephone.Text = patient.Telephone ?? "";
                    txtEmail.Text = patient.Email ?? "";
                    txtAdresse.Text = patient.Adresse ?? "";
                    txtVille.Text = patient.Ville ?? "";
                    txtCodePostal.Text = patient.CodePostal ?? "";

                    // Sélectionner le groupe sanguin
                    if (cmbGrpSanguin.Items.Contains(patient.GroupeSanguin))
                        cmbGrpSanguin.SelectedItem = patient.GroupeSanguin;
                    else
                        cmbGrpSanguin.SelectedIndex = 0;

                    txtMutuelle.Text = patient.Mutuelle ?? "";
                    txtNumMutuelle.Text = patient.NumeroMutuelle ?? "";
                    txtAntecedents.Text = patient.Antecedents ?? "";
                    txtAllergies.Text = patient.Allergies ?? "";
                    txtPersonneContact.Text = patient.PersonneContact ?? "";
                    txtTelContact.Text = patient.TelContact ?? "";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des détails: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPatients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Cette méthode est appelée quand on clique sur le contenu d'une cellule
            // Pour la sélection de ligne, on utilise l'événement SelectionChanged
        }

        private void txtRechercher_TextChanged(object sender, EventArgs e)
        {
            // Si le texte est vide ou contient le texte d'aide, on affiche tout
            if (txtRechercher.Text == "Nom, prénom, téléphone..." || string.IsNullOrWhiteSpace(txtRechercher.Text))
            {
                LoadPatients();
            }
            else if (txtRechercher.Text.Length > 2)
            {
                SearchPatients();
            }
        }

        private void txtRechercher_Enter(object sender, EventArgs e)
        {
            if (txtRechercher.Text == "Nom, prénom, téléphone...")
            {
                txtRechercher.Text = "";
                txtRechercher.ForeColor = SystemColors.ControlText;
            }
        }

        private void txtRechercher_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRechercher.Text))
            {
                txtRechercher.Text = "Nom, prénom, téléphone...";
                txtRechercher.ForeColor = SystemColors.GrayText;
            }
        }

        private void cmbGrpSanguins_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchPatients();
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            SearchPatients();
        }

        private void SearchPatients()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                string searchText = txtRechercher.Text;
                string bloodGroup = cmbGrpSanguins.SelectedItem?.ToString();

                // Si le texte est l'aide, on le considère comme vide
                if (searchText == "Nom, prénom, téléphone...")
                    searchText = "";

                // Rechercher les patients
                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    patientsList = patientADO.SearchPatients(searchText);
                }
                else
                {
                    patientsList = patientADO.GetAllPatients();
                }

                // Filtrer par groupe sanguin si nécessaire
                if (bloodGroup != "Tous" && !string.IsNullOrEmpty(bloodGroup))
                {
                    patientsList = patientsList.Where(p => p.GroupeSanguin == bloodGroup).ToList();
                }

                // Mettre à jour le DataGridView
                dgvPatients.DataSource = patientsList;


                // Désélectionner toute ligne
                dgvPatients.ClearSelection();

                // Désactiver Modifier/Supprimer si aucun patient sélectionné
                btnModifier.Enabled = false;
                btnSupprimer.Enabled = false;
                ClearDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la recherche: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnRafraichir_Click(object sender, EventArgs e)
        {
            // Réinitialiser les filtres
            txtRechercher.Text = "Nom, prénom, téléphone...";
            txtRechercher.ForeColor = SystemColors.GrayText;
            cmbGrpSanguins.SelectedIndex = 0;

            // Recharger les données
            LoadPatients();

            // Vider les détails
            ClearDetails();

            // Désactiver l'édition si en cours
            CancelEdit();

            // Désélectionner dans le DataGridView
            dgvPatients.ClearSelection();

            MessageBox.Show("Liste des patients rafraîchie avec succès!",
                "Rafraîchissement", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ClearDetails()
        {
            txtNom.Text = "";
            txtPrenom.Text = "";
            dtpNaissance.Value = DateTime.Now.AddYears(-30);
            cmbSexe.SelectedIndex = 0;
            txtTelephone.Text = "";
            txtEmail.Text = "";
            txtAdresse.Text = "";
            txtVille.Text = "";
            txtCodePostal.Text = "";
            cmbGrpSanguin.SelectedIndex = 0;
            txtMutuelle.Text = "";
            txtNumMutuelle.Text = "";
            txtAntecedents.Text = "";
            txtAllergies.Text = "";
            txtPersonneContact.Text = "";
            txtTelContact.Text = "";
           

            currentPatientId = -1;
            currentSelectedRow = null;
        }

        private void SetDetailsEnabled(bool enabled)
        {
            txtNom.Enabled = enabled;
            txtPrenom.Enabled = enabled;
            dtpNaissance.Enabled = enabled;
            cmbSexe.Enabled = enabled;
            txtTelephone.Enabled = enabled;
            txtEmail.Enabled = enabled;
            txtAdresse.Enabled = enabled;
            txtVille.Enabled = enabled;
            txtCodePostal.Enabled = enabled;
            cmbGrpSanguin.Enabled = enabled;
            txtMutuelle.Enabled = enabled;
            txtNumMutuelle.Enabled = enabled;
            txtAntecedents.Enabled = enabled;
            txtAllergies.Enabled = enabled;
            txtPersonneContact.Enabled = enabled;
            txtTelContact.Enabled = enabled;
        
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            isAddingNew = true;
            isEditing = true;

            // Activer les champs
            SetDetailsEnabled(true);

            // Vider les champs
            ClearDetails();

            // Afficher les boutons d'action
            btnSauvegarder.Visible = true;
            btnAnnuler.Visible = true;
            btnNouveau.Enabled = false;
            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;

            // Désactiver la recherche et la grille
            gbRecherche.Enabled = false;
            dgvPatients.Enabled = false;

            // Focus sur le premier champ
            txtNom.Focus();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (currentPatientId == -1 || currentSelectedRow == null)
            {
                MessageBox.Show("Veuillez sélectionner un patient à modifier.",
                    "Aucun patient sélectionné", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isEditing = true;
            isAddingNew = false;

            // Activer les champs
            SetDetailsEnabled(true);

            // Afficher les boutons d'action
            btnSauvegarder.Visible = true;
            btnAnnuler.Visible = true;
            btnNouveau.Enabled = false;
            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;

            // Désactiver la recherche et la grille
            gbRecherche.Enabled = false;
            dgvPatients.Enabled = false;

            // Focus sur le premier champ
            txtNom.Focus();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (currentPatientId == -1 || currentSelectedRow == null)
            {
                MessageBox.Show("Veuillez sélectionner un patient à supprimer.",
                    "Aucun patient sélectionné", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string patientName = $"{txtNom.Text} {txtPrenom.Text}";

            DialogResult result = MessageBox.Show(
                $"Êtes-vous sûr de vouloir supprimer le patient '{patientName}' ?\nCette action est irréversible.",
                "Confirmation de suppression",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;

                    // Supprimer le patient (soft delete)
                    bool success = patientADO.DeletePatient(currentPatientId);

                    if (success)
                    {
                        // Recharger l'affichage
                        LoadPatients();

                        // Vider les détails
                        ClearDetails();

                        // Désactiver les boutons
                        btnModifier.Enabled = false;
                        btnSupprimer.Enabled = false;

                        MessageBox.Show($"Patient '{patientName}' supprimé avec succès!",
                            "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de la suppression du patient.",
                            "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la suppression: {ex.Message}",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        private void btnSauvegarder_Click(object sender, EventArgs e)
        {
            if (!ValidatePatientData())
                return;

            try
            {
                Cursor = Cursors.WaitCursor;

                if (isAddingNew)
                {
                    // Créer un nouveau patient
                    Patient newPatient = new Patient
                    {
                        NumeroSecuriteSociale = "NON_RENSEIGNE", // À remplacer par un champ dans le formulaire si nécessaire
                        Nom = txtNom.Text.Trim(),
                        Prenom = txtPrenom.Text.Trim(),
                        DateNaissance = dtpNaissance.Value,
                        Sexe = cmbSexe.SelectedItem?.ToString(),
                        Telephone = txtTelephone.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        Adresse = txtAdresse.Text.Trim(),
                        Ville = txtVille.Text.Trim(),
                        CodePostal = txtCodePostal.Text.Trim(),
                        GroupeSanguin = cmbGrpSanguin.SelectedItem?.ToString(),
                        Mutuelle = txtMutuelle.Text.Trim(),
                        NumeroMutuelle = txtNumMutuelle.Text.Trim(),
                        Antecedents = txtAntecedents.Text.Trim(),
                        Allergies = txtAllergies.Text.Trim(),
                        PersonneContact = txtPersonneContact.Text.Trim(),
                        TelContact = txtTelContact.Text.Trim(),
                     
                    };

                    // Ajouter le patient dans la base de données
                    int newId = patientADO.AjouterPatient(newPatient);

                    if (newId > 0)
                    {
                        currentPatientId = newId;
                        MessageBox.Show("Nouveau patient ajouté avec succès!",
                            "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de l'ajout du patient.",
                            "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (isEditing && currentPatientId > 0)
                {
                    // Récupérer le patient existant
                    Patient existingPatient = patientADO.GetPatientById(currentPatientId);

                    if (existingPatient != null)
                    {
                        // Mettre à jour les informations
                        existingPatient.Nom = txtNom.Text.Trim();
                        existingPatient.Prenom = txtPrenom.Text.Trim();
                        existingPatient.DateNaissance = dtpNaissance.Value;
                        existingPatient.Sexe = cmbSexe.SelectedItem?.ToString();
                        existingPatient.Telephone = txtTelephone.Text.Trim();
                        existingPatient.Email = txtEmail.Text.Trim();
                        existingPatient.Adresse = txtAdresse.Text.Trim();
                        existingPatient.Ville = txtVille.Text.Trim();
                        existingPatient.CodePostal = txtCodePostal.Text.Trim();
                        existingPatient.GroupeSanguin = cmbGrpSanguin.SelectedItem?.ToString();
                        existingPatient.Mutuelle = txtMutuelle.Text.Trim();
                        existingPatient.NumeroMutuelle = txtNumMutuelle.Text.Trim();
                        existingPatient.Antecedents = txtAntecedents.Text.Trim();
                        existingPatient.Allergies = txtAllergies.Text.Trim();
                        existingPatient.PersonneContact = txtPersonneContact.Text.Trim();
                        existingPatient.TelContact = txtTelContact.Text.Trim();
              

                        // Mettre à jour dans la base de données
                        bool success = patientADO.UpdatePatient(existingPatient);

                        if (success)
                        {
                            MessageBox.Show("Patient modifié avec succès!",
                                "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Erreur lors de la modification du patient.",
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                // Terminer l'édition
                CancelEdit();

                // Recharger et sélectionner le patient modifié/ajouté
                LoadPatients();

                // Sélectionner le patient ajouté/modifié
                if (currentPatientId > 0)
                {
                    foreach (DataGridViewRow row in dgvPatients.Rows)
                    {
                        if (Convert.ToInt32(row.Cells["Id"].Value) == currentPatientId)
                        {
                            dgvPatients.ClearSelection();
                            row.Selected = true;
                            LoadPatientDetails(currentPatientId);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la sauvegarde: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private bool ValidatePatientData()
        {
            // Validation de base
            if (string.IsNullOrWhiteSpace(txtNom.Text))
            {
                MessageBox.Show("Le nom est obligatoire.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNom.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPrenom.Text))
            {
                MessageBox.Show("Le prénom est obligatoire.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrenom.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTelephone.Text))
            {
                MessageBox.Show("Le téléphone est obligatoire.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelephone.Focus();
                return false;
            }

            // Validation de l'email si renseigné
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
                {
                    MessageBox.Show("L'adresse email n'est pas valide.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return false;
                }
            }

            // Validation de la date de naissance
            if (dtpNaissance.Value > DateTime.Now)
            {
                MessageBox.Show("La date de naissance ne peut pas être dans le futur.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNaissance.Focus();
                return false;
            }

            if (dtpNaissance.Value < DateTime.Now.AddYears(-120))
            {
                MessageBox.Show("La date de naissance n'est pas plausible.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNaissance.Focus();
                return false;
            }

            return true;
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            CancelEdit();

            // Si un patient était sélectionné avant l'édition, recharger ses détails
            if (currentSelectedRow != null && currentPatientId != -1)
            {
                // Trouver le patient dans la liste actuelle
                foreach (DataGridViewRow row in dgvPatients.Rows)
                {
                    if (Convert.ToInt32(row.Cells["Id"].Value) == currentPatientId)
                    {
                        LoadPatientDetails(currentPatientId);
                        row.Selected = true;
                        break;
                    }
                }
            }
            else
            {
                ClearDetails();
                dgvPatients.ClearSelection();
            }
        }

        private void CancelEdit()
        {
            isEditing = false;
            isAddingNew = false;

            // Désactiver les champs
            SetDetailsEnabled(false);

            // Cacher les boutons d'action
            btnSauvegarder.Visible = false;
            btnAnnuler.Visible = false;
            btnNouveau.Enabled = true;

            // Réactiver la recherche et la grille
            gbRecherche.Enabled = true;
            dgvPatients.Enabled = true;

            // L'état de btnModifier et btnSupprimer dépend de la sélection
            btnModifier.Enabled = (dgvPatients.SelectedRows.Count > 0);
            btnSupprimer.Enabled = (dgvPatients.SelectedRows.Count > 0);

            // Effacer les erreurs de validation
            errorProvider1.Clear();

            // Réinitialiser les couleurs de fond
            txtNom.BackColor = SystemColors.Window;
            txtPrenom.BackColor = SystemColors.Window;
            txtTelephone.BackColor = SystemColors.Window;
            txtEmail.BackColor = SystemColors.Window;
        }

        // Gestionnaires d'événements pour la validation en temps réel
        private void txtNom_TextChanged(object sender, EventArgs e)
        {
            if (isEditing)
                ValidateRequiredField(txtNom, "Nom");
        }

        private void txtPrenom_TextChanged(object sender, EventArgs e)
        {
            if (isEditing)
                ValidateRequiredField(txtPrenom, "Prénom");
        }

        private void txtTelephone_TextChanged(object sender, EventArgs e)
        {
            if (isEditing)
                ValidateRequiredField(txtTelephone, "Téléphone");
        }

        private void ValidateRequiredField(TextBox textBox, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.BackColor = Color.LightPink;
                errorProvider1.SetError(textBox, $"{fieldName} est requis");
            }
            else
            {
                textBox.BackColor = SystemColors.Window;
                errorProvider1.SetError(textBox, "");
            }
        }

        // Gestionnaires d'événements pour les autres champs
        private void txtAntecedents_TextChanged(object sender, EventArgs e) { }
        private void txtCodePostal_TextChanged(object sender, EventArgs e) { }
        private void txtNumMutuelle_TextChanged(object sender, EventArgs e) { }
        private void rbtnActif_CheckedChanged(object sender, EventArgs e) { }
        private void cmbSexe_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtAllergies_TextChanged(object sender, EventArgs e) { }
        private void txtAdresse_TextChanged(object sender, EventArgs e) { }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (isEditing && !string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
                {
                    txtEmail.BackColor = Color.LightPink;
                    errorProvider1.SetError(txtEmail, "Email invalide");
                }
                else
                {
                    txtEmail.BackColor = SystemColors.Window;
                    errorProvider1.SetError(txtEmail, "");
                }
            }
        }

        private void txtVille_TextChanged(object sender, EventArgs e) { }
        private void txtMutuelle_TextChanged(object sender, EventArgs e) { }
        private void txtPersonneContact_TextChanged(object sender, EventArgs e) { }

        private void dtpNaissance_ValueChanged(object sender, EventArgs e)
        {
            if (isEditing)
            {
                if (dtpNaissance.Value > DateTime.Now)
                {
                    errorProvider1.SetError(dtpNaissance, "Date future invalide");
                }
                else
                {
                    errorProvider1.SetError(dtpNaissance, "");
                }
            }
        }

        private void cmbGrpSanguin_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtTelContact_TextChanged(object sender, EventArgs e) { }

        private void frmPatientProfil_Load(object sender, EventArgs e)
        {
            // Cette méthode est déjà appelée dans InitializeForm
        }

        private void frmPatientProfil_Load_1(object sender, EventArgs e)
        {

        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}