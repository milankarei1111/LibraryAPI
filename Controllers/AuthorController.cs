﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        public readonly IAuthorRepository AuthorRepository;
        public AuthorController(IAuthorRepository authorRepository) => AuthorRepository = authorRepository;

        [HttpGet]
        public ActionResult <List<AuthorDto>> GetAuthors()
        {
            return AuthorRepository.GetAuthors().ToList();
        }

        [HttpGet("{authorId}")]
        public ActionResult<AuthorDto> GetAuthor(Guid authorId)
        {
            var author = AuthorRepository.GetAuthor(authorId);
            if(author == null)
            {
                return NotFound();
            } 
            else
            {
                return author;
            }
        }
    }
}
