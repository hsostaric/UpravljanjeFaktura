using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZadatakFaktureMVC5.DatabaseModels;

namespace ZadatakFaktureMVC5.ViewModels
{
    public class FakturaStavkaViewDisplay
    {
        [Display(Name = "Redni broj računa")]
        public int RacunID { get; set; }
        [Display(Name = "Odabrani artikl")]
        public int StavkaID { get; set; }
        [Display(Name = "Količina artikla")]
        [Range(Int32.MinValue, 99)]
        public int KolicinaArtikla { get; set; }

        public FakturaStavkaViewDisplay()
        {

        }

    }
}