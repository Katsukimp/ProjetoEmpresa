using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringTest.Domain.Entities
{
    public class Person : BaseModel
    {
        public string Name { get; set; }

        public string LastName { get; set; }
    }
}
