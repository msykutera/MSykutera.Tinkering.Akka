﻿using Akka.Actor;

namespace MSykutera.Tinkering.Akka
{
    internal class FibonacciSequenceActor : ReceiveActor
    {
        private decimal CalculateFibonacciNumber(int n)
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

        public FibonacciSequenceActor()
        {
            Receive<int>(n =>
            {
                if (n < 0) return;

                var fibonacciNumber = CalculateFibonacciNumber(n);
                Sender.Tell(fibonacciNumber);
            });
        }
    }
}
