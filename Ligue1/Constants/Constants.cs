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

namespace Ligue1.Constants
{
    public static class Constants
    {
        /// <summary>
        /// Url du web-service
        /// </summary>
        public const string URL_WEB_SERVICE = "http://api.football-data.org/v1/";

        /// <summary>
        /// Url des competions
        /// </summary>
        public const string URL_WEB_SERVICE_COMPETITIONS_FIXTURES = URL_WEB_SERVICE + "competitions /{0}/fixtures";

    }
}