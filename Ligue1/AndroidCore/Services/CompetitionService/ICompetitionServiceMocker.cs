using Ligue1.AndroidCore.Entities;

namespace Ligue1.AndroidCore.Services.CompetitionService
{
    interface ICompetitionServiceMocker
    {
        /// <summary>
        /// R�cup�re une comp�tition par son identifiant
        /// </summary>
        /// <param name="id">Identifiant de la comp�tition</param>
        /// <returns>Comp�tition</returns>
        CompetitionRootObject GetCompetition(string id);
    }
}