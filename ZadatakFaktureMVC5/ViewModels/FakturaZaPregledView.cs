using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ZadatakFaktureMVC5.DatabaseModels;

namespace ZadatakFaktureMVC5.ViewModels
{
    public class FakturaZaPregledView
    {
        [Display(Name = "Broj fakture")]
        public int BrojFakture { get; set; }
        [Display(Name = "Datum stvaranja fakture")]
        public DateTime DatumStvaranjaFaktura { get; set; }
        [Display(Name = "Datum dospijeca fakture")]
        public DateTime DatumDospijecaFakture { get; set; }
        public List<StavkaPrilagodjenoView> StavkeRacuna { get; set; }

        [Display(Name = "Cijena bez poreza")]
        public double CijenaBezPoreza { get; set; }
        [Display(Name = "Cijena s porezom")]
        public double CijenaSaPorezom { get; set; }
        [Display(Name = "Stvaratelj računa")]
        public string Username { get; set; }
        [Display(Name = "Naziv primatelja")]
        public string NazivPrimatelja { get; set; }
        public FakturaZaPregledView()
        {
            StavkeRacuna = new List<StavkaPrilagodjenoView>();
        }

        public FakturaZaPregledView(int brojFakture, DateTime datumStvaranjaFaktura, DateTime datumDospijecaFakture,
            double cijenaBezPoreza, double cijenaSaPorezom, string username, string nazivPrimatelja)
        {
            BrojFakture = brojFakture;
            DatumStvaranjaFaktura = datumStvaranjaFaktura;
            DatumDospijecaFakture = datumDospijecaFakture;
            StavkeRacuna = new List<StavkaPrilagodjenoView>();
            CijenaBezPoreza = cijenaBezPoreza;
            CijenaSaPorezom = cijenaSaPorezom;
            Username = username;
            NazivPrimatelja = nazivPrimatelja;
        }
    }
}