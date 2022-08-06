using Microsoft.AspNetCore.Http;

namespace API.DTOs
{
    public class BookCreationDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IFormFile Cover { get; set; }
        public string Content { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
    }
}