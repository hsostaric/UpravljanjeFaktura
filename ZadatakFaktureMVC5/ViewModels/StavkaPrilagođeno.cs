using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZadatakFaktureMVC5.ViewModels
{
    public class StavkaPrilagođeno
    {
        public int Id { get; set; }
        public string Opis { get; set; }
        public double Cijena { get; set; }
        public StavkaPrilagođeno()
        {

        }

        public StavkaPrilagođeno(int id, string opis, double cijena)
        {
            Id = id;
            Opis = opis;
            Cijena = cijena;
        }
    }
}