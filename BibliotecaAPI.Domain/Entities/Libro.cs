namespace BibliotecaApi.Domain.Entities
{
    public class Libro
    {
        public Libro(int id,string titulo, string autor, int anio, string genero, bool? disponible )
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            Anio = (int)anio;
            Genero = genero;            
            Disponible = disponible.HasValue ? disponible.Value : false;
        }

        public Libro()
        {
  
        }

        public int Id { get; set; }
        public string Titulo { get; set; } 
        public string Autor { get; set; } 
        public int Anio { get; set; }
        public string Genero { get; set; } = string.Empty;
        public bool Disponible { get; set; } = true;

    }
}