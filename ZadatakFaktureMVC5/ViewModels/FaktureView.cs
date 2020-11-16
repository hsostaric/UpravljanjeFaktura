using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ZadatakFaktureMVC5.ViewModels
{
    public class FaktureView
    {
        [DisplayName("Šifra računa")]
        public int Id { get; set; }
        [DisplayName("Mogućnost uređivanja")]
        public bool Spremljeno { get; set; }
        public FaktureView()
        {

        }

        public FaktureView(int id, bool spremljeno)
        {
            Id = id;
            Spremljeno = spremljeno;
        }
    }
}