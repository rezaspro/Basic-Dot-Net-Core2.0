using System.Collections.Generic;

namespace BasicDotNetCore.Services
{
    public interface IService<EntityT>
    {
        EntityT Save(EntityT entity);
        List<EntityT> Load(string name, List<string> includeRelationalProperties = null, bool withDeleted = false);
    }


}