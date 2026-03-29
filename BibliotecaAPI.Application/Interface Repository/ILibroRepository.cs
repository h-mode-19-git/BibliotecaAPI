using BibliotecaApi.Domain.Entities;

public interface ILibroRepository
{
    Task<IList<Libro>> GetAll();
    Task<Libro?> GetById(int id);
    Task Add(Libro libro);
    Task<bool> Update(Libro libro);
    Task<bool> Delete(int id);
}