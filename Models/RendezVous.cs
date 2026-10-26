using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCabinet.Models
{
    public class RendezVous
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int MedecinId { get; set; }
        public DateTime DateRendezVous { get; set; }
        public TimeSpan HeureDebut { get; set; }
        public TimeSpan HeureFin { get; set; }
        public string TypeConsultation { get; set; }
        public string Motif { get; set; }
        public string Statut { get; set; }
        public string Priorite { get; set; }
        public string Notes { get; set; }
        public DateTime DateCreation { get; set; }

        // Navigation properties (pour affichage)
        public string NomPatient { get; set; }
        public string NomMedecin { get; set; }

        public RendezVous()
        {
            Statut = "Planifie";
            Priorite = "Normal";
            DateCreation = DateTime.Now;
            TypeConsultation = "Consultation générale";
        }
    }
}
