using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetierPM.Model
{
    public class Commentaire
    {
        [Key]
        public int IdCommentaire { get; set; }

        [Required,MaxLength(3000)]
        public string laDemande { get; set; }

        [MaxLength(3000)]
        public string laReponse { get; set; }

      

        public int? IdDemandeur { get; set; }

        [ForeignKey ("IdDemandeur")]
        public Personne demandeur { get; set; }

        public DateTime dateDemande { get; set; } = DateTime.Now;
        public DateTime dateReponse { get; set; }

        public int? IdRepondeur { get; set; }

        [ForeignKey("IdRepondeur")]
        public Expert expert { get; set; }


    }
}