using Meetup.BLL.ViewModels.Listener;
using Meetup.BLL.ViewModels.Speaker;
using Meetup.Models;
using System;
using System.Collections.Generic;

namespace Meetup.BLL.ViewModels.Meetup
{
    public class InfoMeetup
    {
        public string Name { get; set; }
        public string Place { get; set; }
        public DateTime CreationDate { get; set; }
        public List<InfoSpeaker> Speakers { get; set; } = new List<InfoSpeaker>();
        public List<InfoListener> Listeners { get; set; } = new List<InfoListener>();
    }
}
