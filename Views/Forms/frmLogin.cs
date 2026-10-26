using MediCabinet.Controllers;
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
    public partial class frmLogin : Form
    {
        private readonly UtilisateurController _utilisateurController;
        public Utilisateur UtilisateurConnecte { get; private set; }
        public frmLogin()
        {
            InitializeComponent();
            _utilisateurController = new UtilisateurController();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Authentifier();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Authentifier();
                e.Handled = true;
            }
        }

        private void Authentifier()
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Veuillez saisir le nom d'utilisateur", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Veuillez saisir le mot de passe", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                btnLogin.Enabled = false;

                var result = _utilisateurController.Authentifier(username, password);

                if (result.Success)
                {
                    UtilisateurConnecte = result.Data as Utilisateur;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(result.Message, "Échec de l'authentification",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnLogin.Enabled = true;
            }
        }

        private void lnkMotDePasseOublie_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Veuillez contacter l'administrateur pour réinitialiser votre mot de passe.",
                "Mot de passe oublié", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        
    }
}
