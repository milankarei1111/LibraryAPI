using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public interface IAuthorRepository
    {
        IEnumerable<AuthorDto> GetAuthors();
        AuthorDto GetAuthor(Guid authorId);
        bool IsAuthorExists(Guid authorId);
        void AddAuthor(AuthorDto author);
        void DeleteAuthor(AuthorDto author);
    }
}
