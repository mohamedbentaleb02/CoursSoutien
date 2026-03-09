using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursSoutien.Domain.Entities
{
    public class Attendance
    {
        public int Id { get; set; }
        public AttendanceStatus Status { get; set; } = AttendanceStatus.Present;
        public string? Remarks { get; set; } // ex: "A oublié ses affaires"

        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;

        public int CourseSessionId { get; set; }
        public CourseSession CourseSession { get; set; } = null!;
    }
    public enum AttendanceStatus
    {
        Present,
        Absent,
        Late
    }
}
