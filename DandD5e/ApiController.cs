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
        public List<Topic> GetTopics(string? topic)
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

                Console.WriteLine("D&D 5e Reference\n");

                

                TableFormat.ShowTable(topics, $"{char.ToUpper(topic[0]) + topic.Substring(1)} Menu");
                return topics;
            }

            return topics;
        }

        public List<Manifest> GetManifest()
        {
            var client = new RestClient("https://api.open5e.com/manifest");
            var request = new RestRequest("?format=json");
            var response = client.ExecuteAsync(request);

            List<Manifest> manifestList = new List<Manifest>();

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<Manifests>(rawResponse);
                
                
                manifestList = serialize.ManifestList.GroupBy(x => x.type).Select(x => x.First()).ToList();

                Console.WriteLine("D&D 5e Reference\n");                

                TableFormat.ShowTable(manifestList, "D&D 5e Reference");
                return manifestList;
            }

            return manifestList;
        }

        public void GetDetail(string? topic, string? selection)
        {
            var client = new RestClient($"https://api.open5e.com/{topic}");
            var request = new RestRequest("?format=json");
            var response = client.ExecuteAsync(request);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<TopicDetails>(rawResponse);

                List<TopicDetail> topicList = serialize.TopicDetailList;   
                
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

                    }


                }

                Console.WriteLine();
                Console.ReadLine();
            }
        }


    }
}
