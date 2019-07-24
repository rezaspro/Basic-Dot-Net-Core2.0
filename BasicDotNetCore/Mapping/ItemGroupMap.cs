using BasicDotNetCore.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicDotNetCore.Mapping
{
    public class ItemGroupMap
    {
        public ItemGroupMap(EntityTypeBuilder<ItemGroup> entityBuilder)
        {
            entityBuilder.Property(x => x.Name);
            entityBuilder.Property(x => x.Description);
            entityBuilder.HasMany(x => x.ItemList);
        }
    }
}
