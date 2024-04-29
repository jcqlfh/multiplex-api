using Bogus;
using Bogus.Extensions;
using Shouldly;
using System;

namespace Multiplex.Domain.Tests;

public class MovieTests
{

    [Fact]
    public void Valid_New_Movie()
    {
        var fakerMovie = new Faker<Movie>()
            .CustomInstantiator(f =>
                new Movie(
                    f.Lorem.Sentence().ClampLength(1, 50),
                    f.Name.FullName().ClampLength(1, 50),
                    f.Random.Int(0, 100)
                )
            );
        var fakeMovie = fakerMovie.Generate();

        var movie = new Movie(fakeMovie.Name, fakeMovie.Director, fakeMovie.Duration);

        movie.ShouldSatisfyAllConditions(
            () => movie.Name.ShouldBe(fakeMovie.Name),
            () => movie.Director.ShouldBe(fakeMovie.Director),
            () => movie.Duration.ShouldBe(fakeMovie.Duration));
    }

    [Fact]
    public void Invalid_New_Movie_Name_Null()
    {
        var fakerMovie = new Faker<Movie>()
            .CustomInstantiator(f =>
                new Movie(
                    null!,
                    f.Name.FullName().ClampLength(1, 50),
                    f.Random.Int(0, 100)
                )
            );

        Should.Throw<ArgumentException>(() => fakerMovie.Generate());
    }

    [Fact]
    public void Invalid_New_Movie_Name_Empty()
    {
        var fakerMovie = new Faker<Movie>()
            .CustomInstantiator(f =>
                new Movie(
                    string.Empty,
                    f.Name.FullName().ClampLength(1, 50),
                    f.Random.Int(0, 100)
                )
            );

        Should.Throw<ArgumentException>(() => fakerMovie.Generate());
    }

    [Fact]
    public void Invalid_New_Movie_Name_White_Space()
    {
        var fakerMovie = new Faker<Movie>()
            .CustomInstantiator(f =>
                new Movie(
                    " ",
                    f.Name.FullName().ClampLength(1, 50),
                    f.Random.Int(0, 100)
                )
            );

        Should.Throw<ArgumentException>(() => fakerMovie.Generate());
    }

    [Fact]
    public void Invalid_New_Movie_Name_Large()
    {
        var fakerMovie = new Faker<Movie>()
            .CustomInstantiator(f =>
                new Movie(
                    f.Lorem.Sentences(10),
                    f.Name.FullName().ClampLength(1, 50),
                    f.Random.Int(0, 100)
                )
            );

        Should.Throw<ArgumentException>(() => fakerMovie.Generate());
    }


    [Fact]
    public void Invalid_New_Movie_Director_Null()
    {
        var fakerMovie = new Faker<Movie>()
            .CustomInstantiator(f =>
                new Movie(
                    f.Lorem.Sentence().ClampLength(1, 50),
                    null!,
                    f.Random.Int(0, 100)
                )
            );

        Should.Throw<ArgumentException>(() => fakerMovie.Generate());
    }

    [Fact]
    public void Invalid_New_Movie_Director_Empty()
    {
        var fakerMovie = new Faker<Movie>()
            .CustomInstantiator(f =>
                new Movie(
                    f.Lorem.Sentence().ClampLength(1, 50),
                    string.Empty,
                    f.Random.Int(0, 100)
                )
            );

        Should.Throw<ArgumentException>(() => fakerMovie.Generate());
    }

    [Fact]
    public void Invalid_New_Movie_Director_White_Space()
    {
        var fakerMovie = new Faker<Movie>()
            .CustomInstantiator(f =>
                new Movie(
                    f.Lorem.Sentence().ClampLength(1, 50),
                    " ",
                    f.Random.Int(0, 100)
                )
            );

        Should.Throw<ArgumentException>(() => fakerMovie.Generate());
    }

    [Fact]
    public void Invalid_New_Movie_Director_Large()
    {
        var fakerMovie = new Faker<Movie>()
            .CustomInstantiator(f =>
                new Movie(
                    f.Lorem.Sentence().ClampLength(1, 50),
                    f.Lorem.Sentences(10),
                    f.Random.Int(0, 100)
                )
            );

        Should.Throw<ArgumentException>(() => fakerMovie.Generate());
    }

    [Fact]
    public void Invalid_New_Movie_Duration_Less_Then_One()
    {
        var fakerMovie = new Faker<Movie>()
            .CustomInstantiator(f =>
                new Movie(
                    f.Lorem.Sentence().ClampLength(1, 50),
                    f.Lorem.Sentences(10),
                    f.Random.Int(-100, 0)
                )
            );

        Should.Throw<ArgumentException>(() => fakerMovie.Generate());
    }
}