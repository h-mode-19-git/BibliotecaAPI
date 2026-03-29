using BibliotecaApi.Domain.Entities;

public interface ILibroService
{
    Task<IList<Libro>> GetLibros();
    Task<Libro?> GetLibro(int id);
    Task CrearLibro(Libro libro);
    Task<bool> ActualizarLibro(Libro libro);
    Task<bool> EliminarLibro(int id);
}