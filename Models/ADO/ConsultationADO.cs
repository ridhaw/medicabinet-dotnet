using MediCabinet.Models.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCabinet.Models.ADO
{
    public class ConsultationADO
    {
        // CREATE - Ajouter une consultation
        public int AjouterConsultation(Consultation consultation)
        {
            string query = @"
                INSERT INTO Consultations 
                (PatientId, MedecinId, RendezVousId, DateConsultation, 
                 Poids, Taille, Temperature, PressionArterielle, Pouls,
                 MotifConsultation, Observations, Diagnostic, CodeCIM10,
                 TraitementPrescrit, Recommandations, DateProchaineVisite)
                VALUES 
                (@PatientId, @MedecinId, @RendezVousId, @DateConsultation,
                 @Poids, @Taille, @Temperature, @PressionArterielle, @Pouls,
                 @MotifConsultation, @Observations, @Diagnostic, @CodeCIM10,
                 @TraitementPrescrit, @Recommandations, @DateProchaineVisite);
                SELECT SCOPE_IDENTITY();";

            using (var connection = DbConnexion.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@PatientId", consultation.PatientId);
                command.Parameters.AddWithValue("@MedecinId", consultation.MedecinId);
                command.Parameters.AddWithValue("@RendezVousId", consultation.RendezVousId ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@DateConsultation", consultation.DateConsultation);
                command.Parameters.AddWithValue("@Poids", consultation.Poids ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Taille", consultation.Taille ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Temperature", consultation.Temperature ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@PressionArterielle", consultation.PressionArterielle ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Pouls", consultation.Pouls ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@MotifConsultation", consultation.MotifConsultation);
                command.Parameters.AddWithValue("@Observations", consultation.Observations ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Diagnostic", consultation.Diagnostic ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@CodeCIM10", consultation.CodeCIM10 ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@TraitementPrescrit", consultation.TraitementPrescrit ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Recommandations", consultation.Recommandations ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@DateProchaineVisite", consultation.DateProchaineVisite ?? (object)DBNull.Value);

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }


        
        // READ - Récupérer les consultations d'un patient
        public List<Consultation> GetConsultationsByPatient(int patientId)
        {
            var consultations = new List<Consultation>();
            string query = @"
                SELECT c.*, u.Nom + ' ' + u.Prenom as NomMedecin
                FROM Consultations c
                INNER JOIN Utilisateurs u ON c.MedecinId = u.Id
                WHERE c.PatientId = @PatientId
                ORDER BY c.DateConsultation DESC";

            using (var connection = DbConnexion.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@PatientId", patientId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        consultations.Add(MapFromReader(reader));
                    }
                }
            }

            return consultations;
        }

        // READ - Récupérer une consultation par ID
        public Consultation GetConsultationById(int id)
        {
            Consultation consultation = null;
            string query = @"
        SELECT c.*, 
               p.Nom as PatientNom, p.Prenom as PatientPrenom,
               u.Nom as MedecinNom, u.Prenom as MedecinPrenom
        FROM Consultations c
        LEFT JOIN Patients p ON c.PatientId = p.Id
        LEFT JOIN Utilisateurs u ON c.MedecinId = u.Id
        WHERE c.Id = @Id";

            using (var connection = DbConnexion.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        consultation = new Consultation
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            PatientId = Convert.ToInt32(reader["PatientId"]),
                            MedecinId = Convert.ToInt32(reader["MedecinId"]),
                            RendezVousId = reader["RendezVousId"] as int?,
                            DateConsultation = Convert.ToDateTime(reader["DateConsultation"]),
                            Poids = reader["Poids"] as decimal?,
                            Taille = reader["Taille"] as decimal?,
                            Temperature = reader["Temperature"] as decimal?,
                            PressionArterielle = reader["PressionArterielle"] as string,
                            Pouls = reader["Pouls"] as int?,
                            MotifConsultation = reader["MotifConsultation"] as string,
                            Observations = reader["Observations"] as string,
                            Diagnostic = reader["Diagnostic"] as string,
                            CodeCIM10 = reader["CodeCIM10"] as string,
                            TraitementPrescrit = reader["TraitementPrescrit"] as string,
                            Recommandations = reader["Recommandations"] as string,
                            DateProchaineVisite = reader["DateProchaineVisite"] as DateTime?
                        };
                    }
                }
            }

            return consultation;
        }

        // Dans ConsultationADO.cs
        public List<Consultation> GetConsultationsByMedecin(int medecinId, DateTime? date = null)
        {
            var consultations = new List<Consultation>();
            string query = @"
        SELECT c.*, u.Nom + ' ' + u.Prenom as NomMedecin, p.Nom + ' ' + p.Prenom as NomPatient
        FROM Consultations c
        INNER JOIN Utilisateurs u ON c.MedecinId = u.Id
        INNER JOIN Patients p ON c.PatientId = p.Id
        WHERE c.MedecinId = @MedecinId";

            if (date.HasValue)
            {
                query += " AND CONVERT(DATE, c.DateConsultation) = @Date";
            }

            query += " ORDER BY c.DateConsultation DESC";

            using (var connection = DbConnexion.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@MedecinId", medecinId);

                if (date.HasValue)
                {
                    command.Parameters.AddWithValue("@Date", date.Value.Date);
                }

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        consultations.Add(MapFromReader(reader));
                    }
                }
            }

            return consultations;
        }

        public List<Consultation> RechercherConsultations(string recherche, DateTime? dateDebut = null, DateTime? dateFin = null)
        {
            var consultations = new List<Consultation>();
            string query = @"
        SELECT c.*, u.Nom + ' ' + u.Prenom as NomMedecin, p.Nom + ' ' + p.Prenom as NomPatient
        FROM Consultations c
        INNER JOIN Utilisateurs u ON c.MedecinId = u.Id
        INNER JOIN Patients p ON c.PatientId = p.Id
        WHERE 1=1";

            var parameters = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(recherche))
            {
                query += @" AND (p.Nom LIKE @Recherche OR p.Prenom LIKE @Recherche 
                    OR c.Diagnostic LIKE @Recherche OR c.MotifConsultation LIKE @Recherche)";
                parameters.Add(new SqlParameter("@Recherche", $"%{recherche}%"));
            }

            if (dateDebut.HasValue)
            {
                query += " AND c.DateConsultation >= @DateDebut";
                parameters.Add(new SqlParameter("@DateDebut", dateDebut.Value));
            }

            if (dateFin.HasValue)
            {
                query += " AND c.DateConsultation <= @DateFin";
                parameters.Add(new SqlParameter("@DateFin", dateFin.Value));
            }

            query += " ORDER BY c.DateConsultation DESC";

            using (var connection = DbConnexion.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();

                foreach (var param in parameters)
                {
                    command.Parameters.Add(param);
                }

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        consultations.Add(MapFromReader(reader));
                    }
                }
            }

            return consultations;
        }
        // Helper method
        private Consultation MapFromReader(SqlDataReader reader)
        {
            return new Consultation
            {
                Id = Convert.ToInt32(reader["Id"]),
                PatientId = Convert.ToInt32(reader["PatientId"]),
                MedecinId = Convert.ToInt32(reader["MedecinId"]),
                RendezVousId = reader["RendezVousId"] as int?,
                DateConsultation = Convert.ToDateTime(reader["DateConsultation"]),
                Poids = reader["Poids"] as decimal?,
                Taille = reader["Taille"] as decimal?,
                Temperature = reader["Temperature"] as decimal?,
                PressionArterielle = reader["PressionArterielle"] as string,
                Pouls = reader["Pouls"] as int?,
                MotifConsultation = reader["MotifConsultation"].ToString(),
                Observations = reader["Observations"] as string,
                Diagnostic = reader["Diagnostic"] as string,
                CodeCIM10 = reader["CodeCIM10"] as string,
                TraitementPrescrit = reader["TraitementPrescrit"] as string,
                Recommandations = reader["Recommandations"] as string,
                DateProchaineVisite = reader["DateProchaineVisite"] as DateTime?
            };
        }
    }
}
