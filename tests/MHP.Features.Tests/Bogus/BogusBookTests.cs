using System;
using Xunit;

namespace MHP.Features.Tests.Bogus
{
    [Collection(nameof(BookBogusCollection))]

    public class BogusBookTests
    {
        private readonly BookTestsBogusFixture _bookTestsBogusFixture;

        public BogusBookTests(BookTestsBogusFixture bookTestsBogusFixture)
        {
            _bookTestsBogusFixture = bookTestsBogusFixture;
        }

        [Fact(DisplayName = "Novo Book")]
        [Trait("Book", "Book Bogus Testes")]
        public void Book_NovoBook_DeveEstarValido()
        {
            // Arrange
            var book = _bookTestsBogusFixture.GerarBookCadastro();
            Console.WriteLine(book.Name);

            // Act
            var result = book.EhValido();

            // Assert 
            Assert.True(result);          
        }
    }
}
