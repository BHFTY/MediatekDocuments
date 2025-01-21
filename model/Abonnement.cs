using System;


namespace MediaTekDocuments.model
{
    internal class Abonnement : Commande
    {
        public DateTime DateFinAbonnement { get; }

        public string IdRevue { get; }

        public Abonnement(string id, DateTime dateCommande, double montant, DateTime dateFinAbonnement, string idRevue)
            : base(id, dateCommande, montant)
        {
            DateFinAbonnement = dateFinAbonnement;
            IdRevue = idRevue;
        }
    }
}
