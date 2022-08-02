using BookAuthorMvcCore_16052022.Models.Entities.Abstract;

namespace BookAuthorMvcCore_16052022.Models.Entities.Concrete
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }
        public int PageNumber { get; set; }

        // navigationProp
        // 1 kitabın 1 yazarı vardır.

        public virtual Author BooksAuthor { get; set; }

        public int AuthorID { get; set; }

        // 1 kitabın 1 detayı vardır.

        public int DetailID { get; set; }

        public virtual Detail BooksDetail { get; set; }

    }
}