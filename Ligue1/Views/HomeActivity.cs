using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;
using Ligue1.Models;
using Ligue1.Services.Impl;
using System.Net.Http;
using Ligue1.Services;
using System.Threading.Tasks;

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
        private HttpClient httpClient;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.home);
            scoresList = (ListView)FindViewById(Resource.Id.scoreView);

            // instanciation du service responsable des fixtures
            if (httpClient == null)
            {
                httpClient = new HttpClient();
            }
            if (service == null)
            {
                service = new CompetitionFixturesService(httpClient);
            }

            fixtures = LoadData();
            scoreAdapter = new ScoreAdapter(this, fixtures);
            scoresList.Adapter = scoreAdapter;
        }

        /// <summary>
        /// Chargement des données de résultats
        /// </summary>
        /// <returns>Liset de <seealso cref="Fixture"/></returns>
        private List<Fixture> LoadData()
        {
            List<Fixture> result = new List<Fixture>();

            // TODO Bouchons de données
            //Score s1 = new Score(4, 0);
            //Fixture f1 = new Fixture("Paris", "Barcelone", s1);
            //result.Add(f1);

            // récupération des résultats avec web-service
            Task<List<Fixture>> fixtures = service.GetFixtures(Constants.Constants.COMPETITION_ID_TEST);
            result = fixtures.Result;

            return result;
        }

        
    }
}