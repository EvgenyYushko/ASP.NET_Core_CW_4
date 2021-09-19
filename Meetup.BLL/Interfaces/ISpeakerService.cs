using Meetup.BLL.ViewModels.Speaker;
using Meetup.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.BLL.Interfaces
{
    public interface ISpeakerService
    {
        Task<Guid> RegisterSpeakerAsync(RegisterSpeaker speaker);
        List<InfoSpeaker> FindSpeakerByFunc(Func<Speaker, bool> func);
    }
}
