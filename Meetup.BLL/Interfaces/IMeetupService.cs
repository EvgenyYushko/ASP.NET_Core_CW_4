using Meetup.BLL.ViewModels.Meetup;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.BLL.Interfaces
{
    public interface IMeetupService
    {
        Task<Guid> CreateMeetupAsync(CreateMeetup meetup);
        List<InfoMeetup> FindMeetupByFunc(Func<Models.Meetup, bool> func);
    }
}
