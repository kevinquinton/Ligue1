using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Ligue1.AndroidCore.Constants;
using System.Threading;

namespace Ligue1.Activities
{
    /// <summary>
    /// Activité de chargement de l'application
    /// </summary>
    //[Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/img_logo_ligue1")] // TODO A enlever
    [Activity(Label = "@string/app_name", Icon = "@drawable/img_logo_ligue1")]
    public class SplashScreenActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.splash_screen);

            // gestion du thread
            Thread thread = new Thread(new ThreadStart(ThreadLoop));
            thread.Start();

            // passage à la page d'accueil
            Intent lastFixturesActivity = new Intent(this, typeof(LastFixturesActivity));
            StartActivity(lastFixturesActivity);
        }

        /// <summary>
        /// Boucle pour chargement de l'application
        /// </summary>
        private static void ThreadLoop()
        {
            while (Thread.CurrentThread.IsAlive)
            {
                Thread.Sleep(Constants.SPLASH_DURATION);
            }
        }

    }
}