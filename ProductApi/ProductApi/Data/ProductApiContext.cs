using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductApi.Data.Models;
using Npgsql;
namespace ProductApi.Data
{
    public class ProductApiContext : DbContext
    {
        public ProductApiContext (DbContextOptions<ProductApiContext> options)
            : base(options)
        {
        }

        public DbSet<ProductApi.Data.Models.ProductSubcategory> ProductSubcategory { get; set; } = default!;

        public DbSet<ProductApi.Data.Models.Product> Product { get; set; } = default!;
    }
}
