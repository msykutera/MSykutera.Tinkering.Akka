using Akka.Actor;

namespace MSykutera.Tinkering.Akka
{
    internal class FibonacciSequenceActor : ReceiveActor
    {
        private readonly FibonacciSequenceService _service = new();

        public FibonacciSequenceActor()
        {
            Receive<int>(n =>
            {
                if (n < 0) return;

                var fibonacciNumber = _service.CalculateFibonacciNumber(n);
                Sender.Tell(fibonacciNumber);
            });
        }
    }
}
