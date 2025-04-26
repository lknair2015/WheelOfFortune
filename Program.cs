// See https://aka.ms/new-console-template for more information
using System.IO.Pipes;
using System.Security.Cryptography.X509Certificates;
using WheelOfFortune;

Console.WriteLine("\n\n                             WHEEL OF FORTUNE GAME                                    \n\n");


Phrase phrase = new Phrase();
Player player = new Player();
Wheel wheel = new Wheel();

Console.WriteLine("Player, Please enter your name: \n");

player.Name = Console.ReadLine();

Console.WriteLine($"\nHello {player.Name}, Welcome to the wheel of fortune game!\n");

wheel.SetWheel();

phrase.PhraseString = "HAPPY";

phrase.Hint = "Another word for joy";

string guessedString = "_____";

phrase.GuessedPhrase = guessedString;

while (!(guessedString == phrase.PhraseString))
{
    Console.WriteLine("-----------------------------------------------------------------------------------\n");
    Console.WriteLine($"We have a word for you now and the hint for the word is  ***{phrase.Hint}***\n");
    Console.WriteLine("Please Enter your choice:");
    Console.WriteLine("1. Pay $250 and buy a vowel");
    Console.WriteLine("2. Turn the wheel and guess a consonant");
    Console.WriteLine("3. Loose the turn\n");

    string? userOption = Console.ReadLine();

    if (!string.IsNullOrEmpty(userOption))
    {
        int option = int.Parse(userOption);

        switch (option)
        {
            case 1:
                CheckBalance();
                break;
            case 2:
                GuessAConsonant();
                break;
            case 3:
                LooseTurn();
                break;
        }

    }
}
void CheckBalance() {
    if (player.Balance > 250)
    {

        guessedString = phrase.BuyAVowel();

        if (guessedString == phrase.GuessedPhrase)
        {
            Console.WriteLine("No Vowels left to buy. Please select other options.");
        }
        else 
        {
            phrase.GuessedPhrase = guessedString;
            player.Balance -= 250;
            Console.WriteLine($"Congratulations: The word is {guessedString}");
            Console.WriteLine($"\nYou have successfully bought a vowel.");
            Console.WriteLine($"Your current balance is ${player.Balance}\n");
        }
    }
            
    else
    {
        Console.WriteLine("Not Enough dollars in your account.");
    }
}
        


void GuessAConsonant()
{  
    Console.WriteLine($"\nPlayer {player.Name}, please enter your consonant: \n");

    string? userConsonant = Console.ReadLine();

    

    if (!string.IsNullOrEmpty(userConsonant) && userConsonant.Length == 1)
    {
       
        phrase.UserGuess = userConsonant.ToUpper();
        
        if (phrase.ValidateGuess())
        {
            int selectedSeg = wheel.TurnWheel();
            
            guessedString = phrase.SetGuessedPhrase();

            phrase.GuessedPhrase = guessedString;

            int noOfGuessedConsonants = phrase.NoOfGuessedConsonants();

            if (selectedSeg > 2)
            {               
                player.Balance += noOfGuessedConsonants * selectedSeg;

                Console.WriteLine($"Congratulations: The word is {guessedString}");
                Console.WriteLine($"You guessed correct and you won ${noOfGuessedConsonants * selectedSeg}");
                Console.WriteLine($"Your balance : ${player.Balance}");

            }
            else if (selectedSeg == 1)
            {
                
                player.Balance = 0;

                Console.WriteLine($"Congratulations: The word is {guessedString}");
                Console.WriteLine($"You guessed correct, but sadly you went bankrupt. Try again!");
                Console.WriteLine($"Your balance : ${player.Balance}");
            }
            else 
            {
                
                Console.WriteLine($"Congratulations: The word is {guessedString}");
                Console.WriteLine("You guessed correct, but sadly you lost the turn. Try again!");
                Console.WriteLine($"Your balance : ${player.Balance}");
            }

        }

    }
    else
    {
        Console.WriteLine("You entered incorrect letter. Please ");
    }
}

    void LooseTurn()
    {
        Console.WriteLine("You chose to loose the turn. Try again!");
    }













