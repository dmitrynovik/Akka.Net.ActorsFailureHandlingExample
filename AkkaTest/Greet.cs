using System;
using Akka.Actor;

namespace AkkaTest
{
    // Create an (immutable) message type that your actor will respond to
    public class Greet
    {
        public Greet(string msg)
        {
            Message = msg;
        }

        public string Message { get; }
    }

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

    public class GreetingActorChild : GreetingActor
    {
        protected override void Handle(Greet greet)
        {
            Console.WriteLine("\nChild hello {0}", greet.Message);
            throw new Exception("The child is dying");
        }
    }

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
