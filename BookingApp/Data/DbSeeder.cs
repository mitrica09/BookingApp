using Microsoft.AspNetCore.Identity;

namespace BookingApp.Data
{
    public class DbSeeder
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            string[] roles = { "PATIENT", "DOCTOR", "ASSISTANT", "ADMIN" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
