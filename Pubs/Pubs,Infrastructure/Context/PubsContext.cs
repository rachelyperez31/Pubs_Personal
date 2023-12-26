using Microsoft.EntityFrameworkCore;
using Pubs.Domain.Entities;
using System;

namespace Pubs_Infrastructure.Context
{
    public class PubsContext : DbContext
    {
        public PubsContext(DbContextOptions<PubsContext> options) : base(options) { }
        
        public DbSet<Author>  Authors {  get; set; }   
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Pub_Info> Pub_Info { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Roysched> Roysched { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<TitleAuthor> TitleAuthor { get; set; }
        public DbSet<Title> Titles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasKey(au => au.AuID);
            modelBuilder.Entity<Discount>().HasKey(d => d.DiscountID);
            modelBuilder.Entity<Employee>().HasKey(e => e.EmpID);
            modelBuilder.Entity<Job>().HasKey(j => j.JobID);
            modelBuilder.Entity<Pub_Info>().HasKey(pi => pi.PubID);
            modelBuilder.Entity<Publisher>().HasKey(p => p.PubID);
            modelBuilder.Entity<Roysched>().HasKey(r => r.RoyschedID);
            modelBuilder.Entity<Sale>().HasKey(s => new { s.StoreID, s.OrdNum, s.TitleID });
            modelBuilder.Entity<Store>().HasKey(st => st.StoreID);
            modelBuilder.Entity<TitleAuthor>().HasKey(ta => new { ta.AuID, ta.TitleID });
            modelBuilder.Entity<Title>().HasKey(t => t.TitleID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
