using ManageBookInformation.Models;
using Microsoft.EntityFrameworkCore;

namespace ManageBookInformation.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = Guid.NewGuid(), ISBN = "1234567890", Title = "Sample Book 1", NumberOfPages = 200, Author = "Sample Author 1", PublicationYear = 2023 },
                new Book { Id = Guid.NewGuid(), ISBN = "0987654321", Title = "Sample Book 2", NumberOfPages = 300, Author = "Sample Author 2", PublicationYear = 2024 },
                new Book { Id = Guid.NewGuid(), ISBN = "1212121212", Title = "Sample Book 3", NumberOfPages = 400, Author = "Sample Author 3", PublicationYear = 2025 }
            );
        }
        public DbSet<Book> Books { get; set; }
       
    }
}
