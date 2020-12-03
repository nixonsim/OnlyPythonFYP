using System;
using System.Collections.Generic;

namespace OnlyPythonFYP.Models
{
    public partial class Qntemplate
    {
        public int Template_Id { get; set; }
        public string Template_Question { get; set; }
        public string Topic { get; set; }
        public int Question_Type { get; set; }
        public string Variables { get; set; }
    }
}
