namespace Ecm.Data
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}