using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OPDRACHT_S6_ASPSEC_05.Data;

namespace OPDRACHT_S6_ASPSEC_05
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            // Database en Identity instellen
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>() // Rollen toevoegen
                .AddEntityFrameworkStores<ApplicationDbContext>();

            var app = builder.Build();

            // Rollen en Admin-gebruiker aanmaken bij opstarten
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                string[] roleNames = { "Admin", "Gebruiker" };

                foreach (var roleName in roleNames)
                {
                    if (!roleManager.RoleExistsAsync(roleName).Result)
                    {
                        roleManager.CreateAsync(new IdentityRole(roleName)).Wait();
                    }
                }

                // Admin-gebruiker aanmaken
                string adminEmail = "admin@example.com";
                string adminPassword = "Admin@123";

                if (userManager.FindByEmailAsync(adminEmail).Result == null)
                {
                    var adminUser = new IdentityUser { UserName = adminEmail, Email = adminEmail };
                    userManager.CreateAsync(adminUser, adminPassword).Wait();
                    userManager.AddToRoleAsync(adminUser, "Admin").Wait();
                }
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
