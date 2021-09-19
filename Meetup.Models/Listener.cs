using System;

namespace Meetup.Models
{
    class Listener : BaseEntity
    {
        public string Name { get; set; }
        public Guid MeetupId { get; set; }

        public virtual Meetup Meetup { get; set; }
    }
}
