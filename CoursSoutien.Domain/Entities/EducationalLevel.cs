using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursSoutien.Domain.Entities
{
    public class EducationalLevel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // ex: 1ère Bac, 2ème Bac PC

        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<StudyGroup> StudyGroups { get; set; } = new List<StudyGroup>();
    }
}
