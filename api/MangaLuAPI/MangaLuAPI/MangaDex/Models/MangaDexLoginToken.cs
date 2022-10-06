using Newtonsoft.Json;

namespace MangaLuAPI.MangaDex.Models
{
    public class MangaDexLoginToken
    {
        public string Session { get; set; }
        public string Refresh { get; set; }
    }
}
