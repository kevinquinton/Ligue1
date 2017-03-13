using System.Threading.Tasks;
using Ligue1.AndroidCore.Entities;

namespace Ligue1.AndroidCore.Services.CompetitionService
{
    interface ICompetitionService : IService
    {
        /// <summary>
        /// Récupère une compétition par son identifiant
        /// </summary>
        /// <param name="id">Identifiant de la compétition</param>
        /// <returns>Compétition correspondante à l'identifiant</returns>
        Task<CompetitionRootObject> GetCompetition(string id);
    }
}