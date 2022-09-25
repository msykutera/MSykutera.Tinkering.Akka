using Akka.Actor;
using Akka.Util.Internal;
using MSykutera.Tinkering.Akka;

var options = new
{
    Numbers = 100,
    Actors = 12,
};

var system = ActorSystem.Create("MySystem");
var sequence = new decimal[options.Numbers + 1];

var actors = Enumerable
    .Range(0, options.Actors)
    .Select(i => system.ActorOf<FibonacciSequenceActor>($"fibonacci-{i}"))
    .ToList();

var tasks = Enumerable
    .Range(1, options.Numbers)
    .Select(async i =>
    {
        var actorIndex = i % options.Actors;
        var actor = actors[actorIndex];
        var fibonacciNumber = await actor.Ask<decimal>(i);
        sequence[i] = fibonacciNumber;
    });

await Task.WhenAll(tasks);

Enumerable
    .Range(1, options.Numbers)
    .ForEach(i => Console.WriteLine($"{i}: {sequence[i]}"));