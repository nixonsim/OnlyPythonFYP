using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace OnlyPythonFYP.Models
{
    public class StudLoginUser
    {
        [Required(ErrorMessage = "Please enter Email")]
        [RegularExpression(@"([a-zA-Z_\-\.]+)@rp.edu.sg", ErrorMessage = "You are not a student! Return back to main page.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
