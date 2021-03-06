using System.Collections.Generic;
using Ligue1.AndroidCore.Entities;

namespace Ligue1.AndroidCore.Services.FixtureService
{
    interface IFixtureServiceMocker
    {
        /// <summary>
        /// R�cup�re les fixtures
        /// </summary>
        /// <returns></returns>
        List<Fixture> GetFixtures();
    }
}