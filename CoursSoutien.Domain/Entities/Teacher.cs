using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursSoutien.Domain.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public decimal PercentageCut { get; set; } // ex: 60 (pour 60% des revenus du groupe)

        public ICollection<StudyGroup> StudyGroups { get; set; } = new List<StudyGroup>();
    }
}
