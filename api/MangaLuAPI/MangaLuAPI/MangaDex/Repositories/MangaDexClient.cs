using MangaLuAPI.MangaDex.Models;
using RestSharp;
using System;

namespace MangaLuAPI.MangaDex.Repositories
{
    public class MangaDexClient: IMangaDexClient
    {
        public MangaDexClient(IMangaDexSettings mangaDexSettings)
        {
            MangaDexSettings = mangaDexSettings ?? throw new ArgumentNullException(nameof(mangaDexSettings));
            RestClient = new RestClient(MangaDexSettings.MangaDexApiUrl);
        }

        private IMangaDexSettings MangaDexSettings { get; }
        public RestClient RestClient { get; }

        public string Authorize()
        {
            var login = new RestRequest($"/auth/login", Method.Post);

            var loginModel = new MangaDexLoginRequest 
            {
                Username = "LukaD12",
                Password = "Luka2000"
            };

            login.AddJsonBody(loginModel);

            var result = RestClient.Execute<MangaDexLoginResponse>(login);
            var accessToken = result.Data.Token.Session;

            RestClient.AddDefaultHeader("Authorization", $"Bearer {accessToken}");

            return accessToken;
        }
    }
}
