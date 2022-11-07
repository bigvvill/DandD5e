using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandD5e.Models
{
    internal class ClassDetail : Topic
    {
        public string desc { get; set; }
        public string hit_dice { get; set; }
        public string hp_at_1st_level { get; set; }
        public string hp_at_higher_levels { get; set; }
        public string prof_armor { get; set; }
        public string prof_weapons { get; set; }
        public string prof_saving_throws { get; set; }
        public string prof_skills { get; set; }
        public string equipment { get; set; }
        public string table { get; set; }
        public string spellcasting_ability { get; set; }        
    }

    internal class ClassDetails
    {
        [JsonProperty("results")]

        public List<ClassDetail> ClassDetailList { get; set; }
    }
}
