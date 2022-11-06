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

                Console.WriteLine("D&D 5e Reference\n");                

                TableFormat.ShowTable(topics, $"{char.ToUpper(topic[0]) + topic.Substring(1)} Menu");

                GetUserInput getUserInput = new GetUserInput();
                getUserInput.GetTopicsInput(topic);
               
            }

            
        }

        public void GetManifest()
        {

            Console.WriteLine("Welcome to the D&D 5e Character Helper!\n");
            Console.WriteLine("This app provides information on Races and Classes you can choose for your new character.\n\n");
            Console.WriteLine("Would you like to read about:");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - Races");
            Console.WriteLine("2 - Classes");
            Console.WriteLine("3 - Backgrounds");

            string myTopic = Console.ReadLine();

            switch (myTopic)
            {
                case "0":
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                    break;
                case "1":
                    GetTopics("races");
                    break;
                case "2":
                    GetTopics("classes");
                    break;
                case "3":
                    GetTopics("backgrounds");
                    break;
            }            
        }

        public void GetRace(string? topic, string? selection)
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

                GetTopics(topic);
            }
        }


    }
}
