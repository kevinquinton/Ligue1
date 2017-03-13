using System;

namespace Ligue1.AndroidCore.Entities
{
    /// <summary>
    /// Repr�sente une comp�tition
    /// </summary>
    public class Competition
    {
        /// <summary>
        /// Identifiant de la comp�tition
        /// </summary>
        private string _id;

        /// <summary>
        /// Nom de la comp�tition
        /// </summary>
        private string _caption;

        /// <summary>
        /// Identifiant de la ligue
        /// </summary>
        private string _league;

        /// <summary>
        /// Ann�e de la comp�tition
        /// </summary>
        private string _year;

        /// <summary>
        /// Journ�e de comp�tition
        /// </summary>
        private int _currentMatchday;

        /// <summary>
        /// Nombre total de journ�e de la comp�tition
        /// </summary>
        private int _numberOfMatchdays;

        /// <summary>
        /// Nombre d'�quipes dans la comp�tition
        /// </summary>
        private int _numberOfTeams;

        /// <summary>
        /// Nombre total de matchs jou�s au terme de la comp�tition
        /// </summary>
        private int _numberOfGames;

        /// <summary>
        /// Date de derni�re mise � jour
        /// </summary>
        private DateTime _lastUpdated;

        public string Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Caption
        {
            get
            {
                return _caption;
            }

            set
            {
                _caption = value;
            }
        }

        public string League
        {
            get
            {
                return _league;
            }

            set
            {
                _league = value;
            }
        }

        public string Year
        {
            get
            {
                return _year;
            }

            set
            {
                _year = value;
            }
        }

        public int CurrentMatchday
        {
            get
            {
                return _currentMatchday;
            }

            set
            {
                _currentMatchday = value;
            }
        }

        public int NumberOfMatchdays
        {
            get
            {
                return _numberOfMatchdays;
            }

            set
            {
                _numberOfMatchdays = value;
            }
        }

        public int NumberOfTeams
        {
            get
            {
                return _numberOfTeams;
            }

            set
            {
                _numberOfTeams = value;
            }
        }

        public int NumberOfGames
        {
            get
            {
                return _numberOfGames;
            }

            set
            {
                _numberOfGames = value;
            }
        }

        public DateTime LastUpdated
        {
            get
            {
                return _lastUpdated;
            }

            set
            {
                _lastUpdated = value;
            }
        }
    }
}