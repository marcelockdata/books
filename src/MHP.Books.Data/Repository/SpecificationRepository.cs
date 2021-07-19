using MHP.Books.Business.Interfaces;
using MHP.Books.Business.Models;
using MHP.Books.Data.Context;

namespace MHP.Books.Data.Repository
{
    public class SpecificationRepository : Repository<Specification>, ISpecificationRepository
    {
        public SpecificationRepository(DataDbContext context) : base(context) { }

    }
}
