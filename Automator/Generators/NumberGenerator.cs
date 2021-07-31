using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automator
{
    class NumberGenerator
    {
        private readonly Random _random;

        public NumberGenerator()
        {
            _random = new Random();
        }

        public int GetNumber(int min = 0, int max = 1000000)
        {
            return (int)_random.Next(min, max + 1);
        }
    }
}
