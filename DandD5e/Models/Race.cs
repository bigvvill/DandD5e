using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandD5e.Models
{
    public class Race
    {
        public string name { get; set; }

    }

    public class Races
    {
        [JsonProperty("results")]

        public List<Race> RacesList { get; set; }
    }
}
