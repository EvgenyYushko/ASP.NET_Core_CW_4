using Meetup.BLL.Interfaces;
using Meetup.BLL.ViewModels.Speaker;
using Meetup.DAL.Patterns.Interfaces;
using Meetup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.BLL.Services
{
    class SpeakerService : ISpeakerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SpeakerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<InfoSpeaker> FindSpeakerByFunc(Func<Speaker, bool> func)
        {
            try
            {
                var dbSpeakers = _unitOfWork.Speakers.GetAll().Where(func)
                    .Select(s =>
                    {
                        return new InfoSpeaker()
                        {
                            Name = s.Name,
                            Theme = s.Theme,
                            Materials = s.Materials
                        };
                    }).ToList();
                return dbSpeakers;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Guid> RegisterSpeakerAsync(RegisterSpeaker speaker)
        {
            try
            {
                var dbSpeaker = new Speaker()
                {
                    Name = speaker.Name,
                    Theme = speaker.Theme,
                    Materials = speaker.Materials,
                    MeetupId = speaker.MeetupId
                };

                dbSpeaker = await _unitOfWork.Speakers.CreateAsync(dbSpeaker);
                return dbSpeaker.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
