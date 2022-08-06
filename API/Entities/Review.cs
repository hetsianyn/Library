using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Reviews")]
    public class Review
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public string? Reviewer { get; set; }
        public int SourceBookId { get; set; }
        public Book SourceBook { get; set; }

    }
}