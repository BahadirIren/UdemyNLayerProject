using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Data.Configurations;
using UdemyNLayerProject.Data.Seeds;

namespace UdemyNLayerProject.Data
{
    public class AppDbContext : DbContext
    {
        // TODO bakilacak
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Person> People { get; set; }

        // veritabaninda tablolar olusmadan once calisacak olan metod
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configurationlari burada da yapabilirdik ama burayi temiz tutmak icin
            // ayri bir configuration kismina koyduk
            // modelBuilder.Entity<Product>().Property(x => x.Id).UseIdentityColumn();

            // once belirledigimiz configurationlara gore tablolar olusturulacak
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());

            // daha sonra datalarimiz ilgili tablolara eklenecek
            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] { 1, 2 }));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1, 2 }));

        }
    }
}
