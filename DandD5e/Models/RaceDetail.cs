using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandD5e.Models
{
    internal class RaceDetail : Topic
    {        
        public string desc { get; set; }
        public string asi_desc { get; set; }
        public string age { get; set; }
        public string speed_desc { get; set; }
        public string size { get; set; }
        public string languages { get; set; }
        public string traits { get; set; }
    }

    internal class RaceDetails
    {
        [JsonProperty("results")]

        public List<RaceDetail> RaceDetailList { get; set; }
    }
}
