using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MocAssessment
{
    class Program
    {
        private static int[] _numList = new int[100];        
        private static int _max = _numList.Length - 1;
        private static int _min = 0;
        private static bool _guessed = false;
        static Random random = new Random();

        //Number guessing game
        static void Main(string[] args)
        {
            int n = 1;

            //Populates the array with numbers from 1-100
            for (int i = 0; i < _numList.Length; i++)
            {
                _numList[i] = n;
                n++;
                Console.WriteLine(_numList[i]);
            }

            Console.WriteLine("Hello Player. Think of a number between 1 & 100.");
            Console.ReadKey();
            Console.WriteLine("If you have your number\nI am going to start to try\nand guess it.");

            //Loops through until the computer Guesses the number correctly or the 
            //User decides to stop playing.
            string choice = "";
            while(!_guessed || choice == "0")
            {
                _guessed = true;

                n = GuessNumber(_numList[_min], _numList[_max]);
                Console.WriteLine(n);

                Console.WriteLine("Is this your number?\n0: Exit\n1: Yes\n2:" +
                    " Guess higher\n3: Guess lower");

                //Takes and checks user input to begin guessing higher, lower, 
                //win condition, and or quit.
                choice = Console.ReadLine();
                if(choice == "0")
                {
                    break;
                }
                else if(choice == "1")
                {
                    Console.WriteLine("Good Game!\nThank you for playing!");                    
                }
                else if(choice == "2")
                {
                    _guessed = false;
                    GuessHigher(n);
                }
                else if(choice == "3")
                {
                    _guessed = false;
                    GuessLower(n);
                }
                else
                {
                    _guessed = false;
                }              
            }
            
            Console.ReadKey();
        }

        //Has the computer guess a number between the minimum and maximum number values
        public static int GuessNumber(int min, int max)
        {
            int choice = Program.random.Next(min, max);
            return choice;
        }

        //Reassignes the value of the maximum number for the computer to guess.
        public static int GuessHigher(int min)
        {
            _min = min + 1;

            return _min;
        }

        //Reassignes the value of the minimum number for the computer to guess.
        public static int GuessLower(int max)
        {
            _max = max - 1;
            
            return _max;
        }
    }
}
