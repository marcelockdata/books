using MHP.Books.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MHP.Books.Business.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    { 
        Task<Book> ObterPorNome(string name);
        Task<Book> ObterPorAutor(string autor);
        Task<Book> ObterPorPreco(double price);
        Task<IEnumerable<Book>> ObterTodosRedis();
    }
}
