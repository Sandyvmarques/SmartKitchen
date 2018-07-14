using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

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

		}
    }
}
