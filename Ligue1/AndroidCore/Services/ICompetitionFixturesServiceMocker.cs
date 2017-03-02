using System;
using System.Collections.Generic;
using System.Linq;
using Ligue1.Models;

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