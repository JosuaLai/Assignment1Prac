using Microsoft.AspNetCore.Identity;

namespace Assignment1Prac.Model
{
	public class ApplicationUser : IdentityUser
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string CreditCardNo { get; set; }

		public string MobileNo { get; set; }

		public string BillingAddressLine1 { get; set; }

		public string BillingAddressLine2 { get; set; }


		public string BillingAddressPostalCode { get; set; }

		public string ShippingAddressLine1 { get; set; }

		public string ShippingAddressLine2 { get; set; }


		public string ShippingAddressPostalCode { get; set; }

		
		public string Photo { get; set; }
	}
}
