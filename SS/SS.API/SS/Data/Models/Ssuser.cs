using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SS.Data.Models
{
    public partial class Ssuser : IdentityUser<int>
    {
        public Ssuser()
        {
            ArtistCreatedByNavigation = new HashSet<Artist>();
            ArtistGroupMember = new HashSet<ArtistGroupMember>();
            ArtistGroupMemberRole = new HashSet<ArtistGroupMemberRole>();
            ArtistUser = new HashSet<Artist>();
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
            Ssevent = new HashSet<Ssevent>();
            SsuserClaim = new HashSet<SsuserClaim>();
            SsuserLogin = new HashSet<SsuserLogin>();
            SsuserRole = new HashSet<SsuserRole>();
            SsuserToken = new HashSet<SsuserToken>();
            Venue = new HashSet<Venue>();
            VenueType = new HashSet<VenueType>();
            Wine = new HashSet<Wine>();
            Winery = new HashSet<Winery>();
        }

        public int UserId { get; set; }
        // public string UserName { get; set; }
        // public string NormalizedUserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // public string Email { get; set; }
        // public string NormalizedEmail { get; set; }
        // public bool EmailConfirmed { get; set; }
        // public string PasswordHash { get; set; }
        // public string SecurityStamp { get; set; }
        // public string ConcurrencyStamp { get; set; }
        // public string PhoneNumber { get; set; }
        // public bool PhoneNumberConfirmed { get; set; }
        // public bool TwoFactorEnabled { get; set; }
        // public DateTimeOffset? LockoutEnd { get; set; }
        // public bool LockoutEnabled { get; set; }
        // public int AccessFailedCount { get; set; }
        public string DisplayName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int UserStatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastActive { get; set; }

        public virtual SsuserStatus UserStatus { get; set; }
        public virtual ICollection<Artist> ArtistCreatedByNavigation { get; set; }
        public virtual ICollection<ArtistGroupMember> ArtistGroupMember { get; set; }
        public virtual ICollection<ArtistGroupMemberRole> ArtistGroupMemberRole { get; set; }
        public virtual ICollection<Artist> ArtistUser { get; set; }
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
        public virtual ICollection<Ssevent> Ssevent { get; set; }
        public virtual ICollection<SsuserClaim> SsuserClaim { get; set; }
        public virtual ICollection<SsuserLogin> SsuserLogin { get; set; }
        public virtual ICollection<SsuserRole> SsuserRole { get; set; }
        public virtual ICollection<SsuserToken> SsuserToken { get; set; }
        public virtual ICollection<Venue> Venue { get; set; }
        public virtual ICollection<VenueType> VenueType { get; set; }
        public virtual ICollection<Wine> Wine { get; set; }
        public virtual ICollection<Winery> Winery { get; set; }
    }
}
