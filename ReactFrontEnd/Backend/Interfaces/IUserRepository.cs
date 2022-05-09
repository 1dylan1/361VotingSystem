namespace Backend.Models
{
    public interface IUserRepository
    {
        /**
         * Retreives user information based off of their login credentials.
         * If invalid, returns a dummy account (null variables in fields, -1 key, etc.)
         * 
         * Returns: User Information (user)
         */
        User GetUser(string voterId, string password);

    }
}
