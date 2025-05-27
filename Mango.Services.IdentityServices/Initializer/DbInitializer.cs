using Duende.IdentityModel;
using Mango.Services.IdentityServices.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Mango.Services.IdentityServices.Initializer
{
    public static class DbInitializer 
    {
        public static void Initialize(UserManager<ApplicationUser> _userManager, RoleManager<IdentityRole> _roleManager) 
        {
            if (_roleManager.FindByNameAsync(Consts.Admin).Result == null)
            {
                _roleManager.CreateAsync(new IdentityRole(Consts.Admin)).GetAwaiter().GetResult();
            }
            else { return; }

            ApplicationUser adminUser = new ApplicationUser()
            {
                UserName = "admin1@gmail.com",
                Email = "admin1@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "11111111111",
                FirstName = "Ben",
                LastName ="Admin"
                
            };

            _userManager.CreateAsync(adminUser, "Admin123*").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(adminUser, Consts.Admin).GetAwaiter().GetResult();

            var temp1 = _userManager.AddClaimsAsync(adminUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, adminUser.FirstName + " "+ adminUser.LastName),
                new Claim(JwtClaimTypes.GivenName, adminUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName, adminUser.LastName),
                new Claim(JwtClaimTypes.Role, Consts.Admin),

            }).Result;

            ApplicationUser customerUser = new ApplicationUser()
            {
                UserName = "customer1@gmail.com",
                Email = "customer@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "11111111111",
                FirstName = "Ben",
                LastName = "customer"

            };

            _userManager.CreateAsync(customerUser, "Admin123*").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(customerUser, Consts.Customer).GetAwaiter().GetResult();

            var temp2 = _userManager.AddClaimsAsync(customerUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, customerUser.FirstName + " "+ customerUser.LastName),
                new Claim(JwtClaimTypes.GivenName, customerUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName, customerUser.LastName),
                new Claim(JwtClaimTypes.Role, Consts.Customer),

            }).Result;
        }
    }
}
