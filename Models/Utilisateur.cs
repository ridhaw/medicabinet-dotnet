using System;

namespace MediCabinet.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Role { get; set; }
        public string Specialite { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public bool EstActif { get; set; }
        public DateTime DateCreation { get; set; }

        // Propriété temporaire pour le formulaire (non mappée à la base)
        public string Password { get; set; }

        public string NomComplet => $"{Nom} {Prenom}";
        public string Initiales => Nom.Length > 0 && Prenom.Length > 0 ? $"{Nom[0]}{Prenom[0]}".ToUpper() : "??";

        public Utilisateur()
        {
            EstActif = true;
            DateCreation = DateTime.Now;
            Role = "Secretaire"; // Valeur par défaut
        }
    }
}