using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using ZadatakFaktureMVC5.DataContext;
using ZadatakFaktureMVC5.Repositories;
using ZadatakFaktureMVC5.ViewModels;

namespace ZadatakFaktureMVC5.Controllers
{
    [Authorize]
    public class FaktureController : Controller
    {
        private IUserRepository userRepository;
        private IStavkeRepository stavkeRepository;
        private IFaktureStavkeViewRepository faktureStavkeViewRepository;
        private IFakturaRepository fakturaRepository;

        public FaktureController(IUserRepository _userRepository, IStavkeRepository _stavkeRepository, IFaktureStavkeViewRepository _faktureStavkeViewRepository, IFakturaRepository _fakturaRepository)
        {
            userRepository = _userRepository;
            stavkeRepository = _stavkeRepository;
            faktureStavkeViewRepository = _faktureStavkeViewRepository;
            fakturaRepository = _fakturaRepository;
        }
        public FaktureController()
        {
            userRepository = new UserRepository(new ApplicationDbContext());
            stavkeRepository = new StavkeRepository(new ApplicationDbContext());
            faktureStavkeViewRepository = new FaktureStavkaViewRepository(new ApplicationDbContext());
            fakturaRepository = new FakturaRepository(new ApplicationDbContext());

        }

        // GET: Fakture
        public ActionResult Index()
        {

            string id = User.Identity.GetUserId();
            return View(UpravljanjeFakturama.Instance.DajListuSaSiframaFakturaKorisnika(userRepository.DohvatiFaktureKorisnika(id)));
        }

        [HttpGet]
        public ActionResult NovaFaktura()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NovaFaktura(FakturaTemplateView fakturaTemplateView)
        {
            if (ModelState.IsValid)
            {
                string id = User.Identity.GetUserId();
                userRepository.DodajNovuFakturuKorisniku(id, fakturaTemplateView);
                return RedirectToAction("Index", "Fakture");
            }
            return View(fakturaTemplateView);


        }

        [HttpGet]
        public ActionResult DodavanjeStavki(int id)
        {

            if (id == 0 || id.Equals(null))
            {
                return RedirectToAction("Index", "Fakture");
            }
            FakturaStavkaViewDisplay model = new FakturaStavkaViewDisplay();
            model.RacunID = id;
            ViewBag.ListaStavki = UpravljanjeFakturama.Instance.DajPrilagodjeneStavke(stavkeRepository);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DodavanjeStavki(FakturaStavkaViewDisplay faktura)
        {
            if (ModelState.IsValid)
            {
                UpravljanjeFakturama.Instance.DodajStavkeFakturi(User.Identity.GetUserId(), faktura, stavkeRepository, faktureStavkeViewRepository, fakturaRepository);
                return RedirectToAction("Index", "Fakture");
            }
            if (!ModelState.IsValid)
            {
                return View(faktura);
            }
            return View();
        }

        [HttpGet]
        public ActionResult DetaljiRacuna(int id)
        {
            if (id == 0 || id.Equals(null))
            {
                return RedirectToAction("Index", "Fakture");
            }

            FakturaZaPregledView model = UpravljanjeFakturama.Instance.OblikujFakturuZaIspis(User.Identity.GetUserId(), id, userRepository,
                faktureStavkeViewRepository, fakturaRepository);
            return View(model);

        }




    }
}