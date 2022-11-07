using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandD5e.Models
{
    internal class BackgroundDetail : Topic
    {
        public string desc { get; set; }
        public string skill_proficiencies { get; set; }
        public string equipment { get; set; }
        public string feature { get; set; }
        public string feature_desc { get; set; }
    }

    internal class BackgroundDetails
    {
        [JsonProperty("results")]

        public List<BackgroundDetail> BackgroundDetailList { get; set; }
    }
}
