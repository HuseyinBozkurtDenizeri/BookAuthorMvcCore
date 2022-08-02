using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthorMvcCore_16052022.Models.DTOs
{
    public class CreateAuthorDTO
    {
        [Required(ErrorMessage ="bu alan boş olmaz.")]
        [MinLength(2),MaxLength(30)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "bu alan boş olmaz.")]
        [MinLength(2), MaxLength(30)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "bu alan boş olmaz.")]
        [MinLength(15), MaxLength(200)]
        public string Biography { get; set; }
    }
}
