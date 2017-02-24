namespace Ligue1.Models
{
    /// <summary>
    /// Repr�sente le score d'une rencontre
    /// </summary>
    public class Score
    {
        /// <summary>
        /// Nombre de buts marqu�s par l'�quipe jouant � domicile
        /// </summary>
        private int _goalsHomeTeam;

        /// <summary>
        /// Nombre de buts marqu�s par l'�quipe jouant � l'ext�rieur
        /// </summary>
        private int _goalsAwayTeam;

        /// <summary>
        /// Score � la mi-temps
        /// </summary>
        private HalfTime _halfTime;

        //TODO Delete
        public Score(int goalsHomeTeam)
        {
            _goalsHomeTeam = goalsHomeTeam;
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

        public HalfTime HalfTime
        {
            get
            {
                return _halfTime;
            }

            set
            {
                _halfTime = value;
            }
        }
    }
}