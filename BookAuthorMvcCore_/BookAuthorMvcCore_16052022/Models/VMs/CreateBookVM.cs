using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthorMvcCore_16052022.Models.VMs
{
    public class CreateBookVM
    {
        // book

        [Required(ErrorMessage ="bu alan boş bırakılamaz")]
        [MinLength(2),MaxLength(30)]
        public string Name { get; set; }

        [Required(ErrorMessage = "bu alan boş bırakılamaz")]
        [MinLength(20), MaxLength(300)]
        public string Description { get; set; }

        [Required(ErrorMessage = "bu alan boş bırakılamaz")]
        public int PageNumber { get; set; }

        // detail
        [Required(ErrorMessage = "bu alan boş bırakılamaz")]
        [MinLength(2), MaxLength(30)]
        public string Summary { get; set; }

        [Required(ErrorMessage = "bu alan boş bırakılamaz")]
        [MinLength(20), MaxLength(300)]
        public string DetailDescription { get; set; }

        // author
        [Required(ErrorMessage = "bu alan boş bırakılamaz")]
        public int AuthorID { get; set; }


    }
}
