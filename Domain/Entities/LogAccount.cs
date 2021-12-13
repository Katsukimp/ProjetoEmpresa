using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringTest.Domain.Entities
{
    public class LogAccount : BaseModel
    {
        public string Description { get; set; }
        public DateTime EntryDate { get; set; }
        public virtual Account Account { get; set; }
        public int IdAccount { get; set; }
    }
}
