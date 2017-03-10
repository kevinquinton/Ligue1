using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;
using Ligue1.AndroidCore.Entities;
using Ligue1.AndroidCore.Services.Impl;
using System.Net.Http;
using Ligue1.AndroidCore.Services;
using System.Threading.Tasks;
using Android.Util;
using Ligue1.AndroidCore.Constants;

namespace Ligue1.Activities
{
    /// <summary>
    /// Activité de la page d'accueil
    /// </summary>
    //[Activity(Label = "@string/ApplicationName")]
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/img_logo_ligue1")] // TODO A enlever
    public class HomeActivity : Activity
    {
        private ListView scoresList;
        private ScoreAdapter scoreAdapter;
        private List<Fixture> fixtures;
        private ICompetitionFixturesService service;
        private ICompetitionFixturesServiceMocker serviceMock;
        private HttpClient httpClient;
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
            service = CompetitionFixturesService.CompetitionFixturesServiceSession(httpClient);
            serviceMock = CompetitionFixturesServiceMocker.CompetitionFixturesServiceMockerSession(this);

            bool debug = true;
            fixtures = await LoadLastResults(debug);

            scoreAdapter = new ScoreAdapter(this, fixtures);
            scoresList.Adapter = scoreAdapter;
        }

        /// <summary>
        /// Chargement des derniers résultats
        /// </summary>
        /// <returns>Liset de <seealso cref="Fixture"/></returns>
        private async Task<List<Fixture>> LoadLastResults(bool debug)
        {
            Log.Debug(TAG, "LoadLastResults");

            List<Fixture> result = new List<Fixture>();

            // récupération des résultats avec web-service
            if (debug)
            {
                result = serviceMock.GetFixtures();
            }
            else
            {
                var fixtures = await service.GetFixturesAsync(Url.COMPETITION_ID_TEST);
                result = fixtures;
            }

            return result;
        }

    }
}