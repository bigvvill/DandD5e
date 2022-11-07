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

        public void GetManifest()
        {
            Console.Clear();

            Console.WriteLine("Welcome to the D&D 5e Character Helper!\n");
            Console.WriteLine("This app provides information on Backgrounds, Races, and Classes you can choose for your new character.\n\n");
            Console.WriteLine("Would you like to read about:");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - Backgrounds");
            Console.WriteLine("2 - Races");
            Console.WriteLine("3 - Classes");

            string myTopic = Console.ReadLine();

            switch (myTopic)
            {
                case "0":
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                    break;
                case "1":
                    apiController.GetTopics("backgrounds");
                    break;
                case "2":
                    apiController.GetTopics("races");
                    break;
                case "3":
                    apiController.GetTopics("classes");
                    break;
                default:
                    Console.WriteLine("Please make a valid choice, 0-3! Press Enter...");
                    Console.ReadLine();
                    GetManifest();
                    break;
            }
        }

        public void GetTopicsInput(string? topic)
        {
            Console.WriteLine("\nEnter topic or 0 to go back to Menu:");
            string selection = Console.ReadLine();

            if (string.IsNullOrEmpty(selection))
            {
                Console.WriteLine("Please enter a valid topic. Press Enter...");
                Console.ReadLine();

                ApiController apiController = new ApiController();
                apiController.GetTopics(topic);
            }

            selection = char.ToUpper(selection[0]) + selection.Substring(1);

            while (selection != "0")
            {
                if (topic == "backgrounds")
                {
                    apiController.GetBackground(topic, selection);
                }

                else if (topic == "races")
                {
                    apiController.GetRace(topic, selection);
                }

                else if (topic == "classes")
                {
                    Console.Clear();
                    apiController.GetClass(topic, selection);
                }

                else
                {
                    Console.WriteLine("Please enter a valid topic:");
                    selection = Console.ReadLine();
                }
            }            

            GetManifest();


        }        
    }
}
