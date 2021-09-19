using System;
using System.Collections.Generic;
using System.Text;

namespace Meetup.BLL.ViewModels.Speaker
{
    public class RegisterSpeaker
    {
        public string Name { get; set; }
        public string Theme { get; set; }
        public string Materials { get; set; }
        public Guid MeetupId { get; set; }
    }
}
