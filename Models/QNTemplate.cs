using System;
using System.Collections.Generic;

namespace OnlyPythonFYP.Models
{
    public partial class Qntemplate
    {
        public Qntemplate()
        {
            Qnsbank = new HashSet<Qnsbank>();
        }

        public int Id { get; set; }
        public string TemplateQuestion { get; set; }
        public string Topic { get; set; }
        public int QuestionType { get; set; }
        public string Variables { get; set; }
        public int Frequency { get; set; }
        public int MaxFrequency { get; set; }

        public virtual ICollection<Qnsbank> Qnsbank { get; set; }
    }
}
