using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCabinet.Models
{
    public class Consultation
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int MedecinId { get; set; }
        public int? RendezVousId { get; set; }
        public DateTime DateConsultation { get; set; }
        public decimal? Poids { get; set; }
        public decimal? Taille { get; set; }
        public decimal? Temperature { get; set; }
        public string PressionArterielle { get; set; }
        public int? Pouls { get; set; }
        public string MotifConsultation { get; set; }
        public string Observations { get; set; }
        public string Diagnostic { get; set; }
        public string CodeCIM10 { get; set; }
        public string TraitementPrescrit { get; set; }
        public string Recommandations { get; set; }
        public DateTime? DateProchaineVisite { get; set; }

        // Calculé
        public decimal? IMC => Taille > 0 ? Poids / (Taille * Taille) : null;

        public Consultation()
        {
            DateConsultation = DateTime.Now;
        }
    }
}
