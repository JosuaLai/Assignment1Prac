using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Assignment1Prac.ViewModels
{
    public class Register
    {
        [Required]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

		[Required]
		[DataType(DataType.CreditCard)]
		public string CreditCardNo { get; set; }

		[Required]
        [RegularExpression(@"^[0-9]{8}$")]
        public string MobileNo { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string BillingAddressLine1{ get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string BillingAddressLine2 { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{6}$")]

        public string BillingAddressPostalCode { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string ShippingAddressLine1 { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string ShippingAddressLine2 { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{6}$")]

        public string ShippingAddressPostalCode { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{12}$", ErrorMessage = "Password needs min 12 characters, at least 1 lower case, 1 upper case, 1 number and 1 special character")]
        public string Password { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password and confirmation password does not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        [RegularExpression(@"^.*\.(jpg)$")]
        public string Photo { get; set; }
    }
}
