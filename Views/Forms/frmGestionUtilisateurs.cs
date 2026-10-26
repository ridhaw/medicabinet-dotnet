using MediCabinet.Controllers;
using MediCabinet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace MediCabinet.Views.Forms
{
    public partial class frmGestionUtilisateurs : Form
    {
        private readonly UtilisateurController _utilisateurController;
        private List<Utilisateur> _utilisateursList;
        private Utilisateur _currentUtilisateur;
        private bool _isNew;

        public frmGestionUtilisateurs()
        {
            InitializeComponent();
            _utilisateurController = new UtilisateurController();
            _utilisateursList = new List<Utilisateur>();
            _currentUtilisateur = new Utilisateur();
            _isNew = true;
        }

        private void frmGestionUtilisateurs_Load(object sender, EventArgs e)
        {
            LoadUtilisateurs();
            ClearForm();
            SetFormState();
            cmbRoleRecherche.SelectedIndex = 0;
        }

        private void LoadUtilisateurs(string recherche = "", string role = "")
        {
            try
            {
                _utilisateursList = _utilisateurController.RechercherUtilisateurs(recherche, role);
                BindDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindDataGridView()
        {
            dgvUtilisateurs.DataSource = null;

            if (_utilisateursList.Count > 0)
            {
                var dataTable = new DataTable();
                dataTable.Columns.Add("ID", typeof(int));
                dataTable.Columns.Add("Username", typeof(string));
                dataTable.Columns.Add("Nom", typeof(string));
                dataTable.Columns.Add("Prénom", typeof(string));
                dataTable.Columns.Add("Role", typeof(string));
                dataTable.Columns.Add("Spécialité", typeof(string));
                dataTable.Columns.Add("Email", typeof(string));
                dataTable.Columns.Add("Téléphone", typeof(string));
                dataTable.Columns.Add("Actif", typeof(bool));

                foreach (var user in _utilisateursList.OrderBy(u => u.Nom).ThenBy(u => u.Prenom))
                {
                    dataTable.Rows.Add(
                        user.Id,
                        user.Username,
                        user.Nom,
                        user.Prenom,
                        user.Role,
                        user.Specialite ?? "",
                        user.Email ?? "",
                        user.Telephone ?? "",
                        user.EstActif
                    );
                }

                dgvUtilisateurs.DataSource = dataTable;
                FormatDataGridView();
            }
        }

        private void FormatDataGridView()
        {
            if (dgvUtilisateurs.Columns.Count > 0)
            {
                dgvUtilisateurs.Columns["ID"].Width = 40;
                dgvUtilisateurs.Columns["Username"].Width = 100;
                dgvUtilisateurs.Columns["Nom"].Width = 100;
                dgvUtilisateurs.Columns["Prénom"].Width = 100;
                dgvUtilisateurs.Columns["Role"].Width = 80;
                dgvUtilisateurs.Columns["Spécialité"].Width = 120;
                dgvUtilisateurs.Columns["Email"].Width = 150;
                dgvUtilisateurs.Columns["Téléphone"].Width = 100;
                dgvUtilisateurs.Columns["Actif"].Width = 50;
            }
        }

        private void ClearForm()
        {
            _currentUtilisateur = new Utilisateur();
            _isNew = true;

            lblId.Text = "ID: Nouveau";
            txtUsername.Text = string.Empty;
            txtNom.Text = string.Empty;
            txtPrenom.Text = string.Empty;
            cmbRole.SelectedIndex = 0;
            txtSpecialite.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTelephone.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmerPassword.Text = string.Empty;
            chkEstActif.Checked = true;

            txtSpecialite.Enabled = false; // Seulement pour médecins
        }

        private void LoadUtilisateurDetails(Utilisateur utilisateur)
        {
            if (utilisateur != null)
            {
                _currentUtilisateur = utilisateur;
                _isNew = false;

                lblId.Text = $"ID: {utilisateur.Id}";
                txtUsername.Text = utilisateur.Username;
                txtNom.Text = utilisateur.Nom;
                txtPrenom.Text = utilisateur.Prenom;
                cmbRole.Text = utilisateur.Role;
                txtSpecialite.Text = utilisateur.Specialite ?? "";
                txtEmail.Text = utilisateur.Email ?? "";
                txtTelephone.Text = utilisateur.Telephone ?? "";
                chkEstActif.Checked = utilisateur.EstActif;

                // Vider les champs de mot de passe pour la modification
                txtPassword.Text = string.Empty;
                txtConfirmerPassword.Text = string.Empty;

                // Activer/désactiver spécialité selon le rôle
                txtSpecialite.Enabled = (utilisateur.Role == "Medecin");
            }
        }

        private void SetFormState()
        {
            bool isExisting = !_isNew;

            btnEnregistrer.Text = _isNew ? "Ajouter" : "Modifier";
            btnSupprimer.Enabled = isExisting && _currentUtilisateur.Id > 1; // Empêcher suppression de l'admin principal
            btnAnnuler.Enabled = isExisting;

            // Gérer les champs de mot de passe
            bool showPasswordFields = _isNew;
            txtPassword.Enabled = showPasswordFields;
            txtConfirmerPassword.Enabled = showPasswordFields;
            label3.Enabled = showPasswordFields;
            label11.Enabled = showPasswordFields;
        }

        private Utilisateur GetFormData()
        {
            var utilisateur = new Utilisateur
            {
                Id = _currentUtilisateur.Id,
                Username = txtUsername.Text.Trim(),
                Nom = txtNom.Text.Trim(),
                Prenom = txtPrenom.Text.Trim(),
                Role = cmbRole.Text,
                Specialite = cmbRole.Text == "Medecin" ? txtSpecialite.Text.Trim() : null,
                Email = txtEmail.Text.Trim(),
                Telephone = txtTelephone.Text.Trim(),
                EstActif = chkEstActif.Checked
            };

            // Pour un nouvel utilisateur, utiliser le mot de passe du formulaire (en clair)
            if (_isNew && !string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                utilisateur.PasswordHash = txtPassword.Text; // En clair, pas de hash
            }
            // Pour la modification, garder l'ancien mot de passe
            else if (!_isNew)
            {
                // Récupérer le mot de passe existant
                var existingUser = _utilisateurController.GetUtilisateurParId(_currentUtilisateur.Id);
                if (existingUser != null)
                {
                    utilisateur.PasswordHash = existingUser.PasswordHash;
                }
            }

            return utilisateur;
        }

        private bool ValidateForm()
        {
            // Validation du nom d'utilisateur
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Le nom d'utilisateur est obligatoire", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            // Validation du nom et prénom
            if (string.IsNullOrWhiteSpace(txtNom.Text))
            {
                MessageBox.Show("Le nom est obligatoire", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNom.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPrenom.Text))
            {
                MessageBox.Show("Le prénom est obligatoire", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrenom.Focus();
                return false;
            }

            // Validation du rôle
            if (string.IsNullOrWhiteSpace(cmbRole.Text))
            {
                MessageBox.Show("Le rôle est obligatoire", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRole.Focus();
                return false;
            }

            // Validation du mot de passe pour un nouvel utilisateur
            if (_isNew)
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Le mot de passe est obligatoire pour un nouvel utilisateur", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return false;
                }

                if (txtPassword.Text.Length < 6)
                {
                    MessageBox.Show("Le mot de passe doit contenir au moins 6 caractères", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return false;
                }

                if (txtPassword.Text != txtConfirmerPassword.Text)
                {
                    MessageBox.Show("Les mots de passe ne correspondent pas", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtConfirmerPassword.Focus();
                    return false;
                }
            }

            // Validation spécialité pour les médecins
            if (cmbRole.Text == "Medecin" && string.IsNullOrWhiteSpace(txtSpecialite.Text))
            {
                MessageBox.Show("La spécialité est obligatoire pour un médecin", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSpecialite.Focus();
                return false;
            }

            return true;
        }

        // Événements
        private void btnRechercher_Click(object sender, EventArgs e)
        {
            string recherche = txtRecherche.Text.Trim();
            string role = cmbRoleRecherche.Text == "Tous" ? "" : cmbRoleRecherche.Text;

            LoadUtilisateurs(recherche, role);
        }

        private void txtRecherche_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnRechercher_Click(sender, e);
                e.Handled = true;
            }
        }

        private void dgvUtilisateurs_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUtilisateurs.SelectedRows.Count > 0)
            {
                var selectedRow = dgvUtilisateurs.SelectedRows[0];
                if (selectedRow.Cells["ID"].Value != DBNull.Value)
                {
                    int userId = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                    var user = _utilisateursList.FirstOrDefault(u => u.Id == userId);
                    if (user != null)
                    {
                        LoadUtilisateurDetails(user);
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
                var utilisateur = GetFormData();

                if (_isNew)
                {
                    // Pour un nouvel utilisateur, utiliser la méthode avec password
                    var result = _utilisateurController.AjouterUtilisateur(utilisateur);

                    if (result.Success)
                    {
                        MessageBox.Show(result.Message, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Recharger la liste
                        LoadUtilisateurs(txtRecherche.Text.Trim(),
                            cmbRoleRecherche.Text == "Tous" ? "" : cmbRoleRecherche.Text);

                        ClearForm();
                        SetFormState();
                    }
                    else
                    {
                        MessageBox.Show(result.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Pour la modification
                    var result = _utilisateurController.ModifierUtilisateur(utilisateur);

                    if (result.Success)
                    {
                        MessageBox.Show(result.Message, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Recharger la liste
                        LoadUtilisateurs(txtRecherche.Text.Trim(),
                            cmbRoleRecherche.Text == "Tous" ? "" : cmbRoleRecherche.Text);

                        ClearForm();
                        SetFormState();
                    }
                    else
                    {
                        MessageBox.Show(result.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (_currentUtilisateur == null || _currentUtilisateur.Id <= 0)
            {
                MessageBox.Show("Aucun utilisateur sélectionné", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Empêcher la suppression de l'admin principal (ID 1)
            if (_currentUtilisateur.Id == 1)
            {
                MessageBox.Show("Impossible de supprimer l'administrateur principal", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"Voulez-vous vraiment supprimer l'utilisateur {_currentUtilisateur.Nom} {_currentUtilisateur.Prenom}?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var result = _utilisateurController.SupprimerUtilisateur(_currentUtilisateur.Id);

                    if (result.Success)
                    {
                        MessageBox.Show("Utilisateur supprimé avec succès", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Recharger la liste
                        LoadUtilisateurs(txtRecherche.Text.Trim(),
                            cmbRoleRecherche.Text == "Tous" ? "" : cmbRoleRecherche.Text);

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
            if (_currentUtilisateur != null && _currentUtilisateur.Id > 0)
            {
                // Recharger les données depuis la base
                var user = _utilisateursList.FirstOrDefault(u => u.Id == _currentUtilisateur.Id);
                if (user != null)
                {
                    LoadUtilisateurDetails(user);
                    SetFormState();
                }
            }
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Activer/désactiver le champ spécialité selon le rôle
            txtSpecialite.Enabled = (cmbRole.Text == "Medecin");
        }

        private void gbRecherche_Enter(object sender, EventArgs e)
        {

        }

        private void dgvUtilisateurs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}