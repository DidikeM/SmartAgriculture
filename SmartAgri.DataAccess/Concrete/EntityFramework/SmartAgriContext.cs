using Microsoft.EntityFrameworkCore;
using SmartAgri.Entities.Concrete;
using SmartAgri.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgri.DataAccess.Concrete.EntityFramework;

public class SmartAgriContext : DbContext
{
    public SmartAgriContext()
    {
    }
    public SmartAgriContext(DbContextOptions<SmartAgriContext> options) : base(options)
    {
    }

    public DbSet<Reply> Replies { get; set; }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Advert> Adverts { get; set; }
    public DbSet<AdvertBuy> AdvertBuys { get; set; }
    public DbSet<AdvertSell> AdvertSells { get; set; }
    public DbSet<AdvertStatus> AdvertStatuses { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<GuestMessage> GuestMessages { get; set; }


    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Advert>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.UseTptMappingStrategy();
            entity.HasOne(e => e.Status).WithMany(e => e.Adverts).HasForeignKey(e => e.StatusId);
            entity.HasOne(e => e.Product).WithMany(e => e.Adverts).HasForeignKey(e => e.ProductId);
            entity.HasOne(e => e.User).WithMany(e => e.Adverts).HasForeignKey(e => e.UserId);
        });

        modelBuilder.Entity<AdvertBuy>(entity =>
        {
            entity.HasBaseType<Advert>();
        });

        modelBuilder.Entity<AdvertSell>(entity =>
        {
            entity.HasBaseType<Advert>();
        });

        modelBuilder.Entity<AdvertStatus>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Reply>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.User).WithMany(e => e.Replies).HasForeignKey(e => e.UserId);
            entity.HasOne(e => e.Topic).WithMany(e => e.Replies).HasForeignKey(e => e.TopicId);
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.User).WithMany(e => e.Topics).HasForeignKey(e => e.UserId);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.Role).WithMany(e => e.Users).HasForeignKey(e => e.RoleId);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.BuyAdvert).WithMany(e => e.Transactions).HasForeignKey(e => e.BuyAdvertId);
            entity.HasOne(e => e.SellAdvert).WithOne(e => e.Transaction).HasForeignKey<Transaction>(e => e.SellAdvertId);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<GuestMessage>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        DataSeeder.SeedData(modelBuilder);
    }
}
