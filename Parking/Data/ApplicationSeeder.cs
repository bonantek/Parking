using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Parking.Data.Services;
using Parking.Models;

namespace Parking.Data
{
    public class ApplicationSeeder
    {
        private readonly ParkingService _parkingService;

        public ApplicationSeeder(ParkingService parkingService)
        {
            _parkingService = parkingService;
        }
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            var roles = new[] { "Admin", "Worker" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
        
        public static async Task SeedAdminAsync(UserManager<ApplicationUser> userManager)
        {
            string adminEmail = "admin@admin.com";
            string password = "Test1234!";

            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var user = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail
                };

                await userManager.CreateAsync(user, password);
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }

        public static async Task SeedDataAsync(AppDbContext appDbContext, ParkingService parkingService)
        {
            if (!appDbContext.Parkings.Any())
            {

                var parkingA = new Models.Parking
                {
                    Id = Guid.NewGuid(),
                    Name = "Parking Bonarka",
                    City = "Kraków",
                    Street = "Henryka Kamińskiego",
                    StreetNr = "11",
                    Capacity = 150,
                    Logo = "",
                    Description = "Big parking in Bonarka"
                };

                var parkingB = new Models.Parking
                {
                    Id = Guid.NewGuid(),
                    Name = "Parking Cracovia",
                    City = "Krakow",
                    Street = "Blonia",
                    StreetNr = "2",
                    Capacity = 150,
                    Logo = "",
                    Description = "Parking dla kibicow Cracovii"
                };

                var parkingC = new Models.Parking
                {
                    Id = Guid.NewGuid(),
                    Name = "Parking Reymonta",
                    City = "Krakow",
                    Street = "Reymonta",
                    StreetNr = "3",
                    Capacity = 200,
                    Logo = "",
                    Description = "Parking kibiców Wisły"
                };

                foreach (var parking in new[] { parkingA, parkingB, parkingC })
                {
                    await parkingService.AddAsync(parking);
                }
            }
        }
        
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var parkingService = scope.ServiceProvider.GetRequiredService<ParkingService>();

                await context.Database.MigrateAsync();
                await SeedRolesAsync(roleManager);
                await SeedAdminAsync(userManager);
                await SeedDataAsync(context, parkingService);
            }
        }
        
    }

}