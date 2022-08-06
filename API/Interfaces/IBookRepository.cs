using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;

namespace API
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookDto>> GetBooksOrdered(string orderParameter);
        Task<IEnumerable<BookDto>> GetTopByGenre(string genre);
        Task<BookDetailedDto> GetBookDetails(int id);
        Task DeleteBook(int id, string secret);
        Task<int> SaveBook(BookCreationDto bookCreationDto);
        Task<int> SaveReview(int bookId, ReviewDto reviewDto);
        Task<int> RateBook(int bookId, RatingDto ratingDto);
    }
}