using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursSoutien.Domain.Entities
{
    public class StudyGroup
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // ex: G1 - Maths - 2Bac
        public decimal MonthlyPrice { get; set; } // Tarif par élève
        public int MaxCapacity { get; set; }
        public bool IsActive { get; set; } = true;

        // Relations (Un groupe a 1 Matière, 1 Prof, 1 Niveau)
        public int SubjectId { get; set; }
        public Subject Subject { get; set; } = null!;

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } = null!;

        public int EducationalLevelId { get; set; }
        public EducationalLevel EducationalLevel { get; set; } = null!;

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<CourseSession> Sessions { get; set; } = new List<CourseSession>();
    }
}
