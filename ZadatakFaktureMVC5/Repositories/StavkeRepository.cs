using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZadatakFaktureMVC5.DatabaseModels;
using ZadatakFaktureMVC5.DataContext;

namespace ZadatakFaktureMVC5.Repositories
{
    public class StavkeRepository : BaseRepository<Stavka>, IStavkeRepository
    {
        public StavkeRepository(ApplicationDbContext _context) : base(_context)
        {

        }

        public override void Delete(Stavka obj)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Stavka> GetAll()
        {
            return context.Stavka.ToList();
        }

        public override Stavka GetById(int id)
        {
            return context.Stavka.Where(x => x.Id == id).SingleOrDefault();
        }

        public override void Insert(Stavka obj)
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            context.SaveChanges();
        }

        public override void Update(Stavka obj)
        {
            throw new NotImplementedException();
        }
    }
}