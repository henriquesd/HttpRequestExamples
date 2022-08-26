using HttpRequestExamples.Models;

namespace HttpRequestExamples.Interfaces
{
    public interface IHttpClientExample
    {
        Task<BtcContent?> GetBtcContent();
        Task<BtcContent?> GetBtcContentWithUsing();
        Task<List<int>> GetGoogle();
    }
}