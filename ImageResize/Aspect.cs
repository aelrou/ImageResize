namespace ImageResize
{
    class Aspect
    {
        internal readonly decimal factor;
        internal readonly string orientation;

        internal Aspect(Resolution res)
        {
            decimal landscape = res.x / (decimal)res.y;
            decimal portrait = res.y / (decimal)res.x;

            if (landscape > portrait)
            {
                factor = landscape;
                orientation = "landscape";
                return;
            }

            if (landscape < portrait)
            {
                factor = portrait;
                orientation = "portrait";
                return;
            }

            factor = 1;
            orientation = "square";
        }
    }
}
