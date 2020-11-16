using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZadatakFaktureMVC5.DatabaseModels;
using ZadatakFaktureMVC5.DataContext;
using ZadatakFaktureMVC5.ViewModels;

namespace ZadatakFaktureMVC5.Repositories
{
    public class FaktureStavkaViewRepository : BaseRepository<FakturaStavkaView>, IFaktureStavkeViewRepository
    {
        public FaktureStavkaViewRepository(ApplicationDbContext _context) : base(_context)
        {

        }


        public override void Delete(FakturaStavkaView obj)
        {
            throw new NotImplementedException();
        }

        public void DodajStavkuFakturi(Faktura faktura, Stavka stavka, int kolicina)
        {
            using (var dbContext = new ApplicationDbContext())
            {

                FakturaStavkaView obj = new FakturaStavkaView
                {
                    FakturaID = faktura.Id,
                    StavkaID = stavka.Id,
                    Kolicina = kolicina,
                    KolicinskaCijena = (kolicina * stavka.Cijena)

                };
                dbContext.FakturaStavkaViews.Add(obj);
                dbContext.SaveChanges();
            }
        }
        public void DodajCijenuFakturi(Faktura faktura, FakturaStavkaView fsv)
        {

            using (var dbContext = new ApplicationDbContext())
            {
                dbContext.Faktura.Attach(faktura);
                double razlika = Math.Abs(fsv.KolicinskaCijena - faktura.CijenaBezPDV);
                faktura.CijenaBezPDV = fsv.KolicinskaCijena;
                faktura.CijenaPDV = izracunajCijenuPDV(faktura);
                dbContext.SaveChanges();
            }

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

        public override IEnumerable<FakturaStavkaView> GetAll()
        {
            throw new NotImplementedException();
        }

        public override FakturaStavkaView GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override void Insert(FakturaStavkaView obj)
        {
            context.FakturaStavkaViews.Add(obj);
            Save();
        }

        public override void Save()
        {
            context.SaveChanges();
        }

        public override void Update(FakturaStavkaView obj)
        {
            throw new NotImplementedException();
        }

        public FakturaStavkaView VratiZapis(Stavka stavka, Faktura faktura)
        {
            FakturaStavkaView zapis = null;
            zapis = context.FakturaStavkaViews.Where(x => x.FakturaID == faktura.Id && x.StavkaID == stavka.Id).SingleOrDefault();
            return zapis;
        }

        public void AzurirajZapis(FakturaStavkaView obj, FakturaStavkaViewDisplay noviZapis, Stavka stavka)
        {
            context.FakturaStavkaViews.Attach(obj);
            obj.FakturaID = noviZapis.RacunID;
            obj.StavkaID = noviZapis.StavkaID;
            obj.Kolicina += noviZapis.KolicinaArtikla;
            obj.KolicinskaCijena += (stavka.Cijena * noviZapis.KolicinaArtikla);
            Save();

        }
    }


}