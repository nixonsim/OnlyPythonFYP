using System;
using System.Collections.Generic;

namespace OnlyPythonFYP.Models
{
    public partial class Mcqchoices
    {
        public int ChoiceId { get; set; }
        public int QuestionId { get; set; }
        public int QuestionType { get; set; }
        public string IsCorrect { get; set; }
        public string Choices { get; set; }
    }
}
