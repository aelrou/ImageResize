namespace ImageResize
{
    class Ratio
    {
        internal readonly int horizontal;
        internal readonly int vertical;

        internal Ratio(Resolution res)
        {
            int gcd = GCD(res.x, res.y);
            horizontal = res.x / gcd;
            vertical = res.y / gcd;
        }

        int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}
