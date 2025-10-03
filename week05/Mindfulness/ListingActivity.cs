using System;
using System.Collections.Generic;

namespace Mindfulness
{
    public class ListingActivity : Activity
    {
        private int _count;
        private List<string> _prompts;

        public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
            _prompts = new List<string>()
            {
                "Who are people that you appreciate?",
                "What are personal strengths of yours?",
                "Who are people that you have helped this week?",
                "When have you felt the Holy Ghost this month?",
                "Who are some of your personal heroes?"
            };
        }

        public void Run()
        {
            DisplayStartingMessage();

            Console.WriteLine("List as many responses as you can to the following prompt:");
            string prompt = GetRandomPrompt();
            Console.WriteLine($"--- {prompt} ---");
            Console.WriteLine("You may begin in:");
            ShowCountDown(5);

            List<string> responses = GetListFromUser();

            Console.WriteLine($"You listed {responses.Count} items.");
            DisplayEndingMessage();
        }

        private string GetRandomPrompt()
        {
            Random random = new Random();
            int index = random.Next(_prompts.Count);
            return _prompts[index];
        }

        private List<string> GetListFromUser()
        {
            List<string> responses = new List<string>();
            DateTime endTime = DateTime.Now.AddSeconds(_duration);

            while (DateTime.Now < endTime)
            {
                string response = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(response))
                {
                    responses.Add(response);
                }
            }

            return responses;
        }
    }
}
