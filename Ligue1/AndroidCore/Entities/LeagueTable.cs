using System.Collections.Generic;

namespace Ligue1.AndroidCore.Entities
{
    /// <summary>
    /// Informations sur la ligue
    /// </summary>
    public class LeagueTable
    {
        /// <summary>
        /// Nom de la comp�tition
        /// </summary>
        private string _leagueCaption;

        /// <summary>
        /// Num�ro de la journ�e
        /// </summary>
        private int _matchDay;

        /// <summary>
        /// Liste des �quipes participantes � la comp�tition
        /// </summary>
        private List<Team> _teams;

        public string LeagueCaption
        {
            get
            {
                return _leagueCaption;
            }

            set
            {
                _leagueCaption = value;
            }
        }

        public int MatchDay
        {
            get
            {
                return _matchDay;
            }

            set
            {
                _matchDay = value;
            }
        }

        public List<Team> Teams
        {
            get
            {
                return _teams;
            }

            set
            {
                _teams = value;
            }
        }
    }
}