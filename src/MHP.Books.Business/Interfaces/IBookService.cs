using MHP.Books.Business.Models;
using System;
using System.Threading.Tasks;

namespace MHP.Books.Business.Interfaces
{
    public interface IBookService
    {
        Task<bool> Adicionar(Book book);
        Task<bool> Atualizar(Book book);
        Task<bool> Remover(Guid id);      
    }
}
