using MediCabinet.Models.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCabinet.Models.ADO
{
    public class PatientADO
    {
        // CREATE - Ajouter un patient
        public int AjouterPatient(Patient patient)
        {
            string query = @"
                INSERT INTO Patients 
                (NumeroSecuriteSociale, Nom, Prenom, DateNaissance, Sexe, Adresse, 
                 Ville, CodePostal, Telephone, Email, Mutuelle, NumeroMutuelle,
                 PersonneContact, TelContact, Allergies, Antecedents, GroupeSanguin, EstActif)
                VALUES 
                (@NSS, @Nom, @Prenom, @DateNaissance, @Sexe, @Adresse, 
                 @Ville, @CodePostal, @Telephone, @Email, @Mutuelle, @NumeroMutuelle,
                 @PersonneContact, @TelContact, @Allergies, @Antecedents, @GroupeSanguin, @EstActif);
                SELECT SCOPE_IDENTITY();";

            using (var connection = DbConnexion.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@NSS", patient.NumeroSecuriteSociale);
                command.Parameters.AddWithValue("@Nom", patient.Nom);
                command.Parameters.AddWithValue("@Prenom", patient.Prenom);
                command.Parameters.AddWithValue("@DateNaissance", patient.DateNaissance);
                command.Parameters.AddWithValue("@Sexe", patient.Sexe);
                command.Parameters.AddWithValue("@Adresse", patient.Adresse ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Ville", patient.Ville ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@CodePostal", patient.CodePostal ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Telephone", patient.Telephone ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Email", patient.Email ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Mutuelle", patient.Mutuelle ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@NumeroMutuelle", patient.NumeroMutuelle ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@PersonneContact", patient.PersonneContact ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@TelContact", patient.TelContact ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Allergies", patient.Allergies ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Antecedents", patient.Antecedents ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@GroupeSanguin", patient.GroupeSanguin ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@EstActif", patient.EstActif);

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        // READ - Récupérer tous les patients
        public List<Patient> GetAllPatients()
        {
            var patients = new List<Patient>();
            string query = "SELECT * FROM Patients WHERE EstActif = 1 ORDER BY Nom, Prenom";

            using (var connection = DbConnexion.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        patients.Add(MapFromReader(reader));
                    }
                }
            }

            return patients;
        }

        // READ - Rechercher patients
        public List<Patient> SearchPatients(string searchTerm)
        {
            var patients = new List<Patient>();
            string query = @"
                SELECT * FROM Patients 
                WHERE EstActif = 1 
                AND (Nom LIKE @Search OR 
                     Prenom LIKE @Search OR 
                     NumeroSecuriteSociale LIKE @Search OR
                     Telephone LIKE @Search OR
                     Email LIKE @Search)
                ORDER BY Nom, Prenom";

            using (var connection = DbConnexion.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@Search", $"%{searchTerm}%");

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        patients.Add(MapFromReader(reader));
                    }
                }
            }

            return patients;
        }

        // READ - Récupérer un patient par ID
        public Patient GetPatientById(int id)
        {
            string query = "SELECT * FROM Patients WHERE Id = @Id";

            using (var connection = DbConnexion.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return MapFromReader(reader);
                    }
                }
            }

            return null;
        }

        // UPDATE - Modifier un patient
        public bool UpdatePatient(Patient patient)
        {
            string query = @"
                UPDATE Patients SET
                NumeroSecuriteSociale = @NSS,
                Nom = @Nom,
                Prenom = @Prenom,
                DateNaissance = @DateNaissance,
                Sexe = @Sexe,
                Adresse = @Adresse,
                Ville = @Ville,
                CodePostal = @CodePostal,
                Telephone = @Telephone,
                Email = @Email,
                Mutuelle = @Mutuelle,
                NumeroMutuelle = @NumeroMutuelle,
                PersonneContact = @PersonneContact,
                TelContact = @TelContact,
                Allergies = @Allergies,
                Antecedents = @Antecedents,
                GroupeSanguin = @GroupeSanguin,
                DateModification = GETDATE()
                WHERE Id = @Id";

            using (var connection = DbConnexion.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@Id", patient.Id);
                command.Parameters.AddWithValue("@NSS", patient.NumeroSecuriteSociale);
                command.Parameters.AddWithValue("@Nom", patient.Nom);
                command.Parameters.AddWithValue("@Prenom", patient.Prenom);
                command.Parameters.AddWithValue("@DateNaissance", patient.DateNaissance);
                command.Parameters.AddWithValue("@Sexe", patient.Sexe);
                command.Parameters.AddWithValue("@Adresse", patient.Adresse ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Ville", patient.Ville ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@CodePostal", patient.CodePostal ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Telephone", patient.Telephone ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Email", patient.Email ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Mutuelle", patient.Mutuelle ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@NumeroMutuelle", patient.NumeroMutuelle ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@PersonneContact", patient.PersonneContact ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@TelContact", patient.TelContact ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Allergies", patient.Allergies ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Antecedents", patient.Antecedents ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@GroupeSanguin", patient.GroupeSanguin ?? (object)DBNull.Value);

                return command.ExecuteNonQuery() > 0;
            }
        }

        // DELETE - Supprimer un patient (soft delete)
        public bool DeletePatient(int id)
        {
            string query = "UPDATE Patients SET EstActif = 0 WHERE Id = @Id";

            using (var connection = DbConnexion.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@Id", id);
                return command.ExecuteNonQuery() > 0;
            }
        }

        // Méthode pour vérifier si un numéro de sécurité sociale existe déjà
        public bool NSSExists(string nss, int? excludePatientId = null)
        {
            string query = "SELECT COUNT(*) FROM Patients WHERE NumeroSecuriteSociale = @NSS";

            if (excludePatientId.HasValue)
            {
                query += " AND Id != @ExcludeId";
            }

            using (var connection = DbConnexion.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@NSS", nss);

                if (excludePatientId.HasValue)
                {
                    command.Parameters.AddWithValue("@ExcludeId", excludePatientId.Value);
                }

                return Convert.ToInt32(command.ExecuteScalar()) > 0;
            }
        }

        // Helper method to map SqlDataReader to Patient object
        private Patient MapFromReader(SqlDataReader reader)
        {
            return new Patient
            {
                Id = Convert.ToInt32(reader["Id"]),
                NumeroSecuriteSociale = reader["NumeroSecuriteSociale"].ToString(),
                Nom = reader["Nom"].ToString(),
                Prenom = reader["Prenom"].ToString(),
                DateNaissance = Convert.ToDateTime(reader["DateNaissance"]),
                Sexe = reader["Sexe"].ToString(),
                Adresse = reader["Adresse"] as string,
                Ville = reader["Ville"] as string,
                CodePostal = reader["CodePostal"] as string,
                Telephone = reader["Telephone"] as string,
                Email = reader["Email"] as string,
                Mutuelle = reader["Mutuelle"] as string,
                NumeroMutuelle = reader["NumeroMutuelle"] as string,
                PersonneContact = reader["PersonneContact"] as string,
                TelContact = reader["TelContact"] as string,
                Allergies = reader["Allergies"] as string,
                Antecedents = reader["Antecedents"] as string,
                GroupeSanguin = reader["GroupeSanguin"] as string,
                EstActif = Convert.ToBoolean(reader["EstActif"]),
                DateCreation = Convert.ToDateTime(reader["DateCreation"]),
                DateModification = reader["DateModification"] as DateTime?
            };
        }
    }
}
