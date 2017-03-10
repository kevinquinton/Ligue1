using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace Ligue1.AndroidCore.Helpers
{
    public static class HttpClientExtensions
    {
        /// <summary>
        /// R�cup�re une liste d'objets selon une requ�te ex�cut�e en mode asynchrone
        /// </summary>
        /// <typeparam name="T">type de l'objet souhait�</typeparam>
        /// <param name="client">client http</param>
        /// <param name="url">url du web service</param>
        /// <returns>Liste d'objets</returns>
        public static async Task<T> GetAsync<T>(this HttpClient client, string url)
        {
            var httpRequest = new HttpRequestMessage(new HttpMethod("GET"), url);

            client.Timeout = TimeSpan.FromSeconds(30);

            var response = await client.SendAsync(httpRequest);

            var jsonString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(jsonString);

            return result;
        }

        /// <summary>
        /// R�cup�re en convertissant en chaine de caract�res le JSON retourn�
        /// par l'ex�c
        /// </summary>
        /// <param name="client">client http</param>
        /// <param name="url">url du web service</param>
        /// <returns>Chaine de caract�res repr�sentant le r�sultat de la requ�te</returns>
        public static async Task<string> GetStringAsync(this HttpClient client, string url)
        {
            var httpRequest = new HttpRequestMessage(new HttpMethod("GET"), url);

            var response = client.SendAsync(httpRequest).Result;

            var jsonString = await response.Content.ReadAsStringAsync();

            return jsonString;
        }

    }
}