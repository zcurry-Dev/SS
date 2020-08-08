using System;
using System.Collections.Generic;

namespace SS.Data.Models
{
    public partial class Usstate
    {
        public Usstate()
        {
            Artist = new HashSet<Artist>();
            City = new HashSet<City>();
        }

        public int StateId { get; set; }
        public string StateAbbreviation { get; set; }
        public string StateName { get; set; }

        public virtual ICollection<Artist> Artist { get; set; }
        public virtual ICollection<City> City { get; set; }
    }
}
