using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using SS.API.Models;

namespace SS.API.Data
{
    public partial class DataContext : IdentityDbContext<Ssuser, Ssrole, int,
        SsuserClaim, SsuserRole, SsuserLogin, SsroleClaim, SsuserToken>
    {
        private readonly IConfiguration _config;
        public DataContext() { }
        public DataContext(
            DbContextOptions<DataContext> options,
            IConfiguration config)
            : base(options)
        {
            _config = config;
        }

        public virtual DbSet<AmericanWhiskeyType> AmericanWhiskeyType { get; set; }
        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<ArtistGroupMember> ArtistGroupMember { get; set; }
        public virtual DbSet<ArtistGroupMemberRole> ArtistGroupMemberRole { get; set; }
        public virtual DbSet<ArtistGroupMemberRolesXref> ArtistGroupMemberRolesXref { get; set; }
        public virtual DbSet<ArtistPhoto> ArtistPhoto { get; set; }
        public virtual DbSet<ArtistStatus> ArtistStatus { get; set; }
        public virtual DbSet<ArtistType> ArtistType { get; set; }
        public virtual DbSet<ArtistTypeXref> ArtistTypeXref { get; set; }
        public virtual DbSet<Beer> Beer { get; set; }
        public virtual DbSet<BeerFamily> BeerFamily { get; set; }
        public virtual DbSet<BeerType> BeerType { get; set; }
        public virtual DbSet<BeerTypeSpecific> BeerTypeSpecific { get; set; }
        public virtual DbSet<Brewery> Brewery { get; set; }
        public virtual DbSet<Cider> Cider { get; set; }
        public virtual DbSet<CiderFlavor> CiderFlavor { get; set; }
        public virtual DbSet<CiderType> CiderType { get; set; }
        public virtual DbSet<Cidery> Cidery { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<DatabaseDiagnostics> DatabaseDiagnostics { get; set; }
        public virtual DbSet<DaysOfWeek> DaysOfWeek { get; set; }
        public virtual DbSet<Distillery> Distillery { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeRecord> EmployeeRecord { get; set; }
        public virtual DbSet<EmployeeTitle> EmployeeTitle { get; set; }
        public virtual DbSet<EmploymentStatus> EmploymentStatus { get; set; }
        public virtual DbSet<EventType> EventType { get; set; }
        public virtual DbSet<Liquor> Liquor { get; set; }
        public virtual DbSet<LiquorFamily> LiquorFamily { get; set; }
        public virtual DbSet<LiquorType> LiquorType { get; set; }
        public virtual DbSet<Mead> Mead { get; set; }
        public virtual DbSet<MeadType> MeadType { get; set; }
        public virtual DbSet<Meadery> Meadery { get; set; }
        public virtual DbSet<ScotchWhiskeyType> ScotchWhiskeyType { get; set; }
        public virtual DbSet<Seltzer> Seltzer { get; set; }
        public virtual DbSet<SeltzerFlavor> SeltzerFlavor { get; set; }
        public virtual DbSet<Seltzery> Seltzery { get; set; }
        public virtual DbSet<Ssaddress> Ssaddress { get; set; }
        public virtual DbSet<Ssevent> Ssevent { get; set; }
        public virtual DbSet<Ssrole> Ssrole { get; set; }
        public virtual DbSet<SsroleClaim> SsroleClaim { get; set; }
        public virtual DbSet<Ssuser> Ssuser { get; set; }
        public virtual DbSet<SsuserClaim> SsuserClaim { get; set; }
        public virtual DbSet<SsuserLogin> SsuserLogin { get; set; }
        public virtual DbSet<SsuserRole> SsuserRole { get; set; }
        public virtual DbSet<SsuserStatus> SsuserStatus { get; set; }
        public virtual DbSet<SsuserToken> SsuserToken { get; set; }
        public virtual DbSet<Usstate> Usstate { get; set; }
        public virtual DbSet<Venue> Venue { get; set; }
        public virtual DbSet<VenueHoursOpen> VenueHoursOpen { get; set; }
        public virtual DbSet<VenueType> VenueType { get; set; }
        public virtual DbSet<VenueTypeXref> VenueTypeXref { get; set; }
        public virtual DbSet<Wine> Wine { get; set; }
        public virtual DbSet<WineFamily> WineFamily { get; set; }
        public virtual DbSet<WineType> WineType { get; set; }
        public virtual DbSet<WineTypeSpecific> WineTypeSpecific { get; set; }
        public virtual DbSet<Winery> Winery { get; set; }
        public virtual DbSet<ZipCode> ZipCode { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AmericanWhiskeyType>(entity =>
            {
                entity.ToTable("AmericanWhiskeyType", "ref");

                entity.Property(e => e.AmericanWhiskeyTypeId).HasColumnName("AmericanWhiskeyTypeID");

                entity.Property(e => e.AmericanWhiskeyType1)
                    .IsRequired()
                    .HasColumnName("AmericanWhiskeyType")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.Property(e => e.ArtistId).HasColumnName("ArtistID");

                entity.Property(e => e.ArtistName).HasMaxLength(255);

                entity.Property(e => e.ArtistStatusId).HasColumnName("ArtistStatusID");

                entity.Property(e => e.CareerBeginDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.ArtistStatus)
                    .WithMany(p => p.Artist)
                    .HasForeignKey(d => d.ArtistStatusId)
                    .HasConstraintName("FK_Artist_ArtistStatusID");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ArtistCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Artist_CreatedBy");

                entity.HasOne(d => d.CurrentCityNavigation)
                    .WithMany(p => p.ArtistCurrentCityNavigation)
                    .HasForeignKey(d => d.CurrentCity)
                    .HasConstraintName("FK_Artist_CurrentCity");

                entity.HasOne(d => d.HomeCityNavigation)
                    .WithMany(p => p.ArtistHomeCityNavigation)
                    .HasForeignKey(d => d.HomeCity)
                    .HasConstraintName("FK_Artist_HomeCity");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ArtistUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Artist_UserID");
            });

            modelBuilder.Entity<ArtistGroupMember>(entity =>
            {
                entity.Property(e => e.ArtistGroupMemberId).HasColumnName("ArtistGroupMemberID");

                entity.Property(e => e.ArtistId).HasColumnName("ArtistID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.JoinDate).HasColumnType("datetime");

                entity.Property(e => e.LeaveDate).HasColumnType("datetime");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.ArtistGroupMember)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArtistGroupMember_ArtistTypeID");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ArtistGroupMember)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArtistGroupMember_CreatedBy");
            });

            modelBuilder.Entity<ArtistGroupMemberRole>(entity =>
            {
                entity.ToTable("ArtistGroupMemberRole", "ref");

                entity.Property(e => e.ArtistGroupMemberRoleId).HasColumnName("ArtistGroupMemberRoleID");

                entity.Property(e => e.ArtistGroupMemberRole1)
                    .IsRequired()
                    .HasColumnName("ArtistGroupMemberRole")
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ArtistGroupMemberRole)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArtistGroupMemberRole_CreatedBy");
            });

            modelBuilder.Entity<ArtistGroupMemberRolesXref>(entity =>
            {
                entity.ToTable("ArtistGroupMemberRolesXRef");

                entity.Property(e => e.ArtistGroupMemberRolesXrefId).HasColumnName("ArtistGroupMemberRolesXRefID");

                entity.Property(e => e.ArtistGroupMemberId).HasColumnName("ArtistGroupMemberID");

                entity.Property(e => e.ArtistGroupMemberRoleId).HasColumnName("ArtistGroupMemberRoleID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.ArtistGroupMember)
                    .WithMany(p => p.ArtistGroupMemberRolesXref)
                    .HasForeignKey(d => d.ArtistGroupMemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArtistGroupMemberRolesXRef_ArtistGroupMemberID");

                entity.HasOne(d => d.ArtistGroupMemberRole)
                    .WithMany(p => p.ArtistGroupMemberRolesXref)
                    .HasForeignKey(d => d.ArtistGroupMemberRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArtistGroupMemberRolesXRef_ArtistGroupMemberRoleID");
            });

            modelBuilder.Entity<ArtistPhoto>(entity =>
            {
                entity.Property(e => e.ArtistPhotoId).HasColumnName("ArtistPhotoID");

                entity.Property(e => e.ArtistId).HasColumnName("ArtistID");

                entity.Property(e => e.DateAdded)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PhotoDescription)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PhotoFileContentType)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PhotoFileExt)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PhotoFileName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PhotoPath)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.ArtistPhoto)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArtistPhoto_ArtistID");
            });

