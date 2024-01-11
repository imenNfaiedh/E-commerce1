using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using E_commerce1.Models.Domain;

namespace E_commerce1.Data
{
    public class E_commerce1Context : DbContext
    {
        public E_commerce1Context (DbContextOptions<E_commerce1Context> options)
            : base(options)
        {
        }

        public DbSet<E_commerce1.Models.Domain.Categorie> Categorie { get; set; } = default!;
    }
}
