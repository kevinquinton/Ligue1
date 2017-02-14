using System.Collections.Generic;

/// <summary>
/// Résultats de la journée
/// </summary>
namespace Ligue1.Entities
{
    public class Result : EntityBase
    {
        /// <summary>
        /// Liste des matchs de la journée
        /// </summary>
        private List<Match> _matchs;

        public List<Match> Matchs
        {
            get
            {
                return _matchs;
            }

            set
            {
                _matchs = value;
            }
        }
    }
}