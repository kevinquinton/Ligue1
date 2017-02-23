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
using System.Threading;

namespace Ligue1.Activities
{
    [Activity(Label = "Ligue1", MainLauncher = true, Icon = "@drawable/img_logo_ligue1")]
    public class LoadingActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.loading);

            Thread thread = new Thread(new ThreadStart(ThreadLoop));
            thread.Start();

            // Passage à la page d'accueil
            Intent mainActivity = new Intent(this, typeof(MainActivity));
            StartActivity(mainActivity);
        }

        /// <summary>
        /// Gestion du thread
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