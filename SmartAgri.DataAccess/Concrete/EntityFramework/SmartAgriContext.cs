using Microsoft.EntityFrameworkCore;
using SmartAgri.Entities.Concrete;
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
    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
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
        });
    }
}
