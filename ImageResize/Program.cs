namespace ImageResize
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Set the apartment state to STA (Single-Threaded Apartment)
            //Thread.CurrentThread.SetApartmentState(ApartmentState.STA);
            ApplicationConfiguration.Initialize();

            Resolution res = new Resolution();
            res.x = 1350;
            res.y = 1340;
            Console.WriteLine(string.Concat("Source resolution ", res.x, " x ", res.y));

            Ratio ra = new Ratio(res);
            Console.WriteLine(string.Concat("Ratio ", ra.horizontal, ":", ra.vertical));

            Aspect ap = new Aspect(res);
            Console.WriteLine(string.Concat("Factor ", ap.factor.ToString("F27")));
            Console.WriteLine(string.Concat("Orientation ", ap.orientation));

            Viewport vp = new Viewport(ap.factor);
            Console.WriteLine(string.Concat("Viewport ", vp.name));

            if (vp.name.Equals("undefined"))
            {
                Console.WriteLine(string.Concat("Do nothing"));
            }
            else
            {
                if (vp.name.Equals("custom"))
                {
                    Console.WriteLine(string.Concat("Log custom resolution"));
                }
                else
                {
                    Resolution resize = new Resolution();
                    decimal factor;

                    if (vp.name.Equals("square"))
                    {
                        int larger = Math.Max(res.x, res.y);
                        if (larger > 1080)
                        {
                            factor = 1080 / (decimal)larger;
                            resize = Scale(res, factor);
                        }
                    }

                    if (vp.name.Equals("standard"))
                    {
                        int smaller = Math.Min(res.x, res.y);
                        if (smaller > 1080)
                        {
                            factor = 1080 / (decimal)smaller;
                            resize = Scale(res, factor);
                        }
                    }

                    if (vp.name.Equals("widescreen"))
                    {
                        int larger = Math.Max(res.x, res.y);
                        if (larger > 1920)
                        {
                            factor = 1920 / (decimal)larger;
                            resize = Scale(res, factor);
                        }
                    }

                    if (vp.name.Equals("extrawide"))
                    {
                        int larger = Math.Max(res.x, res.y);
                        if (larger > 1920)
                        {
                            factor = 1920 / (decimal)larger;
                            resize = Scale(res, factor);
                        }
                    }

                    Console.WriteLine(string.Concat("Target resolution ", resize.x, " x ", resize.y));
                }
            }
        }

        static Resolution Scale(Resolution res, decimal factor)
        {
            Console.WriteLine(string.Concat("Scale factor ", factor.ToString("F27")));
            decimal x = decimal.Parse(res.x.ToString());
            decimal y = decimal.Parse(res.y.ToString());

            x = decimal.Multiply(x, factor);
            y = decimal.Multiply(y, factor);

            Resolution resize = new Resolution();
            resize.x = decimal.ToInt32(x);
            resize.y = decimal.ToInt32(y);
            return resize;
        }
    }
}
