using BookStoreApp.Blazor.Server.UI.Services.Base;

namespace BookStoreApp.Blazor.Server.UI.Services
{
    public interface IBookService
    {
        Task<Response<List<BookReadOnlyDto>>> Get();
        Task<Response<BookDetailsDto>> Get(int id);

        Task<Response<BookUpdateDto>> GetForUpdate(int id);
        Task<Response<int>> Create(BookCreateDto bookCreateDto);
        Task<Response<int>> Edit(int id, BookUpdateDto bookUpdateDto);
        Task<Response<int>> Delete(int id);
    }
}
