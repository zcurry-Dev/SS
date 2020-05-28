using System;
using System.Collections.Generic;

namespace SS.Data.Models
{
    public partial class EventType
    {
        public EventType()
        {
            Ssevent = new HashSet<Ssevent>();
        }

        public int EventTypeId { get; set; }
        public string EventType1 { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Ssuser CreatedByNavigation { get; set; }
        public virtual ICollection<Ssevent> Ssevent { get; set; }
    }
}
