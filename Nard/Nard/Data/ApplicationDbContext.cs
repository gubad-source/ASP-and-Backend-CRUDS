﻿using Microsoft.EntityFrameworkCore;
using Nard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nard.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category>Categories { get; set; }
        public DbSet<Nerd>Nerds { get; set; }
    }
}
