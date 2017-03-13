using System;
using Android.App;
using Ligue1.AndroidCore.Entities;
using Android.Content.Res;
using System.IO;
using Newtonsoft.Json;
using Android.Util;

namespace Ligue1.AndroidCore.Services.CompetitionService.Mock
{
    /// <summary>
    /// Mock du service <seealso cref="CompetitionService"/>
    /// pour debug sans connexion aux web-services
    /// </summary>
    public class CompetitionServiceMocker : ICompetitionServiceMocker
    {
        /// <summary>
        /// Activity courrante
        /// </summary>
        private Activity _activity;

        /// <summary>
        /// Singleton
        /// </summary>
        private static CompetitionServiceMocker _instance;

        /// <summary>
        /// Tag pour logger
        /// </summary>
        private const string TAG = "CompetitionServiceMocker";

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="activity"></param>
        private CompetitionServiceMocker(Activity activity)
        {
            _activity = activity;
        }

        /// <summary>
        /// Singleton
        /// </summary>
        /// <param name="activity"></param>
        /// <returns></returns>
        public static CompetitionServiceMocker CompetitionServiceMockerSession(Activity activity)
        {
            if (_instance == null)
            {
                _instance = new CompetitionServiceMocker(activity);
            }
            return _instance;
        }

        /// <summary>
        /// Récupère une compétition par son identifiant
        /// </summary>
        /// <returns>Compétition</returns>
        public CompetitionRootObject GetCompetition()
        {
            Log.Debug(TAG, "GetFixtures");

            CompetitionRootObject result = null;

            try
            {
                AssetManager assets = _activity.Assets;

                StreamReader sr = new StreamReader(assets.Open("competition.json"));
                string jsonString = sr.ReadToEnd();
                result = JsonConvert.DeserializeObject<CompetitionRootObject>(jsonString);
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            return result;
        }
    }
}