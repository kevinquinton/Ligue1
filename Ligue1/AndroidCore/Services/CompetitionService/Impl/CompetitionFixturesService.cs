using Ligue1.AndroidCore.Entities;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using Ligue1.AndroidCore.Helpers;
using Android.Util;

namespace Ligue1.AndroidCore.Services.CompetitionService.Impl
{
    public class CompetitionFixturesService : ICompetitionFixturesService
    {
        /// <summary>
        /// Client Http
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Singleton
        /// </summary>
        private static CompetitionFixturesService _instance;

        /// <summary>
        /// Tag pour logger
        /// </summary>
        private const string TAG = "CompetitionFixturesService";

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="httpClient">Client Http</param>
        private CompetitionFixturesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Singleton
        /// </summary>
        /// <param name="httpClient">Client Http</param>
        /// <returns>Unique instanciation</returns>
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
        /// <param name="matchDay">numéro de la journée</param>
        /// <returns>Liste de fixtures</returns>
        public async Task<List<Fixture>> GetFixturesAsync(string competitionId, int matchDay)
        {
            Log.Debug(TAG, "GetFixturesAsync");

            var url = string.Format(GetUrl(), competitionId, matchDay);

            var result = await HttpClientExtensions.GetAsync<FixturesRootObject>(_httpClient, url);

            return result.Fixtures;
        }

        /// <summary>
        /// Récupère l'url
        /// </summary>
        /// <returns>Url</returns>
        public string GetUrl()
        {
            return Constants.Url.URL_WEB_SERVICE_COMPETITIONS_FIXTURES_MATCH_DAY;
        }

    }
}