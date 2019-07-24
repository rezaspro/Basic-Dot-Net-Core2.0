using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BasicDotNetCore.Models
{
    [Serializable]
    public class BaseModel<IdT> : IBaseModel<IdT>
    {
        public BaseModel()
        {
            CreationDate = DateTime.Now;
            ModificationDate = DateTime.Now;
            Status = 0;
            VersionNumber = 1;
            Name = "";
        }

        [Key]
        public IdT Id { get; set; }
        [ConcurrencyCheck]
        public int VersionNumber { get; set; }
        [MaxLength(512)]
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public long CreateBy { get; set; }
        public long ModifyBy { get; set; }
        public int Status { get; set; }
    }
}