            modelBuilder.Entity<ArtistStatus>(entity =>
            {
                entity.ToTable("ArtistStatus", "ref");

                entity.Property(e => e.ArtistStatusId).HasColumnName("ArtistStatusID");

                entity.Property(e => e.ArtistStatus1)
                    .HasColumnName("ArtistStatus")
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ArtistType>(entity =>
            {
                entity.ToTable("ArtistType", "ref");

                entity.Property(e => e.ArtistTypeId).HasColumnName("ArtistTypeID");

                entity.Property(e => e.ArtistType1)
                    .HasColumnName("ArtistType")
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ArtistTypeXref>(entity =>
            {
                entity.ToTable("ArtistTypeXRef");

                entity.Property(e => e.ArtistTypeXrefId).HasColumnName("ArtistTypeXRefID");

                entity.Property(e => e.ArtistId).HasColumnName("ArtistID");

                entity.Property(e => e.ArtistTypeId).HasColumnName("ArtistTypeID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.ArtistTypeXref)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArtistTypeXRef_ArtistID");

                entity.HasOne(d => d.ArtistType)
                    .WithMany(p => p.ArtistTypeXref)
                    .HasForeignKey(d => d.ArtistTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArtistTypeXRef_ArtistTypeID");
            });

            modelBuilder.Entity<Beer>(entity =>
            {
                entity.Property(e => e.BeerId).HasColumnName("BeerID");

                entity.Property(e => e.BeerName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.BeerTypeSpecificId).HasColumnName("BeerTypeSpecificID");

                entity.Property(e => e.BreweryId).HasColumnName("BreweryID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.BeerTypeSpecific)
                    .WithMany(p => p.Beer)
                    .HasForeignKey(d => d.BeerTypeSpecificId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Beer_BeerTypeSpecificID");

                entity.HasOne(d => d.Brewery)
                    .WithMany(p => p.Beer)
                    .HasForeignKey(d => d.BreweryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Beer_BreweryID");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Beer)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Beer_CreatedBy");
            });

            modelBuilder.Entity<BeerFamily>(entity =>
            {
                entity.ToTable("BeerFamily", "ref");

                entity.Property(e => e.BeerFamilyId).HasColumnName("BeerFamilyID");

                entity.Property(e => e.BeerFamily1)
                    .IsRequired()
                    .HasColumnName("BeerFamily")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<BeerType>(entity =>
            {
                entity.ToTable("BeerType", "ref");

                entity.Property(e => e.BeerTypeId).HasColumnName("BeerTypeID");

                entity.Property(e => e.BeerFamilyId).HasColumnName("BeerFamilyID");

                entity.Property(e => e.BeerType1)
                    .IsRequired()
                    .HasColumnName("BeerType")
                    .HasMaxLength(255);

                entity.HasOne(d => d.BeerFamily)
                    .WithMany(p => p.BeerType)
                    .HasForeignKey(d => d.BeerFamilyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BeerType_BeerFamilyID");
            });

            modelBuilder.Entity<BeerTypeSpecific>(entity =>
            {
                entity.ToTable("BeerTypeSpecific", "ref");

                entity.Property(e => e.BeerTypeSpecificId).HasColumnName("BeerTypeSpecificID");

                entity.Property(e => e.BeerTypeId).HasColumnName("BeerTypeID");

                entity.Property(e => e.BeerTypeSpecific1)
                    .IsRequired()
                    .HasColumnName("BeerTypeSpecific")
                    .HasMaxLength(255);

                entity.HasOne(d => d.BeerType)
                    .WithMany(p => p.BeerTypeSpecific)
                    .HasForeignKey(d => d.BeerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BeerTypeSpecific_BeerTypeID");
            });

            modelBuilder.Entity<Brewery>(entity =>
            {
                entity.Property(e => e.BreweryId).HasColumnName("BreweryID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.BreweryName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ClosingDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OpeningDate).HasColumnType("datetime");

                entity.Property(e => e.VenueId).HasColumnName("VenueID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Brewery)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Brewery_AddressID");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Brewery)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Brewery_CreatedBy");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.Brewery)
                    .HasForeignKey(d => d.VenueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Brewery_VenueID");
            });

            modelBuilder.Entity<Cider>(entity =>
            {
                entity.Property(e => e.CiderId).HasColumnName("CiderID");

                entity.Property(e => e.CiderFlavorId).HasColumnName("CiderFlavorID");

                entity.Property(e => e.CiderName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CiderTypeId).HasColumnName("CiderTypeID");

                entity.Property(e => e.CideryId).HasColumnName("CideryID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CiderFlavor)
                    .WithMany(p => p.Cider)
                    .HasForeignKey(d => d.CiderFlavorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cider_CiderFlavorID");

                entity.HasOne(d => d.CiderType)
                    .WithMany(p => p.Cider)
                    .HasForeignKey(d => d.CiderTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cider_CiderTypeID");

                entity.HasOne(d => d.Cidery)
                    .WithMany(p => p.Cider)
                    .HasForeignKey(d => d.CideryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cider_CideryID");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Cider)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cider_CreatedBy");
            });

            modelBuilder.Entity<CiderFlavor>(entity =>
            {
                entity.ToTable("CiderFlavor", "ref");

                entity.Property(e => e.CiderFlavorId).HasColumnName("CiderFlavorID");

                entity.Property(e => e.CiderFlavor1)
                    .IsRequired()
                    .HasColumnName("CiderFlavor")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<CiderType>(entity =>
            {
                entity.ToTable("CiderType", "ref");

                entity.Property(e => e.CiderTypeId).HasColumnName("CiderTypeID");

                entity.Property(e => e.CiderType1)
                    .IsRequired()
                    .HasColumnName("CiderType")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Cidery>(entity =>
            {
                entity.Property(e => e.CideryId).HasColumnName("CideryID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.CideryName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ClosingDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OpeningDate).HasColumnType("datetime");

                entity.Property(e => e.VenueId).HasColumnName("VenueID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Cidery)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cidery_AddressID");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Cidery)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cidery_CreatedBy");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.Cidery)
                    .HasForeignKey(d => d.VenueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cidery_VenueID");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City", "const");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ClosestMajorCityId).HasColumnName("ClosestMajorCityID");

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.HasOne(d => d.ClosestMajorCity)
                    .WithMany(p => p.InverseClosestMajorCity)
                    .HasForeignKey(d => d.ClosestMajorCityId)
                    .HasConstraintName("FK_City_ClosestMajorCityID");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_City_StateID");
            });

            modelBuilder.Entity<DatabaseDiagnostics>(entity =>
            {
                entity.Property(e => e.DatabaseDiagnosticsId).HasColumnName("DatabaseDiagnosticsID");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ErrorMessage).HasMaxLength(500);

                entity.Property(e => e.ExecutedUser).HasMaxLength(256);

                entity.Property(e => e.Parameters).HasColumnType("xml");

                entity.Property(e => e.ProcedureName).HasMaxLength(500);

                entity.Property(e => e.RowGuid)
                    .HasColumnName("RowGUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<DaysOfWeek>(entity =>
            {
                entity.HasKey(e => e.DayOfWeekId)
                    .HasName("PK_DaysOfWeekID");

                entity.ToTable("DaysOfWeek", "const");

                entity.Property(e => e.DayOfWeekId).HasColumnName("DayOfWeekID");

                entity.Property(e => e.DayOfWeekAbbreviation).HasMaxLength(5);

                entity.Property(e => e.DayOfWeekLetterAbbreviation).HasMaxLength(2);

                entity.Property(e => e.DayOfWeekName).HasMaxLength(10);
            });

            modelBuilder.Entity<Distillery>(entity =>
            {
                entity.Property(e => e.DistilleryId).HasColumnName("DistilleryID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.ClosingDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DistilleryName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.OpeningDate).HasColumnType("datetime");

                entity.Property(e => e.VenueId).HasColumnName("VenueID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Distillery)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Distillery_AddressID");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Distillery)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Distillery_CreatedBy");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.Distillery)
                    .HasForeignKey(d => d.VenueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Distillery_VenueID");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee", "hr");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.LastName).HasMaxLength(255);
            });

            modelBuilder.Entity<EmployeeRecord>(entity =>
            {
                entity.ToTable("EmployeeRecord", "hr");

                entity.Property(e => e.EmployeeRecordId).HasColumnName("EmployeeRecordID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EmployeeTitleId).HasColumnName("EmployeeTitleID");

                entity.Property(e => e.EmploymentStatusId).HasColumnName("EmploymentStatusID");

                entity.Property(e => e.HireDate).HasColumnType("datetime");

                entity.Property(e => e.TerminationDate).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeRecord)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeRecord_EmployeeID");

                entity.HasOne(d => d.EmployeeTitle)
                    .WithMany(p => p.EmployeeRecord)
                    .HasForeignKey(d => d.EmployeeTitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_EmployeeTitleID");

                entity.HasOne(d => d.EmploymentStatus)
                    .WithMany(p => p.EmployeeRecord)
                    .HasForeignKey(d => d.EmploymentStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_EmploymentStatusID");
            });

            modelBuilder.Entity<EmployeeTitle>(entity =>
            {
                entity.ToTable("EmployeeTitle", "refHR");

                entity.Property(e => e.EmployeeTitleId).HasColumnName("EmployeeTitleID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmployeeTitle1)
                    .HasColumnName("EmployeeTitle")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EmploymentStatus>(entity =>
            {
                entity.ToTable("EmploymentStatus", "refHR");

                entity.Property(e => e.EmploymentStatusId).HasColumnName("EmploymentStatusID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmploymentStatus1)
                    .HasColumnName("EmploymentStatus")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.ToTable("EventType", "ref");

                entity.Property(e => e.EventTypeId).HasColumnName("EventTypeID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EventType1)
                    .HasColumnName("EventType")
                    .HasMaxLength(255);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.EventType)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventType_CreatedBy");
            });

            modelBuilder.Entity<Liquor>(entity =>
            {
                entity.Property(e => e.LiquorId).HasColumnName("LiquorID");

                entity.Property(e => e.AmericanWhiskeyTypeId).HasColumnName("AmericanWhiskeyTypeID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DistilleryId).HasColumnName("DistilleryID");

                entity.Property(e => e.LiquorName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.LiquorTypeId).HasColumnName("LiquorTypeID");

                entity.Property(e => e.ScotchWhiskeyTypeId).HasColumnName("ScotchWhiskeyTypeID");

                entity.HasOne(d => d.AmericanWhiskeyType)
                    .WithMany(p => p.Liquor)
                    .HasForeignKey(d => d.AmericanWhiskeyTypeId)
                    .HasConstraintName("FK_Liquor_AmericanWhiskeyTypeID");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Liquor)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Liquor_CreatedBy");

                entity.HasOne(d => d.Distillery)
                    .WithMany(p => p.Liquor)
                    .HasForeignKey(d => d.DistilleryId)
                    .HasConstraintName("FK_Liquor_DistilleryID");

                entity.HasOne(d => d.LiquorType)
                    .WithMany(p => p.Liquor)
                    .HasForeignKey(d => d.LiquorTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Liquor_LiquorTypeID");

                entity.HasOne(d => d.ScotchWhiskeyType)
                    .WithMany(p => p.Liquor)
                    .HasForeignKey(d => d.ScotchWhiskeyTypeId)
                    .HasConstraintName("FK_Liquor_ScotchWhiskeyTypeID");
            });

            modelBuilder.Entity<LiquorFamily>(entity =>
            {
                entity.ToTable("LiquorFamily", "ref");

                entity.Property(e => e.LiquorFamilyId).HasColumnName("LiquorFamilyID");

                entity.Property(e => e.LiquorFamily1)
                    .IsRequired()
                    .HasColumnName("LiquorFamily")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<LiquorType>(entity =>
            {
                entity.ToTable("LiquorType", "ref");

                entity.Property(e => e.LiquorTypeId).HasColumnName("LiquorTypeID");

                entity.Property(e => e.LiquorFamilyId).HasColumnName("LiquorFamilyID");

                entity.Property(e => e.LiquorType1)
                    .IsRequired()
                    .HasColumnName("LiquorType")
                    .HasMaxLength(255);

                entity.HasOne(d => d.LiquorFamily)
                    .WithMany(p => p.LiquorType)
                    .HasForeignKey(d => d.LiquorFamilyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LiquorType_LiquorFamilyID");
            });

            modelBuilder.Entity<Mead>(entity =>
            {
                entity.Property(e => e.MeadId).HasColumnName("MeadID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.HoneyWine).HasDefaultValueSql("((0))");

                entity.Property(e => e.MeadName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.MeadTypeId).HasColumnName("MeadTypeID");

                entity.Property(e => e.MeaderyId).HasColumnName("MeaderyID");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Mead)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mead_CreatedBy");

                entity.HasOne(d => d.MeadType)
                    .WithMany(p => p.Mead)
                    .HasForeignKey(d => d.MeadTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mead_MeadTypeID");

                entity.HasOne(d => d.Meadery)
                    .WithMany(p => p.Mead)
                    .HasForeignKey(d => d.MeaderyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mead_MeaderyID");
            });

            modelBuilder.Entity<MeadType>(entity =>
            {
                entity.ToTable("MeadType", "ref");

                entity.Property(e => e.MeadTypeId).HasColumnName("MeadTypeID");

                entity.Property(e => e.MeadType1)
                    .IsRequired()
                    .HasColumnName("MeadType")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Meadery>(entity =>
            {
                entity.Property(e => e.MeaderyId).HasColumnName("MeaderyID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.ClosingDate).HasColumnType("datetime");

                entity.Property(e => e.MeaderyName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.OpeningDate).HasColumnType("datetime");

                entity.Property(e => e.VenueId).HasColumnName("VenueID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Meadery)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Meadery_AddressID");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.Meadery)
                    .HasForeignKey(d => d.VenueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Meadery_VenueID");
            });

            modelBuilder.Entity<ScotchWhiskeyType>(entity =>
            {
                entity.ToTable("ScotchWhiskeyType", "ref");

                entity.Property(e => e.ScotchWhiskeyTypeId).HasColumnName("ScotchWhiskeyTypeID");

                entity.Property(e => e.ScotchWhiskeyType1)
                    .IsRequired()
                    .HasColumnName("ScotchWhiskeyType")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Seltzer>(entity =>
            {
                entity.Property(e => e.SeltzerId).HasColumnName("SeltzerID");

                entity.Property(e => e.BreweryId).HasColumnName("BreweryID");

                entity.Property(e => e.CideryId).HasColumnName("CideryID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MeaderyId).HasColumnName("MeaderyID");

                entity.Property(e => e.SeltzerFlavorId).HasColumnName("SeltzerFlavorID");

                entity.Property(e => e.SeltzerName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.SeltzeryId).HasColumnName("SeltzeryID");

                entity.HasOne(d => d.Brewery)
                    .WithMany(p => p.Seltzer)
                    .HasForeignKey(d => d.BreweryId)
                    .HasConstraintName("FK_Seltzer_BreweryID");

                entity.HasOne(d => d.Cidery)
                    .WithMany(p => p.Seltzer)
                    .HasForeignKey(d => d.CideryId)
                    .HasConstraintName("FK_Seltzer_CideryID");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Seltzer)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Seltzer_CreatedBy");

                entity.HasOne(d => d.Meadery)
                    .WithMany(p => p.Seltzer)
                    .HasForeignKey(d => d.MeaderyId)
                    .HasConstraintName("FK_Seltzer_MeaderyID");

                entity.HasOne(d => d.SeltzerFlavor)
                    .WithMany(p => p.Seltzer)
                    .HasForeignKey(d => d.SeltzerFlavorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Seltzer_SeltzerFlavorID");

                entity.HasOne(d => d.Seltzery)
                    .WithMany(p => p.InverseSeltzery)
                    .HasForeignKey(d => d.SeltzeryId)
                    .HasConstraintName("FK_Seltzer_SeltzeryID");
            });

            modelBuilder.Entity<SeltzerFlavor>(entity =>
            {
                entity.ToTable("SeltzerFlavor", "ref");

                entity.Property(e => e.SeltzerFlavorId).HasColumnName("SeltzerFlavorID");

                entity.Property(e => e.SeltzerFlavor1)
                    .IsRequired()
                    .HasColumnName("SeltzerFlavor")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Seltzery>(entity =>
            {
                entity.Property(e => e.SeltzeryId).HasColumnName("SeltzeryID");

                entity.Property(e => e.ClosingDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OpeningDate).HasColumnType("datetime");

                entity.Property(e => e.SeltzeryName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.VenueId).HasColumnName("VenueID");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Seltzery)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Seltzery_CreatedBy");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.Seltzery)
                    .HasForeignKey(d => d.VenueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Seltzery_VenueID");
            });

            modelBuilder.Entity<Ssaddress>(entity =>
            {
                entity.HasKey(e => e.AddressId)
                    .HasName("PK_AddressID");

                entity.ToTable("SSAddress");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StreetAddress)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.StreetAddress2).HasMaxLength(255);

                entity.Property(e => e.ZipCodeId).HasColumnName("ZipCodeID");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Ssaddress)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_CityID");

                entity.HasOne(d => d.ZipCode)
                    .WithMany(p => p.Ssaddress)
                    .HasForeignKey(d => d.ZipCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_ZipCodeID");
            });

            modelBuilder.Entity<Ssevent>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("PK_EventID");

                entity.ToTable("SSEvent");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.EventTime).HasColumnType("datetime");

                entity.Property(e => e.EventTypeId).HasColumnName("EventTypeID");

                entity.Property(e => e.EventVenueId).HasColumnName("EventVenueID");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Ssevent)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_CreatedBy");

                entity.HasOne(d => d.EventType)
                    .WithMany(p => p.Ssevent)
                    .HasForeignKey(d => d.EventTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_EventTypeID");

                entity.HasOne(d => d.EventVenue)
                    .WithMany(p => p.Ssevent)
                    .HasForeignKey(d => d.EventVenueId)
                    .HasConstraintName("FK_Event_EventVenueID");
            });

            modelBuilder.Entity<Ssrole>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("SSRole", "ident");

                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<SsroleClaim>(entity =>
            {
                entity.HasKey(e => e.RoleClaimId);

                entity.ToTable("SSRoleClaim", "ident");

                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleClaimId).HasColumnName("RoleClaimID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.SsroleClaim)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<Ssuser>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("SSUser", "ident");

                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).HasColumnName("UserID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.LastActive)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.Property(e => e.UserStatusId).HasColumnName("UserStatusID");

                entity.HasOne(d => d.UserStatus)
                    .WithMany(p => p.Ssuser)
                    .HasForeignKey(d => d.UserStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_UserStatusID");
            });

            modelBuilder.Entity<SsuserClaim>(entity =>
            {
                entity.HasKey(e => e.UserClaimId);

                entity.ToTable("SSUserClaim", "ident");

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserClaimId).HasColumnName("UserClaimID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SsuserClaim)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<SsuserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.ToTable("SSUserLogin", "ident");

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SsuserLogin)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<SsuserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.ToTable("SSUserRole", "ident");

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.SsuserRole)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SsuserRole)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<SsuserStatus>(entity =>
            {
                entity.HasKey(e => e.UserStatusId);

                entity.ToTable("SSUserStatus", "ident");

                entity.Property(e => e.UserStatusId).HasColumnName("UserStatusID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserStatus).HasMaxLength(255);
            });

            modelBuilder.Entity<SsuserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.ToTable("SSUserToken", "ident");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SsuserToken)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Usstate>(entity =>
            {
                entity.HasKey(e => e.StateId);

                entity.ToTable("USState", "const");

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.Property(e => e.StateAbbreviation)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Venue>(entity =>
            {
                entity.Property(e => e.VenueId).HasColumnName("VenueID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.VenueAddressId).HasColumnName("VenueAddressID");

                entity.Property(e => e.VenueName).HasMaxLength(255);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Venue)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Venue_CreatedBy");

                entity.HasOne(d => d.VenueAddress)
                    .WithMany(p => p.Venue)
                    .HasForeignKey(d => d.VenueAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Venue_VenueAddressID");
            });

            modelBuilder.Entity<VenueHoursOpen>(entity =>
            {
                entity.Property(e => e.VenueHoursOpenId).HasColumnName("VenueHoursOpenID");

                entity.Property(e => e.DayOfWeekId).HasColumnName("DayOfWeekID");

                entity.Property(e => e.VenueId).HasColumnName("VenueID");

                entity.HasOne(d => d.DayOfWeek)
                    .WithMany(p => p.VenueHoursOpen)
                    .HasForeignKey(d => d.DayOfWeekId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VenueHoursOpen_DayOfWeekID");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.VenueHoursOpen)
                    .HasForeignKey(d => d.VenueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VenueHoursOpen_VenueID");
            });

            modelBuilder.Entity<VenueType>(entity =>
            {
                entity.ToTable("VenueType", "ref");

                entity.Property(e => e.VenueTypeId).HasColumnName("VenueTypeID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.VenueType1)
                    .HasColumnName("VenueType")
                    .HasMaxLength(255);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.VenueType)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VenueType_CreatedBy");
            });

            modelBuilder.Entity<VenueTypeXref>(entity =>
            {
                entity.ToTable("VenueTypeXRef");

                entity.Property(e => e.VenueTypeXrefId).HasColumnName("VenueTypeXRefID");

                entity.Property(e => e.VenueId).HasColumnName("VenueID");

                entity.Property(e => e.VenueTypeId).HasColumnName("VenueTypeID");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.VenueTypeXref)
                    .HasForeignKey(d => d.VenueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VenueTypeXRef_VenueID");

                entity.HasOne(d => d.VenueType)
                    .WithMany(p => p.VenueTypeXref)
                    .HasForeignKey(d => d.VenueTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VenueTypeXRef_VenueTypeID");
            });

            modelBuilder.Entity<Wine>(entity =>
            {
                entity.Property(e => e.WineId).HasColumnName("WineID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.WineName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.WineTypeId).HasColumnName("WineTypeID");

                entity.Property(e => e.WineryId).HasColumnName("WineryID");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Wine)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Wine_CreatedBy");

                entity.HasOne(d => d.WineType)
                    .WithMany(p => p.Wine)
                    .HasForeignKey(d => d.WineTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Wine_WineTypeID");

                entity.HasOne(d => d.Winery)
                    .WithMany(p => p.Wine)
                    .HasForeignKey(d => d.WineryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Wine_WineryID");
            });

            modelBuilder.Entity<WineFamily>(entity =>
            {
                entity.ToTable("WineFamily", "ref");

                entity.Property(e => e.WineFamilyId).HasColumnName("WineFamilyID");

                entity.Property(e => e.WineFamily1)
                    .IsRequired()
                    .HasColumnName("WineFamily")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<WineType>(entity =>
            {
                entity.ToTable("WineType", "ref");

                entity.Property(e => e.WineTypeId).HasColumnName("WineTypeID");

                entity.Property(e => e.WineFamilyId).HasColumnName("WineFamilyID");

                entity.Property(e => e.WineType1)
                    .IsRequired()
                    .HasColumnName("WineType")
                    .HasMaxLength(255);

                entity.HasOne(d => d.WineFamily)
                    .WithMany(p => p.WineType)
                    .HasForeignKey(d => d.WineFamilyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WineType_WineFamilyID");
            });

            modelBuilder.Entity<WineTypeSpecific>(entity =>
            {
                entity.ToTable("WineTypeSpecific", "ref");

                entity.Property(e => e.WineTypeSpecificId).HasColumnName("WineTypeSpecificID");

                entity.Property(e => e.WineTypeId).HasColumnName("WineTypeID");

                entity.Property(e => e.WineTypeSpecific1)
                    .IsRequired()
                    .HasColumnName("WineTypeSpecific")
                    .HasMaxLength(255);

                entity.HasOne(d => d.WineType)
                    .WithMany(p => p.WineTypeSpecific)
                    .HasForeignKey(d => d.WineTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WineTypeSpecific_WineTypeID");
            });

            modelBuilder.Entity<Winery>(entity =>
            {
                entity.Property(e => e.WineryId).HasColumnName("WineryID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.ClosingDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OpeningDate).HasColumnType("datetime");

                entity.Property(e => e.VenueId).HasColumnName("VenueID");

                entity.Property(e => e.WineryName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Winery)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Winery_AddressID");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Winery)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Winery_CreatedBy");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.Winery)
                    .HasForeignKey(d => d.VenueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Winery_VenueID");
            });

            modelBuilder.Entity<ZipCode>(entity =>
            {
                entity.ToTable("ZipCode", "const");

                entity.Property(e => e.ZipCodeId).HasColumnName("ZipCodeID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.ZipCode1).HasColumnName("ZipCode");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.ZipCode)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ZipCode_CityID");
            });

            OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ssuser>().ToTable("SSUser", "ident");
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
