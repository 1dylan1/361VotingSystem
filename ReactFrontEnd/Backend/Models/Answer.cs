namespace Backend.Models
{
    public class Answer
    {
        public int answerId { get; set; }

        public string choice { get; set; }

        public int pollId { get; set; }
    }
}
