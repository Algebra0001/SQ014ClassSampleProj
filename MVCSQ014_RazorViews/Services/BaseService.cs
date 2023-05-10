using System.Net.Http;

namespace MVCSQ014_RazorViews.Services
{
    public class BaseService
    {
        private readonly HttpClient client;
        private readonly object baseUrl;

        public BaseService(HttpClient client, IConfiguration config)
        {
            this.client = client;
            baseUrl = config.GetSection("ApiSettings:BaseUrl").Value;
        }


        public async Task<T> MakeApiRequestAsync<T>(string address, string methodType, HttpContent? data)
        {
            if (!string.IsNullOrWhiteSpace(address))
            {
                var apiResponse = new HttpResponseMessage();
                switch (methodType)
                {
                    case "GET":
                        apiResponse = await client.GetAsync(baseUrl + address);
                        break;
                    case "POST":
                        apiResponse = await client.PostAsync(baseUrl + address, data);
                        break;
                    case "PUT":
                        apiResponse = await client.PutAsync(baseUrl + address, data);
                        break;
                    case "DELETE":
                        apiResponse = await client.DeleteAsync(baseUrl + address);
                        break;
                }

                if (apiResponse != null)
                {
                    if (apiResponse.IsSuccessStatusCode)
                    {
                        var result = await apiResponse.Content.ReadFromJsonAsync<T>();
                        if (result != null)
                            return result;
                    }
                }
            }
            return default(T);

        }

    }

    //public class ApiRequestObject<T> where T : class
    //{
    //    public string Url { get; set; } = "";
    //    public T Data { get; set; }

    //    public Dictionary<string, string> QueryStrings { get; set; } = new Dictionary<string, string>();
    //}
}
