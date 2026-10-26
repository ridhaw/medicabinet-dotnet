# MediCabinet — gestion de cabinet médical (C# / WinForms)

Application de bureau Windows pour la gestion d'un cabinet médical : patients,
rendez-vous, consultations et prescriptions, avec authentification et gestion des
utilisateurs.

## Fonctionnalités

- Connexion des utilisateurs et gestion des comptes (création, modification)
- Dossier patient : création, recherche, fiche profil
- Rendez-vous : planification et sélection
- Consultations liées à un rendez-vous
- Prescriptions : saisie, détail, liste par consultation

## Architecture

Organisation en couches de type MVC :

```
Models/            entités (Patient, RendezVous, Consultation, Prescription, Utilisateur)
Models/ADO/        accès aux données ADO.NET, une classe par entité
Models/Database/   DbConnexion — connexion SQL Server
Controllers/       logique métier et validations, renvoient un OperationResult
Views/Forms/       écrans WinForms (frmLogin, frmMain, frmPatientProfil, …)
```

## Stack

C# · .NET Framework 4.7.2 · Windows Forms · ADO.NET · SQL Server Express

## Lancer

1. Ouvrir `MediCabinet.sln` dans Visual Studio.
2. Créer la base `MediCabinetDB` sur l'instance `.\SQLEXPRESS`
   (chaîne de connexion dans `Models/Database/DbConnexion.cs`, authentification Windows).
3. Démarrer le projet (F5).
