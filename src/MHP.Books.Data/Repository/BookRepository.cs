using MHP.Books.Business.Interfaces;
using MHP.Books.Business.Models;
using MHP.Books.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MHP.Books.Data.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(DataDbContext context) : base(context) { }     

        public Task<Book> ObterPorAutor(string autor)
        {
            throw new NotImplementedException();
        }

        public async Task<Book> ObterPorNome(string name)
        {
            return await Db.Books.AsNoTracking().Include(f => f.Specifications)
                .FirstOrDefaultAsync(p => p.Name == name);
        }

        public async Task<Book> ObterPorPreco(double price)
        {
            return await Db.Books.AsNoTracking().Include(f => f.Specifications)
                .FirstOrDefaultAsync(p => p.Price == price);
        }
    }
}
