using System;
using System.Collections.Generic;

namespace OnlyPythonFYP.Models
{
    public partial class Class
    {
        public int ClassId { get; set; }
        public int StdId { get; set; }
        public int LecId { get; set; }

        public virtual LecUser Lec { get; set; }
        public virtual StdUser Std { get; set; }
    }
}
