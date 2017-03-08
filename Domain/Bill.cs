namespace Domain
{
    public class  Bill: IdHolder
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string[] AliasNames { get; set; }
    }
}
