using System;

namespace Meetup.Models
{
    class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
