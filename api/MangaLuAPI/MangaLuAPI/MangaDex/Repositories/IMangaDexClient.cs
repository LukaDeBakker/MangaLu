using RestSharp;

namespace MangaLuAPI.MangaDex.Repositories
{
    public interface IMangaDexClient
    {
        RestClient RestClient { get; }

        public string Authorize();
    }
}
