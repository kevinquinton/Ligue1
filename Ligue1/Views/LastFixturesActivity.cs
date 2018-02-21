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
    /// Activit� de la page d'accueil
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
        /// Liste de r�sultats
        /// </summary>
        private List<Fixture> fixtures;

        /// <summary>
        /// Service des r�sultats
        /// </summary>
        private IFixtureService fixtureService;

        /// <summary>
        /// Mock du service des r�sultats
        /// </summary>
        private IFixtureServiceMocker fixtureServiceMock;

        /// <summary>
        /// Service des comp�titions
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
        /// Chargement des derniers r�sultats
        /// </summary>
        /// <returns>Liste de <seealso cref="Fixture"/></returns>
        /// TODO Externaliser cette m�thode de l'activity
        private async Task<List<Fixture>> LoadLastFixtures(bool debug)
        {
            Log.Debug(TAG, "LoadLastResults");        

            List<Fixture> result = new List<Fixture>();
            if (debug)
            {
                // r�cup�ration des derniers fixtures
                result = fixtureServiceMock.GetFixtures();
            }
            else
            {
                // r�cup�ration du num�ro de la derni�re journ�e de championnat jou�

                var competition = await competitionService.GetCompetition(Url.LIGUE_1_COMPETITION_ID);
                var idCompetition = competition.Id;
                var matchDay = competition.CurrentMatchday;

                // r�cup�ration des derniers fixtures
                var fixtures = await fixtureService.GetFixturesAsync(idCompetition, matchDay);
                result = fixtures;
            }

            return result;
        }

    }
}