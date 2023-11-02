﻿using System.Runtime;
using AutoMapper;
using BookStoreApp.Blazor.Server.UI.Services.Base;


namespace BookStoreApp.Blazor.Server.UI.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<AuthorDetailsDto, AuthorUpdateDto>().ReverseMap();
            CreateMap<AuthorDetailsDto, AuthorReadOnlyDto>().ReverseMap();
        }
    }
}
