// See https://aka.ms/new-console-template for more information
using System.IO.Pipes;
using System.Security.Cryptography.X509Certificates;
using WheelOfFortune;

Console.WriteLine("\n\n                             WHEEL OF FORTUNE GAME                                    \n\n");

Wheel wheel = new();
//Set 19 segments of the wheel
wheel.SetWheel();


Phrase phrase = new ();

//Ask for player's Name
Console.WriteLine("Player, Please enter your name: \n");
phrase.Name = Console.ReadLine();
Console.WriteLine($"\nHello {phrase.Name}, Welcome to the wheel of fortune game!\n");

//Set the guess phrase and hint
phrase.PhraseString = "RED";
phrase.Hint = "BIG";

//Set the guessed word with underscores
string guessedString = new string('_', phrase.PhraseString.Length);
phrase.GuessedPhrase = guessedString;
Console.WriteLine($"We have a word for you now and it is {phrase.GuessedPhrase} and the hint for the word is  ***{phrase.Hint}***\n");

//Continue the game until the user guessed word matches with game word.
while (!(guessedString == phrase.PhraseString))
{
    Console.WriteLine("-----------------------------------------------------------------------------------\n");
    
    Console.WriteLine("Please Enter your choice:");
    Console.WriteLine("1. Pay $250 and buy a vowel");
    Console.WriteLine("2. Turn the wheel and guess a consonant");
    Console.WriteLine("3. Guess the word\n");

    //check if the user's choice is valid
    bool success = int.TryParse(Console.ReadLine(), out int option);

    try
    {
        if (success)
        {
            switch (option)
            {
                case 1:
                    //
                    CheckBalance();
                    break;
                case 2:
                    GuessAConsonant();
                    break;
                case 3:
                    GuessTheWord();
                    break;
            }
        }
        else Console.WriteLine($"\nYou selected the wrong choice. Try again!\n");
        
    }catch (Exception e) { Console.WriteLine(e.ToString()); }
}

Console.WriteLine("-----------------------------------------------------------------------------------\n");

decimal finalBalance  = phrase.CalculateFinalPayout();
Console.WriteLine($"YAY! You won the round. Your account balance : ${finalBalance}.\n");

Console.WriteLine("-----------------------------------------------------------------------------------\n");




void CheckBalance() {
    if (phrase.Balance > 250)
    {

        guessedString = phrase.BuyAVowel();

        if (guessedString == phrase.GuessedPhrase)
        {
            Console.WriteLine("No Vowels left to buy. Please select other options.");
        }
        else 
        {
            phrase.GuessedPhrase = guessedString;
            phrase.Balance -= 250;
            Console.WriteLine($"Congratulations: The word is {guessedString}");
            Console.WriteLine($"\nYou have successfully bought a vowel.");
            Console.WriteLine($"Your current balance is ${phrase.Balance}\n");
        }
    }          
    else Console.WriteLine("Not Enough dollars in your account.");   
}
        


void GuessAConsonant()
{
    Console.WriteLine("Let's Spin the Wheel first !\n");
    int selectedSeg = wheel.TurnWheel();

    if (selectedSeg > 2)
    {
        Console.WriteLine($"\nPlayer {phrase.Name}, you got .... ${selectedSeg}\n");
        Console.WriteLine($"\nPlayer {phrase.Name}, now... please enter your consonant: \n");
        string? userConsonant = Console.ReadLine();
        if (!string.IsNullOrEmpty(userConsonant) && userConsonant.Length == 1)
        {
            phrase.UserGuess = userConsonant.ToUpper();
            if (phrase.ValidateGuess())
            {
                guessedString = phrase.SetGuessedPhrase();
                phrase.GuessedPhrase = guessedString;
                int noOfGuessedConsonants = phrase.NoOfGuessedConsonants();
                phrase.Balance += noOfGuessedConsonants * selectedSeg;
                Console.WriteLine($"\nYou guessed correct and you won ${noOfGuessedConsonants * selectedSeg}");
            }
            else Console.WriteLine("\nYour guess is incorrect. Try again! ");
        }
        else Console.WriteLine("\nYour entry is invalid. Try again! ");
    }
    else if (selectedSeg == 1)
    {
        phrase.Balance = 0;
        Console.WriteLine($"Sadly you got BANKRUPT. Try again!");
    }
    else Console.WriteLine("Sadly you got LOOSE A TURN. Try again!");

    Console.WriteLine($"The word is {guessedString}");
    Console.WriteLine($"Your balance : ${phrase.Balance}");

}
void GuessTheWord()
{
    Console.WriteLine("Please enter your guess:");
    guessedString = Console.ReadLine() ;

    guessedString = guessedString == null ? "": guessedString.ToUpper();
    
    if(guessedString == phrase.PhraseString)
    {
        phrase.GuessedPhrase = guessedString;
        Console.WriteLine($"Congratulations: The word is {phrase.GuessedPhrase}");
    }
    else Console.WriteLine("\nYour guess is incorrect. Try again! ");
}













