using System;
using System.Collections.Generic;

namespace OnlyPythonFYP.Models
{
    public partial class Class
    {
        public Class()
        {
            ExerPaper = new HashSet<ExerPaper>();
        }

        public int Id { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int OpId { get; set; }

        public virtual Opuser Op { get; set; }
        public virtual ICollection<ExerPaper> ExerPaper { get; set; }
    }
}
