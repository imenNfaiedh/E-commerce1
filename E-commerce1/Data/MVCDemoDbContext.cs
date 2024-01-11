using E_commerce1.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace E_commerce1.Data
{
    public class MVCDemoDbContext : DbContext
    {
        public MVCDemoDbContext(DbContextOptions options) : base(options)
        {
        }


        // nom du table "produit"
        public DbSet<Produit> produit {  get; set; }
        public DbSet<Categorie> categorie { get; set; }
    }
}
