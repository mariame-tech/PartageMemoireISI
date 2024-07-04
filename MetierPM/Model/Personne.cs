using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetierPM.Model
{
    public class Personne
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="*"),MaxLength(80,ErrorMessage ="Taille maximale 80")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "*"), MaxLength(80, ErrorMessage = "Taille maximale 80")]
        public string Prenom { get; set; }
    }
}