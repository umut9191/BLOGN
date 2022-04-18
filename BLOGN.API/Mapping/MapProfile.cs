using AutoMapper;
using BLOGN.Models;
using BLOGN.Models.Dtos;

namespace BLOGN.API.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            //category can be map to CategoryDto and CategoryDto can be mep to Category
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Article, ArticleDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
