using System.Collections.Generic;

namespace Domain
{
    public class VoteForBill : IdHolder
    {
        public int BillId { get; set; }

        public IEnumerable<Vote> Votes { get; set; }
    }
}
