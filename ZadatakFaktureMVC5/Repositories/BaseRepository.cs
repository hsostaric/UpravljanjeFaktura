using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using ZadatakFaktureMVC5.DataContext;
using ZadatakFaktureMVC5.Repositories.Disposable;

namespace ZadatakFaktureMVC5.Repositories
{
    public abstract class BaseRepository<T> : DefaultDisposable, IRepository<T> where T : class
    {

        public BaseRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
        public abstract void Delete(T obj);
        public abstract IEnumerable<T> GetAll();
        public abstract T GetById(int id);
        public abstract void Insert(T obj);
        public abstract void Save();
        public abstract void Update(T obj);
    }
}