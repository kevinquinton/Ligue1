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
using Ligue1.AndroidCore.Services.CompetitionService.Mock;

namespace Ligue1.Activities
{
    /// <summary>
    /// Activité de la page d'accueil
    /// </summary>
    //[Activity(Label = "@string/ApplicationName")]
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/img_logo_ligue1")] // TODO A enlever
    public class HomeActivity : Activity
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
        private ICompetitionFixturesService competitionFixturesService;

        /// <summary>
        /// Mock du service des résultats
        /// </summary>
        private ICompetitionFixturesServiceMocker competitionFixturesServiceMock;

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
        private const string TAG = "HomeActivity";

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
            competitionFixturesService = CompetitionFixturesService.CompetitionFixturesServiceSession(httpClient);
            competitionFixturesServiceMock = CompetitionFixturesServiceMocker.CompetitionFixturesServiceMockerSession(this);
            competitionService = CompetitionService.CompetitionServiceSession(httpClient);

            bool debug = false;
            fixtures = await LoadLastFixtures(debug);

            scoreAdapter = new ScoreAdapter(this, fixtures);
            scoresList.Adapter = scoreAdapter;
        }

        /// <summary>
        /// Chargement des derniers résultats
        /// </summary>
        /// <returns>Liset de <seealso cref="Fixture"/></returns>
        private async Task<List<Fixture>> LoadLastFixtures(bool debug)
        {
            Log.Debug(TAG, "LoadLastResults");        

            List<Fixture> result = new List<Fixture>();
            if (debug)
            {
                // récupération des derniers fixtures
                result = competitionFixturesServiceMock.GetFixtures();
            }
            else
            {
                // récupération du numéro de la dernière journée de championnat joué
                var competition = await competitionService.GetCompetition(Url.LIGUE_1_COMPETITION_ID);
                var idCompetition = competition.Id;
                var matchDay = competition.CurrentMatchday;

                // récupération des derniers fixtures
                var fixtures = await competitionFixturesService.GetFixturesAsync(idCompetition, matchDay);
                result = fixtures;
            }

            return result;
        }

    }
}