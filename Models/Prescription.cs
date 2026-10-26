using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCabinet.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public int ConsultationId { get; set; }
        public DateTime DatePrescription { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public string NomMedicament { get; set; }
        public string Dosage { get; set; }
        public string Posologie { get; set; }
        public int? DureeTraitement { get; set; }
        public int Renouvellements { get; set; }
        public string Instructions { get; set; }
        public bool EstActif { get; set; }

        public Prescription()
        {
            DatePrescription = DateTime.Now;
            DateDebut = DateTime.Now;
            EstActif = true;
            Renouvellements = 0;
        }
    }
}
