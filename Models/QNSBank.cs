using System;
using System.Collections.Generic;

namespace OnlyPythonFYP.Models
{
    public partial class Qnsbank
    {
        public Qnsbank()
        {
            ExerPaper = new HashSet<ExerPaper>();
        }

        public int Id { get; set; }
        public string Topic { get; set; }
        public string Question { get; set; }
        public int QuestionType { get; set; }
        public string Answer { get; set; }
        public string WrongAnswer { get; set; }
        public int TemplateId { get; set; }
        public int Frequency { get; set; }
        public int MaxFrequency { get; set; }
        public int IsActive { get; set; }

        public virtual Qntemplate Template { get; set; }
        public virtual ICollection<ExerPaper> ExerPaper { get; set; }
    }
}
