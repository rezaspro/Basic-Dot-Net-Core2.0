using BasicDotNetCore.Models;
using BasicDotNetCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicDotNetCore.Services
{
    public class ItemGroupService: Service<ItemGroup>
    {
        private readonly ItemGroupRepository _entityRepository;
        public ItemGroupService(ItemGroupRepository entityRepository) : base(entityRepository)
        {
            _entityRepository = entityRepository;
        }
    }
}
