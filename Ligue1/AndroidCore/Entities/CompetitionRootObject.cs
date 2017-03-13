using System;
using Newtonsoft.Json;

namespace Ligue1.AndroidCore.Entities
{
    /// <summary>
    /// Repr�sente un objet JSON conteneur d'une comp�tition
    /// </summary>
    public class CompetitionRootObject
    {
        [JsonProperty(PropertyName = "_links")]
        public object Links { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "caption")]
        public string Caption { get; set; }

        [JsonProperty(PropertyName = "league")]
        public string League { get; set; }

        [JsonProperty(PropertyName = "year")]
        public string Year { get; set; }

        [JsonProperty(PropertyName = "currentMatchday")]
        public int CurrentMatchday { get; set; }

        [JsonProperty(PropertyName = "numberOfMatchdays")]
        public int NumberOfMatchdays { get; set; }

        [JsonProperty(PropertyName = "numberOfTeams")]
        public int NumberOfTeams { get; set; }

        [JsonProperty(PropertyName = "numberOfGames")]
        public int NumberOfGames { get; set; }

        [JsonProperty(PropertyName = "lastUpdated")]
        public DateTime LastUpdated { get; set; }
    }
}