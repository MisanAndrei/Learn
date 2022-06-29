using Vertiv.Interfaces;
using Vertiv.Models;

namespace Vertiv.Services
{
    public class UserInputService : IUserInputService
    { 
        private static List<UserInput> UserInputsList  = new List<UserInput>();

        public UserInput CreateUserPassword(int id)
         {
            UserInput userInput = new UserInput(id);
            UserInputsList.Add(userInput);
            return userInput;
        }

        public bool PasswordStillValid()
        {
            var userInput = UserInputsList.Where(x => x.CreationDateTime.AddSeconds(30) > DateTime.Now).FirstOrDefault();
            if (userInput != null)
                return true;
            return false;
        }

        public bool OneTimePasswordExpired(int id)
        {
            var userInput = UserInputsList.Where(x => x.Id == id).FirstOrDefault();
            if (userInput != null)
                return true;
            return false;
        }

        public UserInput GetAvailablePassword()
        {
            return UserInputsList.Where(x => x.CreationDateTime.AddSeconds(30) > DateTime.Now).FirstOrDefault();
        }
    }
}
