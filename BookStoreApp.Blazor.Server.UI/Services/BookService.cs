using AutoMapper;
using Blazored.LocalStorage;
using BookStoreApp.Blazor.Server.UI.Services.Base;

namespace BookStoreApp.Blazor.Server.UI.Services
{
    public class BookService : BaseHttpService, IBookService
    {

        private readonly IClient client;
        private readonly IMapper mapper;

        public BookService(IClient client, ILocalStorageService localStorage, IMapper mapper) : base(client, localStorage)
        {
            this.client = client;
            this.mapper = mapper;
        }
        public async Task<Response<int>> Create(BookCreateDto bookCreateDto)
        {
            Response<int> response = new();

            try
            {
                await GetBearerToken();
                await client.BooksPOSTAsync(bookCreateDto);
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
                await client.BooksDELETEAsync(id);
            }
            catch (ApiException ex)
            {
                response = ConvertApiException<int>(ex);
            }

            return response;
        }

        public async Task<Response<int>> Edit(int id, BookUpdateDto Book)
        {
            Response<int> response = new();

            try
            {
                await GetBearerToken();
                await client.BooksPUTAsync(id, Book);
            }
            catch (ApiException ex)
            {
                response = ConvertApiException<int>(ex);
            }
            return response;
        }

        public async Task<Response<BookUpdateDto>> GetForUpdate(int id)
        {
            Response<BookUpdateDto> response;

            try
            {
                await GetBearerToken();
                var data = await client.BooksGETAsync(id);
                response = new Response<BookUpdateDto>
                {
                    Data = mapper.Map<BookUpdateDto>(data),
                    Success = true
                };

            }
            catch (ApiException exception)
            {
                response = ConvertApiException<BookUpdateDto>(exception);
            }

            return response;
        }

        public async Task<Response<List<BookReadOnlyDto>>> Get()
        {
            Response<List<BookReadOnlyDto>> response;

            try
            {
                await GetBearerToken();
                var data = await client.BooksAllAsync();
                response = new Response<List<BookReadOnlyDto>>
                {
                    Data = data.ToList(),
                    Success = true
                };
            }
            catch (ApiException exception)
            {
                response = ConvertApiException<List<BookReadOnlyDto>>(exception);
            }
            return response;
        }

        public async Task<Response<BookDetailsDto>> Get(int id)
        {
            Response<BookDetailsDto> response;

            try
            {
                await GetBearerToken();
                var data = await client.BooksGETAsync(id);
                response = new Response<BookDetailsDto>
                {
                    Data = mapper.Map<BookDetailsDto>(data),
                    Success = true
                };
            }
            catch (ApiException exception)
            {
                response = ConvertApiException<BookDetailsDto>(exception);
            }

            return response;
        }
    }
}
