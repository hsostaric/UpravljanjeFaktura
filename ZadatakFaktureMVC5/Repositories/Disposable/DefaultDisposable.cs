using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZadatakFaktureMVC5.DataContext;

namespace ZadatakFaktureMVC5.Repositories.Disposable
{
    public class DefaultDisposable : IDisposable
    {
        protected ApplicationDbContext context;
        private bool _disposed;
        private readonly object _disposeLock = new object();

        protected DefaultDisposable(ApplicationDbContext _context)
        {
            context = _context;
        }
        protected virtual void Dispose(bool disposing)
        {
            lock (_disposeLock)
            {
                if (!_disposed)
                {
                    if (disposing)
                    {
                        context.Dispose();
                    }

                    _disposed = true;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
    }
}