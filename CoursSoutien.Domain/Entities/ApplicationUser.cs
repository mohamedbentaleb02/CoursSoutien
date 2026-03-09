using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;

namespace CoursSoutien.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Propriétés de navigation
        // Si l'utilisateur est un professeur, il aura des sessions enseignées :
        public ICollection<CourseSession> TaughtSessions { get; set; } = new List<CourseSession>();

        // Si l'utilisateur est un étudiant, il aura des inscriptions :
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}