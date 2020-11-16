using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZadatakFaktureMVC5.DatabaseModels;
using ZadatakFaktureMVC5.ViewModels;

namespace ZadatakFaktureMVC5.Repositories
{
    public interface IFaktureStavkeViewRepository : IRepository<FakturaStavkaView>
    {
        void DodajStavkuFakturi(Faktura faktura, Stavka stavka, int kolicina);

        FakturaStavkaView VratiZapis(Stavka stavka, Faktura faktura);

        void AzurirajZapis(FakturaStavkaView obj, FakturaStavkaViewDisplay noviZapis, Stavka stavka);
        void DodajCijenuFakturi(Faktura faktura, FakturaStavkaView fsv);
    }
}
