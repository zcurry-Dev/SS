using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class Ssuser
    {
        public Ssuser()
        {
            Artist = new HashSet<Artist>();
            ArtistGroupMember = new HashSet<ArtistGroupMember>();
            ArtistGroupMemberRole = new HashSet<ArtistGroupMemberRole>();
            Beer = new HashSet<Beer>();
            Brewery = new HashSet<Brewery>();
            Cider = new HashSet<Cider>();
            Cidery = new HashSet<Cidery>();
            Distillery = new HashSet<Distillery>();
            EventType = new HashSet<EventType>();
            Liquor = new HashSet<Liquor>();
            Mead = new HashSet<Mead>();
            Seltzer = new HashSet<Seltzer>();
            Seltzery = new HashSet<Seltzery>();
            Ssadmin = new HashSet<Ssadmin>();
            Ssevent = new HashSet<Ssevent>();
            UserEmployeeXref = new HashSet<UserEmployeeXref>();
            UserRolesXref = new HashSet<UserRolesXref>();
            Venue = new HashSet<Venue>();
            VenueType = new HashSet<VenueType>();
            Wine = new HashSet<Wine>();
            Winery = new HashSet<Winery>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public int UserStatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastActive { get; set; }
        public byte[] PwHash { get; set; }
        public byte[] PwSalt { get; set; }

        public virtual UserStatus UserStatus { get; set; }
        public virtual ICollection<Artist> Artist { get; set; }
        public virtual ICollection<ArtistGroupMember> ArtistGroupMember { get; set; }
        public virtual ICollection<ArtistGroupMemberRole> ArtistGroupMemberRole { get; set; }
        public virtual ICollection<Beer> Beer { get; set; }
        public virtual ICollection<Brewery> Brewery { get; set; }
        public virtual ICollection<Cider> Cider { get; set; }
        public virtual ICollection<Cidery> Cidery { get; set; }
        public virtual ICollection<Distillery> Distillery { get; set; }
        public virtual ICollection<EventType> EventType { get; set; }
        public virtual ICollection<Liquor> Liquor { get; set; }
        public virtual ICollection<Mead> Mead { get; set; }
        public virtual ICollection<Seltzer> Seltzer { get; set; }
        public virtual ICollection<Seltzery> Seltzery { get; set; }
        public virtual ICollection<Ssadmin> Ssadmin { get; set; }
        public virtual ICollection<Ssevent> Ssevent { get; set; }
        public virtual ICollection<UserEmployeeXref> UserEmployeeXref { get; set; }
        public virtual ICollection<UserRolesXref> UserRolesXref { get; set; }
        public virtual ICollection<Venue> Venue { get; set; }
        public virtual ICollection<VenueType> VenueType { get; set; }
        public virtual ICollection<Wine> Wine { get; set; }
        public virtual ICollection<Winery> Winery { get; set; }
    }
}
