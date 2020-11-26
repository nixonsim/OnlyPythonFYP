using System;
using System.Collections.Generic;

namespace OnlyPythonFYP.Models
{
    public partial class LecUser
    {
        public LecUser()
        {
            Class = new HashSet<Class>();
        }

        public int LecId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string ClassId { get; set; }
        public byte[] Password { get; set; }
        public DateTime? LastLogin { get; set; }

        public virtual ICollection<Class> Class { get; set; }
    }
}
