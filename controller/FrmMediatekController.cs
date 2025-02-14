﻿using System;
using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.dal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Threading;

namespace MediaTekDocuments.controller
{
    /// <summary>
    /// Contrôleur lié à FrmMediatek
    /// </summary>
    class FrmMediatekController
    {
        #region Commun
        /// <summary>
        /// Objet d'accès aux données
        /// </summary>
        private readonly Access access;

        /// <summary>
        /// Récupération de l'instance unique d'accès aux données
        /// </summary>
        public FrmMediatekController()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// Getter sur la liste des genres
        /// </summary>
        /// <returns>Liste d'objets Genre</returns>
        public List<Categorie> GetAllGenres()
        {
            return access.GetAllGenres();
        }

        /// <summary>
        /// Getter sur les rayons
        /// </summary>
        /// <returns>Liste d'objets Rayon</returns>
        public List<Categorie> GetAllRayons()
        {
            return access.GetAllRayons();
        }

        /// <summary>
        /// Getter sur les publics
        /// </summary>
        /// <returns>Liste d'objets Public</returns>
        public List<Categorie> GetAllPublics()
        {
            return access.GetAllPublics();
        }

        /// <summary>
        /// Getter sur les suivis
        /// </summary>
        /// <returns></returns>
        public List<Suivi> GetAllSuivis()
        {
            return access.GetAllSuivis();
        }

          /// <summary>
          /// Getter sur les etats
          /// </summary>
          /// <returns></returns>
          public List<Etat> GetAllEtats()
        {
            return access.GetAllEtats();
        }

          /// <summary>
          /// Retourne vrai ou faux si le service de l'utilisateur est accepter
          /// </summary>
          /// <param name="utilisateur"></param>
          /// <returns></returns>
          public bool VerifDroitAccueil(Utilisateur utilisateur)
          {
               List<string> services = new List<string> { "compta", "biblio", "accueil" };
               if (services.Contains(utilisateur.Service.Libelle))
                    return true;
               return false;
          }
          /// <summary>
          /// Retourne vrai ou faux si le service de l'utilisateur est accepter
          /// </summary>
          /// <param name="utilisateur"></param>
          /// <returns></returns>
          public bool VerifDroitModif(Utilisateur utilisateur)
          {
               List<string> services = new List<string> { "biblio", "accueil" };
               if (services.Contains(utilisateur.Service.Libelle))
                    return true;
               return false;
          }
          /// <summary>
          /// Retourne vrai ou faux si le service de l'utilisateur
          /// est autorisé
          /// </summary>
          /// <param name="utilisateur"></param>
          /// <returns></returns>
          public bool VerifCommande(Utilisateur utilisateur)
          {
               List<string> services = new List<string> { "biblio" };
               if (services.Contains(utilisateur.Service.Libelle))
                    return true;
               return false;
          }

          /// <summary>
          /// Modification du convertisseur Json pour gérer le format de date
          /// </summary>
          private sealed class CustomDateTimeConverter : IsoDateTimeConverter
        {
            public CustomDateTimeConverter()
            {
                base.DateTimeFormat = "yyyy-MM-dd";
            }
        }
        #endregion


        #region Onglet Livres
        /// <summary>
        /// Getter sur la liste des livres
        /// </summary>
        /// <returns>Liste d'objets Livre</returns>
        public List<Livre> GetAllLivres()
        {
            return access.GetAllLivres();
        }

        /// <summary>
        /// Update un exemplaire dans la bdd
        /// </summary>
        /// <param name="exemplaire"></param>
        /// <returns></returns>
        public bool UpdateExemplaire(Exemplaire exemplaire)
        {
            return access.UpdateEntite("exemplaire", exemplaire.Id, JsonConvert.SerializeObject(exemplaire, new CustomDateTimeConverter()));
        }
        /// <summary>
        /// Supprime un exemplaire dans la bdd
        /// </summary>
        /// <param name="exemplaire"></param>
        /// <returns></returns>
        public bool SupprimerExemplaire(Exemplaire exemplaire)
        {
            return access.SupprimerEntite("exemplaire", JsonConvert.SerializeObject(exemplaire, new CustomDateTimeConverter()));
        }

