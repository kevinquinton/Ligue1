using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ligue1.Models
{
    class FixturesRootObject
    {
        public List<object> html_attributions { get; set; }

        [JsonProperty(PropertyName = "fixtures")]
        public List<Fixture> Fixtures { get; set; }

        public string status { get; set; }
    }
}