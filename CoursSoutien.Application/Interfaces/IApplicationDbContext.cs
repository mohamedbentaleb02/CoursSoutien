using Microsoft.EntityFrameworkCore;
using CoursSoutien.Domain.Entities;
using System.Collections.Generic;

namespace CoursSoutien.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Subject> Subjects { get; }
        DbSet<EducationalLevel> EducationalLevels { get; }
        DbSet<Room> Rooms { get; }
        DbSet<Student> Students { get; }
        DbSet<Teacher> Teachers { get; }
        DbSet<StudyGroup> StudyGroups { get; }
        DbSet<Enrollment> Enrollments { get; }
        DbSet<CourseSession> CourseSessions { get; }
        DbSet<Attendance> Attendances { get; }
        DbSet<Payment> Payments { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}