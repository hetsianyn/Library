using System.Collections.Generic;
using System.Linq;

namespace API.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Cover { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public ICollection<Review> Reviews { get; set; }

        // public decimal GetRating()
        // {
        //     return Ratings.Average(x => x.Score);
        // }
        //
        // public int GetReviewsNumber()
        // {
        //     return Reviews.Count;
        // }
    } 
}