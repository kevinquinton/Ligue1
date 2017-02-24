using Ligue1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ligue1.Services
{
    interface ICompetitionFixturesService
    {
        /// <summary>
        /// Récupérer la liste de matchs d'une journée
        /// </summary>
        /// <param name="competitionId">Identifiant de la compétition</param>
        /// <returns>Objet Fixture</returns>
        Task<List<Fixture>> GetFixtures(string competitionId);
    }
}