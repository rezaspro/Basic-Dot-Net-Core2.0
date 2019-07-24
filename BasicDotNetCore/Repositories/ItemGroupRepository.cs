using BasicDotNetCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicDotNetCore.Repositories
{
    public class ItemGroupRepository : Repository<ItemGroup, long>
    {
        public ItemGroupRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
