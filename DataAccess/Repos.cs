using Domain;
using Domain.DataAccess;

namespace DataAccess
{
    public class BillRepository : BaseRepository<Bill>, IBillRepository { };

    public class DeputyRepository : BaseRepository<Deputy>, IDeputyRepository { };

    public class VoteForBillRepository : BaseRepository<VoteForBill>, IVoteForBillRepository { };
}
