using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Svc.FizzBuzz.Business
{
    public class FizzBuzz
    {
        public FizzBuzz()
        {

        }

        public List<string> GetList(int max, int divisor1, int divisor2, string word1, string word2)
        {
            if (max < 1 || max > 100)
            {
                throw new ApplicationException("Argument max must be between 1 and 100.");
            }
            else if (divisor1 < 1 || divisor2 < 1)
            {
                throw new ApplicationException("Divisors must be greater than 0.");
            }

            List<string> lstResult = new List<string>();

            for (int i = 1; i <= max; i++)
            {
                if (i % divisor1 == 0 && i % divisor2 == 0)
                {
                    lstResult.Add(string.Format("{0}{1}", word1, word2));
                }
                else if (i % divisor1 == 0)
                {
                    lstResult.Add(word1);
                }
                else if (i % divisor2 == 0)
                {
                    lstResult.Add(word2);
                }
                else
                {
                    lstResult.Add(i.ToString());
                }
            }

            return lstResult;
        }
    }
}
