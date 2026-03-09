using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursSoutien.Domain.Entities
{
    public class CourseSession
    {
        public int Id { get; set; }
        public DateTime SessionDate { get; set; }
        public TimeSpan StartTime { get; set; } // ex: 18:00
        public TimeSpan EndTime { get; set; }   // ex: 20:00

        public int StudyGroupId { get; set; }
        public StudyGroup StudyGroup { get; set; } = null!;

        public int RoomId { get; set; }
        public Room Room { get; set; } = null!;

        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    }
}
