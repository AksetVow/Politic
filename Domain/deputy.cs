using System.Collections.Generic;

namespace Domain
{
    public class Deputy : IdHolder
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set;}

        public string Url { get; set; }

        public string FullName {
            get { return $"{FirstName} {MiddleName} {LastName}"; }
        }

        public IList<int> ParlamentNumbers { get; set; }

        public override int GetHashCode()
        {
            return FullName.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Deputy);
        }

        public bool Equals(Deputy deputy)
        {
            if (deputy == null)
                return false;
            else
                return FullName.Equals(deputy.FullName); 
        }
    }
}
