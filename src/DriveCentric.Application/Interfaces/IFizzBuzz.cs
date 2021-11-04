using System;
using System.Collections.Generic;
using System.Text;

namespace DriveCentric.Application.Interfaces
{
    public interface IFizzBuzz
    {
        public List<string> GetList(int max, int divisor1, int divisor2, string word1, string word2);
    }
}
