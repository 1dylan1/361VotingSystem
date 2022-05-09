namespace Backend.Models
{
    public class Poll
    {
        public string title { get; set; }

        public int pollId { get; set; }

        public string? description { get; set; }

        public int accountId { get; set; }
    }
}