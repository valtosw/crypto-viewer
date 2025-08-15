using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CryptoViewer.Infrastructure.Http
{
    public sealed class ApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;
        private readonly string _apiKey;


        public ApiClient(Uri baseAddress, string apiKey)
        {
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));

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

        public async Task<T?> GetAsync<T>(string path, CancellationToken cancellationToken = default)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, path);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Add("Authorization", $"Bearer {_apiKey}");

            using var response = await _httpClient.SendAsync(request, cancellationToken);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync(cancellationToken);

            var result = JsonSerializer.Deserialize<T>(json, _jsonOptions);

            return result ?? throw new InvalidOperationException($"Failed to deserialize response from {path}");
        }
    }
}
