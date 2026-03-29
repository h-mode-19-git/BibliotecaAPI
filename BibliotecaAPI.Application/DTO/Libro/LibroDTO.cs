using System.ComponentModel.DataAnnotations;

public class LibroDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Titulo es obligatorio")]
    [StringLength(100)]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "Autor es obligatorio")]
    [StringLength(100)]
    public string Autor { get; set; }

    [Required(ErrorMessage = "Año es obligatorio")]
    public int Anio { get; set; }
    public string Genero { get; set; } = string.Empty;
    public bool Disponible { get; set; } = true;
}