using Meetup.BLL.ViewModels.Listener;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.BLL.Interfaces
{
    public interface IListenerService
    {
        Task<Guid> RegisterListenerAsync(RegisterListener listener);
        List<InfoListener> FindMeetupByFunc(Func<Models.Listener, bool> func);
    }
}
