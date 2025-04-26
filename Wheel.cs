using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelOfFortune
{
    internal class Wheel
    {
        public Wheel() {

            this.NoOfSegmants = 19;
        
        }
        public const int Bankrupt = 1;
        public const int LooseTurn = 2;
        public int NoOfSegmants { get; set; }
        public List<int> Segmants
        {
            get { return _segmants; }
        }
        
        private List<int> _segmants = new List<int>();

        public List<int> SetWheel()
        {
            List<int> segmants = Enumerable.Repeat(0, NoOfSegmants).ToList();

            for (int i = 0; i < NoOfSegmants; i++)
            {                
                Random rand = new Random();

                int seg = rand.Next(0, 19);

                if (i == 0)
                {
                    segmants[seg] = 1;
                }
                else if (i == 1 && segmants[seg].Equals(0))
                {
                    segmants[seg] = 2;
                }
                else if (segmants[seg] == 0)
                {
                    segmants[seg] = rand.Next(2, 19) * 50;
                }
                else continue;

            }

            return _segmants = segmants;

        }

        public int TurnWheel()
        {

            Random rand = new Random();

            int segNumer = rand.Next(0, NoOfSegmants);

            return (int) Segmants[segNumer];

        }
    }
}
