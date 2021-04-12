using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //context; Db tabloları ile proje classlarını bağlamak.
    public class ReCapProjectContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //bu metot proje hangi veritabanı ile ilişkiliyi belirteceğimiz yer.
        {
            //Trusted_Connection=true; kullanıcı adı ve şifre gerektirmez.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ReCapProject;Trusted_Connection=true");
        }

        public DbSet<Car> Cars { get; set; } //benim hangi nesnem veritabanından hangi nesneye karşılık gelecek onu belirtiyoruz.
        public DbSet<Brand> Brands { get; set; } //benim hangi nesnem veritabanından hangi nesneye karşılık gelecek onu belirtiyoruz.
        public DbSet<Color> Colors { get; set; } //benim hangi nesnem veritabanından hangi nesneye karşılık gelecek onu belirtiyoruz.
        public DbSet<Order> Orders { get; set; } //benim hangi nesnem veritabanından hangi nesneye karşılık gelecek onu belirtiyoruz.
    }
}