        /// <summary>
        /// Ajouter un livre dans la BDD
        /// </summary>
        /// <param name="livre"></param>
        /// <returns>true si l'oppération est correcte</returns>
        public bool CreerLivre(Livre livre)
        {
            return access.CreerEntite("livre", JsonConvert.SerializeObject(livre));
        }

        /// <summary>
        /// Modifié un livre dans la BDD
        /// </summary>
        /// <param name="livre"></param>
        /// <returns>true si l'oppération est correcte</returns>
        public bool UpdateLivre(Livre livre)
        {
            return access.UpdateEntite("livre", livre.Id, JsonConvert.SerializeObject(livre));
        }

        /// <summary>
        /// Supprimé un livre dans la BDD
        /// </summary>
        /// <param name="livre"></param>
        /// <returns>true si l'oppération est correcte</returns>
        public bool SupprimerLivre(Livre livre)
        {
            return access.SupprimerEntite("livre", JsonConvert.SerializeObject(livre));
        }
        #endregion

        #region Onglet DvD
        /// <summary>
        /// Getter sur la liste des Dvd
        /// </summary>
        /// <returns>Liste d'objets dvd</returns>
        public List<Dvd> GetAllDvd()
        {
            return access.GetAllDvd();
        }

        /// <summary>
        /// Ajouter un dvd dans la BDD
        /// </summary>
        /// <param name="dvd"></param>
        /// <returns>true si l'oppération est correcte</returns>
        public bool CreerDvd(Dvd dvd)
        {
            return access.CreerEntite("dvd", JsonConvert.SerializeObject(dvd));
        }

        /// <summary>
        /// Modifié un dvd dans la BDD
        /// </summary>
        /// <param name="dvd"></param>
        /// <returns>true si l'oppération est correcte</returns>
        public bool UpdateDvd(Dvd dvd)
        {
            return access.UpdateEntite("dvd", dvd.Id, JsonConvert.SerializeObject(dvd));
        }

        /// <summary>
        /// Supprime un dvd dans la BDD
        /// </summary>
        /// <param name="dvd"></param>
        /// <returns>true si l'oppération est correcte</returns>
        public bool SupprimerDvd(Dvd dvd)
        {
            return access.SupprimerEntite("dvd", JsonConvert.SerializeObject(dvd));
        }
        #endregion

        #region Onglet Revues
        /// <summary>
        /// Getter sur la liste des revues
        /// </summary>
        /// <returns>Liste d'objets Revue</returns>
        public List<Revue> GetAllRevues()
        {
            return access.GetAllRevues();
        }

        /// <summary>
        /// Ajouter une revue dans la BDD
        /// </summary>
        /// <param name="revue"></param>
        /// <returns>true si l'oppération est correcte</returns>
        public bool CreerRevue(Revue revue)
        {
            return access.CreerEntite("revue", JsonConvert.SerializeObject(revue));
        }

        /// <summary>
        /// Modifie une revue dans la BDD
        /// </summary>
        /// <param name="revue"></param>
        /// <returns>true si l'oppération est correcte</returns>
        public bool UpdateRevue(Revue revue)
        {
            return access.UpdateEntite("revue", revue.Id, JsonConvert.SerializeObject(revue));
        }

        /// <summary>
        /// Supprime une revue dans la BDD
        /// </summary>
        /// <param name="revue"></param>
        /// <returns>true si l'oppération est correcte</returns>
        public bool SupprimerRevue(Revue revue)
        {
            return access.SupprimerEntite("revue", JsonConvert.SerializeObject(revue));
        }
        #endregion

        #region Onglet Parutions
        /// <summary>
        /// Récupère les exemplaires d'une revue
        /// </summary>
        /// <param name="idDocuement"></param>
        /// <returns>Liste d'objets Exemplaire</returns>
        public List<Exemplaire> GetExemplairesRevue(string idDocuement)
        {
            return access.GetExemplairesRevue(idDocuement);
        }

