using Ligue1.AndroidCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ligue1.AndroidCore.Services
{
    interface ICompetitionFixturesService : IService
    {
        /// <summary>
        /// Récupérer la liste de matchs d'une journée
        /// </summary>
        /// <param name="competitionId">Identifiant de la compétition</param>
        /// <returns>Liste de <seealso cref="Fixture" /></returns>
        Task<List<Fixture>> GetFixturesAsync(string competitionId);
    }
}