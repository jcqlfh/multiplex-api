using System;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;

namespace Multiplex.Domain;

public class Movie : IEntity<Guid>
{
    public Guid Id { get; private set; }

    [MaxLength(10)]
    public string Name { get; private set; }
    public string Director { get; private set; }
    public int Duration { get; private set; }

    public Movie(string name, string director, int duration)
    {
        SetName(name);
        SetDirector(director);
        SetDuration(duration);
    }

    [MemberNotNull(nameof(Name))]
    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(name))
            throw new ArgumentException(nameof(Name));

        if (name.Length > 50)
            throw new ArgumentOutOfRangeException(nameof(Name));

        Name = name;
    }

    [MemberNotNull(nameof(Director))]
    public void SetDirector(string director)
    {
        if (string.IsNullOrWhiteSpace(director) || string.IsNullOrEmpty(director))
            throw new ArgumentException(nameof(Director));

        if (director.Length > 50)
            throw new ArgumentOutOfRangeException(nameof(Director));

        Director = director;
    }

    public void SetDuration(int duration)
    {
        if (duration <= 0)
            throw new ArgumentOutOfRangeException(nameof(Duration));

        Duration = duration;
    }
}