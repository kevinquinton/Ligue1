using System;
using System.Collections.Generic;
using Android.App;
using Ligue1.AndroidCore.Entities;
using Android.Content.Res;
using System.IO;
using Newtonsoft.Json;
using Android.Util;

namespace Ligue1.AndroidCore.Services.FixtureService
{
    /// <summary>
    /// Mock du service <seealso cref="FixtureService"/>
    /// pour debug sans connexion aux web-services
    /// </summary>
    public class FixtureServiceMocker : IFixtureServiceMocker
    {
        /// <summary>
        /// Activity courrante
        /// </summary>
        private Activity _activity;

        /// <summary>
        /// Singleton
        /// </summary>
        private static FixtureServiceMocker _instance;

        /// <summary>
        /// Tag pour logger
        /// </summary>
        private const string TAG = "CompetitionFixturesServicesMocker";

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="activity"></param>
        private FixtureServiceMocker(Activity activity)
        {
            _activity = activity;
        }

        /// <summary>
        /// Singleton
        /// </summary>
        /// <param name="activity"></param>
        /// <returns></returns>
        public static FixtureServiceMocker FixtureServiceMockerSession(Activity activity)
        {
            if (_instance == null)
            {
                _instance = new FixtureServiceMocker(activity);
            }
            return _instance;
        }

        /// <summary>
        /// Mock qui retourne les fixtures
        /// </summary>
        /// <returns></returns>
        public List<Fixture> GetFixtures()
        {
            Log.Debug(TAG, "GetFixtures");

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