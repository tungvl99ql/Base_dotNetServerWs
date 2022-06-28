namespace GameServer.Messaging
{
    public class WsMessage<T>
    {
        public Tags Tags { get; set; }

        public T Data { get; set; }

        public WsMessage(Tags tags, T data)
        {
            Tags = tags;
            Data = data;
        }
    }
}