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
        public void GetTopics(string? topic)
        {
            var client = new RestClient($"https://api.open5e.com/{topic}");
            var request = new RestRequest("?format=json");
            var response = client.ExecuteAsync(request);

            List<Topic> topics = new List<Topic>();

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<Topics>(rawResponse);

                topics = serialize.TopicsList;                      

                TableFormat.ShowTable(topics, $"{char.ToUpper(topic[0]) + topic.Substring(1)} Menu");

                GetUserInput getUserInput = new GetUserInput();
                getUserInput.GetTopicsInput(topic);               
            }            
        }        

        public void GetRace(string? topic, string? selection)
        {
            var client = new RestClient($"https://api.open5e.com/{topic}");
            var request = new RestRequest("?format=json");
            var response = client.ExecuteAsync(request);

            bool validRace = false;

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<RaceDetails>(rawResponse);

                List<RaceDetail> topicList = serialize.RaceDetailList;   
                
                Console.Clear();

                foreach (var currentTopic in topicList)
                {
                    if (currentTopic.name.ToString() == selection)
                    {
                        Console.WriteLine(currentTopic.name.ToString());
                        Console.WriteLine("\n" + currentTopic.desc.ToString());
                        Console.WriteLine("\n" + currentTopic.asi_desc.ToString());
                        Console.WriteLine("\n" + currentTopic.age.ToString());
                        Console.WriteLine("\n" + currentTopic.speed_desc.ToString());
                        Console.WriteLine("\n" + currentTopic.size.ToString());
                        Console.WriteLine("\n" + currentTopic.languages.ToString());
                        Console.WriteLine("\n" + currentTopic.traits.ToString());
                        validRace = true;
                    }
                }

                if (!validRace)
                {
                    Console.WriteLine("Please enter a valid Race. Press Enter...");
                    Console.ReadLine();

                    GetUserInput getUserInput = new GetUserInput();
                    GetTopics(topic);
                }

                Console.WriteLine("\nPress Enter...");
                Console.ReadLine();

                GetTopics(topic);
            }
        }

        public void GetBackground(string? topic, string? selection)
        {
            var client = new RestClient($"https://api.open5e.com/{topic}");
            var request = new RestRequest("?format=json");
            var response = client.ExecuteAsync(request);

            bool validBackground = false;

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<BackgroundDetails>(rawResponse);

                List<BackgroundDetail> topicList = serialize.BackgroundDetailList;

                Console.Clear();

                foreach (var currentTopic in topicList)
                {
                    if (currentTopic.name.ToString() == selection)
                    {
                        Console.WriteLine(currentTopic.name.ToString());
                        Console.WriteLine("\n" + currentTopic.desc.ToString());
                        Console.WriteLine("\n" + currentTopic.skill_proficiencies.ToString());
                        Console.WriteLine("\n" + currentTopic.equipment.ToString());
                        Console.WriteLine("\n" + currentTopic.feature.ToString());
                        Console.WriteLine("\n" + currentTopic.feature_desc.ToString());  
                        validBackground = true;
                    }
                }

                if (!validBackground)
                {
                    Console.WriteLine("Please enter a valid Background. Press Enter...");
                    Console.ReadLine();

                    GetUserInput getUserInput = new GetUserInput();
                    GetTopics(topic);
                }

                Console.WriteLine("\nPress Enter...");
                Console.ReadLine();

                GetTopics(topic);
            }
        }

        public void GetClass(string? topic, string? selection)
        {
            var client = new RestClient($"https://api.open5e.com/{topic}");
            var request = new RestRequest("?format=json");
            var response = client.ExecuteAsync(request);

            bool validClass = false;

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {                
                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<ClassDetails>(rawResponse);

                List<ClassDetail> topicList = serialize.ClassDetailList;

                foreach (var currentTopic in topicList)
                {
                    if (currentTopic.name.ToString() == selection)
                    {
                        Console.WriteLine(currentTopic.name.ToString());
                        Console.WriteLine("\n" + currentTopic.desc.ToString());
                        Console.WriteLine("\n" + currentTopic.hit_dice.ToString());
                        Console.WriteLine("\n" + currentTopic.hp_at_1st_level.ToString());
                        Console.WriteLine("\n" + currentTopic.hp_at_higher_levels.ToString());
                        Console.WriteLine("\n" + currentTopic.prof_armor.ToString());
                        Console.WriteLine("\n" + currentTopic.prof_weapons.ToString());
                        Console.WriteLine("\n" + currentTopic.prof_saving_throws.ToString());
                        Console.WriteLine("\n" + currentTopic.prof_skills.ToString());
                        Console.WriteLine("\n" + currentTopic.equipment.ToString());
                        Console.WriteLine("\n" + currentTopic.table.ToString());
                        Console.WriteLine("\n" + currentTopic.spellcasting_ability.ToString());
                        validClass = true;
                    }
                }

                if (!validClass)
                {
                    Console.WriteLine("Please enter a valid Class. Press Enter...");
                    Console.ReadLine();

                    GetUserInput getUserInput = new GetUserInput();
                    GetTopics(topic);
                }

                Console.WriteLine("\nPress Enter...");
                Console.ReadLine();

                GetTopics(topic);
            }
        }
    }
}
