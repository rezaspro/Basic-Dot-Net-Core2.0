using BasicDotNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicDotNetCore.Repositories
{
    public class ItemRepository : Repository<Item, long>
    {
        public ItemRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
