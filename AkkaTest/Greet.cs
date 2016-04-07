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
}
