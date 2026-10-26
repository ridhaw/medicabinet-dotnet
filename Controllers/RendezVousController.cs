using MediCabinet.Models;
using MediCabinet.Models.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCabinet.Controllers
{
    public class RendezVousController
    {
        private readonly RendezVousADO _rendezVousADO;

        public RendezVousController()
        {
            _rendezVousADO = new RendezVousADO();
        }

        public class OperationResult
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public object Data { get; set; }

            public OperationResult(bool success, string message, object data = null)
            {
                Success = success;
                Message = message;
                Data = data;
            }
        }

        public OperationResult AjouterRendezVous(RendezVous rdv)
        {
            try
            {
                // Validation
                if (rdv.PatientId <= 0)
                    return new OperationResult(false, "Patient invalide");

                if (rdv.MedecinId <= 0)
                    return new OperationResult(false, "Médecin invalide");

                if (rdv.DateRendezVous < DateTime.Today)
                    return new OperationResult(false, "La date doit être aujourd'hui ou dans le futur");

                // Vérifier la disponibilité
                if (!_rendezVousADO.IsCreneauDisponible(rdv.MedecinId, rdv.DateRendezVous, rdv.HeureDebut, rdv.HeureFin))
                    return new OperationResult(false, "Ce créneau n'est pas disponible");

                // Ajouter le rendez-vous
                int rdvId = _rendezVousADO.AjouterRendezVous(rdv);

                return new OperationResult(true, "Rendez-vous ajouté avec succès", rdvId);
            }
            catch (Exception ex)
            {
                return new OperationResult(false, $"Erreur: {ex.Message}");
            }
        }

        public OperationResult ModifierRendezVous(RendezVous rdv)
        {
            try
            {
                if (rdv.Id <= 0)
                    return new OperationResult(false, "Rendez-vous invalide");

                // Vérifier la disponibilité (exclure le rendez-vous en cours de modification)
                if (!_rendezVousADO.IsCreneauDisponible(rdv.MedecinId, rdv.DateRendezVous, rdv.HeureDebut, rdv.HeureFin, rdv.Id))
                    return new OperationResult(false, "Ce créneau n'est pas disponible");

                bool success = _rendezVousADO.UpdateRendezVous(rdv);

                return success ?
                    new OperationResult(true, "Rendez-vous modifié avec succès") :
                    new OperationResult(false, "Échec de la modification");
            }
            catch (Exception ex)
            {
                return new OperationResult(false, $"Erreur: {ex.Message}");
            }
        }

        public OperationResult AnnulerRendezVous(int rdvId, string raison = "")
        {
            try
            {
                bool success = _rendezVousADO.UpdateStatut(rdvId, "Annule");

                return success ?
                    new OperationResult(true, "Rendez-vous annulé avec succès") :
                    new OperationResult(false, "Échec de l'annulation");
            }
            catch (Exception ex)
            {
                return new OperationResult(false, $"Erreur: {ex.Message}");
            }
        }

        public List<RendezVous> GetRendezVousDuJour()
        {
            try
            {
                return _rendezVousADO.GetRendezVousByDate(DateTime.Today);
            }
            catch
            {
                return new List<RendezVous>();
            }
        }

        public List<RendezVous> GetRendezVousParDate(DateTime date, int? medecinId = null)
        {
            try
            {
                return _rendezVousADO.GetRendezVousByDate(date, medecinId);
            }
            catch
            {
                return new List<RendezVous>();
            }
        }

        public List<RendezVous> GetRendezVousParPatient(int patientId)
        {
            try
            {
                return _rendezVousADO.GetRendezVousByPatient(patientId);
            }
            catch
            {
                return new List<RendezVous>();
            }
        }
    }
}
