using System;

namespace Ligue1.Entities
{
    /// <summary>
    /// Match
    /// </summary>
    public class Match : EntityBase
    {
        /// <summary>
        /// Identifiant de l'équipe jouant à domicile
        /// </summary>
        private string _homeTeamId;

        /// <summary>
        /// Nom de l'équipe jouant à domicile
        /// </summary>
        private string _homeTeamName;

        /// <summary>
        /// Identifiant de l'équipe jouant à l'extérieur
        /// </summary>
        private string _awayTeamId;

        /// <summary>
        /// Identifiant de l'équipe jouant à l'extérieur
        /// </summary>
        private string _awayTeamName;

        /// <summary>
        /// Nombre de buts marqués par l'équipe jouant à domicile
        /// </summary>
        private int _goalsHomeTeam;

        /// <summary>
        /// Nombre de buts marqués par l'équipe jouant à l'extérieur
        /// </summary>
        private int _goalsAwayTeam;

        /// <summary>
        /// Date de la rencontre
        /// </summary>
        private DateTime _date;

        public string HomeTeamId
        {
            get
            {
                return _homeTeamId;
            }

            set
            {
                _homeTeamId = value;
            }
        }

        public string HomeTeamName
        {
            get
            {
                return _homeTeamName;
            }

            set
            {
                _homeTeamName = value;
            }
        }

        public string AwayTeamId
        {
            get
            {
                return _awayTeamId;
            }

            set
            {
                _awayTeamId = value;
            }
        }

        public string AwayTeamName
        {
            get
            {
                return _awayTeamName;
            }

            set
            {
                _awayTeamName = value;
            }
        }

        public int GoalsHomeTeam
        {
            get
            {
                return _goalsHomeTeam;
            }

            set
            {
                _goalsHomeTeam = value;
            }
        }

        public int GoalsAwayTeam
        {
            get
            {
                return _goalsAwayTeam;
            }

            set
            {
                _goalsAwayTeam = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return _date;
            }

            set
            {
                _date = value;
            }
        }
    }
}