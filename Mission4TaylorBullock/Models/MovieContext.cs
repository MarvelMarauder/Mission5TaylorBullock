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

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieResponse>().HasData(
                new MovieResponse
                {
                    MovieID = 1,
                    Category = "Action/Adventure",
                    Title = "The Dark Knight",
                    Year = 2008,
                    Director = "Christopher Nolan",
                    Rating = "PG-13"
                },
                new MovieResponse
                {
                    MovieID = 2,
                    Category = "Action/Adventure",
                    Title = "The Lord of the Rings: Return of the King",
                    Year = 2003,
                    Director = "Peter Jackson",
                    Rating = "PG-13"
                },
                new MovieResponse
                {
                    MovieID = 3,
                    Category = "Comedy",
                    Title = "Monty Python and the Holy Grail",
                    Year = 1975,
                    Director = "Terry Gilliam, Terry Jones",
                    Rating = "PG"
                });
        }
    }
}
