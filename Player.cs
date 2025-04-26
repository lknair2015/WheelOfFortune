using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelOfFortune
{
    public abstract class Player
    {
        public Player() 
        {
            this.Balance = 0;
            this.Name = string.Empty;   
            this.MinimumPayout = 1000;
        }
        public string? Name {  get; set; } 
        public decimal Balance {  get; set; }
        public decimal MinimumPayout { get; set; }

        public decimal CalculateFinalPayout()
        {
            if (this.Balance < this.MinimumPayout) { this.Balance = this.MinimumPayout; return this.Balance; }
            else return this.Balance;
        }
    }
}
