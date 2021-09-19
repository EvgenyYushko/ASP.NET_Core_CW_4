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

        public List<InfoListener> FindListenerByFunc(Func<Listener, bool> func)
        {
            try
            {
                List<Listener> dbListeners;
                if (func == null)
                {
                    dbListeners = _unitOfWork.Listeners.GetAll().ToList();
                }
                else
                {
                    dbListeners = _unitOfWork.Listeners.GetAll().Where(func).ToList();
                }

                return dbListeners.Select(s =>
                {
                    return new InfoListener()
                    {
                        Name = s.Name
                    };
                }).ToList();

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
