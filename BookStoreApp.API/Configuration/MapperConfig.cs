using AutoMapper;
using BookStoreApp.API.Data;
using BookStoreApp.API.Models.Author;
using BookStoreApp.API.Models.Book;
using BookStoreApp.API.Models.User;

namespace BookStoreApp.API.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig() {
            CreateMap<AuthorCreateDto, Author>().ReverseMap();
            CreateMap<AuthorUpdateDto, Author>().ReverseMap();
            CreateMap<AuthorReadOnlyDto, Author>().ReverseMap();


            CreateMap<BookCreateDto, Book>().ReverseMap();
            CreateMap<BookUpdateDto, Book>().ReverseMap();
            CreateMap<Book, BookReadOnlyDto>().ForMember(q => q.AuthorName, 
                d => d.MapFrom(map => $"{map.Author.FirstName} {map.Author.LastName}")).ReverseMap(); 
            // convert left to right, and whatever is seen on the right can mapped from left.

            CreateMap<Book, BookDetailsDto>()
                .ForMember(q => q.AuthorName, d => d.MapFrom(map => $"{map.Author.FirstName} {map.Author.LastName}"))
                .ReverseMap();


            CreateMap<ApiUser, UserDto>().ReverseMap();
        }
    }
}
