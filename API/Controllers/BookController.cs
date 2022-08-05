using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;

        public BooksController(IBookRepository bookRepository, IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
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
        
        [HttpDelete("books/{id}")]
        public async Task<ActionResult> DeleteBook(int id, string secret)
        {
            await _bookRepository.DeleteBook(id, secret);
            
            return NoContent();
        }

        [HttpPost("books/save")]
        public async Task<ActionResult> SaveBook([FromForm] BookCreationDto bookDto)
        {
            var bookId = await _bookRepository.SaveBook(bookDto);
            await _unitOfWork.Complete();
            
            return StatusCode(201, bookId);
        }
        
        [HttpPut("books/{id}/review")]
        public async Task<ActionResult> SaveReview(int id,
            [FromForm] ReviewDto reviewDto)
        {
            var response = await _bookRepository.SaveReview(id, reviewDto);
            await _unitOfWork.Complete();
            
            return StatusCode(201, response);
        }
        
        [HttpPut("books/{id}/rate")]
        public async Task<ActionResult> SaveReview(int id,
            [FromForm] RatingDto ratingDto)
        {
            var response = await _bookRepository.RateBook(id, ratingDto);
            await _unitOfWork.Complete();
            
            return StatusCode(201, response);
        }
    }
}