using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandD5e
{
    public class GetUserInput
    {
        ApiController apiController = new ApiController();

        public void GetManifestInput()
        {
            var manifestList = apiController.GetManifest();

            Console.WriteLine("\n\nSelect a topic:");
            string manifest = Console.ReadLine();

            GetTopicsInput(manifest);
        }

        public void GetTopicsInput(string? topic)
        {
            var topics = apiController.GetTopics(topic);

            Console.WriteLine("\n\nSelect a topic:");
            string selection = Console.ReadLine();

            apiController.GetRace(topic, selection);
        }

        //private void GetTopicDetails(string? topic, string? selection)
        //{
        //    apiController.GetDetail(topic, selection);
        //}
    }
}
