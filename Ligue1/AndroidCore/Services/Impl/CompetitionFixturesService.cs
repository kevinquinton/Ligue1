using Ligue1.AndroidCore.Entities;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using Ligue1.AndroidCore.Helpers;
using Android.Util;

namespace Ligue1.AndroidCore.Services.Impl
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
        /// R�cup�re les fixtures correspondant � une comp�tition
        /// </summary>
        /// <param name="competitionId">identifiant de la comp�tition</param>
        /// <returns>Liste de fixtures</returns>
        public async Task<List<Fixture>> GetFixturesAsync(string competitionId)
        {
            Log.Debug(TAG, "GetFixturesAsync");

            // TODO Rendre param�trable num�ro de la journ�e
            var url = string.Format(GetUrl(), competitionId) + "?matchday=24";

            var result = await HttpClientExtensions.GetAsync<FixturesRootObject>(_httpClient, url);

            return result.Fixtures;
        }

        public string GetUrl()
        {
            return Constants.Url.URL_WEB_SERVICE_COMPETITIONS_FIXTURES;
        }

    }
}