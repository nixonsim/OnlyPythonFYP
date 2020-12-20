using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnlyPythonFYP.Models
{
    public class LecLoginUser
    {
        [Required(ErrorMessage = "Please enter Email")]
        [RegularExpression(@"180\d{5}@myrp.edu.sg", ErrorMessage = "You are not a lecturer! Return back to main page.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
