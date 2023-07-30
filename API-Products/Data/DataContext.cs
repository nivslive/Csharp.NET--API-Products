using System;
using Microsoft.EntityFrameworkCore;
using API_Products;
namespace API_Products.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) {}
    public DbSet<Product> Products { get; set; }
}

