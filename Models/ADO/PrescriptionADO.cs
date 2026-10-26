using MediCabinet.Models.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCabinet.Models.ADO
{
    public class PrescriptionADO
    {
        // CREATE - Ajouter une prescription
        public int AjouterPrescription(Prescription prescription)
        {
            string query = @"
                INSERT INTO Prescriptions 
                (ConsultationId, DatePrescription, DateDebut, DateFin,
                 NomMedicament, Dosage, Posologie, DureeTraitement,
                 Renouvellements, Instructions, EstActif)
                VALUES 
                (@ConsultationId, @DatePrescription, @DateDebut, @DateFin,
                 @NomMedicament, @Dosage, @Posologie, @DureeTraitement,
                 @Renouvellements, @Instructions, @EstActif);
                SELECT SCOPE_IDENTITY();";

            using (var connection = DbConnexion.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@ConsultationId", prescription.ConsultationId);
                command.Parameters.AddWithValue("@DatePrescription", prescription.DatePrescription);
                command.Parameters.AddWithValue("@DateDebut", prescription.DateDebut);
                command.Parameters.AddWithValue("@DateFin", prescription.DateFin ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@NomMedicament", prescription.NomMedicament);
                command.Parameters.AddWithValue("@Dosage", prescription.Dosage);
                command.Parameters.AddWithValue("@Posologie", prescription.Posologie);
                command.Parameters.AddWithValue("@DureeTraitement", prescription.DureeTraitement ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Renouvellements", prescription.Renouvellements);
                command.Parameters.AddWithValue("@Instructions", prescription.Instructions ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@EstActif", prescription.EstActif);

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        // READ - Récupérer les prescriptions d'une consultation
        public List<Prescription> GetPrescriptionsByConsultation(int consultationId)
        {
            var prescriptions = new List<Prescription>();
            string query = "SELECT * FROM Prescriptions WHERE ConsultationId = @ConsultationId AND EstActif = 1";

            using (var connection = DbConnexion.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@ConsultationId", consultationId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        prescriptions.Add(MapFromReader(reader));
                    }
                }
            }

            return prescriptions;
        }

        // READ - Récupérer les prescriptions actives d'un patient
        public List<Prescription> GetPrescriptionsActivesByPatient(int patientId)
        {
            var prescriptions = new List<Prescription>();
            string query = @"
                SELECT p.*
                FROM Prescriptions p
                INNER JOIN Consultations c ON p.ConsultationId = c.Id
                WHERE c.PatientId = @PatientId 
                AND p.EstActif = 1
                AND (p.DateFin IS NULL OR p.DateFin >= GETDATE())
                ORDER BY p.DateDebut DESC";

            using (var connection = DbConnexion.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@PatientId", patientId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        prescriptions.Add(MapFromReader(reader));
                    }
                }
            }

            return prescriptions;
        }

        // UPDATE - Désactiver une prescription
        public bool DesactiverPrescription(int prescriptionId)
        {
            string query = "UPDATE Prescriptions SET EstActif = 0 WHERE Id = @Id";

            using (var connection = DbConnexion.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@Id", prescriptionId);
                return command.ExecuteNonQuery() > 0;
            }
        }

        // Helper method
        private Prescription MapFromReader(SqlDataReader reader)
        {
            return new Prescription
            {
                Id = Convert.ToInt32(reader["Id"]),
                ConsultationId = Convert.ToInt32(reader["ConsultationId"]),
                DatePrescription = Convert.ToDateTime(reader["DatePrescription"]),
                DateDebut = Convert.ToDateTime(reader["DateDebut"]),
                DateFin = reader["DateFin"] as DateTime?,
                NomMedicament = reader["NomMedicament"].ToString(),
                Dosage = reader["Dosage"].ToString(),
                Posologie = reader["Posologie"].ToString(),
                DureeTraitement = reader["DureeTraitement"] as int?,
                Renouvellements = Convert.ToInt32(reader["Renouvellements"]),
                Instructions = reader["Instructions"] as string,
                EstActif = Convert.ToBoolean(reader["EstActif"])
            };
        }
    }
}
