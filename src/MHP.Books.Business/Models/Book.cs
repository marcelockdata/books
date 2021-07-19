
using System.Collections.Generic;

namespace MHP.Books.Business.Models
{
    public class Book: Entity
    {     
        public string Name { get; set; }
        public double Price { get; set; }

        /* EF Relations */
        public IEnumerable<Specification> Specifications { get; set; }

    }
}
