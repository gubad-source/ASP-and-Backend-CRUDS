using Microsoft.EntityFrameworkCore;
using MoviesDesktop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesDesktop.Data
{
    public class MovieContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-D6PJ3FJ7;Database=Movies;Integrated Security=True");
        }
        public DbSet<Movie>Movies { get; set; }
        public DbSet<Country>Countries { get; set; }
    }
}
