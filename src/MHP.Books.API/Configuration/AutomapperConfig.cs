using AutoMapper;
using MHP.Books.API.ViewModels;
using MHP.Books.Business.Models;

namespace MHP.Books.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Book, BookViewModel>().ReverseMap();
            CreateMap<Specification, SpecificationViewModel>().ReverseMap();
            CreateMap<Genre, GenreViewModel>().ReverseMap();
            CreateMap<Illustrator, IllustratorViewModel>().ReverseMap();
           
        }
    }
}