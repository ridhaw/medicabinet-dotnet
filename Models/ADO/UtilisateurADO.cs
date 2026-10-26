using global::MediCabinet.Models.Database;
using MediCabinet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MediCabinet.Models.ADO
{
    public class UtilisateurADO
    {
        // CREATE - Ajouter un utilisateur
        public int AjouterUtilisateur(Utilisateur utilisateur)
        {
            string query = @"
            INSERT INTO Utilisateurs 
            (Username, PasswordHash, Nom, Prenom, Role, Specialite, 
             Email, Telephone, EstActif)
            VALUES 
            (@Username, @PasswordHash, @Nom, @Prenom, @Role, @Specialite,
             @Email, @Telephone, @EstActif);
            SELECT SCOPE_IDENTITY();";

            using (var connection = DbConnexion.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@Username", utilisateur.Username);
                command.Parameters.AddWithValue("@PasswordHash", utilisateur.PasswordHash); // Stocké en clair
                command.Parameters.AddWithValue("@Nom", utilisateur.Nom);
                command.Parameters.AddWithValue("@Prenom", utilisateur.Prenom);
                command.Parameters.AddWithValue("@Role", utilisateur.Role);
                command.Parameters.AddWithValue("@Specialite", utilisateur.Specialite ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Email", utilisateur.Email ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Telephone", utilisateur.Telephone ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@EstActif", utilisateur.EstActif);

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        // READ - Récupérer tous les utilisateurs actifs
        public List<Utilisateur> GetAllUtilisateurs()
        {
            var utilisateurs = new List<Utilisateur>();
            string query = "SELECT * FROM Utilisateurs WHERE EstActif = 1 ORDER BY Nom, Prenom";

            using (var connection = DbConnexion.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        utilisateurs.Add(MapFromReader(reader));
                    }
                }
            }

            return utilisateurs;
        }

        // READ - Récupérer un utilisateur par ID
        public Utilisateur GetUtilisateurById(int id)
        {
            string query = "SELECT * FROM Utilisateurs WHERE Id = @Id";

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

        // READ - Récupérer un utilisateur par username
        public Utilisateur GetUtilisateurByUsername(string username)
        {
            string query = "SELECT * FROM Utilisateurs WHERE Username = @Username AND EstActif = 1";

            using (var connection = DbConnexion.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@Username", username);

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

        // READ - Récupérer les médecins seulement
        public List<Utilisateur> GetMedecins()
        {
            var medecins = new List<Utilisateur>();
            string query = "SELECT * FROM Utilisateurs WHERE Role = 'Medecin' AND EstActif = 1 ORDER BY Nom, Prenom";

            using (var connection = DbConnexion.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        medecins.Add(MapFromReader(reader));
                    }
                }
            }

            return medecins;
        }

        // READ - Vérifier les identifiants de connexion (SANS HASH)
        public Utilisateur Authentifier(string username, string password)
        {
            string query = "SELECT * FROM Utilisateurs WHERE Username = @Username AND PasswordHash = @Password AND EstActif = 1";

            using (var connection = DbConnexion.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password); // Comparaison directe

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

        // UPDATE - Modifier un utilisateur
        public bool UpdateUtilisateur(Utilisateur utilisateur)
        {
            string query = @"
            UPDATE Utilisateurs SET
            Username = @Username,
            Nom = @Nom,
            Prenom = @Prenom,
            Role = @Role,
            Specialite = @Specialite,
            Email = @Email,
            Telephone = @Telephone
            WHERE Id = @Id";

            using (var connection = DbConnexion.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@Id", utilisateur.Id);
                command.Parameters.AddWithValue("@Username", utilisateur.Username);
                command.Parameters.AddWithValue("@Nom", utilisateur.Nom);
                command.Parameters.AddWithValue("@Prenom", utilisateur.Prenom);
                command.Parameters.AddWithValue("@Role", utilisateur.Role);
                command.Parameters.AddWithValue("@Specialite", utilisateur.Specialite ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Email", utilisateur.Email ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Telephone", utilisateur.Telephone ?? (object)DBNull.Value);

                return command.ExecuteNonQuery() > 0;
            }
        }

        // UPDATE - Changer le mot de passe (stocké en clair)
        public bool ChangePassword(int userId, string newPassword)
        {
            string query = "UPDATE Utilisateurs SET PasswordHash = @PasswordHash WHERE Id = @Id";

            using (var connection = DbConnexion.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@Id", userId);
                command.Parameters.AddWithValue("@PasswordHash", newPassword); // En clair

                return command.ExecuteNonQuery() > 0;
            }
        }

        // DELETE - Désactiver un utilisateur (soft delete)
        public bool DeleteUtilisateur(int id)
        {
            string query = "UPDATE Utilisateurs SET EstActif = 0 WHERE Id = @Id";

            using (var connection = DbConnexion.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@Id", id);
                return command.ExecuteNonQuery() > 0;
            }
        }

        // Vérifier si un username existe déjà
        public bool UsernameExists(string username, int? excludeUserId = null)
        {
            string query = "SELECT COUNT(*) FROM Utilisateurs WHERE Username = @Username";

            if (excludeUserId.HasValue)
            {
                query += " AND Id != @ExcludeId";
            }

            using (var connection = DbConnexion.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@Username", username);

                if (excludeUserId.HasValue)
                {
                    command.Parameters.AddWithValue("@ExcludeId", excludeUserId.Value);
                }

                return Convert.ToInt32(command.ExecuteScalar()) > 0;
            }
        }

        public List<Utilisateur> RechercherUtilisateurs(string recherche = "", string role = "")
        {
            var utilisateurs = new List<Utilisateur>();

            string query = @"SELECT * FROM Utilisateurs 
                WHERE EstActif = 1 
                AND (@Role = '' OR Role = @Role)
                AND (@Recherche = '' OR 
                    Username LIKE @RecherchePattern OR 
                    Nom LIKE @RecherchePattern OR 
                    Prenom LIKE @RecherchePattern OR 
                    Email LIKE @RecherchePattern)
                ORDER BY Nom, Prenom";

            using (var connection = DbConnexion.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@Role", string.IsNullOrEmpty(role) ? "" : role);
                command.Parameters.AddWithValue("@Recherche", string.IsNullOrEmpty(recherche) ? "" : recherche);
                command.Parameters.AddWithValue("@RecherchePattern", string.IsNullOrEmpty(recherche) ? "" : $"%{recherche}%");

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        utilisateurs.Add(MapFromReader(reader));
                    }
                }
            }

            return utilisateurs;
        }

        // Vérifier si un utilisateur existe
        public bool UtilisateurExiste(string username)
        {
            return UsernameExists(username);
        }

        // Helper method to map SqlDataReader to Utilisateur object
        private Utilisateur MapFromReader(SqlDataReader reader)
        {
            return new Utilisateur
            {
                Id = Convert.ToInt32(reader["Id"]),
                Username = reader["Username"].ToString(),
                PasswordHash = reader["PasswordHash"].ToString(), // Maintenant en clair
                Nom = reader["Nom"].ToString(),
                Prenom = reader["Prenom"].ToString(),
                Role = reader["Role"].ToString(),
                Specialite = reader["Specialite"] as string,
                Email = reader["Email"] as string,
                Telephone = reader["Telephone"] as string,
                EstActif = Convert.ToBoolean(reader["EstActif"]),
                DateCreation = Convert.ToDateTime(reader["DateCreation"])
            };
        }
    }
}