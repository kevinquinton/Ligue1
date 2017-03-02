using Ligue1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ligue1.Services
{
    interface ICompetitionFixturesService
    {
        /// <summary>
        /// R�cup�rer la liste de matchs d'une journ�e
        /// </summary>
        /// <param name="competitionId">Identifiant de la comp�tition</param>
        /// <returns>Liste de <seealso cref="Fixture" /></returns>
        Task<List<Fixture>> GetFixturesAsync(string competitionId);
    }
}