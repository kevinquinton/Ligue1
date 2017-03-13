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
    /// Activit� de la page d'accueil
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
        /// Liste de r�sultats
        /// </summary>
        private List<Fixture> fixtures;

        /// <summary>
        /// Service des r�sultats
        /// </summary>
        private ICompetitionFixturesService competitionFixturesService;

        /// <summary>
        /// Mock du service des r�sultats
        /// </summary>
        private ICompetitionFixturesServiceMocker competitionFixturesServiceMock;

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
        /// Chargement des derniers r�sultats
        /// </summary>
        /// <returns>Liset de <seealso cref="Fixture"/></returns>
        private async Task<List<Fixture>> LoadLastFixtures(bool debug)
        {
            Log.Debug(TAG, "LoadLastResults");        

            List<Fixture> result = new List<Fixture>();
            if (debug)
            {
                // r�cup�ration des derniers fixtures
                result = competitionFixturesServiceMock.GetFixtures();
            }
            else
            {
                // r�cup�ration du num�ro de la derni�re journ�e de championnat jou�
                var competition = await competitionService.GetCompetition(Url.LIGUE_1_COMPETITION_ID);
                var idCompetition = competition.Id;
                var matchDay = competition.CurrentMatchday;

                // r�cup�ration des derniers fixtures
                var fixtures = await competitionFixturesService.GetFixturesAsync(idCompetition, matchDay);
                result = fixtures;
            }

            return result;
        }

    }
}