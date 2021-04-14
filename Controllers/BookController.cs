using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/authors/{authorId}/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public BookController(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            BookRepository = bookRepository;
            AuthorRepository = authorRepository;
        }
        public IBookRepository BookRepository { get; }
        public IAuthorRepository AuthorRepository { get; }


        [HttpGet]
        public ActionResult <List<BookDto>> GetBooks(Guid authorId)
        {
            if(! AuthorRepository.IsAuthorExists(authorId))
            {
                return NotFound();
            }

            return BookRepository.GetBooksForAuthor(authorId).ToList();
        }

        [HttpGet("{bookId}")]
        public ActionResult<BookDto> GetBook(Guid authorId, Guid bookId)
        {
            if (! AuthorRepository.IsAuthorExists(authorId))
            {
                return NotFound();
            }

            var book = BookRepository.GetBookForAuthor(authorId, bookId);
            if(book == null)
            {
                return NotFound();
            } 
            else
            {
                return book;
            }
        }
    }
}
