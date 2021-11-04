using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Svc.FizzBuzz.DTO
{
    public class FizzBuzzRequestDTO
    {
        public int MaxNumber { get; set; }

        public int Divisor1 { get; set; }

        public int Divisor2 { get; set; }

        public string Word1 { get; set; }

        public string Word2 { get; set; }

    }
}
