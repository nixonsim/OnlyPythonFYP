using System;
using System.Collections.Generic;

namespace OnlyPythonFYP.Models
{
    public partial class StdAnswer
    {
        public int AnsId { get; set; }
        public int StdId { get; set; }
        public int QuestionId { get; set; }
        public int QuestionType { get; set; }
        public string Choice { get; set; }
        public int MarksAwarded { get; set; }
    }
}
