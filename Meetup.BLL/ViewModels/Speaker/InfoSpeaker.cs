using System;

namespace Meetup.BLL.ViewModels.Speaker
{
    public class InfoSpeaker
    {
        public string Name { get; set; }
        public string Theme { get; set; }
        public string Materials { get; set; }
        public Guid MeetupId { get; set; }
    }
}
