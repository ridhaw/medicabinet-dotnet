using MediCabinet.Models;
using MediCabinet.Models.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCabinet.Controllers
{
    public class PatientController
    {
        private readonly PatientADO _patientADO;

        public PatientController()
        {
            _patientADO = new PatientADO();
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

        public OperationResult AjouterPatient(Patient patient)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(patient.NumeroSecuriteSociale))
                    return new OperationResult(false, "Le numéro de sécurité sociale est obligatoire");

                if (string.IsNullOrWhiteSpace(patient.Nom))
                    return new OperationResult(false, "Le nom est obligatoire");

                if (string.IsNullOrWhiteSpace(patient.Prenom))
                    return new OperationResult(false, "Le prénom est obligatoire");

                if (patient.DateNaissance >= DateTime.Now)
                    return new OperationResult(false, "La date de naissance doit être dans le passé");

                // Vérifier si le NSS existe déjà
                if (_patientADO.NSSExists(patient.NumeroSecuriteSociale))
                    return new OperationResult(false, "Ce numéro de sécurité sociale existe déjà");

                // Ajouter le patient
                int patientId = _patientADO.AjouterPatient(patient);

                return new OperationResult(true, "Patient ajouté avec succès", patientId);
            }
            catch (Exception ex)
            {
                return new OperationResult(false, $"Erreur: {ex.Message}");
            }
        }

        public OperationResult ModifierPatient(Patient patient)
        {
            try
            {
                if (patient.Id <= 0)
                    return new OperationResult(false, "Patient invalide");

                // Vérifier si le NSS existe déjà (pour un autre patient)
                if (_patientADO.NSSExists(patient.NumeroSecuriteSociale, patient.Id))
                    return new OperationResult(false, "Ce numéro de sécurité sociale est déjà utilisé par un autre patient");

                bool success = _patientADO.UpdatePatient(patient);

                return success ?
                    new OperationResult(true, "Patient modifié avec succès") :
                    new OperationResult(false, "Échec de la modification");
            }
            catch (Exception ex)
            {
                return new OperationResult(false, $"Erreur: {ex.Message}");
            }
        }

        public OperationResult SupprimerPatient(int patientId)
        {
            try
            {
                if (patientId <= 0)
                    return new OperationResult(false, "Patient invalide");

                bool success = _patientADO.DeletePatient(patientId);

                return success ?
                    new OperationResult(true, "Patient supprimé avec succès") :
                    new OperationResult(false, "Échec de la suppression");
            }
            catch (Exception ex)
            {
                return new OperationResult(false, $"Erreur: {ex.Message}");
            }
        }

        public List<Patient> RechercherPatients(string critere)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(critere))
                    return _patientADO.GetAllPatients();

                return _patientADO.SearchPatients(critere);
            }
            catch
            {
                return new List<Patient>();
            }
        }

        public Patient GetPatientParId(int id)
        {
            try
            {
                return _patientADO.GetPatientById(id);
            }
            catch
            {
                return null;
            }
        }

        public List<Patient> GetTousLesPatients()
        {
            try
            {
                return _patientADO.GetAllPatients();
            }
            catch
            {
                return new List<Patient>();
            }
        }
    }
}
