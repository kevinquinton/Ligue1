using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ligue1.Models
{
    /// <summary>
    /// Représente un objet JSON conteneur des fixtures
    /// </summary>
    class FixturesRootObject
    {
        public List<object> html_attributions { get; set; }

        [JsonProperty(PropertyName = "fixtures")]
        public List<Fixture> Fixtures { get; set; }

        public string status { get; set; }
    }
}