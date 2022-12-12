using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LR2_SUPER.Helpers
{
    static class LrHelper
    {
        public static bool MillerRabinTest(BigInteger n, int k)
        {
            if (n == 2 || n == 3)
                return true;
            if (n < 2 || n % 2 == 0)
                return false;

            BigInteger t = n - 1;

            int s = 0;

            while (t % 2 == 0)
            {
                t /= 2;
                s += 1;
            }

            for (int i = 0; i < k; i++)
            {
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                byte[] _a = new byte[n.ToByteArray().LongLength];
                BigInteger a;

                do
                {
                    rng.GetBytes(_a);
                    a = new BigInteger(_a);
                }
                while (a < 2 || a >= n - 2);

                BigInteger x = BigInteger.ModPow(a, t, n);

                if (x == 1 || x == n - 1)
                    continue;

                for (int r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, 2, n);
                    if (x == 1)
                        return false;
                    if (x == n - 1)
                        break;
                }
                if (x != n - 1)
                    return false;
            }
            return true;
        }

        public static int GenerateSimpleNumber()
        {
            int simpleNumber = 5000;
            while (true)
            {
                if (simpleNumber % 2 == 0)
                {
                    simpleNumber--;
                    continue;
                }
                if (MillerRabinTest(simpleNumber, 30))
                    break;
                
            }
            return simpleNumber;
        }

        public static int GetSimple()
        {
            int simple = 0;
            var rnd = new Random();
            do
            {
                simple = rnd.Next(2, 1000);
            } while (!MillerRabinTest((BigInteger)simple, 50));
            return simple;
        }

        public static int GetPRoot(int p)
        {
            for (int i = 0; i < p; i++)
                if (IsPRoot(p, i))
                    return i;
            return 0;
        }

        public static bool IsPRoot(int p, int a)
        {
            if (a == 0 || a == 1)
                return false;
            int last = 1;
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < p - 1; i++)
            {
                last = (last * a) % p;
                if (set.Contains(last)) // Если повтор
                    return false;
                set.Add(last);
            }
            return true;
        }

        public static int BigPow(BigInteger value, int pow, int mod)
        {
            char[] arrBinaryNum = Convert.ToString(pow, 2).ToCharArray();
            BigInteger[] resultArr = new BigInteger[arrBinaryNum.Length];
            resultArr[0] = value;
            for (int i = 1; i < arrBinaryNum.Length; i++)
            {
                if ((int)char.GetNumericValue(arrBinaryNum[i]) == 0)
                    resultArr[i] = (BigInteger.Pow(resultArr[i - 1], 2) % mod);
                else
                    resultArr[i] = ((BigInteger.Pow(resultArr[i - 1], 2) * value) % mod);
            }
            return (int)resultArr.LastOrDefault();
        }

        public static int BigPow(int value, int pow, int mod)
        {
            char[] arrBinaryNum = Convert.ToString(pow, 2).ToCharArray();
            int[] resultArr = new int[arrBinaryNum.Length];
            resultArr[0] = value;
            for (int i = 1; i < arrBinaryNum.Length; i++)
            {
                if ((int)char.GetNumericValue(arrBinaryNum[i]) == 0)
                    resultArr[i] = (int)(Math.Pow(resultArr[i - 1], 2) % mod);
                else
                    resultArr[i] = (int)((Math.Pow(resultArr[i - 1], 2) * value) % mod);
            }
            return resultArr.LastOrDefault();
        }
    }
}
