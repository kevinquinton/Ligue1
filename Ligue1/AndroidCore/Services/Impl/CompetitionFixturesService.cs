using Ligue1.Models;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using Ligue1.Helpers;
using System;
using Android.Util;

namespace Ligue1.Services.Impl
{
    class CompetitionFixturesService : ICompetitionFixturesService
    {
        private readonly HttpClient _httpClient;

        private static CompetitionFixturesService _instance;

        private const string TAG = "CompetitionFixturesService";

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="httpClient"></param>
        private CompetitionFixturesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public static CompetitionFixturesService CompetitionFixturesServiceSession(HttpClient httpClient)
        {
            if (_instance == null)
            {
                _instance = new CompetitionFixturesService(httpClient);
            }
            return _instance;
        }

        /// <summary>
        /// Récupère les fixtures correspondant à une compétition
        /// </summary>
        /// <param name="competitionId">identifiant de la compétition</param>
        /// <returns>Liste de fixtures</returns>
        public async Task<List<Fixture>> GetFixturesAsync(string competitionId)
        {
            Log.Info(TAG, "GetFixturesAsync");

            // TODO Rendre paramétrable numéro de la journée
            var url = string.Format(GetUrl(), competitionId) + "?matchday=24";

            try
            {
                await HttpClientExtensions.MakeGetRequest(url);
            }
            catch(System.Exception e)
            {
                Console.Write(e.ToString());
            }

            var result = await HttpClientExtensions.GetAsync<FixturesRootObject>(_httpClient, url);

            return result.Fixtures;
        }

        public string GetUrl()
        {
            return Constants.Constants.URL_WEB_SERVICE_COMPETITIONS_FIXTURES;
        }

    }
}