using BookAuthorMvcCore_16052022.Models.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthorMvcCore_16052022.Models.Entities.Concrete
{
    public class Author : BaseEntity
    {
        public Author()
        {
            AuthorBooks = new List<Book>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }

        // navigation Prop
        // 1 yazarın çokça kitabı olabilir.

        public virtual List<Book> AuthorBooks { get; set; }


    }
}
