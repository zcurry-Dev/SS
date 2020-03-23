using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class EventTypesSs
    {
        public EventTypesSs()
        {
            EventsSs = new HashSet<EventsSs>();
        }

        public int EventTypeId { get; set; }
        public string EventType { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Employees CreatedByNavigation { get; set; }
        public virtual ICollection<EventsSs> EventsSs { get; set; }
    }
}
