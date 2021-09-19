using Meetup.BLL.Interfaces;
using Meetup.BLL.ViewModels.Listener;
using Meetup.BLL.ViewModels.Meetup;
using Meetup.BLL.ViewModels.Speaker;
using Meetup.DAL.Patterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.BLL.Services
{
    public class MeetupService : IMeetupService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MeetupService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> CreateMeetupAsync(CreateMeetup meetup)
        {
            try
            {
                var dbMeetup = new Models.Meetup()
                {
                    Name = meetup.Name,
                    CreationDate = DateTime.Now,
                    Place = meetup.Place,
                    Status = 0
                };

                dbMeetup = await _unitOfWork.Meetups.CreateAsync(dbMeetup);
                return dbMeetup.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<InfoMeetup> FindMeetupByFunc(Func<Models.Meetup, bool> func)
        {
            try
            {
                var dbMeetups = _unitOfWork.Meetups.GetAll().Where(func).
                    Select(m =>
                    {
                        return new InfoMeetup()
                        {
                            Name = m.Name,
                            Place = m.Place,
                            CreationDate = m.CreationDate,
                            Listeners = m.Listeners.Select(l =>
                            {
                                return new InfoListener()
                                {
                                    Name = l.Name
                                };
                            }).ToList(),
                            Speakers = m.Speakers.Select(s =>
                            {
                                return new InfoSpeaker()
                                {
                                    Name = s.Name,
                                    Theme = s.Theme,
                                    Materials = s.Materials
                                };
                            }).ToList()
                        };
                    }).ToList();

                return dbMeetups;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
