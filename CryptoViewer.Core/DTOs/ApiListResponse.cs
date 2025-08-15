namespace CryptoViewer.Core.DTOs
{
    public class ApiListResponse<T>
    {
        public IReadOnlyList<T> Data { get; set; } = [];
    }
}
