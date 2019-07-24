using BasicDotNetCore.Mapping;
using BasicDotNetCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicDotNetCore.Repositories
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
            
        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new ItemGroupMap(modelBuilder.Entity<ItemGroup>());
        }

        public override int SaveChanges()
        {
            var userId = 1;
            foreach (var entity in ChangeTracker.Entries().Where(e => e.State == EntityState.Added))
            {
                if (typeof(BaseModel<long>).IsAssignableFrom(entity.Entity.GetType()))
                {
                    var model = (BaseModel<long>)entity.Entity;
                    if (model.CreateBy <= 0)
                    {
                        model.ModifyBy = model.CreateBy = userId;
                    }
                    model.VersionNumber = 1;
                    model.CreationDate = model.ModificationDate = DateTime.Now;
                }
            }

            foreach (var entity in ChangeTracker.Entries().Where(e => e.State == EntityState.Modified))
            {
                if (typeof(BaseModel<long>).IsAssignableFrom(entity.Entity.GetType()))
                {
                    var model = (BaseModel<long>)entity.Entity;
                    model.VersionNumber++;
                    model.ModifyBy = userId;
                    model.ModificationDate = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

    }
}
