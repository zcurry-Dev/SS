using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SS.API.Models
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

        public virtual DbSet<AdminRole> AdminRole { get; set; }
        public virtual DbSet<AdminRolesXref> AdminRolesXref { get; set; }
        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<ArtistGroupMember> ArtistGroupMember { get; set; }
        public virtual DbSet<ArtistGroupMemberRole> ArtistGroupMemberRole { get; set; }
        public virtual DbSet<ArtistGroupMemberRolesXref> ArtistGroupMemberRolesXref { get; set; }
        public virtual DbSet<ArtistStatus> ArtistStatus { get; set; }
        public virtual DbSet<ArtistType> ArtistType { get; set; }
        public virtual DbSet<ArtistTypeXref> ArtistTypeXref { get; set; }
        public virtual DbSet<Beer> Beer { get; set; }
        public virtual DbSet<BeerFamily> BeerFamily { get; set; }
        public virtual DbSet<BeerType> BeerType { get; set; }
        public virtual DbSet<Brewery> Brewery { get; set; }
        public virtual DbSet<Cider> Cider { get; set; }
        public virtual DbSet<CiderFamily> CiderFamily { get; set; }
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
        public virtual DbSet<Mead> Mead { get; set; }
        public virtual DbSet<MeadFamily> MeadFamily { get; set; }
        public virtual DbSet<MeadType> MeadType { get; set; }
        public virtual DbSet<Meadery> Meadery { get; set; }
        public virtual DbSet<Spirit> Spirit { get; set; }
        public virtual DbSet<SpiritFamily> SpiritFamily { get; set; }
        public virtual DbSet<SpiritType> SpiritType { get; set; }
        public virtual DbSet<Ssaddress> Ssaddress { get; set; }
        public virtual DbSet<Ssadmin> Ssadmin { get; set; }
        public virtual DbSet<Ssevent> Ssevent { get; set; }
        public virtual DbSet<Ssuser> Ssuser { get; set; }
        public virtual DbSet<UserEmployeeXref> UserEmployeeXref { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<UserRolesXref> UserRolesXref { get; set; }
        public virtual DbSet<UserStatus> UserStatus { get; set; }
        public virtual DbSet<Usstate> Usstate { get; set; }
        public virtual DbSet<Values> Values { get; set; }
        public virtual DbSet<Venue> Venue { get; set; }
        public virtual DbSet<VenueHoursOpen> VenueHoursOpen { get; set; }
        public virtual DbSet<VenueType> VenueType { get; set; }
        public virtual DbSet<VenueTypeXref> VenueTypeXref { get; set; }
        public virtual DbSet<Wine> Wine { get; set; }
        public virtual DbSet<WineFamily> WineFamily { get; set; }
        public virtual DbSet<WineType> WineType { get; set; }
        public virtual DbSet<Winery> Winery { get; set; }
        public virtual DbSet<ZipCode> ZipCode { get; set; }

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
            modelBuilder.Entity<AdminRole>(entity =>
            {
                entity.ToTable("AdminRole", "refAdminSS");

                entity.Property(e => e.AdminRoleId).HasColumnName("AdminRoleID");

                entity.Property(e => e.AdminRole1)
                    .HasColumnName("AdminRole")
                    .HasMaxLength(255);

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

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.Property(e => e.ArtistId).HasColumnName("ArtistID");

                entity.Property(e => e.ArtistName).HasMaxLength(255);

                entity.Property(e => e.CareerBeginDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
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

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ArtistStatus)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArtistStatus_CreatedBy");
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

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ArtistType)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArtistType_CreatedBy");
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

                entity.Property(e => e.BeerTypeId).HasColumnName("BeerTypeID");

                entity.HasOne(d => d.BeerType)
                    .WithMany(p => p.Beer)
                    .HasForeignKey(d => d.BeerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Beer_BeerTypeID");
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

            modelBuilder.Entity<Brewery>(entity =>
            {
                entity.Property(e => e.BreweryId).HasColumnName("BreweryID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.BreweryName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ClosingDate).HasColumnType("datetime");

                entity.Property(e => e.OpeningDate).HasColumnType("datetime");

                entity.Property(e => e.VenueId).HasColumnName("VenueID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Brewery)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Brewery_AddressID");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.Brewery)
                    .HasForeignKey(d => d.VenueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Brewery_VenueID");
            });

            modelBuilder.Entity<Cider>(entity =>
            {
                entity.Property(e => e.CiderId).HasColumnName("CiderID");

                entity.Property(e => e.CiderName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CiderTypeId).HasColumnName("CiderTypeID");

                entity.HasOne(d => d.CiderType)
                    .WithMany(p => p.Cider)
                    .HasForeignKey(d => d.CiderTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cider_CiderTypeID");
            });

            modelBuilder.Entity<CiderFamily>(entity =>
            {
                entity.ToTable("CiderFamily", "ref");

                entity.Property(e => e.CiderFamilyId).HasColumnName("CiderFamilyID");

                entity.Property(e => e.CiderFamily1)
                    .IsRequired()
                    .HasColumnName("CiderFamily")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<CiderType>(entity =>
            {
                entity.ToTable("CiderType", "ref");

                entity.Property(e => e.CiderTypeId).HasColumnName("CiderTypeID");

                entity.Property(e => e.CiderFamilyId).HasColumnName("CiderFamilyID");

                entity.Property(e => e.CiderType1)
                    .IsRequired()
                    .HasColumnName("CiderType")
                    .HasMaxLength(255);

                entity.HasOne(d => d.CiderFamily)
                    .WithMany(p => p.CiderType)
                    .HasForeignKey(d => d.CiderFamilyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CiderType_CiderFamilyID");
            });

            modelBuilder.Entity<Cidery>(entity =>
            {
                entity.Property(e => e.CideryId).HasColumnName("CideryID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.CideryName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ClosingDate).HasColumnType("datetime");

                entity.Property(e => e.OpeningDate).HasColumnType("datetime");

                entity.Property(e => e.VenueId).HasColumnName("VenueID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Cidery)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cidery_AddressID");

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

                entity.Property(e => e.StateId).HasColumnName("StateID");

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

            modelBuilder.Entity<Mead>(entity =>
            {
                entity.Property(e => e.MeadId).HasColumnName("MeadID");

                entity.Property(e => e.HoneyWine).HasDefaultValueSql("((0))");

                entity.Property(e => e.MeadName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.MeadTypeId).HasColumnName("MeadTypeID");

                entity.HasOne(d => d.MeadType)
                    .WithMany(p => p.Mead)
                    .HasForeignKey(d => d.MeadTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mead_MeadTypeID");
            });

            modelBuilder.Entity<MeadFamily>(entity =>
            {
                entity.ToTable("MeadFamily", "ref");

                entity.Property(e => e.MeadFamilyId).HasColumnName("MeadFamilyID");

                entity.Property(e => e.MeadFamily1)
                    .IsRequired()
                    .HasColumnName("MeadFamily")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<MeadType>(entity =>
            {
                entity.ToTable("MeadType", "ref");

                entity.Property(e => e.MeadTypeId).HasColumnName("MeadTypeID");

                entity.Property(e => e.MeadFamilyId).HasColumnName("MeadFamilyID");

                entity.Property(e => e.MeadType1)
                    .IsRequired()
                    .HasColumnName("MeadType")
                    .HasMaxLength(255);

                entity.HasOne(d => d.MeadFamily)
                    .WithMany(p => p.MeadType)
                    .HasForeignKey(d => d.MeadFamilyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MeadFamily_MeadFamilyID");
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

            modelBuilder.Entity<Spirit>(entity =>
            {
                entity.Property(e => e.SpiritId).HasColumnName("SpiritID");

                entity.Property(e => e.SpiritName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.SpiritTypeId).HasColumnName("SpiritTypeID");

                entity.HasOne(d => d.SpiritType)
                    .WithMany(p => p.Spirit)
                    .HasForeignKey(d => d.SpiritTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Spirit_SpiritTypeID");
            });

            modelBuilder.Entity<SpiritFamily>(entity =>
            {
                entity.ToTable("SpiritFamily", "ref");

                entity.Property(e => e.SpiritFamilyId).HasColumnName("SpiritFamilyID");

                entity.Property(e => e.SpiritFamily1)
                    .IsRequired()
                    .HasColumnName("SpiritFamily")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<SpiritType>(entity =>
            {
                entity.ToTable("SpiritType", "ref");

                entity.Property(e => e.SpiritTypeId).HasColumnName("SpiritTypeID");

                entity.Property(e => e.SpiritFamilyId).HasColumnName("SpiritFamilyID");

                entity.Property(e => e.SpiritType1)
                    .IsRequired()
                    .HasColumnName("SpiritType")
                    .HasMaxLength(255);

                entity.HasOne(d => d.SpiritFamily)
                    .WithMany(p => p.SpiritType)
                    .HasForeignKey(d => d.SpiritFamilyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SpiritType_SpiritFamilyID");
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

                entity.Property(e => e.StateId).HasColumnName("StateID");

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

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Ssaddress)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_StateID");

                entity.HasOne(d => d.ZipCode)
                    .WithMany(p => p.Ssaddress)
                    .HasForeignKey(d => d.ZipCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_ZipCodeID");
            });

            modelBuilder.Entity<Ssadmin>(entity =>
            {
                entity.HasKey(e => e.AdminId)
                    .HasName("PK_AdminID");

                entity.ToTable("SSAdmin", "AdminSS");

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ssadmin)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Admin_UserID");
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

            modelBuilder.Entity<Ssuser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_UserID");

                entity.ToTable("SSUser", "UserSS");

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

                entity.Property(e => e.PwHash)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.PwSalt)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UserStatusId).HasColumnName("UserStatusID");

                entity.HasOne(d => d.UserStatus)
                    .WithMany(p => p.Ssuser)
                    .HasForeignKey(d => d.UserStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_UserStatusID");
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

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole", "refUserSS");

                entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserRole1)
                    .IsRequired()
                    .HasColumnName("UserRole")
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
                    .HasConstraintName("FK_UserRolesXRef_UserID");

                entity.HasOne(d => d.UserRolesNavigation)
                    .WithMany(p => p.UserRolesXref)
                    .HasForeignKey(d => d.UserRoles)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRolesXRef_UserRoleID");
            });

            modelBuilder.Entity<UserStatus>(entity =>
            {
                entity.ToTable("UserStatus", "refUserSS");

                entity.Property(e => e.UserStatusId).HasColumnName("UserStatusID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserStatus1)
                    .HasColumnName("UserStatus")
                    .HasMaxLength(255);
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

            modelBuilder.Entity<Values>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
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

                entity.Property(e => e.WineName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.WineTypeId).HasColumnName("WineTypeID");

                entity.HasOne(d => d.WineType)
                    .WithMany(p => p.Wine)
                    .HasForeignKey(d => d.WineTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Wine_WineTypeID");
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

            modelBuilder.Entity<Winery>(entity =>
            {
                entity.Property(e => e.WineryId).HasColumnName("WineryID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.ClosingDate).HasColumnType("datetime");

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
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
