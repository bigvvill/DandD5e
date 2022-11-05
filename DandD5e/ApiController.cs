using DandD5e.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandD5e
{
    internal class ApiController
    {
        public List<Race> GetRaces()
        {
            var client = new RestClient("https://api.open5e.com/races");
            var request = new RestRequest("?format=json");
            var response = client.ExecuteAsync(request);

            List<Race> races = new List<Race>();

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<Races>(rawResponse);

                races = serialize.RacesList;

                TableFormat.ShowTable(races, "Race Menu");
                return races;
            }

            return races;
        }

        public List<Manifest> GetManifest()
        {
            var client = new RestClient("https://api.open5e.com/manifest");
            var request = new RestRequest("?format=json");
            var response = client.ExecuteAsync(request);

            List<Manifest> manifestlist = new List<Manifest>();

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<Manifests>(rawResponse);
                
                manifestlist = serialize.ManifestList;  

                TableFormat.ShowTable(manifestlist, "Manifest");
                return manifestlist;
            }

            return manifestlist;
        }
    }
}
