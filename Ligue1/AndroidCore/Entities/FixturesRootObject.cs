using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ligue1.AndroidCore.Entities
{
    /// <summary>
    /// Représente un objet JSON conteneur des fixtures
    /// </summary>
    public class FixturesRootObject
    {
        [JsonProperty(PropertyName = "_links")]
        public object Links { get; set; }

        [JsonProperty(PropertyName = "fixtures")]
        public List<Fixture> Fixtures { get; set; }

        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }
    }
}