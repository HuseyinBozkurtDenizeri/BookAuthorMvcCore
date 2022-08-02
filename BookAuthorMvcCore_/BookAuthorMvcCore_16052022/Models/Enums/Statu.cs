using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthorMvcCore_16052022.Models.Enums
{
    public enum Statu
    {
        // defaultta 0 dan başlar değerler ama veritabanı tarafında 0 gözükmesin diye değerlerini değiştirdik.
        Active=1,
        Modified=2,
        Passive=3
    }
}
