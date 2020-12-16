using System;
using System.Collections.Generic;

namespace OnlyPythonFYP.Models
{
    public partial class Opuser
    {
        public Opuser()
        {
            Class = new HashSet<Class>();
            ExerPaper = new HashSet<ExerPaper>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public byte[] Password { get; set; }
        public string Role { get; set; }
        public DateTime? LastLogin { get; set; }

        public virtual ICollection<Class> Class { get; set; }
        public virtual ICollection<ExerPaper> ExerPaper { get; set; }
    }
}
