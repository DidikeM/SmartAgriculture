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

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Advert>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.UseTpcMappingStrategy();
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

        modelBuilder.Entity<Role>().HasData(
            new Role
            {
                Id = 1,
                Name = "Admin"
            },
            new Role
            {
                Id = 2,
                Name = "User"
            });

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Name = "admin",
                Surname = "admin",
                Email = "admin@admin.com",
                RoleId = 1,
                Password = "admin123",
                CoinAccountId = Guid.Empty,
                CoinAddress = "",
            });

        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 9,
                Name = "Buğday",
                ImagePath = "wheat.png"
            });

        modelBuilder.Entity<AdvertStatus>().HasData(
            new AdvertStatus
            {
                Id = (int)AdvertStatusEnum.Active,
                Name = AdvertStatusEnum.Active.ToString()
            },
            new AdvertStatus
            {
                Id = (int)AdvertStatusEnum.notProccess,
                Name = AdvertStatusEnum.notProccess.ToString()
            },
            new AdvertStatus
            {
                Id = (int)AdvertStatusEnum.complated,
                Name = AdvertStatusEnum.complated.ToString()
            });

        modelBuilder.Entity<AdvertBuy>().HasData(
            new AdvertBuy
            {
                Id = 6,
                ProductId = 9,
                UnitPrice = 220,
                Quantity = 300,
                UserId = 1,
                StatusId = 1,
                CreatedAt = DateTime.Now
            },
            new AdvertBuy
            {
                Id = 7,
                ProductId = 9,
                UnitPrice = 210,
                Quantity = 200,
                UserId = 1,
                StatusId = 1,
                CreatedAt = DateTime.Now
            },
            new AdvertBuy
            {
                Id = 8,
                ProductId = 9,
                UnitPrice = 200,
                Quantity = 180,
                UserId = 1,
                StatusId = 1,
                CreatedAt = DateTime.Now
            },
            new AdvertBuy
            {
                Id = 9,
                ProductId = 9,
                UnitPrice = 190,
                Quantity = 150,
                UserId = 1,
                StatusId = 1,
                CreatedAt = DateTime.Now
            },
            new AdvertBuy
            {
                Id = 10,
                ProductId = 9,
                UnitPrice = 180,
                Quantity = 200,
                UserId = 1,
                StatusId = 1,
                CreatedAt = DateTime.Now
            });

        modelBuilder.Entity<AdvertSell>().HasData(
            new AdvertSell
            {
                Id = 1,
                ProductId = 9,
                UnitPrice = 295,
                Quantity = 100,
                UserId = 1,
                StatusId = 1,
                CreatedAt = DateTime.Now
            },
            new AdvertSell
            {
                Id = 2,
                ProductId = 9,
                UnitPrice = 285,
                Quantity = 200,
                UserId = 1,
                StatusId = 1,
                CreatedAt = DateTime.Now
            },
            new AdvertSell
            {
                Id = 3,
                ProductId = 9,
                UnitPrice = 280,
                Quantity = 250,
                UserId = 1,
                StatusId = 1,
                CreatedAt = DateTime.Now
            },
            new AdvertSell
            {
                Id = 4,
                ProductId = 9,
                UnitPrice = 240,
                Quantity = 125,
                UserId = 1,
                StatusId = 1,
                CreatedAt = DateTime.Now
            },
            new AdvertSell
            {
                Id = 5,
                ProductId = 9,
                UnitPrice = 230,
                Quantity = 175,
                UserId = 1,
                StatusId = 1,
                CreatedAt = DateTime.Now
            });
    }
}
