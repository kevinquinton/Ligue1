using System;
using System.Threading.Tasks;
using Ligue1.AndroidCore.Entities;
using System.Net.Http;
using Android.Util;
using Ligue1.AndroidCore.Helpers;

namespace Ligue1.AndroidCore.Services.CompetitionService.Impl
{
    public class CompetitionService : ICompetitionService
    {
        /// <summary>
        /// Client Http
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Singleton
        /// </summary>
        private static CompetitionService _instance;

        /// <summary>
        /// Tag pour logger
        /// </summary>
        private const string TAG = "CompetitionService";

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="httpClient">Client Http</param>
        private CompetitionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Singleton
        /// </summary>
        /// <param name="httpClient">Client Http</param>
        /// <returns>Unique instanciation</returns>
        public static CompetitionService CompetitionServiceSession(HttpClient httpClient)
        {
            if (_instance == null)
            {
                _instance = new CompetitionService(httpClient);
            }
            return _instance;
        }

        /// <summary>
        /// Récupère une compétition par son identifiant
        /// </summary>
        /// <param name="id">Identifiant de la compétition</param>
        /// <returns>Compétition correspondante à l'identifiant</returns>
        public async Task<CompetitionRootObject> GetCompetition(string id)
        {
            Log.Debug(TAG, "GetFixturesAsync");

            string url = string.Format(GetUrl(), id);

            var result = await HttpClientExtensions.GetAsync<CompetitionRootObject>(_httpClient, url);

            return result;
        }

        /// <summary>
        /// Récupère l'url
        /// </summary>
        /// <returns>Url</returns>
        public string GetUrl()
        {
            return Constants.Url.URL_WEB_SERVICE_COMPETITION;
        }
    }
}