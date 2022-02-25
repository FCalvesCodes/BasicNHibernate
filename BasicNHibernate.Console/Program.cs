using BasicNHibernate.Console.Data;
using BasicNHibernate.Console.Domain.Users;

var connString = "Server=localhost; Port=5432; User Id=postgres; Password=cs305; Database=academicschedule";

using (var context = new NHibernateManager(connString))
{
    context.Session.Save(new User("Felipe"));
}