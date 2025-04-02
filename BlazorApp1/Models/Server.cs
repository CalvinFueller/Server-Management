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
        /// <summary>
        /// Initializes a new Server instance.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when unable to generate a new ID.</exception>
        public Server()
        {
            try
            {
                List<string> cities = CitiesRepository.GetCities();

                this.City = cities != null ? cities[0] : "Toronto";
                this.IsOnline = false;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"[Server Constructor] Error: {ex.Message}");
                throw;
            }
        }
        #endregion
    }
}
