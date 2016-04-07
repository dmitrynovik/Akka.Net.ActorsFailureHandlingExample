using System;
using Akka.Actor;

namespace AkkaTest
{
    public class GreetingActorParent : GreetingActor
    {
        private readonly IActorRef _child;

        public GreetingActorParent()
        {
            _child = Context.ActorOf<GreetingActorChild>("my-only-child");
        }

        protected override void Handle(Greet greet)
        {
            Console.WriteLine("\nParent hello {0}", greet.Message);
            _child.Forward(greet);
        }
    }
}