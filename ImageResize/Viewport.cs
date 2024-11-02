namespace ImageResize
{
    class Viewport
    {
        internal readonly string name;
        internal readonly decimal square;
        internal readonly decimal standard;
        internal readonly decimal widescreen;
        internal readonly decimal extrawide;

        internal Viewport(decimal number)
        {
            square = 1;
            standard = (decimal)7 / 6;
            widescreen = (decimal)16 / 9;
            extrawide = (decimal)5 / 2;

            if (number < 1 - (decimal)0.01)
            {
                name = "undefined";
                return;
            }

            if (number >= 1 - (decimal)0.01)
            {
                if (number < square + (decimal)0.01)
                {
                    name = "square";
                    return;
                }
            }

            if (number >= square - (decimal)0.01)
            {
                if (number < standard + (decimal)0.01)
                {
                    name = "standard";
                    return;
                }
            }

            if (number >= standard - (decimal)0.01)
            {
                if (number < widescreen + (decimal)0.01)
                {
                    name = "widescreen";
                    return;
                }
            }

            if (number >= widescreen - (decimal)0.01)
            {
                if (number < extrawide + (decimal)0.01)
                {
                    name = "extrawide";
                    return;
                }
            }

            if (number >= extrawide - (decimal)0.01)
            {
                name = "custom";
            }
        }
    }
}
