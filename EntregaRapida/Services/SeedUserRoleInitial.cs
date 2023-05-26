using Microsoft.AspNetCore.Identity;
namespace EntregaRapida.Services
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitial(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager; 
        }

        public void SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync("Lojista").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Lojista";
                role.NormalizedName = "LOJISTA";
                IdentityResult result = _roleManager.CreateAsync(role).Result;

            }
            if (!_roleManager.RoleExistsAsync("Entregador").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Entregador";
                role.NormalizedName = "ENTREGADOR";
                IdentityResult result = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";
                IdentityResult result = _roleManager.CreateAsync(role).Result;
            }
        }
            public void SeedUsers()
            {
           if(_userManager.FindByEmailAsync("usuario@localhost").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "usuario@localhost";
                user.Email = "usuario@localhost";
                user.NormalizedUserName = "USUARIO@LOCALHOST";
                user.NormalizedEmail = "USUARIO@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user,"Senha#123").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Lojista").Wait();
                }
            }
        }
    }
}
