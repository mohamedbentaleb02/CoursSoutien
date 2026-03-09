using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursSoutien.Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

        // Stocke le mois concerné, ex: "2026-10" pour Octobre 2026
        public string TargetMonth { get; set; } = string.Empty;
        public bool IsPaid { get; set; } = false;

        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;

        public int StudyGroupId { get; set; }
        public StudyGroup StudyGroup { get; set; } = null!;
    }
}
