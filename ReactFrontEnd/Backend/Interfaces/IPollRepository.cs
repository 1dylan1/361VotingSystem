namespace Backend.Models
{
    public interface IPollRepository
    {
        /**
         * Gets all poll information (title, description, account who created the poll, pollId)
         * 
         * Returns: List of polls
         */
        List<Poll> GetAllPolls();
    }
}
