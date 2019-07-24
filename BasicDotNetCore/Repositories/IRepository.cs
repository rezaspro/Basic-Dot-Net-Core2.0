using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicDotNetCore.Repositories
{
    public interface IRepository<EntityT, IdT>
    {
        List<string> DefaultIncludedRelationalProperties { get; set; }
        EntityT Add(EntityT entity);
        EntityT Edit(EntityT entity);
        EntityT Get(IdT id, List<string> includeChilds = null);
        List<EntityT> Load(string name, List<string> includeRelationalProperties = null, bool withDeleted = false);
        IDbContextTransaction BeginTransaction();
        void SaveChange();
    }
}
