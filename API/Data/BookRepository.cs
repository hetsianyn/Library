using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public BookRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
                {
                    books = books.OrderBy(b => b.Title);
                }
                if (orderParameter == "author")
                {
                    books = books.OrderBy(b => b.Author);
                }
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
    }
}