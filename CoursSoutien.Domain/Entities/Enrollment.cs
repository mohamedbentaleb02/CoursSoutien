using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursSoutien.Domain.Entities
{
    public class Enrollment
    {
        public int Id { get; set; }
        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true; // Permet de désinscrire un élève sans supprimer son historique

        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;

        public int StudyGroupId { get; set; }
        public StudyGroup StudyGroup { get; set; } = null!;
    }

    
}
