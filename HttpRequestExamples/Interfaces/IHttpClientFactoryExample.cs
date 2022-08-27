using HttpRequestExamples.Models;

namespace HttpRequestExamples.Interfaces
{
    public interface IHttpClientFactoryExample
    {
        Task<BtcContent?> GetBtcContent();
        Task<BtcContent?> GetBtcContentWithNamedClient();
    }
}