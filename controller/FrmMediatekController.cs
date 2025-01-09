using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.dal;
using Newtonsoft.Json;
using System.Threading;

namespace MediaTekDocuments.controller
{
    /// <summary>
    /// Contrôleur lié à FrmMediatek
    /// </summary>
    class FrmMediatekController
    {
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
        /// getter sur la liste des genres
        /// </summary>
        /// <returns>Liste d'objets Genre</returns>
        public List<Categorie> GetAllGenres()
        {
            return access.GetAllGenres();
        }

        /// <summary>
        /// getter sur la liste des livres
        /// </summary>
        /// <returns>Liste d'objets Livre</returns>
        public List<Livre> GetAllLivres()
        {
            return access.GetAllLivres();
        }

        /// <summary>
        /// getter sur la liste des Dvd
        /// </summary>
        /// <returns>Liste d'objets dvd</returns>
        public List<Dvd> GetAllDvd()
        {
            return access.GetAllDvd();
        }

        /// <summary>
        /// getter sur la liste des revues
        /// </summary>
        /// <returns>Liste d'objets Revue</returns>
        public List<Revue> GetAllRevues()
        {
            return access.GetAllRevues();
        }

        /// <summary>
        /// getter sur les rayons
        /// </summary>
        /// <returns>Liste d'objets Rayon</returns>
        public List<Categorie> GetAllRayons()
        {
            return access.GetAllRayons();
        }

        /// <summary>
        /// getter sur les publics
        /// </summary>
        /// <returns>Liste d'objets Public</returns>
        public List<Categorie> GetAllPublics()
        {
            return access.GetAllPublics();
        }


        /// <summary>
        /// récupère les exemplaires d'une revue
        /// </summary>
        /// <param name="idDocuement">id de la revue concernée</param>
        /// <returns>Liste d'objets Exemplaire</returns>
        public List<Exemplaire> GetExemplairesRevue(string idDocuement)
        {
            return access.GetExemplairesRevue(idDocuement);
        }

        /// <summary>
        /// Crée un exemplaire d'une revue dans la bdd
        /// </summary>
        /// <param name="exemplaire">L'objet Exemplaire concerné</param>
        /// <returns>True si la création a pu se faire</returns>
        public bool CreerExemplaire(Exemplaire exemplaire)
        {
            return access.CreerExemplaire(exemplaire);
        }

        /// <summary>
        /// Ajouter un livre dans la BDD
        /// </summary>
        /// <param name="livre"></param>
        /// <returns>true si oppration correcte</returns>
        public bool CreerLivre(Livre livre)
        {
            bool validateur = true;
            Dictionary<string, string> dicDocument = new Dictionary<string, string>();
            dicDocument.Add("id", livre.Id);
            dicDocument.Add("titre", livre.Titre);
            dicDocument.Add("idGenre", livre.IdGenre);
            dicDocument.Add("idPublic", livre.IdPublic);
            dicDocument.Add("idRayon", livre.IdRayon);
            dicDocument.Add("image", livre.Image);
            if (!access.CreerDocument(JsonConvert.SerializeObject(dicDocument)))
                validateur = false;

            Dictionary<string, string> dicLivreDvd = new Dictionary<string, string>();
            dicLivreDvd.Add("id", livre.Id);
            if (!access.CreerLivreDvd(JsonConvert.SerializeObject(dicLivreDvd)))
                validateur = false;

            Dictionary<string, string> unLivre = new Dictionary<string, string>();
            unLivre.Add("id", livre.Id);
            unLivre.Add("ISBN", livre.Isbn);
            unLivre.Add("auteur", livre.Auteur);
            unLivre.Add("collection", livre.Collection);
            if (!access.CreerLivre(JsonConvert.SerializeObject(unLivre)))
                validateur = false;
           
            return validateur;
        }

        /// <summary>
        /// modifie un livre dans la bddd
        /// </summary>
        /// <param name="livre"></param>
        /// <returns>true si oppration correcte</returns>
        public bool UpdateLivre(Livre livre)
        {
            bool validateur = true;
            Dictionary<string, string> dicDocument = new Dictionary<string, string>();
            dicDocument.Add("id", livre.Id);
            dicDocument.Add("titre", livre.Titre);
            dicDocument.Add("idGenre", livre.IdGenre);
            dicDocument.Add("idPublic", livre.IdPublic);
            dicDocument.Add("idRayon", livre.IdRayon);
            dicDocument.Add("image", livre.Image);
            if (!access.UpdateDocument(livre.Id, JsonConvert.SerializeObject(dicDocument)))
                validateur = false;

            Dictionary<string, string> unLivre = new Dictionary<string, string>();
            unLivre.Add("id", livre.Id);
            unLivre.Add("ISBN", livre.Isbn);
            unLivre.Add("auteur", livre.Auteur);
            unLivre.Add("collection", livre.Collection);
            if (!access.UpdateLivre(livre.Id, JsonConvert.SerializeObject(unLivre)))
                validateur = false;

            return validateur;
        }

