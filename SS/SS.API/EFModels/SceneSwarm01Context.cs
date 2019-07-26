using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SS.API.EFModels
{
    public partial class SceneSwarm01Context : DbContext
    {
        public SceneSwarm01Context()
        {
        }

        public SceneSwarm01Context(DbContextOptions<SceneSwarm01Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<AdminRoles> AdminRoles { get; set; }
        public virtual DbSet<AdminRolesXref> AdminRolesXref { get; set; }
        public virtual DbSet<Admins> Admins { get; set; }
        public virtual DbSet<ArtistGroupMemberRoles> ArtistGroupMemberRoles { get; set; }
        public virtual DbSet<ArtistGroupMemberRolesXref> ArtistGroupMemberRolesXref { get; set; }
        public virtual DbSet<ArtistGroupMembers> ArtistGroupMembers { get; set; }
        public virtual DbSet<Artists> Artists { get; set; }
        public virtual DbSet<ArtistStatuses> ArtistStatuses { get; set; }
        public virtual DbSet<ArtistTypes> ArtistTypes { get; set; }
        public virtual DbSet<ArtistTypeXref> ArtistTypeXref { get; set; }
        public virtual DbSet<BeerFamilies> BeerFamilies { get; set; }
        public virtual DbSet<Beers> Beers { get; set; }
        public virtual DbSet<BeerTypes> BeerTypes { get; set; }
        public virtual DbSet<Breweries> Breweries { get; set; }
        public virtual DbSet<CiderFamilies> CiderFamilies { get; set; }
        public virtual DbSet<Cideries> Cideries { get; set; }
        public virtual DbSet<Ciders> Ciders { get; set; }
        public virtual DbSet<CiderTypes> CiderTypes { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<CityZipcodeXref> CityZipcodeXref { get; set; }
        public virtual DbSet<DatabaseDiagnostics> DatabaseDiagnostics { get; set; }
        public virtual DbSet<DaysOfWeek> DaysOfWeek { get; set; }
        public virtual DbSet<Distilleries> Distilleries { get; set; }
        public virtual DbSet<EmployeeRecords> EmployeeRecords { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<EmployeeTitles> EmployeeTitles { get; set; }
        public virtual DbSet<EmploymentStatuses> EmploymentStatuses { get; set; }
        public virtual DbSet<EventsSs> EventsSs { get; set; }
        public virtual DbSet<EventTypesSs> EventTypesSs { get; set; }
        public virtual DbSet<Meaderies> Meaderies { get; set; }
        public virtual DbSet<MeadFamilies> MeadFamilies { get; set; }
        public virtual DbSet<Meads> Meads { get; set; }
        public virtual DbSet<MeadTypes> MeadTypes { get; set; }
        public virtual DbSet<SpiritFamiles> SpiritFamiles { get; set; }
        public virtual DbSet<Spirits> Spirits { get; set; }
        public virtual DbSet<SpiritTypes> SpiritTypes { get; set; }
        public virtual DbSet<States> States { get; set; }
        public virtual DbSet<UserEmployeeXref> UserEmployeeXref { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<UserRolesXref> UserRolesXref { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UserStatuses> UserStatuses { get; set; }
        public virtual DbSet<VenueHoursOpen> VenueHoursOpen { get; set; }
        public virtual DbSet<Venues> Venues { get; set; }
        public virtual DbSet<VenueTypes> VenueTypes { get; set; }
        public virtual DbSet<VenueTypeXref> VenueTypeXref { get; set; }
        public virtual DbSet<WineFamilies> WineFamilies { get; set; }
        public virtual DbSet<Wineries> Wineries { get; set; }
        public virtual DbSet<Wines> Wines { get; set; }
        public virtual DbSet<WineTypes> WineTypes { get; set; }
        public virtual DbSet<ZipCodes> ZipCodes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=SceneSwarm01;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.HasKey(e => e.AddressId);

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.Property(e => e.StreetAddress).HasMaxLength(255);

                entity.Property(e => e.StreetAddress2).HasMaxLength(255);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Addresses_CityID");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Addresses_StateID");

                entity.HasOne(d => d.ZipCodeNavigation)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.ZipCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Addresses_ZipCode");
            });

            modelBuilder.Entity<AdminRoles>(entity =>
            {
                entity.HasKey(e => e.AdminRoleId);

                entity.ToTable("AdminRoles", "refAdminSS");

                entity.Property(e => e.AdminRoleId).HasColumnName("AdminRoleID");

                entity.Property(e => e.AdminRole).HasMaxLength(255);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<AdminRolesXref>(entity =>
            {
                entity.ToTable("AdminRolesXRef", "AdminSS");

                entity.Property(e => e.AdminRolesXrefId).HasColumnName("AdminRolesXRefID");

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.AdminRolesXref)
                    .HasForeignKey(d => d.AdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdminRolesXRef_AdminID");

                entity.HasOne(d => d.UserRolesNavigation)
                    .WithMany(p => p.AdminRolesXref)
                    .HasForeignKey(d => d.UserRoles)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdminRolesXRef_AdminRoleID");
            });

            modelBuilder.Entity<Admins>(entity =>
            {
                entity.HasKey(e => e.AdminId);

                entity.ToTable("Admins", "AdminSS");

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Admins)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Admins_UserID");
            });

            modelBuilder.Entity<ArtistGroupMemberRoles>(entity =>
            {
                entity.HasKey(e => e.ArtistGroupMemberRoleId);

                entity.ToTable("ArtistGroupMemberRoles", "ref");

                entity.Property(e => e.ArtistGroupMemberRoleId).HasColumnName("ArtistGroupMemberRoleID");

                entity.Property(e => e.ArtistGroupMemberRole)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ArtistGroupMemberRoles)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArtistGroupMemberRoles_CreatedBy");
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

            modelBuilder.Entity<ArtistGroupMembers>(entity =>
            {
                entity.HasKey(e => e.ArtistGroupMemberId);

                entity.Property(e => e.ArtistGroupMemberId).HasColumnName("ArtistGroupMemberID");

                entity.Property(e => e.ArtistId).HasColumnName("ArtistID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.JoinDate).HasColumnType("datetime");

                entity.Property(e => e.LeaveDate).HasColumnType("datetime");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.ArtistGroupMembers)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArtistGroupMembers_ArtistTypeID");
            });

            modelBuilder.Entity<Artists>(entity =>
            {
                entity.HasKey(e => e.ArtistId);

                entity.Property(e => e.ArtistId).HasColumnName("ArtistID");

                entity.Property(e => e.ArtistName).HasMaxLength(255);

                entity.Property(e => e.CareerBeginDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ArtistStatuses>(entity =>
            {
                entity.HasKey(e => e.ArtistStatusId);

                entity.ToTable("ArtistStatuses", "ref");

                entity.Property(e => e.ArtistStatusId).HasColumnName("ArtistStatusID");

                entity.Property(e => e.ArtistStatus).HasMaxLength(255);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ArtistStatuses)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArtistStatuses_CreatedBy");
            });

            modelBuilder.Entity<ArtistTypes>(entity =>
            {
                entity.HasKey(e => e.ArtistTypeId);

                entity.ToTable("ArtistTypes", "ref");

                entity.Property(e => e.ArtistTypeId).HasColumnName("ArtistTypeID");

                entity.Property(e => e.ArtistType).HasMaxLength(255);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ArtistTypes)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArtistTypes_CreatedBy");
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

            modelBuilder.Entity<BeerFamilies>(entity =>
            {
                entity.HasKey(e => e.BeerFamilyId);

                entity.ToTable("BeerFamilies", "ref");

                entity.Property(e => e.BeerFamilyId).HasColumnName("BeerFamilyID");

                entity.Property(e => e.BeerFamily)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Beers>(entity =>
            {
                entity.HasKey(e => e.BeerId);

                entity.Property(e => e.BeerId).HasColumnName("BeerID");

                entity.Property(e => e.BeerName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.BeerTypeId).HasColumnName("BeerTypeID");

                entity.HasOne(d => d.BeerType)
                    .WithMany(p => p.Beers)
                    .HasForeignKey(d => d.BeerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Beers_BeerTypeID");
            });

            modelBuilder.Entity<BeerTypes>(entity =>
            {
                entity.HasKey(e => e.BeerTypeId);

                entity.ToTable("BeerTypes", "ref");

                entity.Property(e => e.BeerTypeId).HasColumnName("BeerTypeID");

                entity.Property(e => e.BeerFamilyId).HasColumnName("BeerFamilyID");

                entity.Property(e => e.BeerType)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.BeerFamily)
                    .WithMany(p => p.BeerTypes)
                    .HasForeignKey(d => d.BeerFamilyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BeerTypes_BeerFamilyID");
            });

            modelBuilder.Entity<Breweries>(entity =>
            {
                entity.HasKey(e => e.BreweryId);

                entity.Property(e => e.BreweryId).HasColumnName("BreweryID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.BreweryName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ClosingDate).HasColumnType("datetime");

                entity.Property(e => e.OpeningDate).HasColumnType("datetime");

                entity.Property(e => e.VenueId).HasColumnName("VenueID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Breweries)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Breweries_AddressID");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.Breweries)
                    .HasForeignKey(d => d.VenueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Breweries_VenueID");
            });

            modelBuilder.Entity<CiderFamilies>(entity =>
            {
                entity.HasKey(e => e.CiderFamilyId);

                entity.ToTable("CiderFamilies", "ref");

                entity.Property(e => e.CiderFamilyId).HasColumnName("CiderFamilyID");

                entity.Property(e => e.CiderFamily)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Cideries>(entity =>
            {
                entity.HasKey(e => e.CideryId);

                entity.Property(e => e.CideryId).HasColumnName("CideryID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.CideryName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ClosingDate).HasColumnType("datetime");

                entity.Property(e => e.OpeningDate).HasColumnType("datetime");

                entity.Property(e => e.VenueId).HasColumnName("VenueID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Cideries)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cideries_AddressID");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.Cideries)
                    .HasForeignKey(d => d.VenueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cideries_VenueID");
            });

            modelBuilder.Entity<Ciders>(entity =>
            {
                entity.HasKey(e => e.CiderId);

                entity.Property(e => e.CiderId).HasColumnName("CiderID");

                entity.Property(e => e.CiderName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CiderTypeId).HasColumnName("CiderTypeID");

                entity.HasOne(d => d.CiderType)
                    .WithMany(p => p.Ciders)
                    .HasForeignKey(d => d.CiderTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ciders_CiderTypeID");
            });

            modelBuilder.Entity<CiderTypes>(entity =>
            {
                entity.HasKey(e => e.CiderTypeId);

                entity.ToTable("CiderTypes", "ref");

                entity.Property(e => e.CiderTypeId).HasColumnName("CiderTypeID");

                entity.Property(e => e.CiderFamilyId).HasColumnName("CiderFamilyID");

                entity.Property(e => e.CiderType)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.CiderFamily)
                    .WithMany(p => p.CiderTypes)
                    .HasForeignKey(d => d.CiderFamilyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CiderTypes_CiderFamilyID");
            });

            modelBuilder.Entity<Cities>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.ToTable("Cities", "const");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(2);
            });

            modelBuilder.Entity<CityZipcodeXref>(entity =>
            {
                entity.ToTable("CityZipcodeXRef", "const");

                entity.Property(e => e.CityZipcodeXrefId).HasColumnName("CityZipcodeXRefID");

                entity.HasOne(d => d.ZipCodeNavigation)
                    .WithMany(p => p.CityZipcodeXref)
                    .HasForeignKey(d => d.ZipCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CityZipcodeXRef_ZipCode");
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
                entity.HasKey(e => e.DayOfWeekId);

                entity.ToTable("DaysOfWeek", "const");

                entity.Property(e => e.DayOfWeekId).HasColumnName("DayOfWeekID");

                entity.Property(e => e.DayOfWeekName).HasMaxLength(255);
            });

            modelBuilder.Entity<Distilleries>(entity =>
            {
                entity.HasKey(e => e.DistilleryId);

                entity.Property(e => e.DistilleryId).HasColumnName("DistilleryID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.ClosingDate).HasColumnType("datetime");

                entity.Property(e => e.DistilleryName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.OpeningDate).HasColumnType("datetime");

                entity.Property(e => e.VenueId).HasColumnName("VenueID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Distilleries)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Distilleries_AddressID");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.Distilleries)
                    .HasForeignKey(d => d.VenueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Distilleries_VenueID");
            });

            modelBuilder.Entity<EmployeeRecords>(entity =>
            {
                entity.HasKey(e => e.EmployeeRecordId);

                entity.ToTable("EmployeeRecords", "hr");

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
                    .WithMany(p => p.EmployeeRecords)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeRecords_EmployeeID");

                entity.HasOne(d => d.EmployeeTitle)
                    .WithMany(p => p.EmployeeRecords)
                    .HasForeignKey(d => d.EmployeeTitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_EmployeeTitleID");

                entity.HasOne(d => d.EmploymentStatus)
                    .WithMany(p => p.EmployeeRecords)
                    .HasForeignKey(d => d.EmploymentStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_EmploymentStatusID");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("Employees", "hr");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.LastName).HasMaxLength(255);
            });

            modelBuilder.Entity<EmployeeTitles>(entity =>
            {
                entity.HasKey(e => e.EmployeeTitleId);

                entity.ToTable("EmployeeTitles", "refHR");

                entity.Property(e => e.EmployeeTitleId).HasColumnName("EmployeeTitleID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmployeeTitle).HasMaxLength(255);
            });

            modelBuilder.Entity<EmploymentStatuses>(entity =>
            {
                entity.HasKey(e => e.EmploymentStatusId);

                entity.ToTable("EmploymentStatuses", "refHR");

                entity.Property(e => e.EmploymentStatusId).HasColumnName("EmploymentStatusID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmploymentStatus).HasMaxLength(255);
            });

            modelBuilder.Entity<EventsSs>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.ToTable("EventsSS");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.EventTime).HasColumnType("datetime");

                entity.Property(e => e.EventTypeId).HasColumnName("EventTypeID");

                entity.Property(e => e.EventVenueId).HasColumnName("EventVenueID");

                entity.HasOne(d => d.EventType)
                    .WithMany(p => p.EventsSs)
                    .HasForeignKey(d => d.EventTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventsSS_EventTypeID");

                entity.HasOne(d => d.EventVenue)
                    .WithMany(p => p.EventsSs)
                    .HasForeignKey(d => d.EventVenueId)
                    .HasConstraintName("FK_EventsSS_EventVenueID");
            });

            modelBuilder.Entity<EventTypesSs>(entity =>
            {
                entity.HasKey(e => e.EventTypeId);

                entity.ToTable("EventTypesSS", "ref");

                entity.Property(e => e.EventTypeId).HasColumnName("EventTypeID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EventType).HasMaxLength(255);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.EventTypesSs)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventTypesSSID_CreatedBy");
            });

            modelBuilder.Entity<Meaderies>(entity =>
            {
                entity.HasKey(e => e.MeaderyId);

                entity.Property(e => e.MeaderyId).HasColumnName("MeaderyID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.ClosingDate).HasColumnType("datetime");

                entity.Property(e => e.MeaderyName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.OpeningDate).HasColumnType("datetime");

                entity.Property(e => e.VenueId).HasColumnName("VenueID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Meaderies)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Meaderies_AddressID");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.Meaderies)
                    .HasForeignKey(d => d.VenueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Meaderies_VenueID");
            });

            modelBuilder.Entity<MeadFamilies>(entity =>
            {
                entity.HasKey(e => e.MeadFamilyId);

                entity.ToTable("MeadFamilies", "ref");

                entity.Property(e => e.MeadFamilyId).HasColumnName("MeadFamilyID");

                entity.Property(e => e.MeadFamily)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Meads>(entity =>
            {
                entity.HasKey(e => e.MeadId);

                entity.Property(e => e.MeadId).HasColumnName("MeadID");

                entity.Property(e => e.HoneyWine).HasDefaultValueSql("((0))");

                entity.Property(e => e.MeadName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.MeadTypeId).HasColumnName("MeadTypeID");

                entity.HasOne(d => d.MeadType)
                    .WithMany(p => p.Meads)
                    .HasForeignKey(d => d.MeadTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Meads_MeadTypeID");
            });

            modelBuilder.Entity<MeadTypes>(entity =>
            {
                entity.HasKey(e => e.MeadTypeId);

                entity.ToTable("MeadTypes", "ref");

                entity.Property(e => e.MeadTypeId).HasColumnName("MeadTypeID");

                entity.Property(e => e.MeadFamilyId).HasColumnName("MeadFamilyID");

                entity.Property(e => e.MeadType)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.MeadFamily)
                    .WithMany(p => p.MeadTypes)
                    .HasForeignKey(d => d.MeadFamilyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MeadFamilies_MeadFamilyID");
            });

            modelBuilder.Entity<SpiritFamiles>(entity =>
            {
                entity.HasKey(e => e.SpiritFamilyId);

                entity.ToTable("SpiritFamiles", "ref");

                entity.Property(e => e.SpiritFamilyId).HasColumnName("SpiritFamilyID");

                entity.Property(e => e.SpiritFamily)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Spirits>(entity =>
            {
                entity.HasKey(e => e.SpiritId);

                entity.Property(e => e.SpiritId).HasColumnName("SpiritID");

                entity.Property(e => e.SpiritName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.SpiritTypeId).HasColumnName("SpiritTypeID");

                entity.HasOne(d => d.SpiritType)
                    .WithMany(p => p.Spirits)
                    .HasForeignKey(d => d.SpiritTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Spirits_SpiritTypeID");
            });

            modelBuilder.Entity<SpiritTypes>(entity =>
            {
                entity.HasKey(e => e.SpiritTypeId);

                entity.ToTable("SpiritTypes", "ref");

                entity.Property(e => e.SpiritTypeId).HasColumnName("SpiritTypeID");

                entity.Property(e => e.SpiritFamilyId).HasColumnName("SpiritFamilyID");

                entity.Property(e => e.SpiritType)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.SpiritFamily)
                    .WithMany(p => p.SpiritTypes)
                    .HasForeignKey(d => d.SpiritFamilyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SpiritTypes_SpiritFamilyID");
            });

            modelBuilder.Entity<States>(entity =>
            {
                entity.HasKey(e => e.StateId);

                entity.ToTable("States", "const");

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.Property(e => e.StateAbbreviation)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<UserEmployeeXref>(entity =>
            {
                entity.ToTable("UserEmployeeXRef", "hr");

                entity.Property(e => e.UserEmployeeXrefId).HasColumnName("UserEmployeeXRefID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Zapped).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserEmployeeXref)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserEmployeeXRef_UserID");
            });

            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.HasKey(e => e.UserRoleId);

                entity.ToTable("UserRoles", "refUserSS");

                entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserRole)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<UserRolesXref>(entity =>
            {
                entity.HasKey(e => e.UserRoleXrefId);

                entity.ToTable("UserRolesXRef", "UserSS");

                entity.Property(e => e.UserRoleXrefId).HasColumnName("UserRoleXRefID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRolesXref)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRoleXRef_UserID");

                entity.HasOne(d => d.UserRolesNavigation)
                    .WithMany(p => p.UserRolesXref)
                    .HasForeignKey(d => d.UserRoles)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRoleXRef_UserRoleID");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("Users", "UserSS");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UserStatusId).HasColumnName("UserStatusID");

                entity.HasOne(d => d.UserStatus)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_UserStatusID");
            });

            modelBuilder.Entity<UserStatuses>(entity =>
            {
                entity.HasKey(e => e.UserStatusId);

                entity.ToTable("UserStatuses", "refUserSS");

                entity.Property(e => e.UserStatusId).HasColumnName("UserStatusID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserStatus).HasMaxLength(255);
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

            modelBuilder.Entity<Venues>(entity =>
            {
                entity.HasKey(e => e.VenueId);

                entity.Property(e => e.VenueId).HasColumnName("VenueID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.VenueAddressId).HasColumnName("VenueAddressID");

                entity.Property(e => e.VenueName).HasMaxLength(255);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Venues)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Venues_CreatedBy");

                entity.HasOne(d => d.VenueAddress)
                    .WithMany(p => p.Venues)
                    .HasForeignKey(d => d.VenueAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Venues_VenueAddressID");
            });

            modelBuilder.Entity<VenueTypes>(entity =>
            {
                entity.HasKey(e => e.VenueTypeId);

                entity.ToTable("VenueTypes", "ref");

                entity.Property(e => e.VenueTypeId).HasColumnName("VenueTypeID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.VenueType).HasMaxLength(255);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.VenueTypes)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VenueTypes_CreatedBy");
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

            modelBuilder.Entity<WineFamilies>(entity =>
            {
                entity.HasKey(e => e.WineFamilyId);

                entity.ToTable("WineFamilies", "ref");

                entity.Property(e => e.WineFamilyId).HasColumnName("WineFamilyID");

                entity.Property(e => e.WineFamily)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Wineries>(entity =>
            {
                entity.HasKey(e => e.WineryId);

                entity.Property(e => e.WineryId).HasColumnName("WineryID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.ClosingDate).HasColumnType("datetime");

                entity.Property(e => e.OpeningDate).HasColumnType("datetime");

                entity.Property(e => e.VenueId).HasColumnName("VenueID");

                entity.Property(e => e.WineryName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Wineries)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Wineries_AddressID");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.Wineries)
                    .HasForeignKey(d => d.VenueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Wineries_VenueID");
            });

            modelBuilder.Entity<Wines>(entity =>
            {
                entity.HasKey(e => e.WineId);

                entity.Property(e => e.WineId).HasColumnName("WineID");

                entity.Property(e => e.WineName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.WineTypeId).HasColumnName("WineTypeID");

                entity.HasOne(d => d.WineType)
                    .WithMany(p => p.Wines)
                    .HasForeignKey(d => d.WineTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Wines_WineTypeID");
            });

            modelBuilder.Entity<WineTypes>(entity =>
            {
                entity.HasKey(e => e.WineTypeId);

                entity.ToTable("WineTypes", "ref");

                entity.Property(e => e.WineTypeId).HasColumnName("WineTypeID");

                entity.Property(e => e.WineFamilyId).HasColumnName("WineFamilyID");

                entity.Property(e => e.WineType)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.WineFamily)
                    .WithMany(p => p.WineTypes)
                    .HasForeignKey(d => d.WineFamilyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WineTypes_WineFamilyID");
            });

            modelBuilder.Entity<ZipCodes>(entity =>
            {
                entity.HasKey(e => e.ZipCode);

                entity.ToTable("ZipCodes", "const");

                entity.Property(e => e.ZipCode).ValueGeneratedNever();
            });
        }
    }
}
