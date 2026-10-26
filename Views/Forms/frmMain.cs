using MediCabinet.Models;
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
    public partial class frmMain : Form
    {
        private Utilisateur _currentUser;
        public frmMain(Utilisateur utilisateur)
        {
            try
            {
                InitializeComponent();
                _currentUser = utilisateur;

                if (_currentUser == null)
                {
                    MessageBox.Show("Erreur: Aucun utilisateur connecté", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                ConfigureInterface();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur initialisation frmMain: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void ConfigureInterface()
        {
            try
            {
                // Titre avec nom d'utilisateur
                this.Text = $"MediCabinet - Connecté: {_currentUser.NomComplet} ({_currentUser.Role})";

                // Afficher les informations utilisateur
                lblBienvenue.Text = $"Bienvenue, {_currentUser.NomComplet}";
                lblRole.Text = $"Rôle: {_currentUser.Role}";
                lblDate.Text = $"Date: {DateTime.Now:dd/MM/yyyy HH:mm}";

                // Configuration selon le rôle
                switch (_currentUser.Role)
                {
                    case "Admin":
                        ConfigureMenuAdmin();
                        break;

                    case "Medecin":
                        ConfigureMenuMedecin();
                        break;

                    case "Secretaire":
                        ConfigureMenuSecretaire();
                        break;

                    default:
                        MessageBox.Show($"Rôle inconnu: {_currentUser.Role}", "Erreur",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }

                // Timer pour l'heure
                timer1.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur configuration interface: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ConfigureMenuAdmin()
        {
            try
            {
                // Admin a accès à tout
                menuGestionUtilisateurs.Visible = true;
                menuGestionPatients.Visible = true;
                menuGestionRendezVous.Visible = true;
                menuConsultations.Visible = true;
                menuRapports.Visible = true;
                menuParametres.Visible = true;

                // Interface spécifique admin
                panelHeader.BackColor = Color.DarkRed;
                lblBienvenue.ForeColor = Color.DarkRed;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur configuration menu Admin: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureMenuMedecin()
        {
            try
            {
                // Médecin peut voir patients, consultations, ses rendez-vous
                menuGestionUtilisateurs.Visible = false;
                menuGestionPatients.Visible = true;
                menuGestionRendezVous.Visible = true;
                menuConsultations.Visible = true;
                menuRapports.Visible = false;
                menuParametres.Visible = false;

                // Interface spécifique médecin
                panelHeader.BackColor = Color.DarkGreen;
                lblBienvenue.ForeColor = Color.DarkGreen;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur configuration menu Medecin: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureMenuSecretaire()
        {
            try
            {
                // Secrétaire gère patients et rendez-vous
                menuGestionUtilisateurs.Visible = false;
                menuGestionPatients.Visible = true;
                menuGestionRendezVous.Visible = true;
                menuConsultations.Visible = false;
                menuRapports.Visible = false;
                menuParametres.Visible = false;

                // Interface spécifique secrétaire
                panelHeader.BackColor = Color.DarkBlue;
                lblBienvenue.ForeColor = Color.DarkBlue;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur configuration menu Secretaire: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                // Afficher un dashboard selon le rôle
                AfficherDashboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur chargement dashboard: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AfficherDashboard()
        {
            try
            {
                if (panelMain == null) return;

                // Créer un dashboard personnalisé
                var dashboard = new Panel
                {
                    Dock = DockStyle.Fill,
                    BackColor = Color.WhiteSmoke
                };

                var lblTitre = new Label
                {
                    Text = $"Tableau de bord - {_currentUser.Role}",
                    Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold),
                    Location = new Point(20, 20),
                    AutoSize = true
                };

                var lblInfo = new Label
                {
                    Text = GetDashboardInfo(),
                    Font = new Font("Microsoft Sans Serif", 10),
                    Location = new Point(20, 60),
                    Size = new Size(400, 150)
                };

                dashboard.Controls.Add(lblTitre);
                dashboard.Controls.Add(lblInfo);

                // Ajouter au panel principal
                panelMain.Controls.Clear();
                panelMain.Controls.Add(dashboard);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur création dashboard: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetDashboardInfo()
        {
            if (_currentUser == null) return "Erreur: utilisateur non connecté";

            switch (_currentUser.Role)
            {
                case "Admin":
                    return "• Gestion complète du système\n• Administration des utilisateurs\n• Accès à tous les modules\n• Configuration du système";

                case "Medecin":
                    return "• Consultation des patients\n• Prise de rendez-vous\n• Gestion du dossier médical\n• Prescription de médicaments";

                case "Secretaire":
                    return "• Gestion des rendez-vous\n• Accueil des patients\n• Prise de rendez-vous\n• Gestion administrative";

                default:
                    return "Bienvenue dans MediCabinet";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                lblDate.Text = $"Date: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
            }
            catch { /* Ignorer les erreurs de timer */ }
        }

        // Méthodes d'ouverture des formulaires
        private void menuGestionPatients_Click(object sender, EventArgs e)
        {
            OuvrirFormModal<frmPatientProfil>();
        }

        private void menuGestionUtilisateurs_Click(object sender, EventArgs e)
        {
            if (_currentUser == null || _currentUser.Role != "Admin")
            {
                MessageBox.Show("Accès réservé aux administrateurs",
                               "Accès refusé",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OuvrirFormModal<frmGestionUtilisateurs>();
        }

        private void menuGestionRendezVous_Click(object sender, EventArgs e)
        {
            try
            {
                // Utilisez la méthode générique
                OuvrirFormModal<frmRendezVous>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur ouverture rendez-vous: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Dans frmMain.cs, ajoutez cette méthode
        private void OuvrirConsultation(int? patientId = null, int? rendezVousId = null)
        {
            try
            {
                var form = new frmConsultation(patientId, rendezVousId);
                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog(this);

                AfficherDashboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void menuConsultations_Click(object sender, EventArgs e)
        {
            try
            {
                // Appelez la nouvelle méthode
                OuvrirConsultation();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur ouverture consultation: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuRapports_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Module rapports - À implémenter", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void menuParametres_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Module paramètres - À implémenter", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void menuDeconnexion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vraiment vous déconnecter ?",
                "Déconnexion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void menuQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuAPropos_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"MediCabinet v1.0\n\nConnecté: {_currentUser.NomComplet}\nRôle: {_currentUser.Role}\n\n© 2024 - Tous droits réservés",
                "À propos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OuvrirFormModal<T>() where T : Form, new()
        {
            try
            {
                using (var form = new T())
                {
                    // Sauvegarder la position et taille actuelle
                    form.StartPosition = FormStartPosition.CenterParent;
                    form.ShowDialog(this); // 'this' comme owner

                    // Après fermeture, vous pouvez rafraîchir les données si besoin
                    AfficherDashboard();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FermerFormulairesEnfants()
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        // Et modifiez la méthode OuvrirForm pour optionnellement fermer les autres
        private void OuvrirFormSeul<T>() where T : Form, new()
        {
            FermerFormulairesEnfants();
            OuvrirFormModal<T>();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vraiment quitter l'application ?",
                "Quitter", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
