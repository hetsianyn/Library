using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Exceptions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace API.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public BookRepository(DataContext context, IMapper mapper, IConfiguration config)
        {
            _context = context;
            _mapper = mapper;
            _config = config;
        }

        public async Task<IEnumerable<BookDto>> GetBooksOrdered(string orderParameter)
        {
            var books = _context.Book as IQueryable<Book>;

            books = books
                .Include(b => b.Reviews)
                .Include(b => b.Ratings);

            if (!string.IsNullOrEmpty(orderParameter))
            {
                if (orderParameter == "title")
                    books = books.OrderBy(b => b.Title);
                if (orderParameter == "author")
                    books = books.OrderBy(b => b.Author);
            }

            await books.ToListAsync();

            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<IEnumerable<BookDto>> GetTopByGenre(string genre)
        {
            var books = await _context.Book
                .Include(b => b.Reviews)
                .Include(b => b.Ratings)
                .Where(b => (genre == null || b.Genre.ToLower() == genre) && b.Reviews.Count > 10)
                .ToListAsync();
            
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<BookDetailedDto> GetBookDetails(int id)
        {
            var books = await _context.Book
                .Include(b => b.Reviews)
                .Include(b => b.Ratings)
                .FirstOrDefaultAsync(b => b.Id == id);

            return _mapper.Map<BookDetailedDto>(books);
        }

        public async Task DeleteBook(int id, string secret)
        {
            if (secret != _config["Key:secret"])
                throw new ArgumentException("Invalid secret key");
            
            var book = await _context.Book
                .FirstOrDefaultAsync(b => b.Id == id);
            
            if(book == null)
                throw new NotFoundException(nameof(Book), id);
            
            _context.Book.Remove(book);
            
            await _context.SaveChangesAsync();
        }

        public async Task<int> SaveBook(BookCreationDto bookDto)
        {
            var book = await _context.Book
                .FirstOrDefaultAsync(b => b.Id == bookDto.Id);
            
            var isExist = book != null;
            
            if (!isExist)
            {
                var newBook = _mapper.Map<Book>(bookDto);
                await _context.Book.AddAsync(newBook);

                return newBook.Id;
            }

            _mapper.Map(bookDto, book);
            
            return bookDto.Id;
        }

        public async Task<int> SaveReview(int bookId, ReviewDto reviewDto)
        {
            var book = await _context.Book
                .Include(b => b.Reviews)
                .FirstOrDefaultAsync(b => b.Id == bookId);
            
            if (book == null)
                throw new NotFoundException(nameof(Book), bookId);

            var review = _mapper.Map<Review>(reviewDto);
            
            book.Reviews.Add(review);

            return bookId;
        }

        public async Task<int> RateBook(int bookId, RatingDto ratingDto)
        {
            var book = await _context.Book
                .Include(b => b.Ratings)
                .FirstOrDefaultAsync(b => b.Id == bookId);
            
            if (book == null)
                throw new NotFoundException(nameof(Book), bookId);

            var score = _mapper.Map<Rating>(ratingDto);

            if (score.Score > 5 || score.Score < 1)
                throw new InvalidScoreException(score.Score);
            
            book.Ratings.Add(score);

            return bookId;
        }
    }
}