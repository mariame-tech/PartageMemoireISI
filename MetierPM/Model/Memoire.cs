using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetierPM.Model
{
    public class Memoire
    {
        [Key]
        public int IdMemoire {  get; set; }

        [MaxLength(3000),Required]
        public string Sujet { get; set; }

        [MaxLength(300), Required]
        public string Domaine { get; set; }
    }
}