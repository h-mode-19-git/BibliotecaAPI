using BibliotecaApi.Domain.Entities;

public class LibroService : ILibroService
{
    private readonly ILibroRepository _repo;

    public LibroService(ILibroRepository repo)
    {
        _repo = repo;
    }

    public Task<IList<Libro>> GetLibros() => _repo.GetAll();

    public Task<Libro?> GetLibro(int id) => _repo.GetById(id);

    public Task CrearLibro(Libro libro) => _repo.Add(libro);

    public Task<bool> ActualizarLibro(Libro libro) => _repo.Update(libro);

    public Task<bool> EliminarLibro(int id) => _repo.Delete(id);
}