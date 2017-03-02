using System;
using System.Collections.Generic;
using Android.App;
using Ligue1.Models;
using Android.Content.Res;
using System.IO;
using Newtonsoft.Json;
using Ligue1.Services.Impl;
using Android.Util;

namespace Ligue1.AndroidCore.Services
{
    /// <summary>
    /// Mock du service <seealso cref="CompetitionFixturesService"/>
    /// pour debug sans connexion aux web-services
    /// </summary>
    public class CompetitionFixturesServiceMocker : ICompetitionFixturesServiceMocker
    {

        private Activity _activity;

        private static CompetitionFixturesServiceMocker _instance;

        private const string TAG = "CompetitionFixturesServicesMocker";

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="activity"></param>
        private CompetitionFixturesServiceMocker(Activity activity)
        {
            _activity = activity;
        }

        /// <summary>
        /// Singleton
        /// </summary>
        /// <param name="activity"></param>
        /// <returns></returns>
        public static CompetitionFixturesServiceMocker CompetitionFixturesServiceMockerSession(Activity activity)
        {
            if (_instance == null)
            {
                _instance = new CompetitionFixturesServiceMocker(activity);
            }
            return _instance;
        }

        /// <summary>
        /// Mock qui retourne les fixtures
        /// </summary>
        /// <returns></returns>
        public List<Fixture> GetFixtures()
        {
            Log.Info(TAG, "GetFixtures");

            List<Fixture> result = new List<Fixture>();

            try
            {
                FixturesRootObject ro = new FixturesRootObject();
                AssetManager assets = _activity.Assets;

                StreamReader sr = new StreamReader(assets.Open("fixtures.json"));
                string jsonString = sr.ReadToEnd();
                ro = JsonConvert.DeserializeObject<FixturesRootObject>(jsonString);

                result = ro.Fixtures;
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            return result;
        }

    }
}