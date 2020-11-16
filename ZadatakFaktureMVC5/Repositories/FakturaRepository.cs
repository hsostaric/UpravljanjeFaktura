using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZadatakFaktureMVC5.DatabaseModels;
using ZadatakFaktureMVC5.DataContext;

namespace ZadatakFaktureMVC5.Repositories
{
    public class FakturaRepository : BaseRepository<Faktura>, IFakturaRepository
    {
        public FakturaRepository(ApplicationDbContext _context) : base(_context)
        {

        }

        public override void Delete(Faktura obj)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Faktura> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Faktura GetById(int id)
        {
            return context.Faktura.AsNoTracking().Where(x => x.Id == id).SingleOrDefault();
        }

        public override void Insert(Faktura obj)
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            context.SaveChanges();
        }

        public override void Update(Faktura obj)
        {
            throw new NotImplementedException();
        }
    }
}