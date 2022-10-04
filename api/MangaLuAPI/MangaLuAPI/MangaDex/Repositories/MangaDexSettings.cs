using Microsoft.Extensions.Configuration;
using System;

namespace MangaLuAPI.MangaDex.Repositories
{
    public class MangaDexSettings: IMangaDexSettings
    {
        protected IConfiguration Configuration { get; }

        public MangaDexSettings(IConfiguration configuration)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public string MangaDexApiUrl => Configuration.GetValue<string>("MangaDex:ApiUrl");
    }
}
