namespace Backend.Models
{
    public interface IAnswerRepository
    {
        /**
         * Gets all potential options(answers) information
         * 
         * Returns: List of options for a poll.
         */
        List<Answer> GetAnswers(string pollId);
    }
}
