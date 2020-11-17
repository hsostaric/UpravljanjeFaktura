using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZadatakFaktureMVC5.ViewModels
{
    public class StavkaPrilagodjenoView
    {
        [Display(Name = "Opis stavke")]
        public string OpisProdaneStavke { get; set; }
        [Display(Name = "Količina prodane stavke")]
        public int KolicinaProdaneStavke { get; set; }
        [Display(Name = "Jedinična cijena")]
        public double JedinicnaCijena { get; set; }
        [Display(Name = "Ukupna cijena")]
        public double UkupnaCijenaStavke { get; set; }

        public StavkaPrilagodjenoView(string opisProdaneStavke, int kolicinaProdaneStavke,
            double jedinicnaCijena, double ukupnaCijenaStavke)
        {
            OpisProdaneStavke = opisProdaneStavke;
            KolicinaProdaneStavke = kolicinaProdaneStavke;
            JedinicnaCijena = jedinicnaCijena;
            UkupnaCijenaStavke = ukupnaCijenaStavke;
        }
    }
}