using Ligue1.AndroidCore.Entities;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using Ligue1.AndroidCore.Helpers;
using Android.Util;

namespace Ligue1.AndroidCore.Services.FixtureService.Impl
{
    public class FixtureService : IFixtureService
    {
        /// <summary>
        /// Client Http
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Singleton
        /// </summary>
        private static FixtureService _instance;

        /// <summary>
        /// Tag pour logger
        /// </summary>
        private const string TAG = "CompetitionFixturesService";

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="httpClient">Client Http</param>
        private FixtureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Singleton
        /// </summary>
        /// <param name="httpClient">Client Http</param>
        /// <returns>Unique instanciation</returns>
        public static FixtureService CompetitionFixturesServiceSession(HttpClient httpClient)
        {
            if (_instance == null)
            {
                _instance = new FixtureService(httpClient);
            }
            return _instance;
        }

        /// <summary>
        /// R�cup�re les fixtures correspondant � une comp�tition
        /// </summary>
        /// <param name="competitionId">identifiant de la comp�tition</param>
        /// <param name="matchDay">num�ro de la journ�e</param>
        /// <returns>Liste de fixtures</returns>
        public async Task<List<Fixture>> GetFixturesAsync(string competitionId, int matchDay)
        {
            Log.Debug(TAG, "GetFixturesAsync");

            string url = string.Format(GetUrl(), competitionId, matchDay);

            var result = await HttpClientExtensions.GetAsync<FixturesRootObject>(_httpClient, url);

            return result.Fixtures;
        }

        /// <summary>
        /// R�cup�re l'url
        /// </summary>
        /// <returns>Url</returns>
        public string GetUrl()
        {
            return Constants.Url.URL_WEB_SERVICE_COMPETITIONS_FIXTURES_MATCH_DAY;
        }

    }
}