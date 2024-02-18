using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UkukhulaAPI.Data.Models;

using static UkukhulaAPI.Data.Services.UsersService;

namespace UkukhulaAPI.Data;

public partial class UkukhulaContext : DbContext
{
    public UkukhulaContext()
    {
    }

    public UkukhulaContext(DbContextOptions<UkukhulaContext> options)
        : base(options)
    {
    }
// protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//     {
//        
//     }
    public virtual DbSet<ApplicationStatus> ApplicationStatuses { get; set; }

    public virtual DbSet<Bbdadministrator> Bbdadministrators { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<HeadOfDepartment> HeadOfDepartments { get; set; }

    public virtual DbSet<Race> Races { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentBursaryApplication> StudentBursaryApplications { get; set; }

    public virtual DbSet<StudentBursaryDocument> StudentBursaryDocuments { get; set; }

    public virtual DbSet<University> Universities { get; set; }

    public virtual DbSet<UniversityApplication> UniversityApplications { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<YearlyBursaryDetail> YearlyBursaryDetails { get; set; }

    public virtual DbSet<YearlyUniversityAllocation> YearlyUniversityAllocations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

        var connectionString = configuration.GetConnectionString("DBConnectionString");
        optionsBuilder.UseSqlServer(connectionString);
        //  optionsBuilder.UseLazyLoadingProxies();
    }

protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplicationStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Applicat__C8EE2043D8F9B498");

            entity.ToTable("ApplicationStatus", tb => tb.HasTrigger("no_more_inserts_AppStatus"));

            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Bbdadministrator>(entity =>
        {
            entity.HasKey(e => e.AdministratorId).HasName("PK__BBDAdmin__ACDEFE33B6F617D2");

            entity.ToTable("BBDAdministrator");

            entity.HasIndex(e => e.UserId, "UQ_AdminID").IsUnique();

            entity.HasIndex(e => e.UserId, "UQ__BBDAdmin__1788CCADA4A4510D").IsUnique();

            entity.Property(e => e.AdministratorId).HasColumnName("AdministratorID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithOne(p => p.Bbdadministrator)
                .HasForeignKey<Bbdadministrator>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserID");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK__Contact__5C6625BBDE2B2071");

            entity.ToTable("Contact");

            entity.Property(e => e.ContactId).HasColumnName("ContactID");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BCDA75F8EDF");

            entity.ToTable("Department", tb => tb.HasTrigger("no_more_inserts_departments"));

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HeadOfDepartment>(entity =>
        {
            entity.HasKey(e => e.HeadOfDepartmentId).HasName("PK__HeadOfDe__7E04C0367D41FA61");

            entity.ToTable("HeadOfDepartment");

            entity.HasIndex(e => e.UserId, "UQ__HeadOfDe__1788CCADCCAAD161").IsUnique();

            entity.Property(e => e.HeadOfDepartmentId).HasColumnName("HeadOfDepartmentID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.UniversityId).HasColumnName("UniversityID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Department).WithMany(p => p.HeadOfDepartments)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.University).WithMany(p => p.HeadOfDepartments)
                .HasForeignKey(d => d.UniversityId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User).WithOne(p => p.HeadOfDepartment)
                .HasForeignKey<HeadOfDepartment>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Race>(entity =>
        {
            entity.ToTable("Race", tb => tb.HasTrigger("no_more_inserts_Race"));

            entity.Property(e => e.RaceId).HasColumnName("RaceID");
            entity.Property(e => e.RaceName)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52A79CE11A6E6");

            entity.ToTable("Student");

            entity.HasIndex(e => e.UserId, "UQ__Student__1788CCAD454A7056").IsUnique();

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.CourseOfStudy)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.RaceId).HasColumnName("RaceID");
            entity.Property(e => e.UniversityId).HasColumnName("UniversityID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Department).WithMany(p => p.Students)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("F_KDepartmentID");

            entity.HasOne(d => d.Race).WithMany(p => p.Students)
                .HasForeignKey(d => d.RaceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("F_KRace");

            entity.HasOne(d => d.User).WithOne(p => p.Student)
                .HasForeignKey<Student>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("F_KUserID");
        });

        modelBuilder.Entity<StudentBursaryApplication>(entity =>
        {
            entity.HasKey(e => e.ApplicationId).HasName("PK__StudentB__C93A4F7947AF0334");

            entity.ToTable("StudentBursaryApplication");

            entity.HasIndex(e => e.StudentId, "UQ__StudentB__32C52A78CD1B2EB1").IsUnique();

            entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");
            entity.Property(e => e.ApplicationDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ApplicationMotivation).HasColumnType("text");
            entity.Property(e => e.ApplicationRejectionReason)
                .HasDefaultValue("N/A")
                .HasColumnType("text");
            entity.Property(e => e.BursaryAmount).HasColumnType("money");
            entity.Property(e => e.BursaryDetailsId).HasColumnName("BursaryDetailsID");
            entity.Property(e => e.HeadOfDepartmentId).HasColumnName("HeadOfDepartmentID");
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.BursaryDetails).WithMany(p => p.StudentBursaryApplications)
                .HasForeignKey(d => d.BursaryDetailsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BursaryDetailsID_Application");

            entity.HasOne(d => d.HeadOfDepartment).WithMany(p => p.StudentBursaryApplications)
                .HasForeignKey(d => d.HeadOfDepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HeadOfDepartmentID_Application");

            entity.HasOne(d => d.Status).WithMany(p => p.StudentBursaryApplications)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StatusID_Application");

            entity.HasOne(d => d.Student).WithOne(p => p.StudentBursaryApplication)
                .HasForeignKey<StudentBursaryApplication>(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentID_Application");
        });

        modelBuilder.Entity<StudentBursaryDocument>(entity =>
        {
            entity.HasKey(e => e.StudentDocumentId).HasName("PK__StudentB__F22764D0A3B15A1B");

            entity.HasIndex(e => e.StudentId, "UQ__StudentB__32C52A78388E0FD5").IsUnique();

            entity.Property(e => e.StudentDocumentId).HasColumnName("StudentDocumentID");
            entity.Property(e => e.CurriculumVitae)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.IdCopy)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.Transcript)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithOne(p => p.StudentBursaryDocument)
                .HasForeignKey<StudentBursaryDocument>(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentBursaryDocuments_StudentID");
        });

        modelBuilder.Entity<University>(entity =>
        {
            entity.HasKey(e => e.UniversityId).HasName("PK__Universi__9F19E19C0477C1D1");

            entity.ToTable("University");

            entity.HasIndex(e => e.UniversityName, "UQ__Universi__53F0B53CD621E63F").IsUnique();

            entity.Property(e => e.UniversityId).HasColumnName("UniversityID");
            entity.Property(e => e.UniversityName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Universities)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USER_UNIVERSITY");
        });

        modelBuilder.Entity<UniversityApplication>(entity =>
        {
            entity.HasKey(e => e.UniversityApplicationId).HasName("PK__Universi__C90F376AA724AB5E");

            entity.ToTable("UniversityApplication");

            entity.Property(e => e.UniversityApplicationId).HasColumnName("UniversityApplicationID");
            entity.Property(e => e.ApplicationDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Motivation).HasColumnType("text");
            entity.Property(e => e.ReviewerComment)
                .HasDefaultValue("N/A")
                .HasColumnType("text");
            entity.Property(e => e.StatusId)
                .HasDefaultValue(2)
                .HasColumnName("StatusID");
            entity.Property(e => e.UniversityId).HasColumnName("UniversityID");

            entity.HasOne(d => d.Status).WithMany(p => p.UniversityApplications)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StatusID");

            entity.HasOne(d => d.University).WithMany(p => p.UniversityApplications)
                .HasForeignKey(d => d.UniversityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UniversityID");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CCAC18A12A68");

            entity.ToTable("User");

            entity.HasIndex(e => e.Idnumber, "UQ__User__564DB08A6082D7F3").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.ContactId).HasColumnName("ContactID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Idnumber)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IDNumber");
            entity.Property(e => e.LastName)
                .HasMaxLength(120)
                .IsUnicode(false);

            entity.HasOne(d => d.Contact).WithMany(p => p.Users)
                .HasForeignKey(d => d.ContactId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contact");
        });

        modelBuilder.Entity<YearlyBursaryDetail>(entity =>
        {
            entity.HasKey(e => e.BursaryDetailsId).HasName("PK__YearlyBu__3191EBE2E11B36C1");

            entity.Property(e => e.BursaryDetailsId).HasColumnName("BursaryDetailsID");
            entity.Property(e => e.CapAmountPerStudent).HasColumnType("money");
            entity.Property(e => e.YearBudget).HasColumnType("money");
        });

        modelBuilder.Entity<YearlyUniversityAllocation>(entity =>
        {
            entity.HasKey(e => e.AllocationId).HasName("PK__YearlyUn__B3C6D6ABD7A1CF63");

            entity.ToTable("YearlyUniversityAllocation");

            entity.Property(e => e.AllocationId).HasColumnName("AllocationID");
            entity.Property(e => e.AllocatedAmount).HasColumnType("money");
            entity.Property(e => e.BursaryDetailsId).HasColumnName("BursaryDetailsID");
            entity.Property(e => e.UniversityId).HasColumnName("UniversityID");

            entity.HasOne(d => d.BursaryDetails).WithMany(p => p.YearlyUniversityAllocations)
                .HasForeignKey(d => d.BursaryDetailsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__University_BursaryDetails");

            entity.HasOne(d => d.University).WithMany(p => p.YearlyUniversityAllocations)
                .HasForeignKey(d => d.UniversityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
