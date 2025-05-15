using System.ComponentModel.DataAnnotations;

namespace SupermarketWEB.Models
{
    public class Users
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}