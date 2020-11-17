using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZadatakFaktureMVC5.DatabaseModels;
using ZadatakFaktureMVC5.Repositories;

namespace ZadatakFaktureMVC5.ViewModels
{
    public sealed class UpravljanjeFakturama
    {
        private static UpravljanjeFakturama instance = null;
        private static readonly object padlock = new object();
        UpravljanjeFakturama()
        {

        }

        public static UpravljanjeFakturama Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new UpravljanjeFakturama();
                    }
                    return instance;
                }
            }
        }

        public List<FaktureView> DajListuSaSiframaFakturaKorisnika(IEnumerable<Faktura> faktureKorisnika)
        {
            List<FaktureView> lista = new List<FaktureView>();
            if (faktureKorisnika.ToList().Count > 0)
            {
                foreach (var faktura in faktureKorisnika)
                {
                    lista.Add(new FaktureView(faktura.Id, faktura.Spremljeno));
                }
            }
            return lista;

        }

        public List<StavkaPrilagođeno> DajPrilagodjeneStavke(IStavkeRepository repository)
        {
            List<StavkaPrilagođeno> lista = new List<StavkaPrilagođeno>();
            List<Stavka> listaStavkiIzBaze = new List<Stavka>(repository.GetAll());
            foreach (Stavka stavka in listaStavkiIzBaze)
            {
                lista.Add(new StavkaPrilagođeno(stavka.Id, stavka.Opis, stavka.Cijena));
            }
            return lista;
        }

        public void DodajStavkeFakturi(string userID, FakturaStavkaViewDisplay fakturaStavkaViewDisplay,
            IStavkeRepository stavkeRepository, IFaktureStavkeViewRepository faktureStavkeViewRepository, IFakturaRepository fakturaRepository)
        {

            Faktura faktura = fakturaRepository.GetById(fakturaStavkaViewDisplay.RacunID);
            Stavka stavka = stavkeRepository.GetById(fakturaStavkaViewDisplay.StavkaID);
            FakturaStavkaView obj = faktureStavkeViewRepository.VratiZapis(stavka, faktura);
            if (obj == null)
            {
                faktureStavkeViewRepository.DodajStavkuFakturi(faktura, stavka, fakturaStavkaViewDisplay.KolicinaArtikla);
            }
            else
            {
                faktureStavkeViewRepository.AzurirajZapis(obj, fakturaStavkaViewDisplay, stavka);

            }
            FakturaStavkaView novo = faktureStavkeViewRepository.VratiZapis(stavka, faktura);
            faktureStavkeViewRepository.DodajCijenuFakturi(faktura, novo);

        }

        public FakturaZaPregledView OblikujFakturuZaIspis(string userID, int racunID, IUserRepository userRepository,
            IFaktureStavkeViewRepository faktureStavkeViewRepository, IFakturaRepository fakturaRepository)
        {
            FakturaZaPregledView faktura;
            ApplicationUser prijavljeniKorisnik = userRepository.DohvatiPrijavljenogkorisnika(userID);
            Faktura racun = fakturaRepository.GetById(racunID);
            List<FakturaStavkaView> stavkeFakture = new List<FakturaStavkaView>(faktureStavkeViewRepository.DohvatiStavkeFakture(racun));
            stavkeFakture = faktureStavkeViewRepository.DohvatiStavkeFakture(racun);
            faktura = new FakturaZaPregledView(racun.Id, racun.DatumStvaranja, racun.DatumDospijeća,
                racun.CijenaBezPDV, racun.CijenaPDV, prijavljeniKorisnik.UserName, racun.PrimateljRacuna);
            foreach (var zapis in stavkeFakture)
            {
                faktura.StavkeRacuna.Add(new StavkaPrilagodjenoView(zapis.Stavka.Opis, zapis.Kolicina,
                    zapis.Stavka.Cijena, zapis.KolicinskaCijena));
            }
            return faktura;

        }


    }
}