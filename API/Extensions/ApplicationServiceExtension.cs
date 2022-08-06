using API.Data;
using API.DTOs;
using API.Helpers;
using API.Interfaces;
using API.Validation;
using FluentValidation;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            services.AddHttpLogging(httpLogging =>
            {
                httpLogging.LoggingFields = HttpLoggingFields.All;
                httpLogging.RequestHeaders.Add("Request-Header-Demo");
                httpLogging.ResponseHeaders.Add("Response-Header-Demo");
                httpLogging.MediaTypeOptions.AddText("application/javascript");
                httpLogging.RequestBodyLogLimit = 4096;
                httpLogging.ResponseBodyLogLimit = 4096;
            });
            services.AddScoped<IValidator<BookCreationDto>, BookCreationDtoValidator>();
            services.AddScoped<IValidator<ReviewDto>, SaveReviewValidator>();
            services.AddScoped<IValidator<RatingDto>, RateBookValidator>();

            return services;
        }
    }
}