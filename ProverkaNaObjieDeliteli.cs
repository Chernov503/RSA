using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
    public static class ProverkaNaObjieDeliteli
    {
        public static bool CheckCommonDivisors(int num1, int num2)
        {
            int smallerNum = Math.Min(num1, num2);

            for (int i = 2; i <= smallerNum; i++)
            {
                if (num1 % i == 0 && num2 % i == 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
