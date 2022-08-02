using BookAuthorMvcCore_16052022.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthorMvcCore_16052022.Models.Entities.Abstract
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }

        private DateTime _createdDate = DateTime.Now;

        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate=value; }
        }

        public DateTime? UpdateDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        private Statu _statu = Statu.Active;

        public Statu Statu
        {
            get { return _statu; }
            set { _statu = value; }
        }


    }
}
