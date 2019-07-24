using BasicDotNetCore.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicDotNetCore.Mapping
{
    public class ItemMap
    {
        public ItemMap(EntityTypeBuilder<Item> entityBuilder)
        {
            entityBuilder.Property(x => x.Name);
            entityBuilder.Property(x => x.Description);
            entityBuilder.HasOne(x => x.ItemGroup);
            entityBuilder.HasAlternateKey(x => x.ItemGroupId);
        }
    }
}
