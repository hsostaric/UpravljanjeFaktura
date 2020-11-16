using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZadatakFaktureMVC5.DatabaseModels
{
    public class Faktura
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime DatumStvaranja { get; set; }
        [Required]
        public DateTime DatumDospijeća { get; set; }
        [Required]
        public double CijenaPDV { get; set; }
        [Required]
        public double CijenaBezPDV { get; set; }
        [DefaultValue("")]
        public string PrimateljRacuna { get; set; }
        [DefaultValue(0)]
        public int VrstaPDV { get; set; }
        [DefaultValue(false)]
        public bool Spremljeno { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser Korisnik { get; set; }

        public virtual ICollection<Stavka> Stavke { get; set; }

        public virtual ICollection<FakturaStavkaView> StavkeFakture { get; set; }

        public Faktura()
        {
            Stavke = new List<Stavka>();
            StavkeFakture = new List<FakturaStavkaView>();
        }
    }
}