using Vertiv.Models;

namespace Vertiv.Interfaces
{
    public interface IUserInputService
    {
        public UserInput CreateUserPassword(int id);
        public bool PasswordStillValid();
        public bool OneTimePasswordExpired(int id);
        public UserInput GetAvailablePassword();
    }
}
