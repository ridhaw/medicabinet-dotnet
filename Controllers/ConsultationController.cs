using MediCabinet.Models;
using MediCabinet.Models.ADO;
using System;
using System.Collections.Generic;

namespace MediCabinet.Controllers
{
    public class ConsultationController
    {
        private readonly ConsultationADO _consultationADO;
        private readonly RendezVousADO _rendezVousADO;

        public ConsultationController()
        {
            _consultationADO = new ConsultationADO();
            _rendezVousADO = new RendezVousADO();
        }

        public class OperationResult
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public object Data { get; set; }

            // Constructeur sans paramètres
            public OperationResult()
            {
            }

            // Constructeur avec paramètres
            public OperationResult(bool success, string message, object data = null)
            {
                Success = success;
                Message = message;
                Data = data;
            }
        }




        // Créer une consultation
        public OperationResult CreerConsultation(Consultation consultation)
        {
            try
            {
                // Validation des données obligatoires
                if (consultation.PatientId <= 0)
                    return new OperationResult(false, "Patient invalide");

                if (consultation.MedecinId <= 0)
                    return new OperationResult(false, "Médecin invalide");

                if (string.IsNullOrWhiteSpace(consultation.MotifConsultation))
                    return new OperationResult(false, "Le motif de consultation est obligatoire");

                // Si c'est une consultation suite à un rendez-vous
                if (consultation.RendezVousId.HasValue)
                {
                    // Vérifier que le rendez-vous existe
                    var rdv = _rendezVousADO.GetRendezVousById(consultation.RendezVousId.Value);
                    if (rdv == null)
                        return new OperationResult(false, "Rendez-vous introuvable");

                    // Mettre à jour le statut du rendez-vous
                    _rendezVousADO.UpdateStatut(rdv.Id, "Termine");
                }

                // Ajouter la consultation
                int consultationId = _consultationADO.AjouterConsultation(consultation);

                return new OperationResult(true, "Consultation créée avec succès", consultationId);
            }
            catch (Exception ex)
            {
                return new OperationResult(false, $"Erreur: {ex.Message}");
            }
        }

        // Obtenir les consultations d'un patient
        public OperationResult GetConsultationsParPatient(int patientId)
        {
            try
            {
                var consultations = _consultationADO.GetConsultationsByPatient(patientId);
                return new OperationResult(true, "Consultations récupérées", consultations);
            }
            catch (Exception ex)
            {
                return new OperationResult(false, $"Erreur: {ex.Message}");
            }
        }

        // Obtenir les consultations d'un médecin
        public List<Consultation> GetConsultationsParMedecin(int medecinId, DateTime? date = null)
        {
            try
            {
                // Cette méthode nécessitera une implémentation dans ConsultationADO
                return new List<Consultation>();
            }
            catch
            {
                return new List<Consultation>();
            }
        }
        public OperationResult GetConsultationParId(int consultationId)
        {
            try
            {
                var consultation = _consultationADO.GetConsultationById(consultationId);
                if (consultation != null)
                {
                    return new OperationResult
                    {
                        Success = true,
                        Data = consultation,
                        Message = "Consultation récupérée avec succès"
                    };
                }
                else
                {
                    return new OperationResult
                    {
                        Success = false,
                        Message = "Consultation non trouvée"
                    };
                }
            }
            catch (Exception ex)
            {
                return new OperationResult
                {
                    Success = false,
                    Message = $"Erreur: {ex.Message}"
                };
            }
        }
        // Rechercher des consultations
        public List<Consultation> RechercherConsultations(string recherche, DateTime? dateDebut = null, DateTime? dateFin = null)
        {
            try
            {
                // Cette méthode nécessitera une implémentation dans ConsultationADO
                return new List<Consultation>();
            }
            catch
            {
                return new List<Consultation>();
            }
        }

        // Obtenir une consultation par ID
        public OperationResult GetConsultation(int id)
        {
            try
            {
                var consultation = _consultationADO.GetConsultationById(id);
                if (consultation == null)
                    return new OperationResult(false, "Consultation introuvable");

                return new OperationResult(true, "Consultation récupérée", consultation);
            }
            catch (Exception ex)
            {
                return new OperationResult(false, $"Erreur: {ex.Message}");
            }
        }

        // Statistiques des consultations
        public Dictionary<string, object> GetStatistiquesConsultations(DateTime dateDebut, DateTime dateFin, int? medecinId = null)
        {
            var statistiques = new Dictionary<string, object>
            {
                { "TotalConsultations", 0 },
                { "ConsultationsParJour", new List<object>() },
                { "ConsultationsParMedecin", new List<object>() },
                { "DiagnosticsFrequents", new List<object>() }
            };

            // Implémentation à compléter
            return statistiques;
        }
    }
}