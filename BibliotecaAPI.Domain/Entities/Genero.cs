using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaAPI.Domain.Entities
{
    public class Genero
    {
        public Genero(string titulo)
        {
            Titulo = titulo;
        }

        public Genero()
        {

        }

        public int Id { get; set; }
        public string Titulo { get; set; }
    }
}
