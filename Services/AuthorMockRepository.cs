using LibraryAPI.Data;
using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public class AuthorMockRepository : IAuthorRepository
    {
        public AuthorDto GetAuthor(Guid authorId)
        {
            var author = LibraryMockData.Current.Authors.FirstOrDefault(author => author.Id == authorId);
            return author;
        }

        public IEnumerable<AuthorDto> GetAuthors()
        {
            return LibraryMockData.Current.Authors;
        }

        public bool IsAuthorExists(Guid authorId)
        {
            return LibraryMockData.Current.Authors.Any(author => author.Id == authorId);
        }
        public void AddAuthor(AuthorDto author)
        {
            author.Id = Guid.NewGuid();
            LibraryMockData.Current.Authors.Add(author);
        }
    }
}
