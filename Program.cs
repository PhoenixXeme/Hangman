using System;

namespace Hangman
{
    class Program
    {
        /* 
           TO DO
            [X] Generate random word    
            [X] 10 Guess's
            [X] Create Console text kinda like a UI
            [X] Each correct guess shows the letter
            [ ] Show hangman him self
            [ ] Give hints
            [ ] Score depending on guess's that where used
         */
        static void Main(string[] args)
        {

            Random rand = new Random();
            string[] words = { "Computer", "Elephant", "Guitar", "Sunshine", "Butterfly", "Pizza", "Chocolate", "Rainbow", "Basketball", "Adventure"};
            string wordToGuess = words[rand.Next(words.Length)];

            int guessLimit = 10;
            int guessIndex = 0;
            char guess = '#';
            char[] calc = new char[wordToGuess.Length];
            string result = "";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Hangman");
            Console.WriteLine("--------");
            Console.WriteLine();
            Console.WriteLine("A random word has been generated try to guess it within " + guessLimit + " attempts.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine(wordToGuess); // for debuging

            for (int i = 0; i < wordToGuess.Length; i++)
            {
                calc[i] = '_';
            }

            while (result != wordToGuess)
            {
                result = "";
                Console.WriteLine();
                Console.Write("Enter your guess: ");
                guess = Console.ReadLine().ToLower()[0];

                if (wordToGuess.ToLower().Contains(guess))
                {
                    for (int i = 0; i < wordToGuess.Length; i++)
                    {

                        if (wordToGuess.ToLower()[i] == guess)
                        {
                            calc[i] = guess;
                        }
                    }
                    for (int j = 0; j < calc.Length; j++)
                    {
                        if (j == 0)
                        {
                            result += char.ToUpper(calc[j]);
                        }
                        else
                        {
                            result += calc[j];
                        }
                    }
                    Console. WriteLine(result);
                }
                else
                {
                    guessIndex++;
                    if (guessIndex == guessLimit)
                    {
                        break;
                    }
                    Console.WriteLine("Incorrect Guess \"" + guess + "\" " + guessIndex + "/" + guessLimit + " guess's left.");
                    Console.WriteLine();
                }
            }
            if (result != wordToGuess)
            {
                Game_lost(wordToGuess);
            }
            else if (result == wordToGuess)
            {
                Game_won(wordToGuess);
            }
            
            
        }

        static void Game_lost(string wordToGuess)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("Game Over!");
            Console.WriteLine("The word was: " + wordToGuess);
            Console.ReadLine();
        }

        static void Game_won(string wordToGuess)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("Congrats you win!");
            Console.WriteLine("The word was: " + wordToGuess);
            Console.ReadLine();
        }

    }
}