        /// <summary>
        /// Ajouter un exemplaire d'une revue dans la BDD
        /// </summary>
        /// <param name="exemplaire"></param>
        /// <returns>True si l'opération est correcte</returns>
        public bool CreerExemplaire(Exemplaire exemplaire)
        {
            return access.CreerExemplaire(exemplaire);
        }
        #endregion

        #region Commandes de livres et Dvd
        /// <summary>
        /// Récupère les commandes d'une livre
        /// </summary>
        /// <param name="idLivre">id du livre</param>
        /// <returns></returns>
        public List<CommandeDocument> GetCommandesLivres(string idLivre)
        {
            return access.GetCommandesLivres(idLivre);
        }

        /// <summary>
        /// Retourne l'id max des commandes
        /// </summary>
        /// <returns></returns>
        public string GetNbCommandeMax()
        {
            return access.GetMaxIndex("maxcommande");
        }

        /// <summary>
        /// Retourne l'id max des livres
        /// </summary>
        /// <returns></returns>
        public string getNbLivreMax()
        {
            return access.GetMaxIndex("maxlivre");
        }

        /// <summary>
        /// Retourne l'id max des Dvd
        /// </summary>
        /// <returns></returns>
        public string GetNbDvdMax()
        {
            return access.GetMaxIndex("maxdvd");
        }

        /// <summary>
        /// Retourne l'id max des revues
        /// </summary>
        /// <returns></returns>
        public string GetNbRevueMax()
        {
            return access.GetMaxIndex("maxrevue");
        }

        /// <summary>
        /// Requêtes post update delete concernant une commande de livre ou dvd
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nbExemplaire"></param>
        /// <param name="idLivreDvd"></param>
        /// <param name="idsuivi"></param>
        /// <param name="verbose"></param>
        /// <returns></returns>
        public bool utilCommandeDocument(string id, DateTime dateCommande, double montant, int nbExemplaire,
            string idLivreDvd, int idsuivi, string etat, string verbose)
        {
            Dictionary<string, object> uneCommandeDocument = new Dictionary<string, object>();
            uneCommandeDocument.Add("Id", id);
            uneCommandeDocument.Add("DateCommande", dateCommande.ToString("yyyy-MM-dd"));
            uneCommandeDocument.Add("Montant", montant);
            uneCommandeDocument.Add("NbExemplaire", nbExemplaire);
            uneCommandeDocument.Add("IdLivreDvd", idLivreDvd);
            uneCommandeDocument.Add("IdSuivi", idsuivi);
            uneCommandeDocument.Add("Etat", etat);

            if (verbose == "post")
                return access.CreerEntite("commandedocument", JsonConvert.SerializeObject(uneCommandeDocument));
            if (verbose == "update")
                return access.UpdateEntite("commandedocument", id, JsonConvert.SerializeObject(uneCommandeDocument));
            if (verbose == "delete")
                return access.SupprimerEntite("commandedocument", JsonConvert.SerializeObject(uneCommandeDocument));
            return false;
        }

        /// <summary>
        /// Ajouter une commande livre, Dvd dans la BDD
        /// </summary>
        /// <param name="commandeLivreDvd"></param>
        /// <returns></returns>
        public bool CreerLivreDvdCom(CommandeDocument commandeLivreDvd)
        {
            return utilCommandeDocument(commandeLivreDvd.Id, commandeLivreDvd.DateCommande, commandeLivreDvd.Montant, commandeLivreDvd.NbExemplaire ?? 0,
                    commandeLivreDvd.IdLivreDvd, commandeLivreDvd.IdSuivi ?? 0, commandeLivreDvd.Etat, "post");
        }


