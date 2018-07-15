using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using SmartKitchen.Models;

[assembly: OwinStartup(typeof(SmartKitchen.Startup))]

namespace SmartKitchen
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

			iniciaApp();
        }

		private void iniciaApp()
		{
			ApplicationDbContext db = new ApplicationDbContext();
			var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
			var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

			// criar a Role 'Admin' 

			if (!roleManager.RoleExists("Admin"))
			{

				  // não existe a 'role' 
				 // então, criar essa role 
				var role = new IdentityRole();
				role.Name = "Admin";
					roleManager.Create(role);
  }

			// criar a Role 'Clientes' 

			if (!roleManager.RoleExists("Clientes"))
			{

			       // não existe a 'role' 
				  // então, criar essa role 
					var role = new IdentityRole();
					role.Name = "Clientes";
					roleManager.Create(role);
			    }
			       // criar um utilizador 'Admin' 
			var user = new ApplicationUser();
			user.UserName = "susMart";
			user.Email = "susMart@mail.com";
			string userPWD = "1AssdABHN2.";
			var chkUser = userManager.Create(user, userPWD);

			 //Adicionar o Utilizador à respetiva Role-Agente- 
			  if (chkUser.Succeeded)
			{
				var result1 = userManager.AddToRole(user.Id, "Admin");
					 }
	}
    }
}
