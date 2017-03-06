namespace Ligue1.AndroidCore.Constants
{
    /// <summary>
    /// Url d'appel aux web-services de l'application
    /// </summary>
    public static class Url
    {
        /// <summary>
        /// Url du web-service
        /// </summary>
        public const string URL_WEB_SERVICE = "http://api.football-data.org/v1/";

        /// <summary>
        /// Url des competions
        /// </summary>
        public const string URL_WEB_SERVICE_COMPETITIONS_FIXTURES = URL_WEB_SERVICE + "competitions/{0}/fixtures";

        // TODO TO DELETE
        public const string COMPETITION_ID_TEST = "434";
    }
}