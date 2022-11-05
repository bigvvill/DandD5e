using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandD5e.Models
{
    public class Manifest
    {
        public string type { get; set; }
    }

    public class Manifests
    {
        [JsonProperty("results")]

        public List<Manifest> ManifestList { get; set; }
    }
}
