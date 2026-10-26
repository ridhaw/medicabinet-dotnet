using MediCabinet.Models.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCabinet.Models.ADO
{
    public class RendezVousADO
    {
        // CREATE - Ajouter un rendez-vous
        public int AjouterRendezVous(RendezVous rdv)
        {
            string query = @"
                INSERT INTO RendezVous 
                (PatientId, MedecinId, DateRendezVous, HeureDebut, HeureFin, 
                 TypeConsultation, Motif, Statut, Priorite, Notes)
                VALUES 
                (@PatientId, @MedecinId, @DateRendezVous, @HeureDebut, @HeureFin, 
                 @TypeConsultation, @Motif, @Statut, @Priorite, @Notes);
                SELECT SCOPE_IDENTITY();";

            using (var connection = DbConnexion.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@PatientId", rdv.PatientId);
                command.Parameters.AddWithValue("@MedecinId", rdv.MedecinId);
                command.Parameters.AddWithValue("@DateRendezVous", rdv.DateRendezVous);
                command.Parameters.AddWithValue("@HeureDebut", rdv.HeureDebut);
                command.Parameters.AddWithValue("@HeureFin", rdv.HeureFin);
                command.Parameters.AddWithValue("@TypeConsultation", rdv.TypeConsultation);
                command.Parameters.AddWithValue("@Motif", rdv.Motif);
                command.Parameters.AddWithValue("@Statut", rdv.Statut);
                command.Parameters.AddWithValue("@Priorite", rdv.Priorite);
                command.Parameters.AddWithValue("@Notes", rdv.Notes ?? (object)DBNull.Value);

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        // READ - Récupérer les rendez-vous par date
        public List<RendezVous> GetRendezVousByDate(DateTime date, int? medecinId = null)
        {
            var rendezVousList = new List<RendezVous>();
            string query = @"
                SELECT rv.*, p.Nom + ' ' + p.Prenom as NomPatient, 
                       u.Nom + ' ' + u.Prenom as NomMedecin
                FROM RendezVous rv
                INNER JOIN Patients p ON rv.PatientId = p.Id
                INNER JOIN Utilisateurs u ON rv.MedecinId = u.Id
                WHERE CONVERT(DATE, rv.DateRendezVous) = @Date";

            if (medecinId.HasValue)
            {
                query += " AND rv.MedecinId = @MedecinId";
            }

            query += " ORDER BY rv.HeureDebut";

            using (var connection = DbConnexion.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@Date", date.Date);

                if (medecinId.HasValue)
                {
                    command.Parameters.AddWithValue("@MedecinId", medecinId.Value);
                }

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        rendezVousList.Add(MapFromReader(reader));
                    }
                }
            }

            return rendezVousList;
        }

        // READ - Récupérer les rendez-vous d'un patient
        public List<RendezVous> GetRendezVousByPatient(int patientId)
        {
            var rendezVousList = new List<RendezVous>();
            string query = @"
                SELECT rv.*, p.Nom + ' ' + p.Prenom as NomPatient, 
                       u.Nom + ' ' + u.Prenom as NomMedecin
                FROM RendezVous rv
                INNER JOIN Patients p ON rv.PatientId = p.Id
                INNER JOIN Utilisateurs u ON rv.MedecinId = u.Id
                WHERE rv.PatientId = @PatientId
                ORDER BY rv.DateRendezVous DESC, rv.HeureDebut";

            using (var connection = DbConnexion.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@PatientId", patientId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        rendezVousList.Add(MapFromReader(reader));
                    }
                }
            }

            return rendezVousList;
        }

        // UPDATE - Modifier le statut d'un rendez-vous
        public bool UpdateStatut(int rdvId, string statut)
        {
            string query = "UPDATE RendezVous SET Statut = @Statut WHERE Id = @Id";

            using (var connection = DbConnexion.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@Id", rdvId);
                command.Parameters.AddWithValue("@Statut", statut);

                return command.ExecuteNonQuery() > 0;
            }
        }

        // UPDATE - Modifier un rendez-vous
        public bool UpdateRendezVous(RendezVous rdv)
        {
            string query = @"
                UPDATE RendezVous SET
                PatientId = @PatientId,
                MedecinId = @MedecinId,
                DateRendezVous = @DateRendezVous,
                HeureDebut = @HeureDebut,
                HeureFin = @HeureFin,
                TypeConsultation = @TypeConsultation,
                Motif = @Motif,
                Statut = @Statut,
                Priorite = @Priorite,
                Notes = @Notes
                WHERE Id = @Id";

            using (var connection = DbConnexion.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@Id", rdv.Id);
                command.Parameters.AddWithValue("@PatientId", rdv.PatientId);
                command.Parameters.AddWithValue("@MedecinId", rdv.MedecinId);
                command.Parameters.AddWithValue("@DateRendezVous", rdv.DateRendezVous);
                command.Parameters.AddWithValue("@HeureDebut", rdv.HeureDebut);
                command.Parameters.AddWithValue("@HeureFin", rdv.HeureFin);
                command.Parameters.AddWithValue("@TypeConsultation", rdv.TypeConsultation);
                command.Parameters.AddWithValue("@Motif", rdv.Motif);
                command.Parameters.AddWithValue("@Statut", rdv.Statut);
                command.Parameters.AddWithValue("@Priorite", rdv.Priorite);
                command.Parameters.AddWithValue("@Notes", rdv.Notes ?? (object)DBNull.Value);

                return command.ExecuteNonQuery() > 0;
            }
        }

        // DELETE - Supprimer un rendez-vous
        public bool DeleteRendezVous(int id)
        {
            string query = "DELETE FROM RendezVous WHERE Id = @Id";

            using (var connection = DbConnexion.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@Id", id);
                return command.ExecuteNonQuery() > 0;
            }
        }

        // Vérifier la disponibilité d'un créneau
        public bool IsCreneauDisponible(int medecinId, DateTime date, TimeSpan heureDebut, TimeSpan heureFin, int? excludeRdvId = null)
        {
            string query = @"
                SELECT COUNT(*) FROM RendezVous 
                WHERE MedecinId = @MedecinId 
                AND CONVERT(DATE, DateRendezVous) = @Date
                AND Statut != 'Annule'
                AND ((HeureDebut < @HeureFin AND HeureFin > @HeureDebut) OR
                     (HeureDebut = @HeureDebut))";

            if (excludeRdvId.HasValue)
            {
                query += " AND Id != @ExcludeId";
            }

            using (var connection = DbConnexion.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@MedecinId", medecinId);
                command.Parameters.AddWithValue("@Date", date.Date);
                command.Parameters.AddWithValue("@HeureDebut", heureDebut);
                command.Parameters.AddWithValue("@HeureFin", heureFin);

                if (excludeRdvId.HasValue)
                {
                    command.Parameters.AddWithValue("@ExcludeId", excludeRdvId.Value);
                }

                return Convert.ToInt32(command.ExecuteScalar()) == 0;
            }
        }
        // Ajoutez cette méthode dans votre classe RendezVousADO
        public RendezVous GetRendezVousById(int rdvId)
        {
            RendezVous rendezVous = null;

            string query = @"
        SELECT r.*, 
               p.Nom + ' ' + p.Prenom as NomPatient,
               u.Nom + ' ' + u.Prenom as NomMedecin
        FROM RendezVous r
        INNER JOIN Patients p ON r.PatientId = p.Id
        INNER JOIN Utilisateurs u ON r.MedecinId = u.Id
        WHERE r.Id = @RdvId";

            using (var connection = DbConnexion.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@RdvId", rdvId);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        rendezVous = new RendezVous
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            PatientId = Convert.ToInt32(reader["PatientId"]),
                            MedecinId = Convert.ToInt32(reader["MedecinId"]),
                            DateRendezVous = Convert.ToDateTime(reader["DateRendezVous"]),
                            HeureDebut = (TimeSpan)reader["HeureDebut"],
                            HeureFin = (TimeSpan)reader["HeureFin"],
                            TypeConsultation = reader["TypeConsultation"].ToString(),
                            Motif = reader["Motif"].ToString(),
                            Statut = reader["Statut"].ToString(),
                            Priorite = reader["Priorite"].ToString(),
                            Notes = reader["Notes"] as string,
                            DateCreation = Convert.ToDateTime(reader["DateCreation"]),
                            NomPatient = reader["NomPatient"].ToString(),
                            NomMedecin = reader["NomMedecin"].ToString()
                        };
                    }
                }
            }

            return rendezVous;
        }
        // Helper method
        private RendezVous MapFromReader(SqlDataReader reader)
        {
            return new RendezVous
            {
                Id = Convert.ToInt32(reader["Id"]),
                PatientId = Convert.ToInt32(reader["PatientId"]),
                MedecinId = Convert.ToInt32(reader["MedecinId"]),
                DateRendezVous = Convert.ToDateTime(reader["DateRendezVous"]),
                HeureDebut = (TimeSpan)reader["HeureDebut"],
                HeureFin = (TimeSpan)reader["HeureFin"],
                TypeConsultation = reader["TypeConsultation"].ToString(),
                Motif = reader["Motif"].ToString(),
                Statut = reader["Statut"].ToString(),
                Priorite = reader["Priorite"].ToString(),
                Notes = reader["Notes"] as string,
                DateCreation = Convert.ToDateTime(reader["DateCreation"]),
                NomPatient = reader["NomPatient"].ToString(),
                NomMedecin = reader["NomMedecin"].ToString()
            };
        }
    }
}
