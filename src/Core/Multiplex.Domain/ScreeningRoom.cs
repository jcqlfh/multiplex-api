using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Multiplex.Domain;

public class ScreeningRoom : IEntity<Guid>
{
    public Guid Id { get; private set; }
    public int Number { get; private set; }
    public string Description { get; private set; }
    public IList<Movie> Movies { get; private set; } = new List<Movie>();

    public ScreeningRoom(int number, string description)
    {
        SetNumber(number);
        SetDescription(description);
    }

    public void SetNumber(int number)
    {
        if (number <= 0)
            throw new ArgumentOutOfRangeException(nameof(Number));

        Number = number;
    }

    [MemberNotNull(nameof(Description))]
    public void SetDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description) || string.IsNullOrEmpty(description))
            throw new ArgumentException(nameof(Description));

        if (description.Length > 50)
            throw new ArgumentOutOfRangeException(nameof(Description));

        Description = description;
    }

    public void AddMovie(Movie movie)
    {
        if (movie is null)
            throw new ArgumentNullException(nameof(movie));

        if (Movies.Contains(movie))
            throw new InvalidOperationException(nameof(Movies));

        Movies.Add(movie);
    }

    public Movie? ContainsMovie(Guid movieId)
    {
        return Movies.Where(x => x.Id == movieId).FirstOrDefault();
    }

    public void RemoveMovie(Movie movie)
    {
        if (movie is null)
            throw new ArgumentNullException(nameof(movie));

        if (ContainsMovie(movie.Id) is not null)
            Movies = Movies.Except(new Movie[] { movie }).ToList();
    }
}