using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursSoutien.Domain.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // ex: Mathématiques, PC, SVT

        public ICollection<StudyGroup> StudyGroups { get; set; } = new List<StudyGroup>();
    }
}
