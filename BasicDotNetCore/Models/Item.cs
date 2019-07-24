using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicDotNetCore.Models
{
    public class Item : BaseModel<long>
    {
        public Item()
        {
        }
        public new string Name { get; set; }
        public string Description { get; set; }

        //reference
        public long ItemGroupId { get; set; }
        public ItemGroup ItemGroup { get; set; }
    }
}
