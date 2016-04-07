using System;
using Akka.Actor;

namespace AkkaTest
{
    class Program
    {
        static Props CreateParent()
        {
            return Props.Create(() => new GreetingActorParent(),
                new OneForOneStrategy(_ =>
                {
                    if (_ is ApplicationException)
                        return Directive.Escalate;

                    if (_ is ArgumentException)
                        return Directive.Restart;

                    return Directive.Resume;
                }));
        }

        static void Main()
        {
            using (var system = ActorSystem.Create("my-actors-circus"))
            {
                // Create a new actor system (a container for your actors)
                var greeterParent = system.ActorOf(CreateParent(), "parent-greeter");

                // Send a message to the actor
                greeterParent.Tell(new Greet("world"));

                // This prevents the app from exiting before the async work is done
                Console.ReadLine();
            }
        }
    }
}