        /// <summary>
        /// supprime un livre dans la bdd
        /// </summary>
        /// <param name="livre"></param>
        /// <returns>true si oppration correcte</returns>
        public bool SupprimerLivre(Livre livre)
        {
            bool validateur = true;

            Dictionary<string, string> unLivre = new Dictionary<string, string>();
            unLivre.Add("id", livre.Id);
            unLivre.Add("ISBN", livre.Isbn);
            unLivre.Add("auteur", livre.Auteur);
            unLivre.Add("collection", livre.Collection);
            if (!access.SupprimerLivre(JsonConvert.SerializeObject(unLivre)))
                validateur = false;

            Dictionary<string, string> dicLivreDvd = new Dictionary<string, string>();
            dicLivreDvd.Add("id", livre.Id);
            if (!access.SupprimerLivreDvD(JsonConvert.SerializeObject(dicLivreDvd)))
                validateur = false;

            Dictionary<string, string> dicDocument = new Dictionary<string, string>();
            dicDocument.Add("id", livre.Id);
            dicDocument.Add("titre", livre.Titre);
            dicDocument.Add("idGenre", livre.IdGenre);
            dicDocument.Add("idPublic", livre.IdPublic);
            dicDocument.Add("idRayon", livre.IdRayon);
            dicDocument.Add("image", livre.Image);
            if (!access.SupprimerDocument(JsonConvert.SerializeObject(dicDocument)))
                validateur = false;

            return validateur;
        }

        /// <summary>
        /// Ajouter un dvd dans la bdd
        /// </summary>
        /// <param name="dvd"></param>
        /// <returns>true si oppration correcte</returns>
        public bool CreerDvd(Dvd dvd)
        {
            bool validateur = true;
            Dictionary<string, string> dicDocument = new Dictionary<string, string>();
            dicDocument.Add("id", dvd.Id);
            dicDocument.Add("titre", dvd.Titre);
            dicDocument.Add("idGenre", dvd.IdGenre);
            dicDocument.Add("idPublic", dvd.IdPublic);
            dicDocument.Add("idRayon", dvd.IdRayon);
            dicDocument.Add("image", dvd.Image);
            if (!access.CreerDocument(JsonConvert.SerializeObject(dicDocument)))
                validateur = false;

            Dictionary<string, string> dicLivreDvd = new Dictionary<string, string>();
            dicLivreDvd.Add("id", dvd.Id);
            if (!access.CreerLivreDvd(JsonConvert.SerializeObject(dicLivreDvd)))
                validateur = false;

            Dictionary<string, object> unDvd = new Dictionary<string, object>();
            unDvd.Add("duree", dvd.Duree);
            unDvd.Add("realisateur", dvd.Realisateur);
            unDvd.Add("synopsis", dvd.Synopsis);
            if (!access.CreerDvd(JsonConvert.SerializeObject(unDvd)))
                validateur = false;

            return validateur;
        }

        /// <summary>
        /// modifie un dvd dans la bdd
        /// </summary>
        /// <param name="dvd"></param>
        /// <returns>true si oppration correcte</returns>
        public bool UpdateDvd(Dvd dvd)
        {
            bool validateur = true;
            Dictionary<string, string> dicDocument = new Dictionary<string, string>();
            dicDocument.Add("id", dvd.Id);
            dicDocument.Add("titre", dvd.Titre);
            dicDocument.Add("idGenre", dvd.IdGenre);
            dicDocument.Add("idPublic", dvd.IdPublic);
            dicDocument.Add("idRayon", dvd.IdRayon);
            dicDocument.Add("image", dvd.Image);
            if (!access.UpdateDocument(dvd.Id, JsonConvert.SerializeObject(dicDocument)))
                validateur = false;

            Dictionary<string, object> unDvd = new Dictionary<string, object>();
            unDvd.Add("id", dvd.Id);
            unDvd.Add("duree", dvd.Duree);
            unDvd.Add("realisateur", dvd.Realisateur);
            unDvd.Add("synopsis", dvd.Synopsis);
            if (!access.UpdateDvd(dvd.Id, JsonConvert.SerializeObject(unDvd)))
                validateur = false;

            return validateur;
        }

