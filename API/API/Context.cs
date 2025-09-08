using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed User
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "",
                Email = "admin@gmail.com",
                MobileNumber = "1234567890",
                AccountStatus = AccountStatus.ACTIVE,
                UserType = UserType.ADMIN,
                Password = "admin1999",
                CreatedOn = new DateTime(2023, 11, 01, 13, 28, 12)
            });

            // Seed Book Categories
            modelBuilder.Entity<BookCategory>().HasData(
                new BookCategory { Id = 1, Category = "computer", SubCategory = "algorithm" },
                new BookCategory { Id = 2, Category = "computer", SubCategory = "programming languages" },
                new BookCategory { Id = 3, Category = "computer", SubCategory = "networking" },
                new BookCategory { Id = 4, Category = "computer", SubCategory = "hardware" },
                new BookCategory { Id = 5, Category = "mechanical", SubCategory = "machine" },
                new BookCategory { Id = 6, Category = "mechanical", SubCategory = "transfer of energy" },
                new BookCategory { Id = 7, Category = "mathematics", SubCategory = "calculus" },
                new BookCategory { Id = 8, Category = "mathematics", SubCategory = "algebra" }
            );

            // Seed Books (Fixed Author/Title issues)
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, BookCategoryId = 1, Ordered = false, Price = 100, Author = "Thomas Cormen", Title = "Introduction to Algorithms" },
                new Book { Id = 2, BookCategoryId = 1, Ordered = false, Price = 100, Author = "Thomas Cormen", Title = "Introduction to Algorithms" },
                new Book { Id = 3, BookCategoryId = 1, Ordered = false, Price = 200, Author = "Robert Sedgewick & Kevin Wayne", Title = "Algorithms" },
                new Book { Id = 4, BookCategoryId = 1, Ordered = false, Price = 300, Author = "Steve Skiena", Title = "The Algorithm Design Manual" },
                new Book { Id = 5, BookCategoryId = 1, Ordered = false, Price = 400, Author = "Adnan Aziz", Title = "Algorithms For Interviews" },
                new Book { Id = 6, BookCategoryId = 1, Ordered = false, Price = 400, Author = "Adnan Aziz", Title = "Algorithms For Interviews" },
                new Book { Id = 7, BookCategoryId = 1, Ordered = false, Price = 400, Author = "Adnan Aziz", Title = "Algorithms For Interviews" },
                new Book { Id = 8, BookCategoryId = 1, Ordered = false, Price = 500, Author = "George Heineman", Title = "Algorithm in a Nutshell" },
                new Book { Id = 9, BookCategoryId = 1, Ordered = false, Price = 600, Author = "Klienberg & Tardos", Title = "Algorithm Design" },

                new Book { Id = 10, BookCategoryId = 2, Ordered = false, Price = 700, Author = "Eric Matthes", Title = "Python Crash Course" },
                new Book { Id = 11, BookCategoryId = 2, Ordered = false, Price = 700, Author = "Eric Matthes", Title = "Python Crash Course" },
                new Book { Id = 12, BookCategoryId = 2, Ordered = false, Price = 700, Author = "Eric Matthes", Title = "Python Crash Course" },
                new Book { Id = 13, BookCategoryId = 2, Ordered = false, Price = 800, Author = "Paul Barry", Title = "Head First Python" },
                new Book { Id = 14, BookCategoryId = 2, Ordered = false, Price = 900, Author = "Joshua Bloch", Title = "Effective Java" },
                new Book { Id = 15, BookCategoryId = 2, Ordered = false, Price = 900, Author = "Joshua Bloch", Title = "Effective Java" },
                new Book { Id = 16, BookCategoryId = 2, Ordered = false, Price = 1000, Author = "Kathy Sierra & Bert Bates", Title = "Head First Java" },
                new Book { Id = 17, BookCategoryId = 2, Ordered = false, Price = 1100, Author = "Brian W. Kernighan & Dennis M. Ritchie", Title = "C Programming Language" },
                new Book { Id = 18, BookCategoryId = 2, Ordered = false, Price = 1100, Author = "Brian W. Kernighan & Dennis M. Ritchie", Title = "C Programming Language" },
                new Book { Id = 19, BookCategoryId = 2, Ordered = false, Price = 1100, Author = "Brian W. Kernighan & Dennis M. Ritchie", Title = "C Programming Language" },
                new Book { Id = 20, BookCategoryId = 2, Ordered = false, Price = 1200, Author = "Marijn Haverbeke", Title = "Eloquent JavaScript" },
                new Book { Id = 21, BookCategoryId = 2, Ordered = false, Price = 1300, Author = "Donald E. Knuth", Title = "The Art of Computer Programming" },
                new Book { Id = 22, BookCategoryId = 2, Ordered = false, Price = 1300, Author = "Donald E. Knuth", Title = "The Art of Computer Programming" }
                // ... Continue the rest with same format
            );
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<UserType>().HaveConversion<string>();
            configurationBuilder.Properties<AccountStatus>().HaveConversion<string>();
        }
    }
}
    