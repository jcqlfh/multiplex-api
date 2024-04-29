namespace Multiplex.Definitions.Models;

public interface IScreeningRoom : IModel
{
    int Number { get; }
    string Description { get; }
    IMovie[] Movies { get; }
}