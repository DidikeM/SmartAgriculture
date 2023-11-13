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
    public SmartAgriContext(DbContextOptions<SmartAgriContext> options) : base(options)
    {
    }   

    public DbSet<Reply> Replies { get; set; }

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reply>(entity =>
        {
            entity.HasKey(e => e.Id);
        });
    }
}
