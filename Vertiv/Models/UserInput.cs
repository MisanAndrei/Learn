using System.ComponentModel.DataAnnotations;

namespace Vertiv.Models
{
    public class UserInput
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime CreationDateTime { get; set; }
        [Required]
        public string Password { get; set; }
         
        public UserInput()
        {
            //empty ctor
        }

        public UserInput(int id)
        {
            Id = id;    
            CreationDateTime = DateTime.Now;
            Password = Guid.NewGuid().ToString();
        }
    }
}
