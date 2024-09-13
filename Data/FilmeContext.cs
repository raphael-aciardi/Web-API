﻿using Microsoft.EntityFrameworkCore;
using Web_API.Models;

namespace Web_API.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opts) : base(opts) { }
        public DbSet<Filme> Filmes { get; set; }
    }
}
