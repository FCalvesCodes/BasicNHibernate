using BasicNHibernate.Console.Domain.Entities;

namespace BasicNHibernate.Console.Domain.Users
{
    public class User :  Entity<int>
    {
        public virtual string? Name { get; set; }

        public User()
        {
        }

        public User(string name)
        {
            Name = name;
        }
    }
}
