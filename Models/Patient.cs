using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCabinet.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string NumeroSecuriteSociale { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Sexe { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string CodePostal { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Mutuelle { get; set; }
        public string NumeroMutuelle { get; set; }  
        public string PersonneContact { get; set; }
        public string TelContact { get; set; }
        public string Allergies { get; set; }
        public string Antecedents { get; set; }
        public string GroupeSanguin { get; set; }
        public bool EstActif { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateModification { get; set; }

        // Propriétés calculées
        public int Age => (int)((DateTime.Now - DateNaissance).TotalDays / 365.25);
        public string NomComplet => $"{Nom.ToUpper()} {Prenom}";
        public string AdresseComplete => $"{Adresse}, {CodePostal} {Ville}";

        public Patient()
        {
            EstActif = true;
            DateCreation = DateTime.Now;
            Sexe = "M"; // Valeur par défaut
        }
    }
}
