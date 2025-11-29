using API_01.DAL.Models;
using API_01.DAL.Models.Dtos;
using API_01.DAL.Models.Dtos.Category;
using AutoMapper;

namespace API_01.MoviesMapper
{
    public class Mappers : Profile
    {
        public Mappers() 
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateUpdateDto>().ReverseMap();
        }
    }
}
