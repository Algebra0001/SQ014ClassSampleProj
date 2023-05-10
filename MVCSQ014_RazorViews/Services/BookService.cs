using MVCSQ014_RazorViews.Models;

namespace MVCSQ014_RazorViews.Services
{
    public class BookService : BaseService, IBookService
    {
        public BookService(HttpClient client, IConfiguration config) : base(client, config)
        {}

        public async Task<Book> GetBookAsync()
        {
            var address = "/api/Book/{id}";
            var apiResponse = await this.MakeApiRequestAsync<Book>(address, "GET", null);

            if (apiResponse != null)
            {
                return apiResponse;
            }

            return null;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            var address = "/api/Book/all";
            var apiResponse = await this.MakeApiRequestAsync<IEnumerable<Book>>(address, "GET", null);

            if(apiResponse != null) { 
                return apiResponse;
            }

            return null;
        }
    }
}
