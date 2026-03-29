using BibliotecaApi.Domain.Entities;

public class CrearLibroUseCase
{
    private readonly ILibroRepository _repo;

    public CrearLibroUseCase(ILibroRepository repo)
    {
        _repo = repo;
    }

    public async Task Ejecutar(LibroDTO dto)
    {
        var libro = new Libro(0,dto.Titulo, dto.Autor,2000,"1",null);
        await _repo.Add(libro);
    }

    public async Task Modificar(int id, LibroDTO dto)
    {
        // 1. Buscar el libro existente
        var libro = await _repo.GetById(id);

        if (libro == null)
            throw new Exception("El libro no existe");

        // 2. Validaciones básicas
        if (string.IsNullOrWhiteSpace(dto.Titulo))
            throw new ArgumentException("El título es obligatorio");

        if (string.IsNullOrWhiteSpace(dto.Autor))
            throw new ArgumentException("El autor es obligatorio");

        // 3. Actualizar propiedades
        libro.Titulo = dto.Titulo;
        libro.Autor = dto.Autor;

        // 4. Persistir cambios
        await _repo.Update(libro);
    }


}