using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ZadatakFaktureMVC5.Enums;

namespace ZadatakFaktureMVC5.ViewModels
{
    public class FakturaTemplateView
    {
        [Required]
        [DisplayName("Datum stvaranja fakture:")]
        [DataType(DataType.Date)]
        public DateTime DatumStvaranjaFakture { get; set; }
        [Required]
        [DisplayName("Datum stvaranja fakture:")]
        [DataType(DataType.Date)]
        public DateTime DatumDospijecaFakture { get; set; }

        [DisplayName("Odabrana stopa PDV-a")]
        [Required]
        public PDV VrstaPDV { get; set; }
        [DisplayName("Naziv primatelja:")]
        [DefaultValue("")]
        public string NazivPrimateljaRacuna { get; set; }

        public FakturaTemplateView()
        {

        }
        public FakturaTemplateView(DateTime datumStvaranjaFakture, DateTime datumDospijecaFakture, string nazivPrimateljaRacuna, PDV _vrsta)
        {
            DatumStvaranjaFakture = datumStvaranjaFakture;
            DatumDospijecaFakture = datumDospijecaFakture;
            NazivPrimateljaRacuna = nazivPrimateljaRacuna;
            VrstaPDV = _vrsta;
        }
    }
}