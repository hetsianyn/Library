using System.Diagnostics.Eventing.Reader;
using System.Linq;
using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            
            CreateMap<Rating, RatingDto>();
            CreateMap<Review, ReviewDto>();
            CreateMap<Book, BookDto>()
                .ForMember(book => book.Rating, opt => opt.MapFrom(book =>
                    book.Ratings.Average(ratings => ratings.Score)))
                .ForMember(book => book.ReviewsNumber, opt => opt.MapFrom(book => book.Reviews.Count));
            CreateMap<Book, BookDetailedDto>()
                .ForMember(book => book.Rating, opt => opt.MapFrom(book =>
                    book.Ratings.Average(ratings => ratings.Score)));
        }
    }
}