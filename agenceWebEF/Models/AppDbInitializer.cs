using Microsoft.AspNetCore.Identity;

namespace agenceWebEF.Models
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder appBuilder)
        {
            using (var serviceScope = appBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<agencewebContext>();

                context.Database.EnsureCreated();
            }
        }

        public static async Task SeedUsersAndRoles(IApplicationBuilder appBuilder)
        {
            using (var serviceScope = appBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UtilisateurRoles.Master))
                {
                    await roleManager.CreateAsync(new IdentityRole(UtilisateurRoles.Master));
                }

                if (!await roleManager.RoleExistsAsync(UtilisateurRoles.Admin))
                {
                    await roleManager.CreateAsync(new IdentityRole(UtilisateurRoles.Admin));
                }


                if (!await roleManager.RoleExistsAsync(UtilisateurRoles.User))
                {
                    await roleManager.CreateAsync(new IdentityRole(UtilisateurRoles.User));
                }

                if (!await roleManager.RoleExistsAsync(UtilisateurRoles.Client))
                {
                    await roleManager.CreateAsync(new IdentityRole(UtilisateurRoles.Client));
                }

                //User Admin
                /*var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<Utilisateur>>();

                var newUtilisateur = new Utilisateur()
                {
                    UserName = "rom1",
                    Email = "romain.cotoni@gmail.com",
                    EmailConfirmed = true,
                };
                await userManager.CreateAsync(newUtilisateur, "Romain1!");
                await userManager.AddToRoleAsync(newUtilisateur, UtilisateurRoles.Admin);*/



                //User User
                /*userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<Utilisateur>>();

                newUtilisateur = new Utilisateur()
                {
                    UserName = "rom2",
                    Email = "romain.cotoni@gmail.com",
                    EmailConfirmed = true,
                };
                await userManager.CreateAsync(newUtilisateur, "Romain1!");
                await userManager.AddToRoleAsync(newUtilisateur, UtilisateurRoles.Client);*/

            }

        }
    }
}
