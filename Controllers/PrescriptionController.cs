using MediCabinet.Models;
using MediCabinet.Models.ADO;
using System;
using System.Collections.Generic;

namespace MediCabinet.Controllers
{
    public class PrescriptionController
    {
        private readonly PrescriptionADO _prescriptionADO;

        public PrescriptionController()
        {
            _prescriptionADO = new PrescriptionADO();
        }

        public OperationResult CreerPrescription(Prescription prescription)
        {
            try
            {
                // Validation
                var validationResult = ValiderPrescription(prescription);
                if (!validationResult.Success)
                    return validationResult;

                // Créer la prescription
                int prescriptionId = _prescriptionADO.AjouterPrescription(prescription);
                prescription.Id = prescriptionId;

                return new OperationResult
                {
                    Success = true,
                    Message = "Prescription créée avec succès",
                    Data = prescriptionId
                };
            }
            catch (Exception ex)
            {
                return new OperationResult
                {
                    Success = false,
                    Message = $"Erreur création prescription: {ex.Message}"
                };
            }
        }

        public OperationResult<List<Prescription>> GetPrescriptionsParConsultation(int consultationId)
        {
            try
            {
                var prescriptions = _prescriptionADO.GetPrescriptionsByConsultation(consultationId);
                return new OperationResult<List<Prescription>>
                {
                    Success = true,
                    Data = prescriptions,
                    Message = $"Prescriptions récupérées: {prescriptions.Count}"
                };
            }
            catch (Exception ex)
            {
                return new OperationResult<List<Prescription>>
                {
                    Success = false,
                    Message = $"Erreur récupération prescriptions: {ex.Message}"
                };
            }
        }

        public OperationResult<List<Prescription>> GetPrescriptionsActivesParPatient(int patientId)
        {
            try
            {
                var prescriptions = _prescriptionADO.GetPrescriptionsActivesByPatient(patientId);
                return new OperationResult<List<Prescription>>
                {
                    Success = true,
                    Data = prescriptions,
                    Message = $"Prescriptions actives récupérées: {prescriptions.Count}"
                };
            }
            catch (Exception ex)
            {
                return new OperationResult<List<Prescription>>
                {
                    Success = false,
                    Message = $"Erreur récupération prescriptions actives: {ex.Message}"
                };
            }
        }

        public OperationResult DesactiverPrescription(int prescriptionId)
        {
            try
            {
                bool success = _prescriptionADO.DesactiverPrescription(prescriptionId);
                return new OperationResult
                {
                    Success = success,
                    Message = success ? "Prescription désactivée" : "Prescription non trouvée"
                };
            }
            catch (Exception ex)
            {
                return new OperationResult
                {
                    Success = false,
                    Message = $"Erreur désactivation prescription: {ex.Message}"
                };
            }
        }

        private OperationResult ValiderPrescription(Prescription prescription)
        {
            if (prescription.ConsultationId <= 0)
                return new OperationResult { Success = false, Message = "Consultation invalide" };

            if (string.IsNullOrWhiteSpace(prescription.NomMedicament))
                return new OperationResult { Success = false, Message = "Nom du médicament requis" };

            if (string.IsNullOrWhiteSpace(prescription.Dosage))
                return new OperationResult { Success = false, Message = "Dosage requis" };

            if (string.IsNullOrWhiteSpace(prescription.Posologie))
                return new OperationResult { Success = false, Message = "Posologie requise" };

            if (prescription.DateDebut < DateTime.Today.AddDays(-7))
                return new OperationResult { Success = false, Message = "Date de début invalide" };

            return new OperationResult { Success = true };
        }
    }

    // Si vous n'avez pas déjà OperationResult
    public class OperationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }

    public class OperationResult<T> : OperationResult
    {
        public new T Data { get; set; }
    }
}