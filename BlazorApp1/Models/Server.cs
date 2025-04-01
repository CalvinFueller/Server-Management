using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Models
{
    public class Server
    {
        #region Properties/Fields
        [Required]
        public int ServerId { get; set; }
        public bool IsOnline { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")] // Just as a demo to use multiple annotations
        public string? Name { get; set; }

        [Required]
        public string? City { get; set; }
        #endregion

        #region Constructors
        public Server()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 2);
            IsOnline = randomNumber == 0 ? false : true;
        }
        #endregion
    }
}
