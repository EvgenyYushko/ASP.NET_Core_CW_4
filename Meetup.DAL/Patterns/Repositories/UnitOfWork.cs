using Meetup.DAL.Patterns.Interfaces;
using System;

namespace Meetup.DAL.Patterns.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        private bool _disposed = false;

        private IRepository<Models.Meetup> _meetups;
        private IRepository<Models.Speaker> _speakers;
        private IRepository<Models.Listener> _listeners;

        public UnitOfWork(AppDbContext context)
        {
            _db = context;
        }

        public IRepository<Models.Meetup> Meetups => _meetups ?? (_meetups = new Repository<Models.Meetup>(_db));
        public IRepository<Models.Speaker> Speakers => _speakers ?? (_speakers = new Repository<Models.Speaker>(_db));
        public IRepository<Models.Listener> Listeners => _listeners ?? (_listeners = new Repository<Models.Listener>(_db));

        public virtual void Dispose(bool disposing)
        {
            if (this._disposed)
                return;
            if (disposing)
            {
                _db.Dispose();
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
