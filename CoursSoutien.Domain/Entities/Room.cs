using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursSoutien.Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // ex: Salle 1, Salle VIP
        public int Capacity { get; set; } // Pour bloquer les surréservations

        public ICollection<CourseSession> CourseSessions { get; set; } = new List<CourseSession>();
    }
}
