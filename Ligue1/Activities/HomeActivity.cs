using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;
using Ligue1.Models;

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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.home);
            scoresList = (ListView)FindViewById(Resource.Id.scoreView);

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
            // TODO Bouchons de données
            List<Fixture> result = new List<Fixture>();
            Score s1 = new Score(4);
            Fixture f1 = new Fixture("Paris", s1);
            result.Add(f1);

            return result;
        }

        
    }
}