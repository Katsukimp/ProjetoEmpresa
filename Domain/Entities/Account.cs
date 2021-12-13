using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringTest.Domain.Entities
{
    public class Account : BaseModel
    {
        public string AccountNumber { get; set; }
        public bool Active { get; set; }
        public decimal PreviousBalance { get; set; }
        public decimal? TotalDebt { get; set; }
        public decimal? TotalCredit { get; set; }
        public decimal? FinalBalance { get; set; }
        public int IdBank { get; set; }
        public virtual Bank Bank { get; set; }
        public int IdPerson { get; set; }
        public virtual Person Person { get; set; }
    }
}
