using Android.App;
using Android.Content;
using Android.OS;
using System.Threading;

namespace Ligue1.Activities
{
    /// <summary>
    /// Activité de chargement de l'application
    /// </summary>
    //[Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/img_logo_ligue1")] // TODO A enlever
    [Activity(Label = "@string/ApplicationName", Icon = "@drawable/img_logo_ligue1")]
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
            Intent homeActivity = new Intent(this, typeof(HomeActivity));
            StartActivity(homeActivity);
        }

        /// <summary>
        /// Boucle pour chargement de l'application
        /// </summary>
        private static void ThreadLoop()
        {
            while (Thread.CurrentThread.IsAlive)
            {
                Thread.Sleep(1500);
            }
        }

    }
}