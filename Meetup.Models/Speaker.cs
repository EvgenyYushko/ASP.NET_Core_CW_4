using System;

namespace Meetup.Models
{
    class Speaker : BaseEntity
    {
        public string Name { get; set; }
        public string Theme { get; set; }
        public string Materials { get; set; }
        public Guid MeetupId { get; set; }

        public virtual Meetup Meetup { get; set; }
    }
}
