namespace Domain
{
    public enum VoteType
    {
        For,
        Against,
        NotVote,
        Missed
    }


    public class Vote
    {
        public int Deputy { get; set; }

        public VoteType VoteType {get;set;}
    }
}
