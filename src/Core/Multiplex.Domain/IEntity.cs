namespace Multiplex.Domain;

public interface IEntity<T>
{
    T Id { get; }
}