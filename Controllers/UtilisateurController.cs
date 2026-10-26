using MediCabinet.Models;
using MediCabinet.Models.ADO;
using System;
using System.Collections.Generic;

namespace MediCabinet.Controllers
{
    public class UtilisateurController
    {
        private readonly UtilisateurADO _utilisateurADO;

        public UtilisateurController()
        {
            _utilisateurADO = new UtilisateurADO();
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

        // Pas de méthode HashPassword nécessaire

        // Rechercher des utilisateurs
        public List<Utilisateur> RechercherUtilisateurs(string recherche = "", string role = "")
        {
            try
            {
                return _utilisateurADO.RechercherUtilisateurs(recherche, role);
            }
            catch (Exception)
            {
                return new List<Utilisateur>();
            }
        }

        // Authentification (SANS HASH)
        public OperationResult Authentifier(string username, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                    return new OperationResult(false, "Veuillez saisir un nom d'utilisateur et un mot de passe");

                // Appel direct avec le mot de passe en clair
                var utilisateur = _utilisateurADO.Authentifier(username, password);

                if (utilisateur != null)
                {
                    return new OperationResult(true, "Authentification réussie", utilisateur);
                }

                return new OperationResult(false, "Nom d'utilisateur ou mot de passe incorrect");
            }
            catch (Exception ex)
            {
                return new OperationResult(false, $"Erreur d'authentification: {ex.Message}");
            }
        }

        // Ajouter un utilisateur
        public OperationResult AjouterUtilisateur(Utilisateur utilisateur, string password)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(utilisateur.Username))
                    return new OperationResult(false, "Le nom d'utilisateur est obligatoire");

                if (string.IsNullOrWhiteSpace(password))
                    return new OperationResult(false, "Le mot de passe est obligatoire");

                if (string.IsNullOrWhiteSpace(utilisateur.Nom))
                    return new OperationResult(false, "Le nom est obligatoire");

                if (string.IsNullOrWhiteSpace(utilisateur.Prenom))
                    return new OperationResult(false, "Le prénom est obligatoire");

                if (string.IsNullOrWhiteSpace(utilisateur.Role))
                    return new OperationResult(false, "Le rôle est obligatoire");

                // Vérifier les rôles valides
                if (utilisateur.Role != "Medecin" && utilisateur.Role != "Secretaire" && utilisateur.Role != "Admin")
                    return new OperationResult(false, "Rôle invalide. Choisir parmi: Medecin, Secretaire, Admin");

                // Vérifier si le username existe déjà
                if (_utilisateurADO.UsernameExists(utilisateur.Username))
                    return new OperationResult(false, "Ce nom d'utilisateur existe déjà");

                // Stocker le mot de passe en clair
                utilisateur.PasswordHash = password; // Pas de hash
                utilisateur.EstActif = true;

                // Ajouter l'utilisateur
                int userId = _utilisateurADO.AjouterUtilisateur(utilisateur);

