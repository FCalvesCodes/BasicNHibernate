using BasicNHibernate.Console.Domain.Users;
using FluentNHibernate.Mapping;

namespace BasicNHibernate.Console.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(c => c.Id).CustomSqlType("Serial").GeneratedBy.Native();

            Map(c => c.Name).Length(150).Not.Nullable();
        }
    }
}
