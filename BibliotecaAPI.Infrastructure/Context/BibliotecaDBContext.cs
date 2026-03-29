using BibliotecaApi.Domain.Entities;
using BibliotecaAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Infrastructure.Context
{
    public class BibliotecaDBContext : DbContext
    {
        public BibliotecaDBContext(DbContextOptions<BibliotecaDBContext> options)
            : base(options)
        {
        }

        public DbSet<Libro> Libros => Set<Libro>();

        public DbSet<Genero> Generos => Set<Genero>();

    }
}