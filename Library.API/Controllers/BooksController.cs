using System;
using System.Threading.Tasks;
using AutoMapper;
using Library.Api.Filters;
using Library.API.Models;
using Library.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IMapper _mapper;
        public BooksController(IBooksRepository booksRepository, IMapper mapper
            )
        {
            _booksRepository = booksRepository ?? throw new ArgumentException(nameof(booksRepository));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }


        [HttpGet]
        [BooksResultFilter]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _booksRepository.GetBooksAsync();

            return Ok(books);
        }


        [HttpGet]
        [BooksResultFilter]
        [Route("id", Name = "GetBook")]
        public async Task<IActionResult> GetBook(Guid id)
        {
            var book = await _booksRepository.GetBookAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }


        [HttpPost]
        [BookResultFilter]
        public async Task<IActionResult> CreateBook([FromBody] BookForCreation book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var bookEntity = _mapper.Map<Entities.Book>(book);
            _booksRepository.AddBook(bookEntity);
            await _booksRepository.SaveChangesAsync();

            await _booksRepository.GetBookAsync(bookEntity.Id);

            return CreatedAtRoute("GetBook", new { bookEntity.Id }, bookEntity);
        }
    }
}
