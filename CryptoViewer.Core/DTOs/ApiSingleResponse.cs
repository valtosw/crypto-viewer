namespace CryptoViewer.Core.DTOs
{
    public class ApiSingleResponse<T>
    {
        public T Data { get; set; } = default!;
    }
}