        /// <summary>
        /// supprime un dvd dans la bdd
        /// </summary>
        /// <param name="dvd"></param>
        /// <returns>true si oppration correcte</returns>
        public bool SupprimerDvd(Dvd dvd)
        {
            bool validateur = true;

            Dictionary<string, object> unDvd = new Dictionary<string, object>();
            unDvd.Add("id", dvd.Id);
            unDvd.Add("duree", dvd.Duree);
            unDvd.Add("realisateur", dvd.Realisateur);
            unDvd.Add("synopsis", dvd.Synopsis);
            if (!access.SupprimerDvd(JsonConvert.SerializeObject(unDvd)))
                validateur = false;

            Dictionary<string, string> dicLivreDvd = new Dictionary<string, string>();
            dicLivreDvd.Add("id", dvd.Id);
            if (!access.SupprimerLivreDvD(JsonConvert.SerializeObject(dicLivreDvd)))
                validateur = false;

            Dictionary<string, string> dicDocument = new Dictionary<string, string>();
            dicDocument.Add("id", dvd.Id);
            dicDocument.Add("titre", dvd.Titre);
            dicDocument.Add("idGenre", dvd.IdGenre);
            dicDocument.Add("idPublic", dvd.IdPublic);
            dicDocument.Add("idRayon", dvd.IdRayon);
            dicDocument.Add("image", dvd.Image);
            if (!access.SupprimerDocument(JsonConvert.SerializeObject(dicDocument)))
                validateur = false;

            return validateur;
        }


        /// <summary>
        /// Ajouter une revue dans la bdd
        /// </summary>
        /// <param name="revue"></param>
        /// <returns>true si oppration correcte</returns>
        public bool CreerRevue(Revue revue)
        {
            bool validateur = true;
            Dictionary<string, string> dicDocument = new Dictionary<string, string>();
            dicDocument.Add("id", revue.Id);
            dicDocument.Add("titre", revue.Titre);
            dicDocument.Add("idGenre", revue.IdGenre);
            dicDocument.Add("idPublic", revue.IdPublic);
            dicDocument.Add("idRayon", revue.IdRayon);
            dicDocument.Add("image", revue.Image);
            if (!access.CreerDocument(JsonConvert.SerializeObject(dicDocument)))
                validateur = false;

            Dictionary<string, object> uneRevue = new Dictionary<string, object>();
            uneRevue.Add("id", revue.Id);
            uneRevue.Add("periodicite", revue.Periodicite);
            uneRevue.Add("delaiMiseADispo", revue.DelaiMiseADispo);
            if (!access.CreerRevue(JsonConvert.SerializeObject(uneRevue)))
                validateur = false;

            return validateur;
        }

        /// <summary>
        /// modifie une revue dans la bdd
        /// </summary>
        /// <param name="revue"></param>
        /// <returns>true si oppration correcte</returns>
        public bool UpdateRevue(Revue revue)
        {
            bool validateur = true;
            Dictionary<string, string> dicDocument = new Dictionary<string, string>();
            dicDocument.Add("id", revue.Id);
            dicDocument.Add("titre", revue.Titre);
            dicDocument.Add("idGenre", revue.IdGenre);
            dicDocument.Add("idPublic", revue.IdPublic);
            dicDocument.Add("idRayon", revue.IdRayon);
            dicDocument.Add("image", revue.Image);
            if (!access.UpdateDocument(revue.Id, JsonConvert.SerializeObject(dicDocument)))
                validateur = false;

            Dictionary<string, object> uneRevue = new Dictionary<string, object>();
            uneRevue.Add("id", revue.Id);
            uneRevue.Add("periodicite", revue.Periodicite);
            uneRevue.Add("delaiMiseADispo", revue.DelaiMiseADispo);
            if (!access.UpdateRevue(revue.Id, JsonConvert.SerializeObject(uneRevue)))
                validateur = false;

            return validateur;
        }

        /// <summary>
        /// supprime une revue dans la bdd
        /// </summary>
        /// <param name="revue"></param>
        /// <returns>true si oppration correcte</returns>
        public bool SupprimerRevue(Revue revue)
        {
            bool validateur = true;

            Dictionary<string, object> uneRevue = new Dictionary<string, object>();
            uneRevue.Add("id", revue.Id);
            uneRevue.Add("periodicite", revue.Periodicite);
            uneRevue.Add("delaiMiseADispo", revue.DelaiMiseADispo);
            if (!access.SupprimerRevue(JsonConvert.SerializeObject(uneRevue)))
                validateur = false;

            Dictionary<string, string> dicDocument = new Dictionary<string, string>();
            dicDocument.Add("id", revue.Id);
            dicDocument.Add("titre", revue.Titre);
            dicDocument.Add("idGenre", revue.IdGenre);
            dicDocument.Add("idPublic", revue.IdPublic);
            dicDocument.Add("idRayon", revue.IdRayon);
            dicDocument.Add("image", revue.Image);
            if (!access.SupprimerDocument(JsonConvert.SerializeObject(dicDocument)))
                validateur = false;

            return validateur;
        }
    }
}
