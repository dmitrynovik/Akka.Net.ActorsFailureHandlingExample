using System;

namespace AkkaTest
{
    public class GreetingActorChild : GreetingActor
    {
        protected override void Handle(Greet greet)
        {
            Console.WriteLine("\nChild hello {0}", greet.Message);
            throw new Exception("The child is dying");
        }
    }
}