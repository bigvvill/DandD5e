using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandD5e.Models
{
    public class Topic
    {
        public string name { get; set; }

    }

    public class Topics
    {
        [JsonProperty("results")]

        public List<Topic> TopicsList { get; set; }
    }
}
