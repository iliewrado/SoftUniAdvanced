using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> member;

        public Family()
        {
            Member = new List<Person>();
        }
        public List<Person> Member
        {
            get { return this.member; }
            set { this.member = value; }
        }
        public void AddMember(Person member)
        {
            Member.Add(member);
        }
        public Person GetOldestMember()
        {
            Person oldestMember = member.OrderByDescending(x => x.Age).First();
            return oldestMember;
        }
    }
}
