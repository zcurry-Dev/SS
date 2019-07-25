using System;
using System.Collections.Generic;

namespace SS.API.EFModels.Tables
{
    public partial class SseventTypes
    {
        public SseventTypes()
        {
            Ssevents = new HashSet<Ssevents>();
        }

        public int SsEventTypeId { get; set; }
        public string EventType { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public Employees CreatedByNavigation { get; set; }
        public ICollection<Ssevents> Ssevents { get; set; }
    }
}
