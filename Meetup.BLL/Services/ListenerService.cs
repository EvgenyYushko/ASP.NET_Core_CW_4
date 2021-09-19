using Meetup.BLL.Interfaces;
using Meetup.BLL.ViewModels.Listener;
using Meetup.DAL.Patterns.Interfaces;
using Meetup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.BLL.Services
{
    public class ListenerService : IListenerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ListenerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<InfoListener> FindMeetupByFunc(Func<Listener, bool> func)
        {
            try
            {
                var dbListeners = _unitOfWork.Listeners.GetAll().Where(func)
                    .Select(s =>
                    {
                        return new InfoListener()
                        {
                            Name = s.Name
                        };
                    }).ToList();
                return dbListeners;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Guid> RegisterListenerAsync(RegisterListener listener)
        {
            try
            {
                var dbListener = new Listener()
                {
                    Name = listener.Name,
                    MeetupId = listener.MeetupId
                };

                dbListener = await _unitOfWork.Listeners.CreateAsync(dbListener);
                return dbListener.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
