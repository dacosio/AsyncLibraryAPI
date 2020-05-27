using System;
using AutoMapper;

namespace Library.API.Profiles
{
    public class BooksProfile : Profile
    {
        public BooksProfile()
        {
            CreateMap<Entities.Book, Models.Book>()
                .ForMember(dest => dest.Author,
                //this will map the first name and last name from Author Navigation to the destination DTO Author
                opt => opt.MapFrom(src => $"{src.Author.FirstName} {src.Author.LastName}"));

            CreateMap<Entities.Book, Models.Book>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src =>
                   $"{src.Author.FirstName} {src.Author.LastName}"));

        }
    }
}