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

        private IEnumerable<Book> GetFromCache(string cacheKey)
        {
            var cacheData = _cache.GetString(cacheKey);

            if (cacheData != null)
                return JsonSerializer.Deserialize<IEnumerable<Book>>(cacheData);

            return null;
        }

        private DistributedCacheEntryOptions GetCacheOptions(
                                                    int slidingExpirationSecs = 0,
                                                    int absoluteExpirationSecs = 0)
        {
            var cacheOptions = new DistributedCacheEntryOptions();

            if (slidingExpirationSecs > 0)
                cacheOptions.SetSlidingExpiration(TimeSpan.FromSeconds(slidingExpirationSecs)); // inactive

            if (absoluteExpirationSecs > 0)
                cacheOptions.SetAbsoluteExpiration(TimeSpan.FromSeconds(absoluteExpirationSecs)); // absolute

            return cacheOptions;
        }

        public async Task<IEnumerable<Book>> ObterTodosRedis()
        {
            IEnumerable<Book> books = GetFromCache(CacheKeys.BOOK_GET_ALL);
            if (books != null) { return books; }

            books = await DbSet.ToListAsync();          

            var toCache = JsonSerializer.Serialize(books);
            _cache.SetString(CacheKeys.BOOK_GET_ALL, toCache, GetCacheOptions(15, 30));

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
