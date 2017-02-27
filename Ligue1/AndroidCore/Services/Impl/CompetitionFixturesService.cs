using System;
using Ligue1.Models;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using Ligue1.Helpers;

namespace Ligue1.Services.Impl
{
    class CompetitionFixturesService : ICompetitionFixturesService
    {
        private readonly HttpClient _httpClient;

        public CompetitionFixturesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// R�cup�re les fixtures correspondant � une comp�tition
        /// </summary>
        /// <param name="competitionId">identifiant de la comp�tition</param>
        /// <returns>Liste de fixtures</returns>
        public async Task<List<Fixture>> GetFixtures(string competitionId)
        {
            // TODO Rendre param�trable num�ro de la journ�e
            var url = string.Format(GetUrl(), competitionId) + "?matchday=24";

            var result = await HttpClientExtensions.GetAsync<FixturesRootObject>(_httpClient, url);

            return result.Fixtures;
        }

        public string GetUrl()
        {
            return Constants.Constants.URL_WEB_SERVICE_COMPETITIONS_FIXTURES;
        }


    }
}