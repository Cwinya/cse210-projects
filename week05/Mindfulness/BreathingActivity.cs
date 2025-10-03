// I added a program that allow the text in the animation
// Adding more meaningful animations for the breathing (such as text that grows out quickly at first and then slows as they near the end of the breath).
using System;

namespace Mindfulness
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {
        }

        public void Run()
        {
            DisplayStartingMessage();

            int breathInSeconds = 4;
            int breathOutSeconds = 6;
            int totalTime = 0;

            while (totalTime < _duration)
            {
                AnimateBreath("Breathe in...", breathInSeconds);
                AnimateBreath("Breathe out...", breathOutSeconds);

                totalTime += breathInSeconds + breathOutSeconds;
            }

            DisplayEndingMessage();
        }

        private void AnimateBreath(string action, int duration)
        {
            Console.WriteLine(action);
            int steps = 20;
            double[] delays = new double[steps];
            double totalDelay = 0;

            // Create delays that start short and get longer (slowing down)
            for (int i = 0; i < steps; i++)
            {
                delays[i] = 50 + (i * i * 10); // quadratic increase in delay
                totalDelay += delays[i];
            }

            // Normalize delays to match total duration in milliseconds
            double scale = (duration * 1000) / totalDelay;
            for (int i = 0; i < steps; i++)
            {
                delays[i] = delays[i] * scale;
            }

            string baseText = ".";
            for (int i = 0; i < steps; i++)
            {
                Console.Write(baseText.PadRight(i + 1));
                System.Threading.Thread.Sleep((int)delays[i]);
                Console.Write(new string('\b', i + 1));
            }
            Console.WriteLine();
        }
    }
}
