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
        
        public void GetTopicsInput(string? topic)
        {
            //apiController.GetTopics(topic);

            Console.WriteLine("\n\nSelect a topic:");
            string selection = Console.ReadLine();

            if (selection == "dwarf")
            {
                apiController.GetRace(topic, "Dwarf");
            }

            
        }        
    }
}
