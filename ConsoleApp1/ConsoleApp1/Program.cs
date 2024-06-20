using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //user enters their menu option bn
            Console.WriteLine("Welcome to Hangman, Enter a number fom 1 - 5\n");

            //display menu function
            DisplayMenu();

            //getting user choice from menu option
            int optionnum = Convert.ToInt32(Console.ReadLine());


            if (optionnum == 1)
            {
                Console.Clear();
                //player vs cpu
                Console.WriteLine("Payer vs CPU selected!");
            }
            else if (optionnum == 2) 
            {

                Console.Clear();        
                //player vs player 
                Console.WriteLine("Payer vs Player selected!");

            }
            else if (optionnum == 3)
            {
                //adding to the word bank
                Console.Clear();
                Console.WriteLine("Add/Remove to Word Bank selected!");

                //getting user input
                Console.WriteLine("\nDo you want to add or remove words");
                string addorrmvchoice = Console.ReadLine();

                AddorRemoveWords(addorrmvchoice);

            }
            else if (optionnum == 4) 
            {
                Console.Clear();
                //display the help
                Console.WriteLine("How to play selected!");

                DisplayHowToPlay();
            }
            else if(optionnum == 5) 
            {
                //quit the game
                Console.WriteLine("Quit Game selected!");

                QuitGame();
            }
            else
            {
                //invalid input number
                Console.WriteLine("\nInvalid, Enter a number between 1-5");
                optionnum = Convert.ToInt32(Console.ReadLine());
            }

            Console.ReadKey();
        }

        //display a menu 
        static void DisplayMenu()
        {
            //Creating a list for the different menu options
            List<string> MenuOptions = new List<string>
            {
                "1.Start Player vs CPU",
                "2.Start Player vs Player",
                "3.Add/Remove word",
                "4.How to play",
                "5.Quit Game"
            };

            //Displaying each menu option
            for (int i = 0; i < MenuOptions.Count; i++)
            {
                Console.WriteLine($"{MenuOptions[i]}\n");
            }
        }

        //quit game 
        static void QuitGame()
        { 
            Environment.Exit(0);
        }

        //how to play rules established 
        static void DisplayHowToPlay() 
        {
            Console.WriteLine("Decide who is going first. Start the game by having this person choose a word\r\nor phrase in their mind. (Choose a word from the book just read, and for quick reference to\r\nthe word, use a bookmark to keep track of the page it is located on.)\r\nPlace one dash on the bottom of the game board for each letter of the word or words\r\nchosen. Leave a space between words.\r\nIf the word is dog, draw three spaces, like this: __ __ __.\r\nHave the other player guess one letter at a time - or he or she can use a turn to guess the\r\nentire word or words.\r\n\nFill in the letter everywhere it appears on the appropriate dash (or dashes) each time the\r\nperson guesses correctly. Circle the letter on the alphabet if is guessed correctly. Add one\r\nbody part to the drawing each time the letter chosen is not in the word. Begin by drawing a\r\n\nhead attached to the short vertical line (the \"noose\"). Add eyes, ears, nose, hair, body, legs,\r\n\nand arms. Put an X through the letter that was guessed and not correct. You may also wish\r\n\nto make your drawings very elaborate - one ear at a time, a neck, and a belly button - so that\r\nchildren will have a lot of guesses before losing.\r\nIf the drawing of the person is completed before the word or words are guessed, the\r\nguessing player loses. If the player figures out the word or words first, he or she wins. ");
        }

        //add or remove words
        static void AddorRemoveWords(string addorrmvchoice)
        {
            //declearing the file path
            string FilePath = "Words.txt";
            //making a readalltext variable
            string readwordfile = File.ReadAllText(FilePath);
          

            //user input add
            if (addorrmvchoice.ToLower() == "add")
            {
                //printing out the users words
                Console.WriteLine("Here is the current list of words, in the word bank\n");
                Console.WriteLine($"{readwordfile}\n");

                //validating user input
                int newwordnum = -1;
                do
                {
                    Console.WriteLine("Enter how many new words you want to add");
                    newwordnum = Convert.ToInt32(Console.ReadLine());

                } while (newwordnum < 0);
                           

                //file path and words
                string newwords;
                //user entering words and appending to end of file 
                for (int i = 0; i < newwordnum; i++)
                {
                    //user new woord input
                    Console.WriteLine("\nEnter a new word");
                    //checking if the input string was empty or not 
                    newwords = Console.ReadLine();

                    //checking if the string is empty or not 
                    while (string.IsNullOrEmpty(newwords))
                    {
                        Console.WriteLine("Invalid, enter a word");
                        newwords = Console.ReadLine();
                    }

                    //add to end of file 
                    File.AppendAllText(FilePath, newwords + Environment.NewLine);
                     
                }

                //read the file and print each word
                readwordfile = File.ReadAllText(FilePath);
                Console.Clear();
                Console.WriteLine($"This is your upadated list of words:\n\n{readwordfile}");

            }
            else if (addorrmvchoice.ToLower() == "remove")
            {

                //displaying the current list of words
                Console.WriteLine("Here is the current list of words, in the word bank\n");
                Console.WriteLine($"{readwordfile}\n");

                //puttingt the file content into a list 
                List<string> wordbank = File.ReadAllLines(FilePath).ToList();
                
                //inputting the number of words to remove
                Console.WriteLine("\nHow many words do you want to remove?");
                int wordstormvnum = Convert.ToInt32(Console.ReadLine());

                //declearing the words to remove
                string wordstormv;

                //removing the words 
                for (int i = 0; i < wordstormvnum; i++)
                {

                    Console.WriteLine("\nEnter the words you want to remove");
                    wordstormv = Console.ReadLine();

                    if (wordbank.Remove(wordstormv.ToLower()))
                    {
                        Console.WriteLine($"\n{wordstormv} has been removed from the word bank");
                    }
                    else //if no word is found 
                    {
                        Console.WriteLine($"\n{wordstormv} was not found in the word bank, enter another word");
                        wordstormv = Console.ReadLine();
                    }
                }

                Console.WriteLine("This is the new word bank");
                // printing out updated word bank and save to new file
                foreach (var word in wordbank)
                {
                    Console.WriteLine(word);
                    File.WriteAllText(FilePath, word);                
                }
            }

       
        }
    }
}
