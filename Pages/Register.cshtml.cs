using Assignment1Prac.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Assignment1Prac.ViewModels;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.DataProtection;

namespace Assignment1Prac.Pages
{
    //Initialize the build-in ASP.NET Identity
    public class RegisterModel : PageModel
    {
        private UserManager<ApplicationUser> userManager { get; }
        private SignInManager<ApplicationUser> signInManager { get; }
        //private readonly RoleManager<ApplicationUser> roleManager;

        [BindProperty]
        public Register RModel { get; set; }

        public RegisterModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager
            /*,RoleManager<ApplicationUser> roleManager*/)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            /*this.roleManager = roleManager;*/
        }


        //Save data into the database
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var dataProtectionProvider = DataProtectionProvider.Create("EncryptData");
                var protector = dataProtectionProvider.CreateProtector("MySecretKey");


                var user = new ApplicationUser()
                {
                    FirstName = RModel.FirstName,
                    LastName = RModel.LastName,
                    CreditCardNo = protector.Protect(RModel.CreditCardNo),
                    MobileNo = RModel.MobileNo,
                    BillingAddressLine1 = RModel.BillingAddressLine1,
                    BillingAddressLine2 = RModel.BillingAddressLine2,
                    BillingAddressPostalCode = RModel.BillingAddressPostalCode,
                    ShippingAddressLine1 = RModel.ShippingAddressLine1,
                    ShippingAddressLine2 = RModel.ShippingAddressLine2,
                    ShippingAddressPostalCode = RModel.ShippingAddressPostalCode,
                    Email = RModel.Email,
                    Photo = RModel.Photo,
                    

                };

                /*//Create the Admin role if NOT exist
                IdentityRole role = await roleManager.FindByIdAsync("Admin");
                if (role == null)
                {
                    IdentityResult result2 = await roleManager.CreateAsync(new IdentityRole("Admin"));
                    if (!result2.Succeeded)
                    {
                        ModelState.AddModelError("", "Create role admin failed");
                    }
                }

                //Create the HR role if NOT exist
                IdentityRole HRrole = await roleManager.FindByIdAsync("HR");
                if (HRrole == null)
                {
                    IdentityResult result2 = await roleManager.CreateAsync(new IdentityRole("HR"));
                    if (!result2.Succeeded)
                    {
                        ModelState.AddModelError("", "Create role HR failed");
                    }
                }*/

                var PasswordEncrypt = protector.Protect(RModel.Password);

                var result = await userManager.CreateAsync(user, PasswordEncrypt);
                if (result.Succeeded)
                {
                    /*//Add users to Admin Role
                    result = await userManager.AddToRoleAsync(user, "Admin");

                    //Add users to HR Role
                    result = await userManager.AddToRoleAsync(user, "HR");*/

                    await signInManager.SignInAsync(user, false);
                    return RedirectToPage("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return Page();
        }
    }
}
