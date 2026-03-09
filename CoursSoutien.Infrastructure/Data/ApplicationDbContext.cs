using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CoursSoutien.Domain.Entities;
using CoursSoutien.Application.Interfaces;

namespace CoursSoutien.Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : IdentityDbContext(options), IApplicationDbContext
    {
        public DbSet<Subject> Subjects => Set<Subject>();
        public DbSet<EducationalLevel> EducationalLevels => Set<EducationalLevel>();
        public DbSet<Room> Rooms => Set<Room>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Teacher> Teachers => Set<Teacher>();
        public DbSet<StudyGroup> StudyGroups => Set<StudyGroup>();
        public DbSet<Enrollment> Enrollments => Set<Enrollment>();
        public DbSet<CourseSession> CourseSessions => Set<CourseSession>();
        public DbSet<Attendance> Attendances => Set<Attendance>();
        public DbSet<Payment> Payments => Set<Payment>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<StudyGroup>()
                .Property(g => g.MonthlyPrice)
                .HasPrecision(18, 2);

            builder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2);

            builder.Entity<Teacher>()
                .Property(t => t.PercentageCut)
                .HasPrecision(5, 2); 

           

            builder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Enrollment>()
                .HasOne(e => e.StudyGroup)
                .WithMany(sg => sg.Enrollments)
                .HasForeignKey(e => e.StudyGroupId)
                .OnDelete(DeleteBehavior.Restrict);

       

            builder.Entity<Attendance>()
                .HasOne(a => a.Student)
                .WithMany(s => s.Attendances)
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Attendance>()
                .HasOne(a => a.CourseSession)
                .WithMany(cs => cs.Attendances)
                .HasForeignKey(a => a.CourseSessionId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<Payment>()
                .HasOne(p => p.Student)
                .WithMany(s => s.Payments)
                .HasForeignKey(p => p.StudentId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<CourseSession>()
                .HasOne(cs => cs.StudyGroup)
                .WithMany(sg => sg.Sessions)
                .HasForeignKey(cs => cs.StudyGroupId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}