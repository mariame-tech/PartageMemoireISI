using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MetierPM.Model
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]

    public class bdMemoireM1Context : DbContext
    {

        public bdMemoireM1Context() : base("connBdMemoire1")
        {
        }

        public DbSet<Personne> personnes { get; set; }
        public DbSet<Expert> experts { get; set; }
        public DbSet<Commentaire> comments { get; set; }    
        public DbSet<Td_Erreur> td_erreurs { get;set; }
        public DbSet<Memoire> memoires { get; set; }
    }
}