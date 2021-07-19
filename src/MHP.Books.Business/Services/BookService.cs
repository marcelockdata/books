using MHP.Books.Business.Interfaces;
using MHP.Books.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHP.Books.Business.Services
{
    public class BookService : BaseService, IBookService
    {
        private readonly IBookRepository _bookRepository;
       
        public BookService(IBookRepository bookRepository,                                
                                 INotificador notificador) : base(notificador)
        {
            _bookRepository = bookRepository;          
        }

        public async Task<bool> Adicionar(Book book)
        {
            if (_bookRepository.Buscar(f => f.Name == book.Name).Result.Any())
            {
                Notificar("Já existe um Book cadastrado.");
                return false;
            }

            await _bookRepository.Adicionar(book);
            return true;
        }

        public async Task<bool> Atualizar(Book book)
        {
            /*if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)) return false;

            if (_fornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento && f.Id != fornecedor.Id).Result.Any())
            {
                Notificar("Já existe um fornecedor com este documento infomado.");
                return false;
            }*/

            await _bookRepository.Atualizar(book);
            return true;
        }

      
        public async Task<bool> Remover(Guid id)
        {
           /* if (_fornecedorRepository.ObterFornecedorProdutosEndereco(id).Result.Produtos.Any())
            {
                Notificar("O fornecedor possui produtos cadastrados!");
                return false;
            }

            var endereco = await _enderecoRepository.ObterEnderecoPorFornecedor(id);

            if (endereco != null)
            {
                await _enderecoRepository.Remover(endereco.Id);
            }*/

            await _bookRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _bookRepository?.Dispose();           
        }
    }
}
