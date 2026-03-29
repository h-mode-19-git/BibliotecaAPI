using AutoMapper;
using BibliotecaApi.Domain.Entities;

namespace BibliotecaApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Libro, LibroDTO>().ReverseMap();
            CreateMap<Libro, CLibroDTO>().ReverseMap();
            CreateMap<Libro, MLibroDTO>().ReverseMap();


        }
    }
}