

using System;

namespace MHP.Books.Business.Models
{
    public class Illustrator : Entity
    {
        public Guid SpecificationId { get; set; }
        public string Name { get; set; }

        /* EF Relation */       
        public Specification Specification { get; set; }
    }
}
