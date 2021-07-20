using AutoMapper;
using MHP.Books.API.Extensions;
using MHP.Books.API.ViewModels;
using MHP.Books.Business.Interfaces;
using MHP.Books.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MHP.Books.API.Controllers
{
    /*[Authorize]*/
    [Route("api/book")]
    public class BookController : MainController
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BookController(IBookRepository bookRepository,
                                      IMapper mapper,
                                      IBookService bookService,
                                      INotificador notificador,
                                      IUser user) : base(notificador, user)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _bookService = bookService;
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<BookViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<BookViewModel>>(await _bookRepository.ObterTodos());
        }

        [HttpGet("ObterTodosRedis")]
        public async Task<IEnumerable<Book>> ObterTodosRedis()
        {
            return await _bookRepository.ObterTodosRedis();
        }

        [HttpGet("ObterPorAutor/{autor}")]
        public async Task<ActionResult<IEnumerable<BookViewModel>>> ObterPorAutor(string autor)
        {
            var bookViewModel = _mapper.Map<IEnumerable<BookViewModel>>(await _bookRepository.ObterPorAutor(autor));

            if (bookViewModel.Any()) return NotFound();

            return Ok(bookViewModel);
        }

        [HttpGet("ObterPorNome/{nome}")]     
        public async Task<IEnumerable<BookViewModel>> ObterPorNome(string nome)
        {
            return _mapper.Map<IEnumerable<BookViewModel>>(await _bookRepository.ObterPorNome(nome));
        }

        [HttpGet("ObterPorId/{id:guid}")]
        public async Task<ActionResult<BookViewModel>> ObterPorId(Guid id)
        {
            var bookViewModel = _mapper.Map<BookViewModel>(await _bookRepository.ObterPorId(id));

            if (bookViewModel == null) return NotFound();

            return bookViewModel;
        }

       // [ClaimsAuthorize("Book", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<BookViewModel>> Adicionar(BookViewModel bookViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _bookService.Adicionar(_mapper.Map<Book>(bookViewModel));

            return CustomResponse(bookViewModel);
        }
    }
}
