using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GoodCompanyMVC.Auth.Models
{
    public class Registration
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }
 
        [Required]
        //requires they are the same
        [Compare(nameof(Password))]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
