using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedBooks(DataContext context)
        {
            if (await context.Book.AnyAsync()) return;

            var bookData = await System.IO.File.ReadAllTextAsync("Data/BookSeedData.json");
            var books = JsonSerializer.Deserialize<List<Book>>(bookData);

            foreach (var book in books)
            {
                context.Book.Add(book);
            }

            await context.SaveChangesAsync();
        }
    }
}