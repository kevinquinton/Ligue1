using System.Collections.Generic;
using Ligue1.AndroidCore.Entities;

namespace Ligue1.AndroidCore.Services
{
    interface ICompetitionFixturesServiceMocker
    {
        /// <summary>
        /// Récupère les fixtures
        /// </summary>
        /// <returns></returns>
        List<Fixture> GetFixtures();
    }
}