using Newtonsoft.Json;

namespace MangaLuAPI.MangaDex.Models
{
    public class MangaDexLoginRequest
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
