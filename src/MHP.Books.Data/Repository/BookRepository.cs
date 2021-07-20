using MHP.Books.Business.Constant;
using MHP.Books.Business.Interfaces;
using MHP.Books.Business.Models;
using MHP.Books.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace MHP.Books.Data.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly IDistributedCache _cache;    
        public BookRepository(DataDbContext context, IDistributedCache cache) : base(context) 
        {
            _cache = cache;
        }

        public async Task<IEnumerable<Book>> ObterTodosRedis()
        {           
         
            var books = new List<Book>();

            var json = await _cache.GetStringAsync(CacheKeys.BOOK_GET_ALL);
            if (json != null)
            {
                books = JsonSerializer.Deserialize<List<Book>>(json);
            }
            else
            {
                books = await DbSet.ToListAsync();
                json = JsonSerializer.Serialize<List<Book>>(books);
                await _cache.SetStringAsync(CacheKeys.BOOK_GET_ALL, json);
            }

            return books;
        }

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
