namespace SimpleCQRS.Eventing
{

    public abstract class Event : IMessage
    {
        public int Version;
    }

}