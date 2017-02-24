using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Ligue1.Models;

namespace Ligue1.Activities
{
    //[Activity(Label = "@string/ApplicationName")]
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/img_logo_ligue1")] // TODO A enlever
    public class HomeActivity : Activity
    {
        private ListView scoresList;
        private string[] items;
        private ArrayAdapter<string> adapter;
        private ScoreAdapter scoreAdapter;
        private List<Fixture> fixtures;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.home);
            scoresList = (ListView)FindViewById(Resource.Id.scoreView);

            //items = new string[] { "Vegetables", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Tubers" };
            //adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, items);

            //scoresList.Adapter = adapter;
            fixtures = LoadData();
            scoreAdapter = new ScoreAdapter(this, fixtures);
        }

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