namespace MSykutera.Tinkering.Akka
{
    internal class FibonacciSequenceService
    {
        public decimal CalculateFibonacciNumber(int n)
        {
            decimal previous = 1;
            decimal current = 1;

            if (n <= 2) return 1;

            for (var i = 2; i < n; i++)
            {
                var temp = current;
                current = previous + current;
                previous = temp;
            }

            return current;
        }
    }
}
