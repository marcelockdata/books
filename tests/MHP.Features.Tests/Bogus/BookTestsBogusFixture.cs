using Bogus;
using Bogus.DataSets;
using MHP.Domain.Tests.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MHP.Features.Tests.Bogus
{
    [CollectionDefinition(nameof(BookBogusCollection))]
    public class BookBogusCollection : ICollectionFixture<BookTestsBogusFixture>
    { }

    public class BookTestsBogusFixture 
    {
        public Book GerarBookCadastro()
        {
            return GerarBooks(1, true).FirstOrDefault();
        }

        public IEnumerable<Book> ObterClientesVariados()
        {
            var books = new List<Book>();

            books.AddRange(GerarBooks(50, true).ToList());         

            return books;
        }

        public IEnumerable<Book> GerarBooks(int quantidade, bool ativo)
        {
            var genero = new Faker().PickRandom<Name.Gender>();
          
            var books = new Faker<Book>("pt_BR").CustomInstantiator(b => new Book(
                 Guid.NewGuid(),
                  b.Name.FullName(genero),
                  b.Random.Double()
                  ));            

            return books.Generate(quantidade);
        }

       
    }
}
