namespace Core.Models.Hubs
{
    public class Connection
    {
        public Connection(string connectionId)
        {
            ConnectionId = connectionId;
        }

        public string ConnectionId { get; set; }
    }
}