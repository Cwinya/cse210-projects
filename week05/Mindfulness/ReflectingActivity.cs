using System;
using System.Collections.Generic;

namespace Mindfulness
{
    public class ReflectingActivity : Activity
    {
        private List<string> _prompts;
        private List<string> _questions;

        public ReflectingActivity() : base("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
        {
            _prompts = new List<string>()
            {
                "Think of a time when you stood up for someone else.",
                "Think of a time when you did something really difficult.",
                "Think of a time when you helped someone in need.",
                "Think of a time when you did something truly selfless."
            };

            _questions = new List<string>()
            {
                "Why was this experience meaningful to you?",
                "Have you ever done anything like this before?",
                "How did you get through the difficult time?",
                "What did you learn about yourself through this experience?",
                "How can you apply what you learned to other situations?"
            };
        }

        public void Run()
        {
            DisplayStartingMessage();

            DisplayPrompt();

            Console.WriteLine("When you have something in mind, press enter to continue.");
            Console.ReadLine();

            DisplayQuestions();

            DisplayEndingMessage();
        }

        private string GetRandomPrompt()
        {
            Random random = new Random();
            int index = random.Next(_prompts.Count);
            return _prompts[index];
        }

        private string GetRandomQuestion()
        {
            Random random = new Random();
            int index = random.Next(_questions.Count);
            return _questions[index];
        }

        private void DisplayPrompt()
        {
            string prompt = GetRandomPrompt();
            Console.WriteLine($"--- {prompt} ---");
        }

        private void DisplayQuestions()
        {
            DateTime endTime = DateTime.Now.AddSeconds(_duration);
            while (DateTime.Now < endTime)
            {
                string question = GetRandomQuestion();
                Console.WriteLine($"> {question}");
                ShowSpinner(10);
                Console.WriteLine();
            }
        }
    }
}
