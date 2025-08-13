using System.Text.Json;
using System.Text.Json.Serialization;

namespace CryptoViewer.Infrastructure.Http
{
    public sealed class ApiClient
    {
        //private const string _apiPath = "https://rest.coincap.io/v3/";

        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;


        public ApiClient(Uri baseAddress)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = baseAddress,
                Timeout = TimeSpan.FromSeconds(30)
            };

            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                NumberHandling = JsonNumberHandling.AllowReadingFromString,
            };
        }

        public static async Task<T> GetAsync<T>(string path, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
