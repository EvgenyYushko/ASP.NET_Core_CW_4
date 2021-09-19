using System;
using System.Collections.Generic;

namespace Meetup.Models
{
    class Meetup : BaseEntity
    {
        public string Name { get; set; }
        public string Place { get; set; }
        public DateTime Date { get; set; }

        /// <summary>wW
        /// 0 - Ожидание; 1 - Подтверждено; 2 - Отклонено
        /// </summary>
        public int Status { get; set; }


        public virtual List<Speaker> Speakers { get; set; } = new List<Speaker>();
        public virtual List<Listener> Listeners { get; set; } = new List<Listener>();
    }
}
