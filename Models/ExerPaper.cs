using System;
using System.Collections.Generic;

namespace OnlyPythonFYP.Models
{
    public partial class ExerPaper
    {
        public int Id { get; set; }
        public int ExerId { get; set; }
        public string ExerName { get; set; }
        public int QnsId { get; set; }
        public int ClassId { get; set; }
        public int CreatedBy { get; set; }

        public virtual Class Class { get; set; }
        public virtual Opuser CreatedByNavigation { get; set; }
        public virtual Qnsbank Qns { get; set; }
    }
}
