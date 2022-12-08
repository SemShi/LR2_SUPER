namespace LR2_SUPER.Helpers
{
    public class BBS
    {
        internal static bool IsNumberSimple(long num)
        {
            if (num < 2) return false;
            if (num == 2) return true;
            for (long i = 2; i < num; i++)
            {
                if (num % i == 0)
                    return false;
            }

            return true;
        }

        public static long Calculate_m(long p, long q)
        {
            long m;
            while (true)
            {
                if (IsNumberSimple(p) && IsNumberSimple(q) && (p % 4 == 3) && (q % 4 == 3))
                {
                    return m = p * q;
                }
            }
        }

        public static string BuildingBBS(long x, long m, int msgLength)
        {
            string gammaKey = String.Empty;
            int count = 0;
            char[] numberBinary;
            numberBinary = Convert.ToString(x, 2).ToCharArray();          //Перевод в двоичную систему
            for (int i = 0; i < numberBinary.Length; i++)   //Вычисление паритетного бита для первого числа
            {
                if (numberBinary[i] == '1') count++;
            }
            gammaKey = (count % 2).ToString();
            count = 0;
            while (gammaKey.Length != msgLength * 8 + 8)
            {
                x = (x * x) % m;
                numberBinary = Convert.ToString(x, 2).ToCharArray();
                for (int i = 0; i < numberBinary.Length; i++)   //Вычисление паритетного бита для остальной части гаммы
                {
                    if (numberBinary[i] == '1') count++;
                }
                gammaKey += (count % 2).ToString();
                count = 0;
            }
            return gammaKey;
        }
    }
}
