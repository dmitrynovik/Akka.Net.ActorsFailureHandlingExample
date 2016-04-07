using System;
using Akka.Actor;

namespace AkkaTest
{
    public abstract class GreetingActor : ReceiveActor
    {
        protected GreetingActor()
        {
            var type = GetType();
            Console.WriteLine("Creating {0}", type);

            Receive<Greet>(m =>
            {
                Handle(m);
            });
        }

        protected abstract void Handle(Greet greet);
    }
}