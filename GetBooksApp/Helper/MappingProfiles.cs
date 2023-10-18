using AutoMapper;
using GetBooksApp.Dtos;
using GetBooksApp.Models;

namespace GetBooksApp.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<BookModel, BookDto>();
            // for when updating or creating
            CreateMap<BookDto, BookModel>();


            CreateMap<BookModel, BookForCreationDto>();

            //for when updating or creating
            CreateMap<BookForCreationDto, BookModel>();
        }
    }
}
