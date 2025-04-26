using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WheelOfFortune
{
    internal class Phrase : Player
    {
        public Phrase() 
        {
            this.PhraseString = string.Empty;
            this.GuessedPhrase = string.Empty;
            this.UserGuess = string.Empty;
            
        } 

        public string PhraseString {  get; set; }
        public string GuessedPhrase { get; set; }
        public string UserGuess { get; set; }
        public string Hint {  get; set; }

        private string _guessedPhrase;
        int _count;


        public string BuyAVowel() {

            _guessedPhrase = "";

            _count = 0;

            for (int i = 0; i < PhraseString.Length; i++)
            {
                if ("AEIOU".Contains(PhraseString[i].ToString()) && GuessedPhrase[i].ToString() == "_" && _count< 1)
                {
                    _guessedPhrase += PhraseString[i];
                    _count++;
                }
                else
                {
                    _guessedPhrase += GuessedPhrase[i];
                }
            }

            return _guessedPhrase;

        }

        public bool ValidateGuess()      
        {
            if(this.PhraseString.Contains(UserGuess) && !"AEIOU".Contains(UserGuess) )
            { 
                
                return true; 

            }
            return false;
            
        }

        public string SetGuessedPhrase()
        {
            _guessedPhrase = string.Empty;
            for (int i = 0; i < PhraseString.Length; i++)
            {
                if (PhraseString[i].ToString() == UserGuess && GuessedPhrase[i].ToString() == "_") 
                {
                    _guessedPhrase += PhraseString[i];
                }
                else
                {
                    _guessedPhrase += GuessedPhrase[i];
                }
            }
            
            return _guessedPhrase;

        }

        public int NoOfGuessedConsonants()
        {
            _count = 0;
            foreach (char c in PhraseString)
            {
                if (c.ToString() == UserGuess)
                    _count++;
            }
            return _count;
        }

    }
}
