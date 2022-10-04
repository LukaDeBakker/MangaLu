using Newtonsoft.Json;

namespace MangaLuAPI.MangaDex.Models
{
    public class MangaDexLoginToken
    {
        [JsonProperty("token")]
        public string AccessToken { get; set; }
        public string Refresh { get; set; }
    }
}
