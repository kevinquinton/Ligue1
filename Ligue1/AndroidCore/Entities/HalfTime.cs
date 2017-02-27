namespace Ligue1.Models
{
    /// <summary>
    /// Repr�sente le score d'une rencontre � la mi-temps
    /// </summary>
    public class HalfTime
    {
        /// <summary>
        /// Nombre de buts marqu�s par l'�quipe jouant � domicile
        /// </summary>
        private int _goalsHomeTeam;

        /// <summary>
        /// Nombre de buts marqu�s par l'�quipe jouant � l'ext�rieur
        /// </summary>
        private int _goalsAwayTeam;

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

    }
}