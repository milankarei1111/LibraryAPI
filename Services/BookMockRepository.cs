using LibraryAPI.Data;
using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public class BookMockRepository : IBookRepository
    {
        public BookDto GetBookForAuthor(Guid authorId, Guid bookId)
        {

            return LibraryMockData.Current.Books.FirstOrDefault(book => book.AuthorId == authorId && book.Id == bookId);
        }

        public IEnumerable<BookDto> GetBooksForAuthor(Guid authorId)
        {
            return LibraryMockData.Current.Books.Where(book => book.AuthorId == authorId).ToList();
        }
        public void AddBook(BookDto bookDto)
        {
            LibraryMockData.Current.Books.Add(bookDto);
        }

        public void DeleteBook(BookDto bookDto)
        {
            LibraryMockData.Current.Books.Remove(bookDto);
        }
    }
}