                return new OperationResult(true, "Utilisateur ajouté avec succès", userId);
            }
            catch (Exception ex)
            {
                return new OperationResult(false, $"Erreur: {ex.Message}");
            }
        }

        // Ajouter un utilisateur (surcharge)
        public OperationResult AjouterUtilisateur(Utilisateur utilisateur)
        {
            // Si un mot de passe temporaire est fourni dans l'objet
            if (!string.IsNullOrWhiteSpace(utilisateur.PasswordHash))
            {
                return AjouterUtilisateur(utilisateur, utilisateur.PasswordHash);
            }
            else
            {
                return new OperationResult(false, "Le mot de passe est obligatoire");
            }
        }

        // Modifier un utilisateur
        public OperationResult ModifierUtilisateur(Utilisateur utilisateur)
        {
            try
            {
                if (utilisateur.Id <= 0)
                    return new OperationResult(false, "Utilisateur invalide");

                // Vérifier les rôles valides
                if (utilisateur.Role != "Medecin" && utilisateur.Role != "Secretaire" && utilisateur.Role != "Admin")
                    return new OperationResult(false, "Rôle invalide. Choisir parmi: Medecin, Secretaire, Admin");

                // Vérifier si le username existe déjà (pour un autre utilisateur)
                if (_utilisateurADO.UsernameExists(utilisateur.Username, utilisateur.Id))
                    return new OperationResult(false, "Ce nom d'utilisateur est déjà utilisé par un autre utilisateur");

                // Ne pas modifier le mot de passe ici
                // Récupérer l'utilisateur existant pour garder le mot de passe
                var existingUser = _utilisateurADO.GetUtilisateurById(utilisateur.Id);
                if (existingUser != null)
                {
                    utilisateur.PasswordHash = existingUser.PasswordHash;
                    utilisateur.EstActif = existingUser.EstActif;
                    utilisateur.DateCreation = existingUser.DateCreation;
                }

                bool success = _utilisateurADO.UpdateUtilisateur(utilisateur);

                return success ?
                    new OperationResult(true, "Utilisateur modifié avec succès") :
                    new OperationResult(false, "Échec de la modification");
            }
            catch (Exception ex)
            {
                return new OperationResult(false, $"Erreur: {ex.Message}");
            }
        }

        // Changer le mot de passe (stocké en clair)
        public OperationResult ChangerMotDePasse(int userId, string ancienMotDePasse, string nouveauMotDePasse)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nouveauMotDePasse))
                    return new OperationResult(false, "Le nouveau mot de passe est obligatoire");

                if (nouveauMotDePasse.Length < 6)
                    return new OperationResult(false, "Le mot de passe doit contenir au moins 6 caractères");

                // Vérifier l'ancien mot de passe
                var utilisateur = _utilisateurADO.GetUtilisateurById(userId);
                if (utilisateur == null)
                    return new OperationResult(false, "Utilisateur non trouvé");

                // Comparaison directe (sans hash)
                if (ancienMotDePasse != utilisateur.PasswordHash)
                    return new OperationResult(false, "Ancien mot de passe incorrect");

                // Changer le mot de passe (en clair)
                bool success = _utilisateurADO.ChangePassword(userId, nouveauMotDePasse);

                return success ?
                    new OperationResult(true, "Mot de passe changé avec succès") :
                    new OperationResult(false, "Échec du changement de mot de passe");
            }
            catch (Exception ex)
            {
                return new OperationResult(false, $"Erreur: {ex.Message}");
            }
        }

        // Supprimer un utilisateur
        public OperationResult SupprimerUtilisateur(int userId)
        {
            try
            {
                if (userId <= 0)
                    return new OperationResult(false, "Utilisateur invalide");

                // Empêcher la suppression de l'admin principal
                if (userId == 1)
                    return new OperationResult(false, "Impossible de supprimer l'administrateur principal");

                bool success = _utilisateurADO.DeleteUtilisateur(userId);

                return success ?
                    new OperationResult(true, "Utilisateur désactivé avec succès") :
                    new OperationResult(false, "Échec de la désactivation");
            }
            catch (Exception ex)
            {
                return new OperationResult(false, $"Erreur: {ex.Message}");
            }
        }

        // Récupérer tous les utilisateurs
        public List<Utilisateur> GetTousLesUtilisateurs()
        {
            try
            {
                return _utilisateurADO.GetAllUtilisateurs();
            }
            catch
            {
                return new List<Utilisateur>();
            }
        }

        // Récupérer tous les médecins
        public List<Utilisateur> GetMedecins()
        {
            try
            {
                return _utilisateurADO.GetMedecins();
            }
            catch
            {
                return new List<Utilisateur>();
            }
        }

        // Récupérer un utilisateur par ID
        public Utilisateur GetUtilisateurParId(int id)
        {
            try
            {
                return _utilisateurADO.GetUtilisateurById(id);
            }
            catch
            {
                return null;
            }
        }

        // Récupérer un utilisateur par username
        public Utilisateur GetUtilisateurParUsername(string username)
        {
            try
            {
                return _utilisateurADO.GetUtilisateurByUsername(username);
            }
            catch
            {
                return null;
            }
        }
    }
}