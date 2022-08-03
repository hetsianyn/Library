using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Ratings")]
    public class Rating
    {
        public int Id { get; set; }
        public decimal Score { get; set; }
        public int SourceBookId { get; set; }
        public Book SourceBook { get; set; }
    }
}