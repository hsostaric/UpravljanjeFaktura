using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
using ZadatakFaktureMVC5.DatabaseModels;
using ZadatakFaktureMVC5.DataContext;
using ZadatakFaktureMVC5.ViewModels;

namespace ZadatakFaktureMVC5.Repositories
{
    public class UserRepository : BaseRepository<ApplicationUser>, IUserRepository
    {

        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public override void Delete(ApplicationUser obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Faktura> DohvatiFaktureKorisnika(string id)
        {
            ApplicationUser user = DohvatiPrijavljenogkorisnika(id);
            return user.Fakture.ToList();
        }

        public override IEnumerable<ApplicationUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public override ApplicationUser GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override void Insert(ApplicationUser obj)
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            context.SaveChanges();
        }

        public override void Update(ApplicationUser obj)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser DohvatiPrijavljenogkorisnika(string id)
        {
            return context.Users.Find(id);
        }

        public void DodajNovuFakturuKorisniku(string id, FakturaTemplateView view)
        {
            ApplicationUser user = DohvatiPrijavljenogkorisnika(id);
            context.Users.Attach(user);
            Faktura novaFaktura = new Faktura
            {
                DatumStvaranja = view.DatumStvaranjaFakture,
                DatumDospijeća = view.DatumDospijecaFakture,
                CijenaPDV = 0,
                CijenaBezPDV = 0,
                PrimateljRacuna = view.NazivPrimateljaRacuna,
                Spremljeno = false,
                VrstaPDV = (int)view.VrstaPDV,
                Korisnik = user
            };
            context.Faktura.Add(novaFaktura);
            Save();
        }

        public void DodajCijenuFakturi(string id, Faktura faktura, FakturaStavkaView fsv)
        {
            ApplicationUser user = DohvatiPrijavljenogkorisnika(id);
            context.Users.Attach(user);
            double razlika = Math.Abs(fsv.KolicinskaCijena - faktura.CijenaBezPDV);
            faktura.CijenaBezPDV += razlika;
            faktura.CijenaPDV = izracunajCijenuPDV(faktura);
            Save();
        }

        private double izracunajCijenuPDV(Faktura faktura)
        {
            double pdvCijena = 0;
            switch (faktura.VrstaPDV)
            {
                case 1:
                    pdvCijena = faktura.CijenaBezPDV * 1.25;
                    break;
                case 2:
                    pdvCijena = faktura.CijenaBezPDV * 1.17;
                    break;
                case 3:
                    pdvCijena = faktura.CijenaBezPDV * 1.10;
                    break;
                default:
                    pdvCijena = 0;
                    break;

            }
            return pdvCijena;
        }
    }
}
