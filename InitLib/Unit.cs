namespace InitLib
{
    public class Unit
    {
        public string Title { get; set; }
        public int Attack { get; set; }
    }

    public static class Opers
    {
        public static double Power(double x, int n)
        {
            return Math.Pow(x, n);
        }
    }
}
