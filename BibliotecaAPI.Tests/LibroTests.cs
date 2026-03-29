using BibliotecaApi.Domain.Entities;
using Moq;

public class LibroTests
{
    [Fact]
    public async Task DebeCrearLibro()
    {
        var mockRepo = new Mock<ILibroRepository>();
        var useCase = new CrearLibroUseCase(mockRepo.Object);

        var dto = new LibroDTO
        {
            Titulo = "Test",
            Autor = "Autor"
        };

        await useCase.Ejecutar(dto);

        mockRepo.Verify(r => r.Add(It.IsAny<Libro>()), Times.Once);
    }

    [Fact]
    public async Task DebeActualizarLibro()
    {
        var mockRepo = new Mock<ILibroRepository>();

        var libroExistente = new Libro
        {
            Id = 1,
            Titulo = "Viejo",
            Autor = "Viejo Autor"
        };

        mockRepo
            .Setup(r => r.GetById(1))
            .ReturnsAsync(libroExistente);

        var useCase = new CrearLibroUseCase(mockRepo.Object);

        var dto = new LibroDTO
        {
            Titulo = "Nuevo",
            Autor = "Nuevo Autor"
        };

        // Act
        await useCase.Modificar(1, dto);

        // Assert
        mockRepo.Verify(r => r.Update(It.Is<Libro>(l =>
            l.Id == 1 &&
            l.Titulo == dto.Titulo &&
            l.Autor == dto.Autor
        )), Times.Once);
    }
}