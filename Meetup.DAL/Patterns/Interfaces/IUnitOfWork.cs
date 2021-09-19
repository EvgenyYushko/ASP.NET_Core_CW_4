using System;

namespace Meetup.DAL.Patterns.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
       IRepository<Models.Meetup> Meetups { get; }
       IRepository<Models.Speaker> Speakers { get; }
       IRepository<Models.Listener> Listeners { get; }
    }
}
