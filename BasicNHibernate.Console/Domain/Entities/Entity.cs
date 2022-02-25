namespace BasicNHibernate.Console.Domain.Entities
{
    public class Entity<TId>
        where TId : struct
    {
        public virtual TId Id { get; set; } = default(TId);
    }
}
