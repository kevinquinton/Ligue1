using System;

/// <summary>
/// Représente une rencontre de championnat
/// </summary>
namespace Ligue1.Models
{
    public class Fixture : EntityBase
    {
        /// <summary>
        /// Nom de l'équipe jouant à domicile
        /// </summary>
        private string _homeTeamName;

        /// <summary>
        /// Identifiant de l'équipe jouant à l'extérieur
        /// </summary>
        private string _awayTeamName;

        /// <summary>
        /// Date de la rencontre
        /// </summary>
        private DateTime _date;

        /// <summary>
        /// Numéro de la journée de championnat
        /// </summary>
        private int _matchday;

        /// <summary>
        /// Résultat de la rencontre
        /// </summary>
        private Score _result;

        // TODO Delete
        public Fixture(string homeTeamName, Score result)
        {
            _homeTeamName = homeTeamName;
            _result = result;
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

        public Score Score
        {
            get
            {
                return _result;
            }

            set
            {
                _result = value;
            }
        }

    }
}