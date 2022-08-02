using BookAuthorMvcCore_16052022.Models.Entities.Abstract;

namespace BookAuthorMvcCore_16052022.Models.Entities.Concrete
{
    public class Detail : BaseEntity
    {
        public string Summary { get; set; }

        public string Description { get; set; }

        // navigationProp
        // 1 detaın ait olduğu 1 kitap vardır.

        public int BookID { get; set; }

        public virtual Book DetailsBook { get; set; }
    }
}