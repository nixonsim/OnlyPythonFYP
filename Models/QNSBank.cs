using System;
using System.Collections.Generic;

namespace OnlyPythonFYP.Models
{
    public partial class Qnsbank
    {
        public int QnsId { get; set; }
        public string Topic { get; set; }
        public string Question { get; set; }
        public int QuestionType { get; set; }
        public string Answer { get; set; }
    }
}
