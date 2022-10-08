using MangaLuAPI.MangaDex.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

            if (!result.IsSuccessful)
            {
                return null;
            }
            var accessToken = result.Data.Token.Session;

            RestClient.AddDefaultHeader("Authorization", $"Bearer {accessToken}");

            return accessToken;
        }

        public void RequestStatus()
        {
            var returnValue = new List<string>();

            var status = new RestRequest($"/manga/status", Method.Get);

            var result = RestClient.Execute<MangaDexStatusResponse>(status);

            var mangaIds = JsonConvert.DeserializeObject<Dictionary<string, string>>(result.Data.statuses.ToString().Trim());

            foreach (var id in mangaIds.keys)
            {
                returnValue.Add(id);
            }
        }
    }
}
