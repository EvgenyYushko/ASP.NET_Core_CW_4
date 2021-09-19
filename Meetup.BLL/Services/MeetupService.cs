using Meetup.BLL.Interfaces;
using Meetup.BLL.ViewModels.Listener;
using Meetup.BLL.ViewModels.Meetup;
using Meetup.BLL.ViewModels.Speaker;
using Meetup.DAL.Patterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task DeleteMeetupById(Guid id)
        {
            var dbMeetup = _unitOfWork.Meetups.GetAll().Where(m => m.Id == id).FirstOrDefault();
            await _unitOfWork.Meetups.DeleteAsync(dbMeetup);
        }

        public List<InfoMeetup> FindMeetupByFunc(Func<Models.Meetup, bool> func)
        {
            try
            {
                List<Models.Meetup> dbMeetups;
                if (func == null)
                {
                    dbMeetups = _unitOfWork.Meetups.GetAll().ToList();
                }
                else
                {
                    dbMeetups = _unitOfWork.Meetups.GetAll().Where(func).ToList();
                }
                return dbMeetups.Select(m => GetInfoMeetup(m)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<InfoMeetup> UpdateMeetupById(Guid id, int statusId)
        {
            var dbMeetup = _unitOfWork.Meetups.GetAll().Where(m => m.Id == id).FirstOrDefault();
            dbMeetup.Status = statusId;
            dbMeetup = await _unitOfWork.Meetups.UpdateAsync(dbMeetup);

            return GetInfoMeetup(dbMeetup);
        }

        private InfoMeetup GetInfoMeetup(Models.Meetup m)
        {
            return new InfoMeetup()
            {
                Name = m.Name,
                Place = m.Place,
                CreationDate = m.CreationDate,
                Status = m.Status,
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
        }
    }
}
