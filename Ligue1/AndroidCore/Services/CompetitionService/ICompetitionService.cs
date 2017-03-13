using System.Threading.Tasks;
using Ligue1.AndroidCore.Entities;

namespace Ligue1.AndroidCore.Services.CompetitionService
{
    interface ICompetitionService : IService
    {
        /// <summary>
        /// R�cup�re une comp�tition par son identifiant
        /// </summary>
        /// <param name="id">Identifiant de la comp�tition</param>
        /// <returns>Comp�tition correspondante � l'identifiant</returns>
        Task<CompetitionRootObject> GetCompetition(string id);
    }
}