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

        internal void GetManifestInput()
        {
            var manifestList = apiController.GetManifest();

            Console.WriteLine("Select a topic:");
            string topic = Console.ReadLine();

            GetTopicsInput(topic);
        }

        private void GetTopicsInput(string? topic)
        {
            var topics = apiController.GetTopics(topic);
        }
    }
}
