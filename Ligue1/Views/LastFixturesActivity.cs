using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;
using Ligue1.AndroidCore.Entities;
using System.Net.Http;
using System.Threading.Tasks;
using Android.Util;
using Ligue1.AndroidCore.Constants;
using Ligue1.AndroidCore.Services.CompetitionService;
using Ligue1.AndroidCore.Services.CompetitionService.Impl;
using Android.Content.PM;
using Ligue1.AndroidCore.Services.FixtureService;
using Ligue1.AndroidCore.Services.FixtureService.Impl;

namespace Ligue1.Activities
{
    /// <summary>
    /// Activité de la page d'accueil
    /// </summary>
    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/img_logo_ligue1", ConfigurationChanges = ConfigChanges.Locale)]
    public class LastFixturesActivity : Activity
    {
        /// <summary>
        /// 
        /// </summary>
        private ListView scoresList;

        /// <summary>
        /// Adapter custom
        /// </summary>
        private ScoreAdapter scoreAdapter;

        /// <summary>
        /// Liste de résultats
        /// </summary>
        private List<Fixture> fixtures;

        /// <summary>
        /// Service des résultats
        /// </summary>
        private IFixtureService fixtureService;

        /// <summary>
        /// Mock du service des résultats
        /// </summary>
        private IFixtureServiceMocker fixtureServiceMock;

        /// <summary>
        /// Service des compétitions
        /// </summary>
        private ICompetitionService competitionService;

        /// <summary>
        /// Client http
        /// </summary>          
        private HttpClient httpClient;

        /// <summary>
        /// Tag pour logger
        /// </summary>
        private const string TAG = "LastFixturesActivity";

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.home);
            scoresList = (ListView)FindViewById(Resource.Id.scoreView);

            if (httpClient == null)
            {
                httpClient = new HttpClient();
            }

            // instanciation du service responsable des fixtures
            fixtureService = FixtureService.CompetitionFixturesServiceSession(httpClient);
            fixtureServiceMock = FixtureServiceMocker.FixtureServiceMockerSession(this);
            competitionService = CompetitionService.CompetitionServiceSession(httpClient);

            bool debug = true; // TODO A enlever
            fixtures = await LoadLastFixtures(debug);

            scoreAdapter = new ScoreAdapter(this, fixtures);
            scoresList.Adapter = scoreAdapter;
        }

        /// <summary>
        /// Chargement des derniers résultats
        /// </summary>
        /// <returns>Liste de <seealso cref="Fixture"/></returns>
        /// TODO Externaliser cette méthode de l'activity
        private async Task<List<Fixture>> LoadLastFixtures(bool debug)
        {
            Log.Debug(TAG, "LoadLastResults");        

            List<Fixture> result = new List<Fixture>();
            if (debug)
            {
                // récupération des derniers fixtures
                result = fixtureServiceMock.GetFixtures();
            }
            else
            {
                // récupération du numéro de la dernière journée de championnat joué

                var competition = await competitionService.GetCompetition(Url.LIGUE_1_COMPETITION_ID);
                var idCompetition = competition.Id;
                var matchDay = competition.CurrentMatchday;

                // récupération des derniers fixtures
                var fixtures = await fixtureService.GetFixturesAsync(idCompetition, matchDay);
                result = fixtures;
            }

            return result;
        }

    }
}