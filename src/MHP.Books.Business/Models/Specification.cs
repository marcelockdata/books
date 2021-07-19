using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHP.Books.Business.Models
{
    public class Specification: Entity
    {
        public Guid BookId { get; set; }
        public string OriginallyPublished { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }

        /* EF Relations */
        public Book Book { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public IEnumerable<Illustrator> Illustrators { get; set; }
    }
}
