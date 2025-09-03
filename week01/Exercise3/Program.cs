using System;

class Program
{
    static void Main(string[] args)
    {

        /*Console.WriteLine("Hello World! This is the Exercise3 Project.");
        Console.Write("What is your guess: ");
        string userGuess = Console.ReadLine();
        int userGuessNum = int.Parse(userGuess);

        if (userGuessNum == magicNum)
        {
            Console.WriteLine("You guessed it!");
        }
        else if (userGuessNum < magicNum)
        {
            Console.WriteLine("Higher");
        }
        else
        {
            Console.WriteLine("Lower");
        }
        */

        Random random = new Random();
        int magicNum = random.Next(1, 101);

        int userGuessNum = 0;
        int guessCount = 0;
        do
        {
            Console.Write("What is your guess: ");
            string userGuess = Console.ReadLine();
            userGuessNum = int.Parse(userGuess);
            guessCount++;

            if (userGuessNum == magicNum)
            {
                Console.WriteLine("You guessed it!");
            }
            else if (userGuessNum < magicNum)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("Lower");
            }
        } while (userGuessNum != magicNum);

        if (userGuessNum == magicNum)
        {
            Console.WriteLine("You guessed it!");
        }
        else if (userGuessNum < magicNum)
        {
            Console.WriteLine("Higher");
        }
        else
        {
            Console.WriteLine("Lower");
        }
        /*
        Keep track of how many guesses the user has made and inform them of it at the end of the game.

        After the game is over, ask the user if they want to play again. Then, loop back and play the whole game again and continue this loop as long as they keep saying "yes"
        */
        string playAgain;
        do
        {
            // Reset the game
            magicNum = random.Next(1, 101);
            userGuessNum = 0;
            guessCount = 0;

            do
            {
                Console.Write("What is your guess: ");
                string userGuess = Console.ReadLine();
                userGuessNum = int.Parse(userGuess);
                guessCount++;

                if (userGuessNum == magicNum)
                {
                    Console.WriteLine("You guessed it!");
                }
                else if (userGuessNum < magicNum)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("Lower");
                }
            } while (userGuessNum != magicNum);

            Console.WriteLine($"You took {guessCount} guesses.");
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
        } while (playAgain.ToLower() == "yes");
    }
}