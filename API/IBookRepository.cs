using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookDto>> GetBooksOrdered(string orderParameter);
        Task<IEnumerable<BookDto>> GetTopByGenre(string genre);
        Task<BookDetailedDto> GetBookDetails(int id);

    }
}