        /// <summary>
        /// Modifie une commande livre, Dvd dans la BDD
        /// </summary>
        /// <param name="commandeLivreDvd"></param>
        /// <returns></returns>
        public bool UpdateLivreDvdCom(CommandeDocument commandeLivreDvd)
        {
            return utilCommandeDocument(commandeLivreDvd.Id, commandeLivreDvd.DateCommande, commandeLivreDvd.Montant, commandeLivreDvd.NbExemplaire ?? 0,
                   commandeLivreDvd.IdLivreDvd, commandeLivreDvd.IdSuivi ?? 0, commandeLivreDvd.Etat, "update");
        }

        /// <summary>
        /// Supprime une commande livre,Dvd dans la BDD
        /// </summary>
        /// <param name="commandeLivreDvd"></param>
        /// <returns></returns>
        public bool SupprimerLivreDvdCom(CommandeDocument commandeLivreDvd)
        {
            return utilCommandeDocument(commandeLivreDvd.Id, commandeLivreDvd.DateCommande, commandeLivreDvd.Montant, commandeLivreDvd.NbExemplaire ?? 0,
                   commandeLivreDvd.IdLivreDvd, commandeLivreDvd.IdSuivi ?? 0, commandeLivreDvd.Etat, "delete");
        }
        #endregion

        #region abonnements
        /// <summary>
        /// Retourne tous les abonnements d'une revue
        /// </summary>
        /// <param name="idRevue"></param>
        /// <returns></returns>
        public List<Abonnement> GetAbonnements(string idRevue)
        {
            return access.GetAbonnements(idRevue);
        }
        /// <summary>
        /// Requêtes post update delete d'un abonnement
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dateCommande"></param>
        /// <param name="montant"></param>
        /// <param name="dateFinAbonnement"></param>
        /// <param name="idRevue"></param>
        /// <param name="verbose"></param>
        /// <returns></returns>
        public bool utilAbonnement(string id, DateTime dateCommande, double montant, DateTime dateFinAbonnement, string idRevue, string verbose)
        {
            Dictionary<string, object> unAbonnement = new Dictionary<string, object>();
            unAbonnement.Add("Id", id);
            unAbonnement.Add("DateCommande", dateCommande.ToString("yyyy-MM-dd"));
            unAbonnement.Add("Montant", montant);
            unAbonnement.Add("DateFinAbonnement", dateFinAbonnement.ToString("yyyy-MM-dd"));
            unAbonnement.Add("IdRevue", idRevue);
            if (verbose == "post")
                return access.CreerEntite("abonnement", JsonConvert.SerializeObject(unAbonnement));
            if (verbose == "update")
                return access.UpdateEntite("abonnement", id, JsonConvert.SerializeObject(unAbonnement));
            if (verbose == "delete")
                return access.SupprimerEntite("abonnement", JsonConvert.SerializeObject(unAbonnement));
            return false;
        }
        /// <summary>
        /// Ajouter un abonnement dans la BDD
        /// </summary>
        /// <param name="commandeLivreDvd"></param>
        /// <returns></returns>
        public bool CreerAbonnement(Abonnement abonnement)
        {
            return utilAbonnement(abonnement.Id, abonnement.DateCommande, abonnement.Montant, abonnement.DateFinAbonnement, abonnement.IdRevue, "post");
        }

        /// <summary>
        /// Modifier un abonnement dans la BDD
        /// </summary>
        /// <param name="commandeLivreDvd"></param>
        /// <returns></returns>
        public bool UpdateAbonnement(Abonnement abonnement)
        {
            return utilAbonnement(abonnement.Id, abonnement.DateCommande, abonnement.Montant, abonnement.DateFinAbonnement, abonnement.IdRevue, "update");
        }
        /// <summary>
        /// Supprimer un abonnement dans la BDD
        /// </summary>
        /// <param name="abonnement"></param>
        /// <returns></returns>
        public bool SupprimerAbonnement(Abonnement abonnement)
        {
            return utilAbonnement(abonnement.Id, abonnement.DateCommande, abonnement.Montant, abonnement.DateFinAbonnement, abonnement.IdRevue, "delete");
        }
        #endregion

    }
}