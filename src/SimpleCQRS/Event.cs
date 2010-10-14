namespace SimpleCQRS
{

    public abstract class Event : IMessage
    {
        public int Version;
    }

}