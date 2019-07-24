using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicDotNetCore.Models
{
    public class ItemGroup : BaseModel<long>
    {
        public ItemGroup()
        {
            ItemList = new List<Item>();
        }
        public string Name { get; set; }
        public string Description { get; set; }

        //has many
        public List<Item> ItemList { get; set; }
    }
}
