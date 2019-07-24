using BasicDotNetCore.Models;
using BasicDotNetCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicDotNetCore.Services
{
    public class ItemService : Service<Item>
    {
        private readonly ItemRepository _entityRepository;
        public ItemService(ItemRepository entityRepository) : base(entityRepository, new List<string>() { "ItemGroup"})
        {
            _entityRepository = entityRepository;
        }
    }
}
