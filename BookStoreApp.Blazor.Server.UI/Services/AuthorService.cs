using AutoMapper;
using Blazored.LocalStorage;
using BookStoreApp.Blazor.Server.UI.Services.Base;
    
  
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BookStoreApp.Blazor.Server.UI.Services
{
    public class AuthorService : BaseHttpService, IAuthorService
    {

        private readonly IClient client;
        private readonly IMapper mapper;

        public AuthorService(IClient client, ILocalStorageService localStorage, IMapper mapper) : base(client, localStorage)
        {
            this.client = client;
            this.mapper = mapper;
        }
        public async Task<Response<int>> Create(AuthorCreateDto author)
        {
            Response<int> response = new();

            try 
            {
                await GetBearerToken();
                await client.AuthorsPOSTAsync(author);
            }
            catch (ApiException ex)
            {
                response = ConvertApiException<int>(ex);
            }

            return response;
        }

        public async Task<Response<int>> Delete(int id)
        {
            Response<int> response = new();
            
            try 
            {
                await GetBearerToken();
                await client.AuthorsDELETEAsync(id);
            }
            catch(ApiException ex) 
            {
                response = ConvertApiException<int>(ex);
            }

            return response;
        }

        public async Task<Response<int>> EditAuthor(int id, AuthorUpdateDto author)
        {
            Response<int> response = new();

            try 
            {
                await GetBearerToken();
                await client.AuthorsPUTAsync(id, author);
            }
            catch (ApiException ex) 
            {
                response = ConvertApiException<int>(ex);
            }
            return response;
        }

        

        public async Task<Response<AuthorUpdateDto>> GetAuthorForUpdate(int id)
        {
            Response<AuthorUpdateDto> response;

            try
            {
                await GetBearerToken();
                var data = await client.AuthorsGETAsync(id);
                response = new Response<AuthorUpdateDto>
                {
                    Data = mapper.Map<AuthorUpdateDto>(data),
                    Success = true
                };

            }
            catch (ApiException exception)
            {
                response = ConvertApiException<AuthorUpdateDto>(exception);
            }

            return response; 
        }

        public async Task<Response<List<AuthorReadOnlyDto>>> GetAuthors()
        {
            Response<List<AuthorReadOnlyDto>> response;

            try
            {
                await GetBearerToken();
                var data = await client.AuthorsAllAsync();
                response = new Response<List<AuthorReadOnlyDto>>
                {
                    Data = data.ToList(),
                    Success = true
                };
            }
            catch (ApiException exception)
            {
                response = ConvertApiException<List<AuthorReadOnlyDto>>(exception);
            }
            return response;
        }

        public async Task<Response<AuthorDetailsDto>> GetAuthor(int id)
        {
            Response<AuthorDetailsDto> response;

            try
            {
                await GetBearerToken();
                var data = await client.AuthorsGETAsync(id);
                response = new Response<AuthorDetailsDto>
                {
                    Data = mapper.Map<AuthorDetailsDto>(data),
                    Success = true
                };
            }
            catch (ApiException exception)
            {
                response = ConvertApiException<AuthorDetailsDto>(exception);
            }

            return response;
        }
    }
}
