using System;
using System.Collections.Generic;

namespace OnlyPythonFYP.Models
{
    public partial class Qnsbank
    {
        public int Qns_Id { get; set; }
        public string Topic { get; set; }
        public string Question { get; set; }
        public int Question_Type { get; set; }
        public string Answer { get; set; }
        public string Wrong_Answer { get; set; }
        public int Template_Id { get; set; }
    }
}
