using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZadatakFaktureMVC5.DatabaseModels
{
    public class Stavka
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Opis { get; set; }
        [Required]
        public double Cijena { get; set; }

        public virtual ICollection<Faktura> Fakture { get; set; }
        public virtual ICollection<FakturaStavkaView> StavkeFakture { get; set; }

        public Stavka(int id, string opis, double cijena)
        {
            Id = id;
            Opis = opis;
            Cijena = cijena;
        }

        public Stavka()
        {
            Fakture = new List<Faktura>();
        }
    }


}