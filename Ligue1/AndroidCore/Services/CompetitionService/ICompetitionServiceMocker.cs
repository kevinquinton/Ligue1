using Ligue1.AndroidCore.Entities;

namespace Ligue1.AndroidCore.Services.CompetitionService
{
    interface ICompetitionServiceMocker
    {
        /// <summary>
        /// Récupère une compétition par son identifiant
        /// </summary>
        /// <param name="id">Identifiant de la compétition</param>
        /// <returns>Compétition</returns>
        CompetitionRootObject GetCompetition(string id);
    }
}