using System.ComponentModel.DataAnnotations;

namespace GoodCompanyMVC.Auth.Models
{
    public class Credentials
    {
        [Required]
        //checks for valid email
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
