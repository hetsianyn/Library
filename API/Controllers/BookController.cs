using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BooksController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        
        [HttpGet("books")]
        public async Task<ActionResult> GetBooksOrdered(string order)
        {
            var books = await _bookRepository.GetBooksOrdered(order);
            return Ok(books);
        }
        
        [HttpGet("recommended")]
        public async Task<ActionResult> GetRecommended(string genre)
        {
            var books = await _bookRepository.GetTopByGenre(genre);
            books = books.OrderByDescending(x => x.Rating).Take(5);
            return Ok(books);
        }
        
        [HttpGet("books/{id}")]
        public async Task<ActionResult> GetBookDetails(int id)
        {
            var books = await _bookRepository.GetBookDetails(id);
            return Ok(books);
        }


    }
}