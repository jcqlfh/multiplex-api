namespace Multiplex.Definitions.Models;

public interface IMovie : IModel
{
    string Name { get; }
    string Director { get; }
    int Duration { get; }
}