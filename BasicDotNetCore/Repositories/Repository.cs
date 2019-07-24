using BasicDotNetCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicDotNetCore.Repositories
{
    public class Repository<EntityT, IdT> : IRepository<EntityT, IdT> where EntityT : class, IBaseModel<IdT>
    {
        public List<string> DefaultIncludedRelationalProperties { get; set; }
        public Repository(DatabaseContext context)
        {
            Context = context;
            DbSet = Context.Set<EntityT>();
        }

        protected DbContext Context { get; }

        protected DbSet<EntityT> DbSet { get; }
        //List<string> IRepository<EntityT, IdT>.DefaultIncludedRelationalProperties { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public EntityT Add(EntityT entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public EntityT Edit(EntityT entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return Context.Database.BeginTransaction();
        }

        public void SaveChange()
        {
            var effectedChanges = Context.SaveChanges();
        }

        public EntityT Get(IdT id, List<string> includeChilds = null)
        {
            IQueryable<EntityT> query = Query(null, includeChilds);
            query = query.Where(x => x.Id.Equals(id));
            //return ExecuteQuery(query);
            return query.FirstOrDefault();
        }

        public List<EntityT> Load(string name, List<string> includeRelationalProperties = null, bool withDeleted = false)
        {
            IQueryable<EntityT> tempDbSet = DbSet;

            if (includeRelationalProperties != null)
            {
                foreach (var item in includeRelationalProperties)
                {
                    tempDbSet = tempDbSet.Include(item);
                }
            }

            //tempDbSet = tempDbSet.Where(x => x.Name.Contains(name));

            if (withDeleted == false)
                tempDbSet = tempDbSet.Where(x => x.Status != EntityStatus.Deleted);

            return tempDbSet.ToList();
        }

        private IQueryable<EntityT> Query(bool? isActive = null, List<string> includeChilds = null)
        {
            IQueryable<EntityT> query = DbSet;
            if (isActive != null)
            {
                if (isActive.Value)
                    query = query.Where(x => x.Status == EntityStatus.Active);
                else
                    query = query.Where(x => x.Status == EntityStatus.Inactive);
            }

            if (includeChilds != null && DefaultIncludedRelationalProperties != null)
            {
                foreach (var item in DefaultIncludedRelationalProperties)
                {
                    query = query.Include(item);
                }
            }

            return query;
        }
    }
}
