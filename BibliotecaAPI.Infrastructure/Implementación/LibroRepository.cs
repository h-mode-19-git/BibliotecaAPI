using BibliotecaApi.Domain.Entities;
using BibliotecaAPI.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

public class LibroRepository : ILibroRepository
{
    private readonly BibliotecaDBContext _context;

    public LibroRepository(BibliotecaDBContext context)
    {
        _context = context;
    }

    public async Task<IList<Libro>> GetAll() =>
        await _context.Libros.ToListAsync();

    public async Task<Libro?> GetById(int id) =>
        await _context.Libros.FindAsync(id);

    public async Task Add(Libro libro)
    {
        _context.Libros.Add(libro);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> Update(Libro libro)
    {
        if (libro != null)
        {
            //var exlibro = await _context.Libros.FindAsync(libro.Id);
            //if (exlibro != null)
            //{

                _context.Libros.Update(libro);
                return await _context.SaveChangesAsync() > 0;
                //return true;
            //}
            //else
            //{
            //    return false;
            //} 
        }
        else
        {
            return false;
        }
    }

    public async Task<bool> Delete(int id)
    {
        var libro = await _context.Libros.FindAsync(id);
        if (libro != null)
        {
            _context.Libros.Remove(libro);
            return await _context.SaveChangesAsync() > 0;
            //return true;
        }
        else
        {
            return false;
        }
    }
}