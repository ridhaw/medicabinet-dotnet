using MediCabinet.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediCabinet
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmGestionUtilisateurs());

            // Formulaire de connexion
            using (var frmLogin = new frmLogin())
            {
                if (frmLogin.ShowDialog() == DialogResult.OK)
                {
                    // L'utilisateur est dans la propriété UtilisateurConnecte
                    if (frmLogin.UtilisateurConnecte != null)
                    {
                        // Passez l'utilisateur au formulaire principal
                        Application.Run(new frmMain(frmLogin.UtilisateurConnecte));
                    }
                }
                else
                {
                    // L'utilisateur a annulé
                    Application.Exit();
                }
            }
        }
    }
}
