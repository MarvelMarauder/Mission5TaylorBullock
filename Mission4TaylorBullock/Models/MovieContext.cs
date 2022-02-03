using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4TaylorBullock.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext (DbContextOptions<MovieContext> options) : base (options)
        {

        }

        public DbSet<MovieResponse> Response { get; set;  }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryID = 2, CategoryName = "Comedy" },
                new Category { CategoryID = 3, CategoryName = "Drama"},
                new Category { CategoryID = 4, CategoryName = "Family"},
                new Category { CategoryID = 5, CategoryName = "Horror/Suspense"},
                new Category { CategoryID = 6, CategoryName = "Miscellaneous"},
                new Category { CategoryID = 7, CategoryName = "Television" },
                new Category { CategoryID = 8, CategoryName = "VHS"}
                );

            mb.Entity<MovieResponse>().HasData(
                new MovieResponse
                {
                    MovieID = 1,
                    CategoryID = 1,
                    Title = "The Dark Knight",
                    Year = 2008,
                    Director = "Christopher Nolan",
                    Rating = "PG-13"
                },
                new MovieResponse
                {
                    MovieID = 2,
                    CategoryID = 1,
                    Title = "The Lord of the Rings: Return of the King",
                    Year = 2003,
                    Director = "Peter Jackson",
                    Rating = "PG-13"
                },
                new MovieResponse
                {
                    MovieID = 3,
                    CategoryID = 2,
                    Title = "Monty Python and the Holy Grail",
                    Year = 1975,
                    Director = "Terry Gilliam, Terry Jones",
                    Rating = "PG"
                });
        }
    }
}
