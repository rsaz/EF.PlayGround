/* 
 * Entity Framework Playground
 * Author: Richard Zampieri
 */

using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Entity
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Profile> Profile { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EntityDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}