using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZadatakFaktureMVC5.DatabaseModels;
using ZadatakFaktureMVC5.ViewModels;

namespace ZadatakFaktureMVC5.Repositories
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        IEnumerable<Faktura> DohvatiFaktureKorisnika(string id);
        ApplicationUser DohvatiPrijavljenogkorisnika(string id);

        void DodajNovuFakturuKorisniku(string id, FakturaTemplateView view);
    }
}
