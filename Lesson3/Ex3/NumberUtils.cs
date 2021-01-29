using System;
namespace Lesson3
{
    namespace Ex3
    {
        public static class NumberUtils
        {
            public static bool IsOdd(this int value)
            {
                return value % 2 != 0;
            }

            public static bool IsEven(this int value)
            {
                return value % 2 == 0;
            }

            public static int Nod(int v1, int v2)
            {
                if (v1 == 0)
                    return v2;
                if (v2 == 0)
                    return v1;
                if (v1 == v2)
                    return v1;

                if (v1 == 1 || v2 == 1)
                    return 1;

                if (v1.IsEven() && v2.IsEven())
                    return 2 * Nod(v1 / 2, v2 / 2);

                if (v1.IsEven() && v2.IsOdd())
                    return Nod(v1 / 2, v2);

                if (v2.IsEven() && v1.IsOdd())
                    return Nod(v1, v2 / 2);

                if (v1 > v2)
                    return Nod((v1 - v2) / 2, v2);

                return Nod((v2 - v1) / 2, v1);
            }

        }
    }
}
