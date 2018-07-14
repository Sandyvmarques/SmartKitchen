using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace SmartKitchen.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class SmartKitchenDB : IdentityDbContext<ApplicationUser>
    {
        public SmartKitchenDB()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static SmartKitchenDB Create()
        {
            return new SmartKitchenDB();

        }
		public virtual DbSet<Produtos> Produtos { get; set; } //tabela dos Produtos
		public virtual DbSet<Categorias> Categorias { get; set; }//tabela dos Categorias
		public virtual DbSet<Clientes> Clientes { get; set; }//tabela dos Clientes
		public virtual DbSet<Encomendas> Encomendas { get; set; }//tabela dos Encomendas
		public virtual DbSet<Imagens> Imagens { get; set; }//tabela dos Imagens
		public virtual DbSet<EncProd> EncProd { get; set; }//tabela dos Encomendas-Produtos

	}
}