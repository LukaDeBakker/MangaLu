using MangaLuAPI.MangaDex.Repositories;
using System;

namespace MangaLuAPI.MangaDex.Scraper
{
    public class ScraperJob : IScraperJob
    {
        public ScraperJob(IMangaDexClient mangaDexClient)
        {
            MangaDexClient = mangaDexClient ?? throw new ArgumentNullException(nameof(mangaDexClient));
        }

        public IMangaDexClient MangaDexClient { get; set; }

        public void Run()
        {
            var accesToken = MangaDexClient.Authorize();

            if (!string.IsNullOrEmpty(accesToken))
            {
                return;
            }

            MangaDexClient.RequestStatus();
        }
    }
}
