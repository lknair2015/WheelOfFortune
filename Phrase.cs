using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WheelOfFortune
{
    internal class Phrase
    {
        public Phrase() 
        {
            this.PhraseString = "";
            this.GuessedPhrase = "";
            this.UserGuess = "";
        } 

        public string PhraseString {  get; set; }

        public string GuessedPhrase { get; set; }
        public int TotalNoOfLetters
        {
            get
            {
                char[] chars = PhraseString.ToCharArray();
                return chars.Length;
            }
        }

        public string UserGuess { get; set; }
        public string Hint {  get; set; }

        private string _guessedPhrase;


        public string BuyAVowel() {

            _guessedPhrase = "";

            int count = 0;

            for (int i = 0; i < PhraseString.Length; i++)
            {
                if ("AEIOU".Contains(PhraseString[i].ToString()) && GuessedPhrase[i].ToString() == "_" && count< 1)
                {
                    _guessedPhrase += PhraseString[i];
                    count++;
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
            int count = 0;
            foreach (char c in PhraseString)
            {
                if (c.ToString() == UserGuess)
                    count++;
            }
            return count;
        }


               

    }
}
