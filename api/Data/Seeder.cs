using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public static class Seeder
    {
        public static async Task SeedData(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Ensure database is created
            await context.Database.MigrateAsync();

            // Seed roles if they don't exist
            if (!await roleManager.RoleExistsAsync("User"))
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
                Console.WriteLine("Role 'User' created successfully");
            }
            else
            {
                Console.WriteLine("Role 'User' already exists");
            }

            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
                Console.WriteLine("Role 'Admin' created successfully");
            }
            else
            {
                Console.WriteLine("Role 'Admin' already exists");
            }

            // Get default user credentials from configuration
            var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
            var defaultUsername = configuration["DefaultUser:Username"] ?? "string";
            var defaultPassword = configuration["DefaultUser:Password"] ?? "StringLord555!";
            var defaultEmail = configuration["DefaultUser:Email"] ?? "string@example.com";

            Console.WriteLine($"Checking for default user: {defaultUsername}");

            // Check if the default user exists
            var defaultUser = await userManager.FindByNameAsync(defaultUsername);
            if (defaultUser == null)
            {
                // User doesn't exist, create it
                Console.WriteLine($"Default user '{defaultUsername}' not found. Creating...");
                
                var user = new AppUser
                {
                    UserName = defaultUsername,
                    Email = defaultEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, defaultPassword);
                if (result.Succeeded)
                {
                    // Add user to User role
                    var roleResult = await userManager.AddToRoleAsync(user, "User");
                    if (roleResult.Succeeded)
                    {
                        Console.WriteLine($"Default user '{defaultUsername}' created successfully and assigned to 'User' role");
                    }
                    else
                    {
                        Console.WriteLine($"User created but failed to assign role: {string.Join(", ", roleResult.Errors.Select(e => e.Description))}");
                    }
                }
                else
                {
                    Console.WriteLine($"Failed to create default user '{defaultUsername}': {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }
            else
            {
                // User exists, ensure it has the User role
                Console.WriteLine($"Default user '{defaultUsername}' already exists");
                
                var userRoles = await userManager.GetRolesAsync(defaultUser);
                if (!userRoles.Contains("User"))
                {
                    var roleResult = await userManager.AddToRoleAsync(defaultUser, "User");
                    if (roleResult.Succeeded)
                    {
                        Console.WriteLine($"User '{defaultUsername}' assigned to 'User' role");
                    }
                    else
                    {
                        Console.WriteLine($"Failed to assign role to existing user: {string.Join(", ", roleResult.Errors.Select(e => e.Description))}");
                    }
                }
                else
                {
                    Console.WriteLine($"User '{defaultUsername}' already has 'User' role");
                }
            }

            Console.WriteLine("Database seeding completed successfully");
        }
    }
}
