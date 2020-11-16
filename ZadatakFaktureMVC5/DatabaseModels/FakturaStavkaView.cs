using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZadatakFaktureMVC5.DatabaseModels
{
    public class FakturaStavkaView
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Faktura")]
        public int FakturaID { get; set; }
        [Key]
        [Column(Order = 2)]
        [ForeignKey("Stavka")]
        public int StavkaID { get; set; }
        [Required]
        public int Kolicina { get; set; }
        [Required]
        public double KolicinskaCijena { get; set; }

        public virtual Stavka Stavka { get; set; }

        public virtual Faktura Faktura { get; set; }

        public FakturaStavkaView()
        {
        }

    }
}