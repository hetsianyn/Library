using System.Linq;
using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            
            CreateMap<Review, ReviewDto>();
            CreateMap<Book, BookDto>()
                .ForMember(book => book.Cover, opt => opt.MapFrom(book => book.Cover))
                .ForMember(book => book.Rating, opt => opt.MapFrom(book =>
                    book.Ratings.Average(ratings => ratings.Score)))
                .ForMember(book => book.ReviewsNumber, opt => opt.MapFrom(book =>
                    book.Reviews.Count));
            CreateMap<Book, BookDetailedDto>()
                .ForMember(book => book.Rating, opt => opt.MapFrom(book =>
                    book.Ratings.Average(ratings => ratings.Score)));
            CreateMap<BookCreationDto, Book>()
                .ForMember(book => book.Cover, opt => opt.MapFrom(book =>
                    book.Cover.ConvertToBase64()));
            CreateMap<Review, ReviewDto>().ReverseMap();
            CreateMap<Rating, RatingDto>().ReverseMap();
        }
    }
}